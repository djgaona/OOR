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
    public class TournamentService : ITournamentService
    {
        private readonly OddsContext _context;
        private readonly IOpticOddsApiClient _apiClient;

        public TournamentService(OddsContext context, IOpticOddsApiClient apiClient)
        {
            _context = context;
            _apiClient = apiClient;
        }

        public async Task SeedTournamentsAsync()
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

            // Call the API for tournaments.
            string json = await _apiClient.GetTournamentsForSportsRawAsync(sportCodes);
            JToken token = JToken.Parse(json);

            // Assume the API response wraps tournaments in a "data" property.
            JArray tournamentsArray = token["data"] as JArray;
            if (tournamentsArray == null)
            {
                Console.WriteLine("No tournament data found in the API response.");
                return;
            }

            foreach (var tournamentToken in tournamentsArray)
            {
                // Map JSON "id" to Tournament.Code and "name" to Tournament.Name.
                string tournamentCode = tournamentToken["id"]?.ToString();
                string tournamentName = tournamentToken["name"]?.ToString();
                // API returns league as an object; extract its "id".
                string leagueCodeFromApi = tournamentToken["league"]?["id"]?.ToString();

                if (string.IsNullOrWhiteSpace(tournamentCode) ||
                    string.IsNullOrWhiteSpace(tournamentName) ||
                    string.IsNullOrWhiteSpace(leagueCodeFromApi))
                {
                    continue;
                }

                // Verify that the tournament's league is among the seeded leagues.
                var league = await _context.Leagues.FirstOrDefaultAsync(l => l.Code.Equals(leagueCodeFromApi, StringComparison.OrdinalIgnoreCase));
                if (league == null)
                {
                    continue;
                }

                // Check if the tournament already exists (by Code).
                bool tournamentExists = await _context.Tournaments.AnyAsync(t => t.Code == tournamentCode);
                if (tournamentExists)
                    continue;

                // Parse start and end dates (assumes the API returns these in a compatible format).
                DateOnly? startDate = tournamentToken["start_date"]?.ToObject<DateOnly?>();
                DateOnly? endDate = tournamentToken["end_date"]?.ToObject<DateOnly?>();

                // Create and add the new Tournament.
                var tournament = new Tournament
                {
                    Code = tournamentCode,
                    Name = tournamentName,
                    LeagueId = league.Id,
                    StartDate = startDate,
                    EndDate = endDate
                };

                _context.Tournaments.Add(tournament);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Tournament>> GetTournamentsAsync()
        {
            return await _context.Tournaments
                .Include(t => t.League)
                .ToListAsync();
        }
    }
}
