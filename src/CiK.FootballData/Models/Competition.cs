using System;

namespace CiK.FootballData.Models
{
    public class Competition
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public string League { get; set; }
        public string Year { get; set; }
        public int NumberOfTeams { get; set; }
        public int NumberOfGames { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}