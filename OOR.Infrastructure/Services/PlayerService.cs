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
    public class PlayerService : IPlayerService
    {
        private readonly OddsContext _context;
        private readonly IOpticOddsApiClient _apiClient;

        public PlayerService(OddsContext context, IOpticOddsApiClient apiClient)
        {
            _context = context;
            _apiClient = apiClient;
        }

        public async Task SeedPlayersAsync()
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

            // Call the API for players using the already seeded sport codes.
            string json = await _apiClient.GetPlayersForSportsRawAsync(sportCodes);
            JToken token = JToken.Parse(json);

            // Assuming the API response wraps players in a "data" property.
            JArray playersArray = token["data"] as JArray;
            if (playersArray == null)
            {
                Console.WriteLine("No player data found in the API response.");
                return;
            }

            foreach (var playerToken in playersArray)
            {
                // Map JSON "id" to Player.Code and "name" to Player.Name.
                string playerCode = playerToken["id"]?.ToString();
                string playerName = playerToken["name"]?.ToString();
                // Extract sport information from the API.
                string sportCodeFromApi = playerToken["sport"]?["id"]?.ToString();

                if (string.IsNullOrWhiteSpace(playerCode) ||
                    string.IsNullOrWhiteSpace(playerName) ||
                    string.IsNullOrWhiteSpace(sportCodeFromApi))
                {
                    continue;
                }

                // Verify that this player's sport is among the already seeded sports.
                var sport = sports.FirstOrDefault(s => s.Code.Equals(sportCodeFromApi, StringComparison.OrdinalIgnoreCase));
                if (sport == null)
                {
                    continue;
                }

                // Check if the player already exists (by Code).
                bool playerExists = await _context.Players.AnyAsync(p => p.Code == playerCode);
                if (playerExists)
                    continue;

                // Resolve team association if available.
                string teamCodeFromApi = playerToken["team"]?["id"]?.ToString();
                int? teamId = null;
                if (!string.IsNullOrWhiteSpace(teamCodeFromApi))
                {
                    var team = await _context.Teams.FirstOrDefaultAsync(t => t.Code == teamCodeFromApi);
                    if (team != null)
                    {
                        teamId = team.Id;
                    }
                }

                // Create and add the new Player.
                var player = new Player
                {
                    Code = playerCode,
                    Name = playerName,
                    TeamId = teamId,
                    Position = playerToken["position"]?.ToString(),
                    Number = playerToken["number"]?.ToObject<int?>(),
                    StatusId = playerToken["status_id"]?.ToObject<int?>()
                };

                _context.Players.Add(player);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Player>> GetPlayersAsync()
        {
            return await _context.Players
                .Include(p => p.Team)
                .ToListAsync();
        }
    }
}
