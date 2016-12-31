using System;
using System.Collections.Generic;
using System.Reactive.Threading.Tasks;
using System.Threading;
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

        public async Task<IEnumerable<Season>> GetSeasonsAsync(string season)
        {
            var result = await Request.GetAsync<List<Season>>($"competitions?season={season}", ApiKey, CancellationToken.None).ConfigureAwait(false);
            return result;
        }

        public IObservable<IEnumerable<Season>> GetSeasonsStream(string season)
        {
            return GetSeasonsAsync(season).ToObservable();
        }

        public Task<IEnumerable<Team>> GetTeamsBySeasonAsync(int seasonId)
        {
            throw new NotImplementedException();
        }

        public Task<LeagueTable> GetLeagueTableBySeasonAsync(int seasonId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Fixture>> GetFixturesBySeasonAsync(int seasonId, int matchday = -1, string timeFrame = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Fixture>> GetFixturesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Fixture> GetFixtureAsync(int fixtureId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Fixture>> GetFixturesByTeamAsync(int teamId, int seasonId, string timeFrame = null, string venue = null)
        {
            throw new NotImplementedException();
        }

        public Task<Team> GetTeamAsync(int teamId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Player>> GetPlayersByTeamAsync(int teamId)
        {
            throw new NotImplementedException();
        }
    }
}