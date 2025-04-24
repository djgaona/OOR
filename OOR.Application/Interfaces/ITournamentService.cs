using OOR.Domain.Entities;
namespace OOR.Application.Interfaces
{
    public interface ITeamService
    {
        /// <summary>
        /// Seeds teams for multiple sports by calling the API.
        /// </summary>
        Task SeedTeamsAsync();

        /// <summary>
        /// Retrieves all teams from the database.
        /// </summary>
        Task<IEnumerable<Team>> GetTeamsAsync();
    }
}