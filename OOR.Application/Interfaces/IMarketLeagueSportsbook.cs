using OOR.Domain.Entities;

namespace OOR.Application.Interfaces
{
    public interface IMarketLeagueSportsbookService
    {
        /// <summary>
        /// Seeds MarketLeagueSportsbook records from the given JSON.
        /// </summary>
        /// <param name="json">The JSON response from the API.</param>
        Task SeedMarketLeagueSportsbooksAsync(string json);
    }
}