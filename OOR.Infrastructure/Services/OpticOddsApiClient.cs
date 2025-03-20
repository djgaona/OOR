using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OOR.Application.Interfaces;
using OOR.Domain.Entities;

namespace OOR.Infrastructure.Services
{
    public class HttpClientOpticOddsApiClient : IOpticOddsApiClient
    {
        private readonly HttpClient _httpClient;

        public HttpClientOpticOddsApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://api.opticodds.com/api/v3/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Add("X-Api-Key", "3f4990f0-12bc-4951-b2df-2bf75136cf3d");
        }

        public async Task<string> GetLeaguesForSportsRawAsync(IEnumerable<string> sportCodes)
        {
            var query = string.Join("&", sportCodes.Select(s => $"sport={s}"));
            var requestUrl = $"leagues?{query}";
            var response = await _httpClient.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<IEnumerable<Market>?> GetMarketsForSportsAsync(IEnumerable<string> sportCodes)
        {
            // Some APIs support multiple sports in one call, but if not, you can loop sport by sport.
            // For demonstration, let's assume the API supports multiple "sport" parameters.

            var query = string.Join("&", sportCodes.Select(s => $"sport={s}"));
            var requestUrl = $"markets?{query}";

            var response = await _httpClient.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();

            var token = JToken.Parse(json);
            if (token.Type == JTokenType.Object && token["data"] is JArray dataArray)
            {
                var markets = new List<Market>();
                foreach (var item in dataArray)
                {
                    var market = new Market
                    {
                        Code = item["id"]?.ToString(),
                        Name = item["name"]?.ToString(),
                        Description = item["description"]?.ToString()
                    };

                    // Nested "sports" array
                    var sportsArray = item["sports"] as JArray;
                    if (sportsArray != null && sportsArray.Any())
                    {
                        var firstSport = sportsArray.First;
                        string sportCodeFromApi = firstSport["id"]?.ToString();
                        if (!string.IsNullOrWhiteSpace(sportCodeFromApi))
                        {
                            // We'll store the SportCode in the Market's [NotMapped] property
                            market.SportCode = sportCodeFromApi;
                        }
                    }
                    markets.Add(market);
                }
                return markets;
            }
            else
            {
                // Fallback
                return JsonConvert.DeserializeObject<IEnumerable<Market>>(json);
            }
        }

        public async Task<IEnumerable<MarketLeagueSportsbookDto>> GetMarketLeagueSportsbookRelationshipsAsync(IEnumerable<string> sportCodes)
        {
            var query = string.Join("&", sportCodes.Select(s => $"sport={s}"));
            var requestUrl = $"markets?{query}";
            var response = await _httpClient.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();

            var token = JToken.Parse(json);
            var results = new List<MarketLeagueSportsbookDto>();

            if (token.Type == JTokenType.Object && token["data"] is JArray marketsArray)
            {
                foreach (var marketToken in marketsArray)
                {
                    var marketCode = marketToken["id"]?.ToString();
                    if (string.IsNullOrWhiteSpace(marketCode))
                        continue;

                    var sportsArray = marketToken["sports"] as JArray;
                    if (sportsArray == null)
                        continue;

                    foreach (var sportToken in sportsArray)
                    {
                        var leaguesArray = sportToken["leagues"] as JArray;
                        if (leaguesArray == null)
                            continue;

                        foreach (var leagueToken in leaguesArray)
                        {
                            var leagueCode = leagueToken["id"]?.ToString();
                            if (string.IsNullOrWhiteSpace(leagueCode))
                                continue;

                            var sportsbooksArray = leagueToken["sportsbooks"] as JArray;
                            if (sportsbooksArray == null)
                                continue;

                            foreach (var sportsbookToken in sportsbooksArray)
                            {
                                var sportsbookCode = sportsbookToken["id"]?.ToString();
                                if (string.IsNullOrWhiteSpace(sportsbookCode))
                                    continue;

                                results.Add(new MarketLeagueSportsbookDto
                                {
                                    MarketCode = marketCode,
                                    LeagueCode = leagueCode,
                                    SportsbookCode = sportsbookCode
                                });
                            }
                        }
                    }
                }
            }
            return results;
        }

        public async Task<IEnumerable<Sportsbook>?> GetSportsbooksAsync()
        {
            var response = await _httpClient.GetAsync("sportsbooks");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();

            var token = JToken.Parse(json);
            if (token.Type == JTokenType.Object && token["data"] is JArray dataArray)
            {
                var sportsbooks = new List<Sportsbook>();
                foreach (var item in dataArray)
                {
                    var sb = new Sportsbook
                    {
                        Code = item["id"]?.ToString(),
                        Name = item["name"]?.ToString(),
                        Active = item["is_active"]?.ToObject<bool?>()
                        // etc.
                    };
                    sportsbooks.Add(sb);
                }
                return sportsbooks;
            }
            else
            {
                return JsonConvert.DeserializeObject<IEnumerable<Sportsbook>>(json);
            }
        }
    }
}
