using System.Linq;
using CiK.FootballData;

namespace ConsoleSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IFootballDataClient client = new FootballDataClient(Protocol.HTTP, "acec24061235402a802ad04c9f7b6b81");
            var competitions = client.GetCompetitions("2016").Result;
            var firstCompetion = competitions.FirstOrDefault(x => x.League == "PL");
        }
    }
}