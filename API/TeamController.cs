using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeamSeasonEnders.DataAccess;
using TeamSeasonEnders.DB;
using TeamSeasonEnders.Models;

namespace TeamSeasonEnders.API
{
    public class TeamController : ApiController
    {
        private ITeamSeasonsRepository repository;

        public TeamController()
        {
            repository = new TeamSeasonEndersRepository(new TeamSeasonEndersContext());
        }

        public TeamController(ITeamSeasonsRepository _repository)
        {
            repository = _repository;
        }

        public IEnumerable<TeamModel> GetTeams(string division)
        {
           return repository.GetTeamsByDivision(division)
                .Select(r => new TeamModel
                    {
                        Id = r.Id,
                        Name = r.Name,
                        City = r.City,
                        State = r.State,
                        Division = r.Division,
                        Conference = r.Conference
                    }).ToList();            
        }

        public IEnumerable<ResultModel> GetResults(int team, int rival)
        {
            return repository.GetPlayoffHistory(team, rival)
                    .Select(r => new ResultModel
                        {
                            Name = r.Rival.Name,
                            Round = r.Round,
                            Year = r.Year,
                            GamesWon = r.TeamId == team ? r.GamesWon: r.GamesLost,
                            GamesLost = r.TeamId == team ? r.GamesLost : r.GamesWon
                        }).ToList();                            
        }       
    }
}