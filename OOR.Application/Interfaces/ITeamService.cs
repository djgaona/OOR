using System.Collections.Generic;
using System.Threading.Tasks;
using OOR.Domain.Entities;

namespace OOR.Application.Interfaces
{
    public interface ITournamentService
    {
        /// <summary>
        /// Seeds tournaments for the sports already in the database.
        /// </summary>
        Task SeedTournamentsAsync();

        /// <summary>
        /// Retrieves all tournaments from the database.
        /// </summary>
        Task<IEnumerable<Tournament>> GetTournamentsAsync();
    }
}