using OOR.Domain.Entities;

namespace OOR.Application.Interfaces
{
    public interface IOpticOddsApiClient
    {
        Task<IEnumerable<League>?> GetLeaguesForSportsAsync(IEnumerable<string> sportCodes);
        Task<IEnumerable<Sportsbook>?> GetSportsbooksAsync();
        Task<IEnumerable<Market>?> GetMarketsForSportsAsync(IEnumerable<string> sportCodes);
    }
}