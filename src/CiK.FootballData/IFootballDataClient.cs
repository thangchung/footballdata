using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CiK.FootballData.Models;

namespace CiK.FootballData
{
    /// <summary>
    ///     The interface for football-data.org site,
    ///     for more information please go to http://api.football-data.org/documentation
    /// </summary>
    public interface IFootballDataClient
    {
        /// <summary>
        ///     List all available competitions asynchronous.
        /// </summary>
        /// <param name="seasonName"></param>
        /// <returns></returns>
        Task<IEnumerable<Season>> GetSeasonsAsync(string seasonName);

        /// <summary>
        ///     List all teams for a certain competition asynchronous.
        /// </summary>
        /// <param name="seasonId"></param>
        /// <returns></returns>
        Task<IEnumerable<Team>> GetTeamsBySeasonAsync(int seasonId);

        /// <summary>
        ///     Show League Table / current standing asynchronous.
        /// </summary>
        /// <param name="seasonId"></param>
        /// <returns></returns>
        Task<LeagueTable> GetLeagueTableBySeasonAsync(int seasonId);

        /// <summary>
        ///     List all fixtures for a certain competition asynchronous.
        /// </summary>
        /// <param name="seasonId"></param>
        /// <param name="matchday"></param>
        /// <param name="timeFrame"></param>
        /// <returns></returns>
        Task<IEnumerable<Fixture>> GetFixturesBySeasonAsync(int seasonId, int matchday = -1, string timeFrame = null);

        /// <summary>
        ///     List fixtures across a set of competitions asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Fixture>> GetFixturesAsync();

        /// <summary>
        ///     Show one fixture asynchronous.
        /// </summary>
        /// <param name="fixtureId"></param>
        /// <returns></returns>
        Task<Fixture> GetFixtureAsync(int fixtureId);

        /// <summary>
        ///     Show all fixtures for a certain team asynchronous.
        /// </summary>
        /// <param name="teamId"></param>
        /// <param name="season"></param>
        /// <param name="timeFrame"></param>
        /// <param name="venue"></param>
        /// <returns></returns>
        Task<IEnumerable<Fixture>> GetFixturesByTeamAsync(int teamId, int season, string timeFrame = null,
            string venue = null);

        /// <summary>
        ///     Show one team asynchronous.
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns></returns>
        Task<Team> GetTeamAsync(int teamId);

        /// <summary>
        ///     Show all players for a certain team asynchronous.
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns></returns>
        Task<IEnumerable<Player>> GetPlayersByTeamAsync(int teamId);

        /// <summary>
        ///     List all available competitions stream.
        /// </summary>
        /// <param name="season"></param>
        /// <returns></returns>
        IObservable<IEnumerable<Season>> GetSeasonsStream(string season);

        /// <summary>
        ///     List all teams for a certain competition stream.
        /// </summary>
        /// <param name="seasonId"></param>
        /// <returns></returns>
        IObservable<IEnumerable<Team>> GetTeamsBySeasonStream(int seasonId);

        /// <summary>
        ///     Show League Table / current standing stream.
        /// </summary>
        /// <param name="seasonId"></param>
        /// <returns></returns>
        IObservable<LeagueTable> GetLeagueTableBySeasonStream(int seasonId);

        /// <summary>
        ///     List all fixtures for a certain competition stream.
        /// </summary>
        /// <param name="seasonId"></param>
        /// <param name="matchday"></param>
        /// <param name="timeFrame"></param>
        /// <returns></returns>
        IObservable<IEnumerable<Fixture>> GetFixturesBySeasonStream(int seasonId, int matchday = -1,
            string timeFrame = null);

        /// <summary>
        ///     List fixtures across a set of competitions stream.
        /// </summary>
        /// <returns></returns>
        IObservable<IEnumerable<Fixture>> GetFixturesStream();

        /// <summary>
        ///     Show one fixture stream.
        /// </summary>
        /// <param name="fixtureId"></param>
        /// <returns></returns>
        IObservable<Fixture> GetFixtureStream(int fixtureId);

        /// <summary>
        ///     Show all fixtures for a certain team stream.
        /// </summary>
        /// <param name="teamId"></param>
        /// <param name="season"></param>
        /// <param name="timeFrame"></param>
        /// <param name="venue"></param>
        /// <returns></returns>
        IObservable<IEnumerable<Fixture>> GetFixturesByTeamStream(int teamId, int season, string timeFrame = null,
            string venue = null);

        /// <summary>
        ///     Show one team stream.
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns></returns>
        IObservable<Team> GetTeamStream(int teamId);

        /// <summary>
        ///     Show all players for a certain team stream.
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns></returns>
        IObservable<IEnumerable<Player>> GetPlayersByTeamStream(int teamId);
    }
}