using System;

namespace CiK.FootballData.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int JerseyNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public DateTime ContractUntil { get; set; }
        public string MarketValue { get; set; }
    }
}