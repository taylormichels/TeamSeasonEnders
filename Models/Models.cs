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

        public int RoundByTitle(string title, int year)
        {
            // eh scrapping this for now theres too many name changes over the years
            int result = 0;
            switch (title)
            {
                case "Patrick Division semifinals":
                case "Adams Division semifinals":
                case "Norris Division semifinals":
                case "Smythe Dvision semifinals":
                case "preliminary round":
                case "Eastern Conf. quarterfinals":
                case "Western Conf. quarterfinals":
                    result = 1;
                    break;
                
                case "quartefinals":
                    if (year > 1978)
                        result = 2;
                    else
                        result = 1;
                    break;
                case "Patrick Division finals":
                case "Norris Division finals":
                    result = 2;
                    break;

                case "Wales Conference finals":
                case "Campbell Conference finals":
                case "Western Conf. finals":                
                case "Eastern Conf. finals":                
                case "semifinals":
                    result = 3;
                    break;
                case "Eastern Conf, semifinals":
                case "Western Conf. semifinals":
                    if (year > 1992)
                        result = 2;
                    else
                        result = 1;
                    break;
                case "Stanley Cup Finals":
                    result = 4;
                    break;                    
            }
            return result;
        }
    }
}