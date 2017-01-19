using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamSeasonEnders.Models
{
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