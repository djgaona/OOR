using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OOR.Application.Interfaces;
using OOR.Domain.Entities;
using OOR.Infrastructure.Context;

namespace OOR.Infrastructure.Services
{
    public class MarketService : IMarketService
    {
        private readonly OddsContext _context;
        private readonly IOpticOddsApiClient _apiClient;

        public MarketService(OddsContext context, IOpticOddsApiClient apiClient)
        {
            _context = context;
            _apiClient = apiClient;
        }

        public async Task SeedMarketsAsync()
        {
            // 1. Get all seeded sports from the DB.
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

            // 2. Retrieve markets from the API for these sports
            var marketsFromApi = await _apiClient.GetMarketsForSportsAsync(sportCodes);
            if (marketsFromApi == null)
            {
                Console.WriteLine("No markets returned from the API.");
                return;
            }

            // Use a HashSet to track processed market codes
            var processedMarketCodes = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            // 3. Insert new Market records
            foreach (var apiMarket in marketsFromApi)
            {
                if (string.IsNullOrWhiteSpace(apiMarket.Code))
                    continue;

                if (processedMarketCodes.Contains(apiMarket.Code))
                    continue;

                // Check if this market already exists
                bool marketExists = await _context.Markets.AnyAsync(m => m.Code == apiMarket.Code);
                if (marketExists)
                {
                    processedMarketCodes.Add(apiMarket.Code);
                    continue;
                }

                // Attempt to look up the sport ID via SportCode
                int? sportId = null;
                if (!string.IsNullOrWhiteSpace(apiMarket.SportCode))
                {
                    var sportEntity = sports.FirstOrDefault(s =>
                        s.Code.Equals(apiMarket.SportCode, StringComparison.OrdinalIgnoreCase));
                    if (sportEntity != null)
                    {
                        sportId = sportEntity.Id;
                    }
                }
                else if (apiMarket.SportId.HasValue)
                {
                    sportId = apiMarket.SportId.Value;
                }

                var newMarket = new Market
                {
                    Code = apiMarket.Code,
                    Name = apiMarket.Name,
                    Description = apiMarket.Description,
                    SportId = sportId
                };

                _context.Markets.Add(newMarket);
                processedMarketCodes.Add(apiMarket.Code);
            }

            await _context.SaveChangesAsync();

            // 4. Insert MarketLeagueSportsbook relationships
            var relationships = await _apiClient.GetMarketLeagueSportsbookRelationshipsAsync(sportCodes);
            foreach (var dto in relationships)
            {
                // Look up Market, League, Sportsbook by code
                var market = await _context.Markets.FirstOrDefaultAsync(m => m.Code == dto.MarketCode);
                var league = await _context.Leagues.FirstOrDefaultAsync(l => l.Code == dto.LeagueCode);
                var sportsbook = await _context.Sportsbooks.FirstOrDefaultAsync(sb => sb.Code == dto.SportsbookCode);

                if (market == null || league == null || sportsbook == null)
                    continue;

                // Check if combination already exists
                bool exists = await _context.MarketLeagueSportsbooks.AnyAsync(mls =>
                    mls.MarketId == market.Id &&
                    mls.LeagueId == league.Id &&
                    mls.SportsbookId == sportsbook.Id);

                if (!exists)
                {
                    var newMls = new MarketLeagueSportsbook
                    {
                        MarketId = market.Id,
                        LeagueId = league.Id,
                        SportsbookId = sportsbook.Id
                    };
                    _context.MarketLeagueSportsbooks.Add(newMls);
                }
            }

            await _context.SaveChangesAsync();

            Console.WriteLine("Markets and MarketLeagueSportsbook relationships seeded successfully.");
        }

        public async Task<IEnumerable<Market>> GetMarketsBySportAsync(string sportCode)
        {
            return await _context.Markets
                .Include(m => m.Sport)
                .Where(m => m.Sport.Code == sportCode)
                .ToListAsync();
        }
    }
}
