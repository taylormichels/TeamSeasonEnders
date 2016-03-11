using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeamSeasonEnders.Models;

namespace TeamSeasonEnders.API
{
    public class TeamController : ApiController
    {        
        public IEnumerable<TeamModel> GetTeams(string division)
        {
            using (TeamSeasonEndersEntities context = new TeamSeasonEndersEntities())
            {
                var result = context.Teams.Where(t => t.Conference == division)
                    .Select(r => new TeamModel
                    {
                        Id = r.Id,
                        Name = r.Name,
                        City = r.City,
                        State = r.State,
                        Division = r.Division,
                        Conference = r.Conference
                    });

                return result.ToList();
            }
        }

        public IEnumerable<ResultModel> GetResults(int team, int rival)
        {
            using (TeamSeasonEndersEntities context = new TeamSeasonEndersEntities())
            {
                var result = context.PlayoffResults.Where(r => r.TeamId == team
                                                        && r.OpponentId == rival)
                    .Select(r => new ResultModel
                    {
                        Name = r.Rival.Name,
                        Round = r.Round,
                        Year = r.Year,
                        GamesWon = r.GamesWon,
                        GamesLost = r.GamesLost
                    });

                return result.ToList();
            }
        }

        public object Users()
        {
            return new {};
        }

        public class TeamModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Division { get; set; }
            public string Conference { get; set; }
        }

        public class ResultModel
        {
            public string Name { get; set; }
            public string Round { get; set; }
            public int Year { get; set; }
            public int GamesWon { get; set; }
            public int GamesLost { get; set; }
            public bool Win
            {
                get
                {
                    return GamesWon > GamesLost;
                }
            }
        }
    }
}