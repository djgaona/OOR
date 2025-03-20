using OOR.Domain.Entities;
namespace OOR.Application.Interfaces
{
    public interface ISportsbookService
    {
        Task SeedSportsbooksAsync();
        Task<IEnumerable<Sportsbook>> GetAllSportsbooksAsync();
    }
}