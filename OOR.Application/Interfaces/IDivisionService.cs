using System.Collections.Generic;
using System.Threading.Tasks;
using OOR.Domain.Entities;

namespace OOR.Application.Interfaces
{
    public interface IDivisionService
    {
        /// <summary>
        /// Seeds divisions for the sports already in the database.
        /// </summary>
        Task SeedDivisionsAsync();

        /// <summary>
        /// Retrieves all divisions from the database.
        /// </summary>
        Task<IEnumerable<Division>> GetDivisionsAsync();
    }
}