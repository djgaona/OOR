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
    public class FixtureService : IFixtureService
    {
        private readonly OddsContext _context;
        private readonly IOpticOddsApiClient _apiClient;

        public FixtureService(OddsContext context, IOpticOddsApiClient apiClient)
        {
            _context = context;
            _apiClient = apiClient;
        }

        public async Task SeedFixturesAsync()
        {
            // Get the sports already seeded in the database.
            var sports = await _context.Sports.ToListAsync();
            var sportCodes = sports
                .Select(s => s.Code)
                .Where(code => !string.IsNullOrWhiteSpace(code))
                .ToList();
            if (!sportCodes.Any())
            {
                Console.WriteLine("No sports found. Please seed sports first.");
                return;
            }

            // Call the API for fixtures.
            string json = await _apiClient.GetFixturesForSportsRawAsync(sportCodes);
            JToken token = JToken.Parse(json);

            // Assume the API response wraps fixtures in a "data" property.
            JArray fixturesArray = token["data"] as JArray;
            if (fixturesArray == null)
            {
                Console.WriteLine("No fixture data found in the API response.");
                return;
            }

            foreach (var fixtureToken in fixturesArray)
            {
                // Map JSON "id" to Fixture.Code.
                string fixtureCode = fixtureToken["id"]?.ToString();
                if (string.IsNullOrWhiteSpace(fixtureCode))
                    continue;

                // Check if the fixture already exists (by Code).
                bool fixtureExists = await _context.Fixtures.AnyAsync(f => f.Code == fixtureCode);
                if (fixtureExists)
                    continue;

                int? numericalId = fixtureToken["numerical_id"]?.ToObject<int?>();
                DateTime? startDate = fixtureToken["start_date"]?.ToObject<DateTime?>();
                int? statusId = fixtureToken["status_id"]?.ToObject<int?>();
                bool? isLive = fixtureToken["is_live"]?.ToObject<bool?>();

                // Resolve tournament association.
                string tournamentCodeFromApi = fixtureToken["tournament"]?["id"]?.ToString();
                int? tournamentId = null;
                if (!string.IsNullOrWhiteSpace(tournamentCodeFromApi))
                {
                    var tournament = await _context.Tournaments.FirstOrDefaultAsync(t => t.Code == tournamentCodeFromApi);
                    if (tournament != null)
                    {
                        tournamentId = tournament.Id;
                    }
                }

                // Create and add the new Fixture.
                var fixture = new Fixture
                {
                    Code = fixtureCode,
                    NumericalId = numericalId,
                    StartDate = startDate,
                    StatusId = statusId,
                    IsLive = isLive,
                    TournamentId = tournamentId
                    // Map additional properties as needed.
                };

                _context.Fixtures.Add(fixture);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Fixture>> GetFixturesAsync()
        {
            return await _context.Fixtures
                .Include(f => f.Tournament)
                .ToListAsync();
        }
    }
}
