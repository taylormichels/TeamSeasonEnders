﻿using System;
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
                var result = context.PlayoffResults
                                        .Where(r => r.TeamId == team && r.OpponentId == rival
                                            || r.TeamId == rival && r.OpponentId == team)
                    .Select(r => new ResultModel
                    {
                        Name = r.Rival.Name,
                        Round = r.Round,
                        Year = r.Year,
                        GamesWon = r.TeamId == team ? r.GamesWon: r.GamesLost,
                        GamesLost = r.TeamId == team ? r.GamesLost : r.GamesWon
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
            public int Round { get; set; }
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

            public string RoundTitle
            {
                get
                {
                    switch (Round)
                    {
                        case 1:
                            return "First Round";
                        case 2:
                            return "Second Round";
                        case 3:
                            return "Conference Finals";
                        case 4:
                            return "Stanyley Cup Final";
                        default:
                            return "N/A";
                    }
                }
            }
        }
    }
}