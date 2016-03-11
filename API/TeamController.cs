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
                var x = context.Teams.Where(t => t.Conference == division)
                    .Select(r => new TeamModel
                    {
                        Name = r.Name,
                        City = r.City,
                        State = r.State,
                        Division = r.Division,
                        Conference = r.Conference
                    });

                return x.ToList();
            }
        }

        public object Users()
        {
            return new {};
        }

        public class TeamModel
        {
            public string Name { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Division { get; set; }
            public string Conference { get; set; }
        }
    }
}