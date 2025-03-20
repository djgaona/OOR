using System.Collections.Generic;
using System.Threading.Tasks;
using OOR.Domain.Entities;

namespace OOR.Application.Interfaces
{
    public interface IOpticOddsApiClient
    {
        /// <summary>
        /// Returns raw JSON for leagues, filtered by sport codes.
        /// </summary>
        Task<string> GetLeaguesForSportsRawAsync(IEnumerable<string> sportCodes);

        /// <summary>
        /// Returns a list of Market objects (with SportCode set) for the given sport codes.
        /// Each Market's code, name, description are populated from the API.
        /// </summary>
        Task<IEnumerable<Market>?> GetMarketsForSportsAsync(IEnumerable<string> sportCodes);

        /// <summary>
        /// Returns a list of MarketLeagueSportsbookDto representing relationships from the API.
        /// </summary>
        Task<IEnumerable<MarketLeagueSportsbookDto>> GetMarketLeagueSportsbookRelationshipsAsync(IEnumerable<string> sportCodes);

        /// <summary>
        /// Returns a list of Sportsbook objects from the API (with Code, Name, etc.).
        /// </summary>
        Task<IEnumerable<Sportsbook>?> GetSportsbooksAsync();
    }

    /// <summary>
    /// DTO capturing relationships between Market, League, and Sportsbook codes from the API.
    /// </summary>
    public class MarketLeagueSportsbookDto
    {
        public string MarketCode { get; set; } = string.Empty;
        public string LeagueCode { get; set; } = string.Empty;
        public string SportsbookCode { get; set; } = string.Empty;
    }
}