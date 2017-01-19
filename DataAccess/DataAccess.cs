using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamSeasonEnders.DB;

namespace TeamSeasonEnders.DataAccess
{
    public class TeamSeasonEndersRepository : ITeamSeasonsRepository, IDisposable
    {
        private TeamSeasonEndersContext context;

        public TeamSeasonEndersRepository(TeamSeasonEndersContext _context)
        {
            context = _context;
        }
        
        public IEnumerable<Team> GetTeamsByDivision(string division)
        {
            return context.Teams.Where(t => t.Conference == division).ToList();            
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IEnumerable<PlayoffResult> GetPlayoffHistory(int team, int rival)
        {
            return context.PlayoffResults
                    .Where(r => r.TeamId == team && r.OpponentId == rival ||
                            r.TeamId == rival && r.OpponentId == team)
                            .ToList();
        }
    }

    public interface ITeamSeasonsRepository : IDisposable
    {
        IEnumerable<Team> GetTeamsByDivision(string division);
        IEnumerable<PlayoffResult> GetPlayoffHistory(int team, int rival);
    }
}