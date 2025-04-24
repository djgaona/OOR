using OOR.Domain.Entities;
namespace OOR.Application.Interfaces
{
    public interface IPlayerService
    {
        /// <summary>
        /// Seeds players for multiple sports by calling the API.
        /// </summary>
        Task SeedPlayersAsync();

        /// <summary>
        /// Retrieves all players from the database.
        /// </summary>
        Task<IEnumerable<Player>> GetPlayersAsync();
    }
}