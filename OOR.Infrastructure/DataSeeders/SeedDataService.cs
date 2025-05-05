using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OOR.Application.Interfaces;
using OOR.Domain.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OOR.Application.Interfaces.OOR.Application.Interfaces;

namespace OOR.Infrastructure.DataSeeders
{
    public class SeedDataService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOpticOddsApiClient _apiClient;

        public SeedDataService(IUnitOfWork unitOfWork, IOpticOddsApiClient apiClient)
        {
            _unitOfWork = unitOfWork;
            _apiClient = apiClient;
        }

        public async Task SeedAllAsync()
        {
            var sportCodes = new[] { "soccer", "tennis", "baseball" };

            await SeedLeaguesAsync(sportCodes);
            await SeedSportsbooksAsync();
            foreach (var sportCode in sportCodes)
            {
                try
                {
                    await SeedMarketsAsync(sportCode);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching markets for sport '{sportCode}': {ex.Message}");
                }
            }

            await _unitOfWork.SaveAsync();
        }

        public async Task SeedLeaguesAsync(IEnumerable<string> sportCodes)
        {
            var json = await _apiClient.GetLeaguesForSportsRawAsync(sportCodes);
            var token = JToken.Parse(json);

            if (token.Type == JTokenType.Object && token["data"] is JArray dataArray)
            {
                foreach (var league in dataArray)
                {
                    var code = league["id"]?.ToString();
                    if (!string.IsNullOrWhiteSpace(code) && !await _unitOfWork.Leagues.ExistsAsync(code))
                    {
                        var sportCode = league["sport_id"]?.ToString();
                        var sport = await _unitOfWork.Sports.GetByCodeAsync(sportCode);

                        await _unitOfWork.Leagues.AddAsync(new League
                        {
                            Code = code,
                            Name = league["name"]?.ToString(),
                            Sport = sport
                        });
                    }
                }
            }
        }

        public async Task SeedSportsbooksAsync()
        {
            var sportsbooks = await _apiClient.GetSportsbooksAsync();
            if (sportsbooks == null) return;

            foreach (var sb in sportsbooks)
            {
                if (!await _unitOfWork.Sportsbooks.ExistsAsync(sb.Code))
                {
                    await _unitOfWork.Sportsbooks.AddAsync(sb);
                }
            }
        }

        public async Task SeedMarketsAsync(string sportCode)
        {
            var markets = await _apiClient.GetMarketsForSportsAsync(new[] { sportCode });
            if (markets == null) return;

            var sport = await _unitOfWork.Sports.GetByCodeAsync(sportCode);
            if (sport == null) return;

            var insertedCodes = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var market in markets)
            {
                var rawCode = market.Code?.Trim().ToLowerInvariant();
                if (string.IsNullOrWhiteSpace(rawCode)) continue;

                if (insertedCodes.Contains(rawCode) || await _unitOfWork.Markets.ExistsAsync(rawCode))
                    continue;

                insertedCodes.Add(rawCode);
                
      
                market.SportId = sport.Id;
                market.Sport = sport;

                await _unitOfWork.Markets.AddAsync(market);
                await _unitOfWork.SaveAsync();
            }
        }
    }
}
