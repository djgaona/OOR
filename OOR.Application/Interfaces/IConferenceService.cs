using System.Collections.Generic;
using System.Threading.Tasks;
using OOR.Domain.Entities;

namespace OOR.Application.Interfaces
{
    public interface IConferenceService
    {
        /// <summary>
        /// Seeds conferences for the sports already in the database.
        /// </summary>
        Task SeedConferencesAsync();

        /// <summary>
        /// Retrieves all conferences from the database.
        /// </summary>
        Task<IEnumerable<Conference>> GetConferencesAsync();
    }
}