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
        // GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
        
        public IEnumerable<TeamModel> GetTeams(string division)
        {
            using (TeamSeasonEndersEntities context = new TeamSeasonEndersEntities())
            {
                //var x = context.Teams.Where(t => t.Division == division).ToList();
                //return x;

                var x = context.Teams.Where(t => t.Division == division)
                    .Select(r => new TeamModel
                    {
                        Name = r.Name,
                        City = r.City,
                        State = r.State,
                        Division = r.Division
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
        }
    }
}