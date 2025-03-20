using System;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using OOR.Application.Interfaces;
using OOR.Domain.Entities;
using OOR.Infrastructure.Context; // Make sure this points to your DbContext namespace

namespace OOR.Infrastructure.Services
{
    public class MarketLeagueSportsbookService : IMarketLeagueSportsbookService
    {
        private readonly OddsContext _context;

        public MarketLeagueSportsbookService(OddsContext context)
        {
            _context = context;
        }

        public async Task SeedMarketLeagueSportsbooksAsync(string json)
        {
            // Parse the JSON response.
            // The response may be wrapped in an object with a "data" property.
            JToken token = JToken.Parse(json);
            JArray dataArray = null;

            if (token.Type == JTokenType.Object && token["data"] is JArray array)
            {
                dataArray = array;
            }
            else if (token.Type == JTokenType.Array)
            {
                dataArray = (JArray)token;
            }
            else
            {
                throw new Exception("Unexpected JSON format for market data.");
            }

            // Loop through each market object.
            foreach (var marketToken in dataArray)
            {
                // The market response's "id" is used as the Market.Code.
                string marketCode = marketToken["id"]?.ToString();
                if (string.IsNullOrWhiteSpace(marketCode))
                    continue;

                // Find the corresponding Market in the database.
                var market = _context.Markets.FirstOrDefault(m => m.Code == marketCode);
                if (market == null)
                {
                    // Optionally log that this market wasn't found.
                    continue;
                }

                // Process the "sports" array.
                var sportsArray = marketToken["sports"] as JArray;
                if (sportsArray == null)
                    continue;

                foreach (var sportToken in sportsArray)
                {
                    // For each sport, process its leagues.
                    var leaguesArray = sportToken["leagues"] as JArray;
                    if (leaguesArray == null)
                        continue;

                    foreach (var leagueToken in leaguesArray)
                    {
                        string leagueCode = leagueToken["id"]?.ToString();
                        if (string.IsNullOrWhiteSpace(leagueCode))
                            continue;

                        // Find the League by matching its Code.
                        var league = _context.Leagues.FirstOrDefault(l => l.Code == leagueCode);
                        if (league == null)
                        {
                            // Optionally log missing league.
                            continue;
                        }

                        // Process the "sportsbooks" array.
                        var sportsbooksArray = leagueToken["sportsbooks"] as JArray;
                        if (sportsbooksArray == null)
                            continue;

                        foreach (var sportsbookToken in sportsbooksArray)
                        {
                            string sportsbookCode = sportsbookToken["id"]?.ToString();
                            if (string.IsNullOrWhiteSpace(sportsbookCode))
                                continue;

                            // Find the Sportsbook by its Code.
                            var sportsbook = _context.Sportsbooks.FirstOrDefault(s => s.Code == sportsbookCode);
                            if (sportsbook == null)
                            {
                                // Optionally log missing sportsbook.
                                continue;
                            }

                            // Check if this combination already exists.
                            bool exists = _context.MarketLeagueSportsbooks.Any(mls =>
                                mls.MarketId == market.Id &&
                                mls.LeagueId == league.Id &&
                                mls.SportsbookId == sportsbook.Id);

                            if (!exists)
                            {
                                var mlsEntity = new MarketLeagueSportsbook
                                {
                                    MarketId = market.Id,
                                    LeagueId = league.Id,
                                    SportsbookId = sportsbook.Id
                                };
                                _context.MarketLeagueSportsbooks.Add(mlsEntity);
                            }
                        }
                    }
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}
