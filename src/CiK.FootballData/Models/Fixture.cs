using System;

namespace CiK.FootballData.Models
{
    public class Fixture
    {
        public int Id { get; set; }
        public int CompetitionId { get; set; }
        public DateTime Date { get; set; }
        public int Matchday { get; set; }
        public string HomeTeamName { get; set; }
        public int HomeTeamId { get; set; }
        public string AwayTeamName { get; set; }
        public int AwayTeamId { get; set; }
        public FixtureResult Result { get; set; }
    }

    public class FixtureResult
    {
        public int GoalsHomeTeam { get; set; }
        public int GoalsAwayTeam { get; set; }
    }
}