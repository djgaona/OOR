using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using OOR.Application.Interfaces;
using OOR.Domain.Entities;
using OOR.Infrastructure.Context;

namespace OOR.Infrastructure.Services
{
    public class LeagueService : ILeagueService
    {
        private readonly OddsContext _context;
        private readonly IOpticOddsApiClient _apiClient;

        public LeagueService(OddsContext context, IOpticOddsApiClient apiClient)
        {
            _context = context;
            _apiClient = apiClient;
        }

        public async Task SeedLeaguesAsync()
        {
            // Get the sports already seeded in the database.
            var sports = await _context.Sports.ToListAsync();
            // Extract their codes (ensuring they are not null or whitespace).
            var sportCodes = sports.Select(s => s.Code).Where(code => !string.IsNullOrWhiteSpace(code)).ToList();
            if (!sportCodes.Any())
            {
                Console.WriteLine("No sports found. Please seed sports first.");
                return;
            }

            // Call the API for leagues using the already seeded sport codes.
            string json = await _apiClient.GetLeaguesForSportsRawAsync(sportCodes);
            JToken token = JToken.Parse(json);

            // Assuming the API response wraps leagues in a "data" property.
            JArray leaguesArray = token["data"] as JArray;
            if (leaguesArray == null)
            {
                Console.WriteLine("No league data found in the API response.");
                return;
            }

            foreach (var leagueToken in leaguesArray)
            {
                // Map JSON "id" to League.Code and "name" to League.Name.
                string leagueCode = leagueToken["id"]?.ToString();
                string leagueName = leagueToken["name"]?.ToString();
                // API returns sport as an object; we extract the sport code from it.
                string sportCodeFromApi = leagueToken["sport"]?["id"]?.ToString();

                if (string.IsNullOrWhiteSpace(leagueCode) ||
                    string.IsNullOrWhiteSpace(leagueName) ||
                    string.IsNullOrWhiteSpace(sportCodeFromApi))
                {
                    continue;
                }

                // Verify that this league's sport is among the already seeded sports.
                var sport = sports.FirstOrDefault(s => s.Code.Equals(sportCodeFromApi, StringComparison.OrdinalIgnoreCase));
                if (sport == null)
                {
                    // Skip leagues for which the corresponding sport isn't seeded.
                    continue;
                }

                // Check if the league already exists (by Code).
                bool leagueExists = await _context.Leagues.AnyAsync(l => l.Code == leagueCode);
                if (leagueExists)
                    continue;

                // Process region information.
                // Assume the API returns a "region" (name) and "region_code" (code).
                string regionName = leagueToken["region"]?.ToString();
                string regionCode = leagueToken["region_code"]?.ToString();

                int? regionId = null;
                if (!string.IsNullOrWhiteSpace(regionCode))
                {
                    var region = await _context.Regions.FirstOrDefaultAsync(r => r.Code == regionCode);
                    if (region == null)
                    {
                        // Create new region if not found.
                        region = new Region
                        {
                            Code = regionCode,
                            Name = regionName ?? regionCode
                        };
                        _context.Regions.Add(region);
                        await _context.SaveChangesAsync();
                    }
                    regionId = region.Id;
                }

                // Create and add the new League.
                var league = new League
                {
                    Code = leagueCode,
                    Name = leagueName,
                    SportId = sport.Id,
                    RegionId = regionId,
                    Level = leagueToken["level"]?.ToObject<int?>()
                };

                _context.Leagues.Add(league);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<League>> GetLeaguesBySportAsync(string sportCode)
        {
            return await _context.Leagues
                .Include(l => l.Sport)
                .Include(l => l.Region)
                .Where(l => l.Sport.Code == sportCode)
                .ToListAsync();
        }
    }
}
