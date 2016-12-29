using System.Collections.Generic;
using System.Threading.Tasks;
using CiK.FootballData.Models;

namespace CiK.FootballData
{
    public interface IFootballDataClient
    {
        Task<List<Competition>> GetCompetitions(string season);
    }
}