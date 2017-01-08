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

        public FootballDataClient(Protocol protocol, string apiKey)
        {
            Protocol = protocol;
            ApiKey = apiKey;
        }

        public Protocol Protocol { get; private set; }
        public string ApiKey { get; }
        public SimpleRequest Request { get; set; } = new SimpleRequest();

        #region "TPL implementation"

        public async Task<IEnumerable<Season>> GetSeasonsAsync(string season)
        {
            var result = await Request.GetAsync<List<Season>>(
                    $"competitions?season={season}",
                    ApiKey,
                    CancellationToken.None)
                .ConfigureAwait(false);
            return result;
        }

        public async Task<IEnumerable<Team>> GetTeamsBySeasonAsync(int seasonId)
        {
            var result = await Request.GetAsync<List<Team>>(
                    $"competitions/{seasonId}/teams",
                    ApiKey,
                    CancellationToken.None)
                .ConfigureAwait(false);
            return result;
        }

        public async Task<LeagueTable> GetLeagueTableBySeasonAsync(int seasonId)
        {
            var result = await Request.GetAsync<LeagueTable>(
                    $"competitions/{seasonId}/leagueTable",
                    ApiKey,
                    CancellationToken.None)
                .ConfigureAwait(false);
            return result;
        }

        public async Task<IEnumerable<Fixture>> GetFixturesBySeasonAsync(int seasonId, int matchday = -1,
            string timeFrame = null)
        {
            var queryString = string.Empty;
            if (matchday > 0)
                queryString += "matchday=" + matchday;
            if (!string.IsNullOrEmpty(timeFrame))
                queryString += "&timeFrame=" + timeFrame;
            var result = await Request.GetAsync<List<Fixture>>(
                    $"competitions/{seasonId}/fixtures?{queryString}",
                    ApiKey,
                    CancellationToken.None)
                .ConfigureAwait(false);
            return result;
        }

        public async Task<IEnumerable<Fixture>> GetFixturesAsync()
        {
            var result = await Request.GetAsync<List<Fixture>>(
                    $"fixtures/",
                    ApiKey,
                    CancellationToken.None)
                .ConfigureAwait(false);
            return result;
        }

        public async Task<Fixture> GetFixtureAsync(int fixtureId)
        {
            var result = await Request.GetAsync<Fixture>(
                    $"fixtures/{fixtureId}/",
                    ApiKey,
                    CancellationToken.None)
                .ConfigureAwait(false);
            return result;
        }

        public async Task<IEnumerable<Fixture>> GetFixturesByTeamAsync(int teamId, int season, string timeFrame = null,
            string venue = null)
        {
            var queryString = string.Empty;
            if (season.ToString().Length >= 4)
                queryString += "season=" + season;
            if (!string.IsNullOrEmpty(timeFrame))
                queryString += "timeFrame=" + timeFrame;
            if (!string.IsNullOrEmpty(venue))
                queryString += "venue=" + venue;
            var result = await Request.GetAsync<List<Fixture>>(
                    $"teams/{teamId}/fixtures?{queryString}",
                    ApiKey,
                    CancellationToken.None)
                .ConfigureAwait(false);
            return result;
        }

        public async Task<Team> GetTeamAsync(int teamId)
        {
            var result = await Request.GetAsync<Team>(
                    $"teams/{teamId}/",
                    ApiKey,
                    CancellationToken.None)
                .ConfigureAwait(false);
            return result;
        }

        public async Task<IEnumerable<Player>> GetPlayersByTeamAsync(int teamId)
        {
            var result = await Request.GetAsync<List<Player>>(
                    $"teams/{teamId}/players",
                    ApiKey,
                    CancellationToken.None)
                .ConfigureAwait(false);
            return result;
        }

        #endregion

        #region "reactive implementation" 

        public IObservable<IEnumerable<Season>> GetSeasonsStream(string season)
        {
            return GetSeasonsAsync(season).ToObservable();
        }

        public IObservable<IEnumerable<Team>> GetTeamsBySeasonStream(int seasonId)
        {
            return GetTeamsBySeasonAsync(seasonId).ToObservable();
        }

        public IObservable<LeagueTable> GetLeagueTableBySeasonStream(int seasonId)
        {
            return GetLeagueTableBySeasonAsync(seasonId).ToObservable();
        }

        public IObservable<IEnumerable<Fixture>> GetFixturesBySeasonStream(int seasonId, int matchday = -1,
            string timeFrame = null)
        {
            return GetFixturesBySeasonAsync(seasonId, matchday, timeFrame).ToObservable();
        }

        public IObservable<IEnumerable<Fixture>> GetFixturesStream()
        {
            return GetFixturesAsync().ToObservable();
        }

        public IObservable<Fixture> GetFixtureStream(int fixtureId)
        {
            return GetFixtureAsync(fixtureId).ToObservable();
        }

        public IObservable<IEnumerable<Fixture>> GetFixturesByTeamStream(int teamId, int season, string timeFrame = null,
            string venue = null)
        {
            return GetFixturesByTeamAsync(teamId, season, timeFrame, venue).ToObservable();
        }

        public IObservable<Team> GetTeamStream(int teamId)
        {
            return GetTeamAsync(teamId).ToObservable();
        }

        public IObservable<IEnumerable<Player>> GetPlayersByTeamStream(int teamId)
        {
            return GetPlayersByTeamAsync(teamId).ToObservable();
        }

        #endregion
    }
}