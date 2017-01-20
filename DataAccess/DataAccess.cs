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

        public Team GetTeamById(int id)
        {
            return context.Teams.FirstOrDefault(t => t.Id == id);
        }

        public Team GetTeamByCity(string city)
        {
            return context.Teams.FirstOrDefault(t => t.City == city);
        }

        public void Save(Team team)
        {
            context.Teams.Add(team);
            context.SaveChanges();
        }

        public void Insert(PlayoffResult result)
        {
            if (context.PlayoffResults.FirstOrDefault(p => p.Year == result.Year && 
                    ((p.TeamId == result.TeamId && p.OpponentId == result.OpponentId) ||
                    (p.TeamId == result.OpponentId && p.OpponentId == result.TeamId))) == null)
            {
                context.PlayoffResults.Add(result);
                context.SaveChanges();
            }            
        }
    }

    public interface ITeamSeasonsRepository : IDisposable
    {
        void Save(Team team);
        void Insert(PlayoffResult result);
        Team GetTeamById(int id);
        Team GetTeamByCity(string city);
        IEnumerable<Team> GetTeamsByDivision(string division);
        IEnumerable<PlayoffResult> GetPlayoffHistory(int team, int rival);
    }
}