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
    public class ConferenceService : IConferenceService
    {
        private readonly OddsContext _context;
        private readonly IOpticOddsApiClient _apiClient;

        public ConferenceService(OddsContext context, IOpticOddsApiClient apiClient)
        {
            _context = context;
            _apiClient = apiClient;
        }

        public async Task SeedConferencesAsync()
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

            // Call the API for conferences.
            string json = await _apiClient.GetConferencesForSportsRawAsync(sportCodes);
            JToken token = JToken.Parse(json);

            // Assume the API response wraps conferences in a "data" property.
            JArray conferencesArray = token["data"] as JArray;
            if (conferencesArray == null)
            {
                Console.WriteLine("No conference data found in the API response.");
                return;
            }

            foreach (var conferenceToken in conferencesArray)
            {
                // Map JSON "id" to Conference.Code and "name" to Conference.Name.
                string conferenceCode = conferenceToken["id"]?.ToString();
                string conferenceName = conferenceToken["name"]?.ToString();
                // API returns league as an object; extract its "id".
                string leagueCodeFromApi = conferenceToken["league"]?["id"]?.ToString();

                if (string.IsNullOrWhiteSpace(conferenceCode) ||
                    string.IsNullOrWhiteSpace(conferenceName) ||
                    string.IsNullOrWhiteSpace(leagueCodeFromApi))
                {
                    continue;
                }

                // Verify that the conference's league exists.
                var league = await _context.Leagues.FirstOrDefaultAsync(l => l.Code.Equals(leagueCodeFromApi, StringComparison.OrdinalIgnoreCase));
                if (league == null)
                    continue;

                // Check if the conference already exists.
                bool conferenceExists = await _context.Conferences.AnyAsync(c => c.Code == conferenceCode);
                if (conferenceExists)
                    continue;

                var conference = new Conference
                {
                    Code = conferenceCode,
                    Name = conferenceName,
                    LeagueId = league.Id
                };

                _context.Conferences.Add(conference);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Conference>> GetConferencesAsync()
        {
            return await _context.Conferences
                .Include(c => c.League)
                .ToListAsync();
        }
    }
}
