//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TeamSeasonEnders.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PlayoffResult
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public int OpponentId { get; set; }
        public string Round { get; set; }
        public int Year { get; set; }
        public Nullable<int> GameCount { get; set; }
        public Nullable<int> GamesWon { get; set; }
        public Nullable<int> GamesLost { get; set; }
    
        public virtual Team Team { get; set; }
    }
}
