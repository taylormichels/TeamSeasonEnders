using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HtmlAgilityPack;
using System.Web.Http;
using System.Text.RegularExpressions;
using TeamSeasonEnders.DataAccess;
using TeamSeasonEnders.DB;
using System.Net.Http;
using System.Net;

namespace TeamSeasonEnders.API
{
    public class DataParserController : ApiController
    {
        private ITeamSeasonsRepository repository;

        public DataParserController()
        {
            repository = new TeamSeasonEndersRepository(new TeamSeasonEndersContext());
        }

        public DataParserController(ITeamSeasonsRepository _repository)
        {
            repository = _repository;
        }
        // GET: DataParser
        [System.Web.Http.HttpGet]
        public HttpResponseMessage Index()
        {
            foreach (var url in yahooUrls)
            {                
                HtmlDocument doc = new HtmlWeb().Load(url.Value);
                var pre = doc.DocumentNode.SelectNodes("//pre").FirstOrDefault();
                var splits = Regex.Split(pre.InnerHtml, "\r\n|\r|\n");
                int year, round, wins, losses = 0;
                Team rival = null;
                
                foreach (var split in splits)
                {
                    PlayoffResult playoffResult = null;
                    // regex https://regex101.com/r/EgsknO/1
                    var match = Regex.Match(split, "(\\d{4}) -- (defeated|lost to)\\s([a-zA-Z]*),\\s(\\d-\\d),\\s(.*)");
                    if (match.Success)
                    {
                        round = 1;
                        year = int.Parse(match.Groups[1].Value);
                        rival = GetTeamByCity(match.Groups[3].Value);
                        if (rival.Id == -1) continue;
                        var results = Array.ConvertAll(match.Groups[4].Value.Split('-'), int.Parse);
                        wins = match.Groups[2].Value == "defeated" ? results[0] : results[1];
                        losses = match.Groups[2].Value == "lost to" ? results[0] : results[1];
                        //round = match.Groups[4].Value;                        
                        playoffResult = new PlayoffResult
                        {
                            TeamId = url.Key,
                            OpponentId = rival.Id,
                            Round = round,
                            Year = year,
                            GamesWon = wins,
                            GamesLost = losses
                        };                      
                    }
                    else // is continued playoff appearance for that year
                    {
                        if (!string.IsNullOrEmpty(split))
                        {
                            var nextMatch = Regex.Match(split, "(defeated|lost to)\\s([a-zA-Z]*),\\s(\\d-\\d),\\s(.*)");
                            if (nextMatch.Success)
                            {
                                round++;
                                rival = GetTeamByCity(nextMatch.Groups[2].Value);
                                if (rival.Id == -1) continue;
                                var results = Array.ConvertAll(nextMatch.Groups[3].Value.Split('-'), int.Parse);
                                wins = nextMatch.Groups[1].Value == "defeated" ? results[0] : results[1];
                                losses = nextMatch.Groups[1].Value == "lost to" ? results[0] : results[1];
                                playoffResult = new PlayoffResult
                                {
                                    TeamId = url.Key,
                                    OpponentId = rival.Id,
                                    Round = round,
                                    Year = year,
                                    GamesWon = wins,
                                    GamesLost = losses                                    
                                };
                            }
                        }
                    }

                    if (playoffResult != null)
                        repository.Insert(playoffResult);
                }                
            }

            return Request.CreateResponse(HttpStatusCode.OK, new { success = true });
        }

        public Team GetTeamByCity(string city)
        {
            if (teamLookup.ContainsKey(city))
            {
                if (teamLookup[city] == -1)                
                    return new Team { Id = -1 };
                
                return repository.GetTeamById(teamLookup[city]);
            }                                

            return repository.GetTeamByCity(city);
        }

        public Dictionary<int, string> yahooUrls = new Dictionary<int, string>
        {
            {3, "http://sports.yahoo.com/nhl/news?slug=detroitpost" },
            {13,  "https://sports.yahoo.com/nhl/news?slug=nyrangerspost" },
            {1,  "http://sports.yahoo.com/nhl/news?slug=bostonpost" }
        };

        public Dictionary<string, int> teamLookup = new Dictionary<string, int>
        {
            { "Quebec", -1 },
            { "Atlanta", -1 },
            { "N.Y. Americans", -1},
            { "Montreal Maroons", -1 },
            { "Hartford", -1 },
            {"Montreal Wanderers", -1 },
            { "N.Y. Islanders",  13},
            { "NY Islanders",  13},
            {  "N.Y. Rangers",  14},
            { "NY Rangers", 14 },
            { "Colorado", 27 },
            { "Phoenix",  19},
            { "Minnesota", 29 },
            { "Florida", 5 }

        };
    }
}