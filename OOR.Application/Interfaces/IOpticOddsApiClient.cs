using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
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
        Task<string> GetFixturesForSportsRawAsync(IEnumerable<string> sportCodes, int page);

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
        /// Returns raw JSON for tournaments filtered by league.
        /// </summary>
        Task<string> GetTournamentsForLeagueRawAsync(string leagueCode);

        /// <summary>
        /// Returns raw JSON for conferences filtered by league.
        /// </summary>
        Task<string> GetConferencesForLeagueRawAsync(string leagueCode);

        /// <summary>
        /// Returns raw JSON for divisions filtered by league.
        /// </summary>
        Task<string> GetDivisionsForLeagueRawAsync(string leagueCode);

        /// <summary>
        /// Returns a list of Market objects (with SportCode set) for the given sport codes.
        /// Each Market's code, name, and description are populated from the API.
        /// </summary>
        Task<IEnumerable<Market>?> GetMarketsForSportsAsync(IEnumerable<string> sportCodes);

        /// <summary>
        /// Returns a list of MarketLeagueSportsbookDto representing relationships from the API.
        /// </summary>
        Task<IEnumerable<Sportsbook>?> GetSportsbooksAsync();
        Task<string> GetTournamentsForSportRawAsync(string sportCode);

        Task<string> GetTeamsForSportRawAsync(string sportCode, int page);
        Task<string> GetPlayersForSportRawAsync(string sportCode, int page);
        /// <summary>
        /// Gets a single player by ID from the OpticOdds API.
        /// </summary>
        Task<Player?> GetPlayerByIdAsync(string playerId);

        /// <summary>
        /// Gets a single team by ID from the OpticOdds API.
        /// </summary>
        Task<Team?> GetTeamByIdAsync(string teamId);
        Task<HttpResponseMessage> GetRawAsync(string url, CancellationToken cancellationToken);

    }
}
