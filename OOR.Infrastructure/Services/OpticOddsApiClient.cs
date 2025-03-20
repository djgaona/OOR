using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OOR.Application.Interfaces;
using OOR.Domain.Entities;

namespace OOR.Infrastructure.Services
{
    public class HttpClientOpticOddsApiClient : IOpticOddsApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public HttpClientOpticOddsApiClient(HttpClient httpClient, string apiKey)
        {
            _httpClient = httpClient;
            _apiKey = apiKey;
            // Set base address if desired.
            _httpClient.BaseAddress = new Uri("https://api.opticodds.com/api/v3/");
            // Set default request headers.
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Add("X-Api-Key", _apiKey);
        }

        public async Task<IEnumerable<League>?> GetLeaguesForSportsAsync(IEnumerable<string> sportCodes)
        {
            // Build query string like "sport=soccer&sport=tennis"
            var query = string.Join("&", sportCodes.Select(s => $"sport={s}"));
            var requestUrl = $"leagues?{query}";
            var response = await _httpClient.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<League>>(json);
        }

        public async Task<IEnumerable<Sportsbook>?> GetSportsbooksAsync()
        {
            var response = await _httpClient.GetAsync("sportsbooks");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Sportsbook>>(json);
        }

        public async Task<IEnumerable<Market>?> GetMarketsForSportsAsync(IEnumerable<string> sportCodes)
        {
            var query = string.Join("&", sportCodes.Select(s => $"sport={s}"));
            var requestUrl = $"markets?{query}";
            var response = await _httpClient.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Market>>(json);
        }
    }
}
