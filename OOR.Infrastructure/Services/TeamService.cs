using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using OOR.Application.Interfaces;
using OOR.Domain.Entities;
using OOR.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOR.Infrastructure.Services
{
    public class TeamService : ITeamService
    {
        private readonly OddsContext _context;
        private readonly IOpticOddsApiClient _apiClient;

        public TeamService(OddsContext context, IOpticOddsApiClient apiClient)
        {
            _context = context;
            _apiClient = apiClient;
        }

        public async Task SeedTeamsAsync()
        {
            // Get the sports already seeded in the database.
            var sports = await _context.Sports.ToListAsync();
            var sportCodes = sports.Select(s => s.Code)
                                   .Where(code => !string.IsNullOrWhiteSpace(code))
                                   .ToList();
            if (!sportCodes.Any())
            {
                Console.WriteLine("No sports found. Please seed sports first.");
                return;
            }

            // Call the API for teams using the already seeded sport codes.
            string json = await _apiClient.GetTeamsForSportsRawAsync(sportCodes);
            JToken token = JToken.Parse(json);

            // Assuming the API response wraps teams in a "data" property.
            JArray teamsArray = token["data"] as JArray;
            if (teamsArray == null)
            {
                Console.WriteLine("No team data found in the API response.");
                return;
            }

            foreach (var teamToken in teamsArray)
            {
                // Map JSON "id" to Team.Code and "name" to Team.Name.
                string teamCode = teamToken["id"]?.ToString();
                string teamName = teamToken["name"]?.ToString();
                // API returns sport as an object; extract its "id".
                string sportCodeFromApi = teamToken["sport"]?["id"]?.ToString();

                if (string.IsNullOrWhiteSpace(teamCode) ||
                    string.IsNullOrWhiteSpace(teamName) ||
                    string.IsNullOrWhiteSpace(sportCodeFromApi))
                {
                    continue;
                }

                // Verify that this team's sport is among the already seeded sports.
                var sport = sports.FirstOrDefault(s => s.Code.Equals(sportCodeFromApi, StringComparison.OrdinalIgnoreCase));
                if (sport == null)
                {
                    continue;
                }

                // Check if the team already exists (by Code).
                bool teamExists = await _context.Teams.AnyAsync(t => t.Code == teamCode);
                if (teamExists)
                    continue;

                // Create and add the new Team.
                var team = new Team
                {
                    Code = teamCode,
                    Name = teamName,
                    Abbreviation = teamToken["abbreviation"]?.ToString(),
                    LogoUrl = teamToken["logo_url"]?.ToString()
                    // Optionally map additional properties (e.g., CityId, DivisionId) if provided.
                };

                _context.Teams.Add(team);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Team>> GetTeamsAsync()
        {
            return await _context.Teams
                .Include(t => t.Players)
                .ToListAsync();
        }
    }
}
