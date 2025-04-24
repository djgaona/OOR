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
        /// Returns raw JSON for teams, filtered by sport codes.
        /// </summary>
        Task<string> GetTeamsForSportsRawAsync(IEnumerable<string> sportCodes);

        /// <summary>
        /// Returns raw JSON for players, filtered by sport codes.
        /// </summary>
        Task<string> GetPlayersForSportsRawAsync(IEnumerable<string> sportCodes);

        /// <summary>
        /// Returns raw JSON for fixtures, filtered by sport codes.
        /// </summary>
        Task<string> GetFixturesForSportsRawAsync(IEnumerable<string> sportCodes);

        /// <summary>
        /// Returns raw JSON for tournaments, filtered by sport codes.
        /// </summary>
        Task<string> GetTournamentsForSportsRawAsync(IEnumerable<string> sportCodes);

        /// <summary>
        /// Returns raw JSON for conferences, filtered by sport codes.
        /// </summary>
        Task<string> GetConferencesForSportsRawAsync(IEnumerable<string> sportCodes);

        /// <summary>
        /// Returns raw JSON for divisions, filtered by sport codes.
        /// </summary>
        Task<string> GetDivisionsForSportsRawAsync(IEnumerable<string> sportCodes);

        /// <summary>
        /// Returns a list of Market objects (with SportCode set) for the given sport codes.
        /// Each Market's code, name, and description are populated from the API.
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
