using OOR.Domain.Entities;
namespace OOR.Application.Interfaces
{
    public interface ILeagueService
    {
        Task SeedLeaguesAsync();
        Task<IEnumerable<League>> GetLeaguesBySportAsync(string sportCode);
    }
}