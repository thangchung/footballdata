using System.Collections.Generic;
using System.Threading.Tasks;
using CiK.FootballData.Models;

namespace CiK.FootballData
{
    public class FootballDataClient : IFootballDataClient
    {
        public static readonly string FootballDataApiUrl = "api.football-data.org/v1/";
        public Protocol Protocol { get; private set; }
        public string ApiKey { get; }
        public SimpleRequest Request { get; set; } = new SimpleRequest();

        public FootballDataClient(Protocol protocol, string apiKey)
        {
            Protocol = protocol;
            ApiKey = apiKey;
        }

        public async Task<List<Competition>> GetCompetitions(string season)
        {
            var result = await Request.GetAsync<List<Competition>>($"competitions?season={season}", ApiKey);
            return result;
        }
    }
}