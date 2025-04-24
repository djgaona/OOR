using System.Collections.Generic;
using System.Threading.Tasks;
using OOR.Domain.Entities;

namespace OOR.Application.Interfaces
{
    public interface IFixtureService
    {
        /// <summary>
        /// Seeds fixtures for the sports already in the database.
        /// </summary>
        Task SeedFixturesAsync();

        /// <summary>
        /// Retrieves all fixtures from the database.
        /// </summary>
        Task<IEnumerable<Fixture>> GetFixturesAsync();
    }
}