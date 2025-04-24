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
    public class DivisionService : IDivisionService
    {
        private readonly OddsContext _context;
        private readonly IOpticOddsApiClient _apiClient;

        public DivisionService(OddsContext context, IOpticOddsApiClient apiClient)
        {
            _context = context;
            _apiClient = apiClient;
        }

        public async Task SeedDivisionsAsync()
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

            // Call the API for divisions.
            string json = await _apiClient.GetDivisionsForSportsRawAsync(sportCodes);
            JToken token = JToken.Parse(json);

            // Assume the API response wraps divisions in a "data" property.
            JArray divisionsArray = token["data"] as JArray;
            if (divisionsArray == null)
            {
                Console.WriteLine("No division data found in the API response.");
                return;
            }

            foreach (var divisionToken in divisionsArray)
            {
                // Map JSON "id" to Division.Code and "name" to Division.Name.
                string divisionCode = divisionToken["id"]?.ToString();
                string divisionName = divisionToken["name"]?.ToString();
                // API returns conference as an object; extract its "id".
                string conferenceCodeFromApi = divisionToken["conference"]?["id"]?.ToString();

                if (string.IsNullOrWhiteSpace(divisionCode) ||
                    string.IsNullOrWhiteSpace(divisionName) ||
                    string.IsNullOrWhiteSpace(conferenceCodeFromApi))
                {
                    continue;
                }

                // Verify that the division's conference exists.
                var conference = await _context.Conferences.FirstOrDefaultAsync(c => c.Code.Equals(conferenceCodeFromApi, StringComparison.OrdinalIgnoreCase));
                if (conference == null)
                    continue;

                // Check if the division already exists.
                bool divisionExists = await _context.Divisions.AnyAsync(d => d.Code == divisionCode);
                if (divisionExists)
                    continue;

                var division = new Division
                {
                    Code = divisionCode,
                    Name = divisionName,
                    ConferenceId = conference.Id
                };

                _context.Divisions.Add(division);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Division>> GetDivisionsAsync()
        {
            return await _context.Divisions
                .Include(d => d.Conference)
                .ThenInclude(c => c.League)
                .ToListAsync();
        }
    }
}
