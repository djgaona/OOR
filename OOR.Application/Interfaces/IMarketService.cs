using OOR.Domain.Entities;

namespace OOR.Application.Interfaces;

public interface IMarketService
{
    Task SeedMarketsAsync();
    Task<IEnumerable<Market>> GetMarketsBySportAsync(string sportCode);
}