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
            _httpClient.DefaultRequestHeaders.Add("X-Api-Key", "1183340c-d160-4f77-9447-90416c7ff363");
        }

        public async Task<string> GetLeaguesForSportsRawAsync(IEnumerable<string> sportCodes)
        {
            var query = string.Join("&", sportCodes.Select(s => $"sport={s}"));
            var requestUrl = $"leagues?{query}";
            var response = await _httpClient.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetTeamsForSportsRawAsync(IEnumerable<string> sportCodes)
        {
            var query = string.Join("&", sportCodes.Select(s => $"sport={s}"));
            var requestUrl = $"teams?{query}";
            var response = await _httpClient.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetPlayersForSportsRawAsync(IEnumerable<string> sportCodes)
        {
            var query = string.Join("&", sportCodes.Select(s => $"sport={s}"));
            var requestUrl = $"players?{query}";
            var response = await _httpClient.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetFixturesForSportsRawAsync(IEnumerable<string> sportCodes, int page)
        {
            var query = string.Join("&", sportCodes.Select(s => $"sport={s}"));
            var requestUrl = $"fixtures?{query}&page={page}";
            var response = await _httpClient.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetTournamentsForSportsRawAsync(IEnumerable<string> sportCodes)
        {
            var query = string.Join("&", sportCodes.Select(s => $"sport={s}"));
            var requestUrl = $"tournaments?{query}";
            var response = await _httpClient.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetConferencesForSportsRawAsync(IEnumerable<string> sportCodes)
        {
            var query = string.Join("&", sportCodes.Select(s => $"sport={s}"));
            var requestUrl = $"conferences?{query}";
            var response = await _httpClient.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetDivisionsForSportsRawAsync(IEnumerable<string> sportCodes)
        {
            var query = string.Join("&", sportCodes.Select(s => $"sport={s}"));
            var requestUrl = $"divisions?{query}";
            var response = await _httpClient.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetTournamentsForLeagueRawAsync(string leagueCode)
        {
            var response = await _httpClient.GetAsync($"tournaments?league={leagueCode}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetConferencesForLeagueRawAsync(string leagueCode)
        {
            var response = await _httpClient.GetAsync($"conferences?league={leagueCode}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetDivisionsForLeagueRawAsync(string leagueCode)
        {
            var response = await _httpClient.GetAsync($"divisions?league={leagueCode}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<IEnumerable<Market>?> GetMarketsForSportsAsync(IEnumerable<string> sportCodes)
        {
            var allMarkets = new List<Market>();

            foreach (var sportCode in sportCodes)
            {
                var requestUrl = $"markets?sport={sportCode}";
                var response = await _httpClient.GetAsync(requestUrl);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();

                var token = JToken.Parse(json);
                if (token.Type == JTokenType.Object && token["data"] is JArray dataArray)
                {
                    foreach (var item in dataArray)
                    {
                        var market = new Market
                        {
                            Code = item["id"]?.ToString(),
                            Name = item["name"]?.ToString(),
                            Description = item["description"]?.ToString(),
                            SportCode = sportCode
                        };
                        allMarkets.Add(market);
                    }
                }
            }

            return allMarkets;
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

        public async Task<string> GetTournamentsForSportRawAsync(string sportCode)
        {
            var url = $"https://api.opticodds.com/api/v3/tournaments?sport={sportCode}";
            var response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetTeamsForSportRawAsync(string sportCode, int page)
        {
            var url = $"https://api.opticodds.com/api/v3/teams?sport={sportCode}&page={page}";
            var response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetPlayersForSportRawAsync(string sportCode, int page)
        {
            var url = $"https://api.opticodds.com/api/v3/players?sport={sportCode}&page={page}";
            var response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<Player?> GetPlayerByIdAsync(string playerId)
        {
            var url = $"players?id={playerId}";
            var response = await _httpClient.GetStringAsync(url);
            var token = JToken.Parse(response);
            var data = token["data"]?.FirstOrDefault();
            if (data == null) return null;

            return new Player
            {
                Code = data["id"]?.ToString(),
                Name = data["name"]?.ToString(),
                Position = data["position"]?.ToString(),
                Number = data["number"]?.ToObject<int?>(),
                Team = data["team"]?["id"] != null ? new Team { Code = data["team"]?["id"]?.ToString() } : null,
                TeamId = null, // You may resolve this with lookup if necessary
                StatusId = null // Not available in API
            };
        }

        public async Task<Team?> GetTeamByIdAsync(string teamId)
        {
            var url = $"teams?id={teamId}";
            var response = await _httpClient.GetStringAsync(url);
            var token = JToken.Parse(response);
            var data = token["data"]?.FirstOrDefault();
            if (data == null) return null;

            return new Team
            {
                Code = data["id"]?.ToString(),
                Name = data["name"]?.ToString(),
                Abbreviation = data["abbreviation"]?.ToString(),
                LogoUrl = data["logo"]?.ToString(),
                Sport = data["sport"]?["id"] != null ? new Sport { Code = data["sport"]?["id"]?.ToString() } : null,
                League = data["league"]?["id"] != null ? new League { Code = data["league"]?["id"]?.ToString() } : null,
 };
        }
    }
}
