using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CiK.FootballData.Models;

namespace CiK.FootballData
{
    public interface IFootballDataClient
    {
        /// <summary>
        ///     List all available competitions.
        /// </summary>
        /// <param name="seasonName"></param>
        /// <returns></returns>
        Task<IEnumerable<Season>> GetSeasonsAsync(string seasonName);

        /// <summary>
        ///     List all teams for a certain competition.
        /// </summary>
        /// <param name="seasonId"></param>
        /// <returns></returns>
        Task<IEnumerable<Team>> GetTeamsBySeasonAsync(int seasonId);

        /// <summary>
        ///     Show League Table / current standing.
        /// </summary>
        /// <param name="seasonId"></param>
        /// <returns></returns>
        Task<LeagueTable> GetLeagueTableBySeasonAsync(int seasonId);

        /// <summary>
        ///     List all fixtures for a certain competition.
        /// </summary>
        /// <param name="seasonId"></param>
        /// <param name="matchday"></param>
        /// <param name="timeFrame"></param>
        /// <returns></returns>
        Task<IEnumerable<Fixture>> GetFixturesBySeasonAsync(int seasonId, int matchday = -1, string timeFrame = null);

        /// <summary>
        ///     List fixtures across a set of competitions.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Fixture>> GetFixturesAsync();

        /// <summary>
        ///     Show one fixture.
        /// </summary>
        /// <param name="fixtureId"></param>
        /// <returns></returns>
        Task<Fixture> GetFixtureAsync(int fixtureId);

        /// <summary>
        ///     Show all fixtures for a certain team.
        /// </summary>
        /// <param name="teamId"></param>
        /// <param name="seasonId"></param>
        /// <param name="timeFrame"></param>
        /// <param name="venue"></param>
        /// <returns></returns>
        Task<IEnumerable<Fixture>> GetFixturesByTeamAsync(int teamId, int seasonId, string timeFrame = null,
            string venue = null);

        /// <summary>
        ///     Show one team.
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns></returns>
        Task<Team> GetTeamAsync(int teamId);

        /// <summary>
        ///     Show all players for a certain team.
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns></returns>
        Task<IEnumerable<Player>> GetPlayersByTeamAsync(int teamId);

        // Reactive API
        IObservable<IEnumerable<Season>> GetSeasonsStream(string season);
    }
}