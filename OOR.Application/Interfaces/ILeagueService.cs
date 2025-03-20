
using OOR.Domain.Entities;

namespace OOR.Application.Interfaces
{
       public interface ILeagueService
    {
        /// <summary>
        /// Retrieves leagues for all sports and seeds the database if they do not exist.
        /// </summary>
        Task SeedLeaguesAsync();

        /// <summary>
        /// Gets leagues for a specific sport (by sport code).
        /// </summary>
        Task<IEnumerable<League>> GetLeaguesBySportAsync(string sportCode);
    }
}
