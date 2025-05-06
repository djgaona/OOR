using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using OOR.Application.Interfaces;
using OOR.Application.Interfaces.OOR.Application.Interfaces;
using OOR.Domain.Entities;

namespace OOR.Infrastructure.DataSeeders
{
    public class SeedDataService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOpticOddsApiClient _apiClient;
        private readonly ILogger<SeedDataService> _logger;
        private readonly string[] _sportCodes = new[] {"tennis", "baseball" };

        public SeedDataService(IUnitOfWork unitOfWork, IOpticOddsApiClient apiClient, ILogger<SeedDataService> logger)
        {
            _unitOfWork = unitOfWork;
            _apiClient = apiClient;
            _logger = logger;
        }

        public async Task SeedFromFixturesAsync()
        {
            try
            {
                foreach (var code in _sportCodes)
                    await EnsureSportAsync(new JObject { ["id"] = code, ["name"] = code.ToUpperInvariant() });

                foreach (var sportCode in _sportCodes)
                {
                    var leaguesJson = await _apiClient.GetLeaguesForSportsRawAsync(new[] { sportCode });
                    var leaguesToken = JToken.Parse(leaguesJson)["data"] as JArray;
                    var sport = await _unitOfWork.Sports.GetByCodeAsync(sportCode);
                    if (leaguesToken == null || sport == null) continue;

                    foreach (var leagueToken in leaguesToken)
                        await EnsureLeagueAsync(leagueToken, sport);
                }

                foreach (var sportCode in _sportCodes)
                {
                    int page = 1;
                    while (true)
                    {
                        var fixturesJson = await _apiClient.GetFixturesForSportsRawAsync(new[] { sportCode }, page);
                        var rootToken = JToken.Parse(fixturesJson);
                        var fixturesToken = rootToken["data"] as JArray;

                        if (fixturesToken == null || !fixturesToken.Any())
                            break;

                        foreach (var fixture in fixturesToken)
                        {
                            var code = GetTokenValue<string>(fixture, "id");
                            if (string.IsNullOrWhiteSpace(code) || await _unitOfWork.Fixtures.ExistsAsync(code)) continue;

                            var sport = await _unitOfWork.Sports.GetByCodeAsync(sportCode);
                            if (sport == null) continue;

                            var leagueCode = GetTokenValue<string>(fixture, "league.id");
                            var league = string.IsNullOrWhiteSpace(leagueCode) ? null : await EnsureLeagueExists(leagueCode);

                            await EnsureCompetitorsAsync(fixture, sportCode);

                            var seasonTypeName = GetTokenValue<string>(fixture, "season_type");
                            var seasonYearStr = GetTokenValue<string>(fixture, "season_year");
                            var seasonWeek = GetTokenValue<int?>(fixture, "season_week");
                            var season = await EnsureSeasonAsync(seasonYearStr, seasonTypeName, seasonWeek);

                            var venue = await EnsureVenueAsync(
                                GetTokenValue<string>(fixture, "venue_name"),
                                GetTokenValue<string>(fixture, "venue_location"),
                                GetTokenValue<bool?>(fixture, "venue_neutral")
                            );

                            var statusId = await EnsureStatusAsync(fixture);

                            var entity = new Fixture
                            {
                                Code = code,
                                SportId = sport.Id,
                                LeagueId = league?.Id ?? 0,
                                SeasonId = season?.Id,
                                StartDate = GetTokenValue<DateTime>(fixture, "start_date"),
                                IsLive = GetTokenValue<bool>(fixture, "is_live"),
                                StatusId = statusId,
                                HomeTeamId = await GetTeamId(fixture["home_competitors"]),
                                AwayTeamId = await GetTeamId(fixture["away_competitors"]),
                                HomeScoreTotal = GetTokenValue<int?>(fixture, "result.scores.home.total"),
                                AwayScoreTotal = GetTokenValue<int?>(fixture, "result.scores.away.total"),
                                PeriodStatus = GetTokenValue<string>(fixture, "result.in_play_data.period"),
                                VenueId = venue?.Id
                            };

                            await _unitOfWork.Fixtures.AddAsync(entity);

                            var homeScores = GetTokenValue<Dictionary<string, int>>(fixture, "result.scores.home.periods") ?? new();
                            var awayScores = GetTokenValue<Dictionary<string, int>>(fixture, "result.scores.away.periods") ?? new();

                            foreach (var (key, value) in homeScores)
                                entity.PeriodScores.Add(new FixturePeriodScore { FixtureId = entity.Id, TeamId = entity.HomeTeamId ?? 0, PeriodId = ParsePeriod(key), Score = value });

                            foreach (var (key, value) in awayScores)
                                entity.PeriodScores.Add(new FixturePeriodScore { FixtureId = entity.Id, TeamId = entity.AwayTeamId ?? 0, PeriodId = ParsePeriod(key), Score = value });
                        }

                        page++;
                    }
                }

                await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during fixture seeding");
                throw;
            }
        }

        private async Task<Season?> EnsureSeasonAsync(string? yearStr, string? typeName, int? week)
        {
            if (!int.TryParse(yearStr, out int year) || string.IsNullOrWhiteSpace(typeName)) return null;

            var type = await _unitOfWork.SeasonTypes.GetByNameAsync(typeName) ??
                       await _unitOfWork.SeasonTypes.AddAndReturnAsync(new SeasonType { Name = typeName });

            var season = await _unitOfWork.Seasons.GetByYearAndTypeAsync(year, type.Id);
            if (season != null) return season;

            season = new Season
            {
                Year = year,
                Week = week ?? 0,
                SeasonTypeId = type.Id
            };

            await _unitOfWork.Seasons.AddAsync(season);
            await _unitOfWork.SaveAsync();
            return season;
        }

    
        private async Task<Venue?> EnsureVenueAsync(string? name, string? location, bool? neutral)
        {
            if (string.IsNullOrWhiteSpace(name) && string.IsNullOrWhiteSpace(location)) return null;

            var existing = await _unitOfWork.Venues.GetByNameAndLocationAsync(name, location);
            if (existing != null) return existing;

            var venue = new Venue
            {
                Name = name ?? "Unknown",
                Location = location ?? "Unknown",
                IsNeutral = neutral ?? false
            };

            await _unitOfWork.Venues.AddAsync(venue);
            await _unitOfWork.SaveAsync();
            return venue;
        }

        private async Task<int?> EnsureStatusAsync(JToken fixture)
        {
            var code = fixture["status"]?.ToString();
            if (string.IsNullOrWhiteSpace(code)) return null;

            var existing = await _unitOfWork.Statuses.GetByCodeAsync(code);
            if (existing != null) return existing.Id;

            var status = new Status { Code = code, Name = code };
            await _unitOfWork.Statuses.AddAsync(status);
            await _unitOfWork.SaveAsync();
            return status.Id;
        }

        private async Task EnsureCompetitorsAsync(JToken fixture, string sportCode)
        {
            if (sportCode == "tennis")
            {
                await EnsureTeamsAsync(fixture["home_competitors"]);
                await EnsureTeamsAsync(fixture["away_competitors"]);
            }
            else
            {
                await EnsureTeamsAsync(fixture["home_competitors"]);
                await EnsureTeamsAsync(fixture["away_competitors"]);
            }
        }

        private async Task EnsurePlayersAsync(JToken? competitors)
        {
            if (competitors is not JArray array) return;
            foreach (var player in array)
            {
                var id = player["id"]?.ToString();
                if (string.IsNullOrWhiteSpace(id) || await _unitOfWork.Players.ExistsAsync(id)) continue;

                var playerData = await _apiClient.GetPlayerByIdAsync(id);
                if (playerData == null) throw new($"Player not found in API: {id}");

                await EnsureTeamExists(playerData.Team.Code);
                playerData.Team = null;
                await _unitOfWork.Players.AddAsync(playerData);
                await _unitOfWork.SaveAsync();
            }
        }

        private async Task EnsureTeamsAsync(JToken? competitors)
        {
            if (competitors is not JArray array) return;
            foreach (var teamToken in array)
            {
                var id = teamToken["id"]?.ToString();
                if (string.IsNullOrWhiteSpace(id) || await _unitOfWork.Teams.ExistsAsync(id)) continue;

                var team = await _apiClient.GetTeamByIdAsync(id);
                if (team == null) throw new($"Team not found in API: {id}");

                var league = await EnsureLeagueExists(team.League.Code);
                var sport = await _unitOfWork.Sports.GetByCodeAsync(team.Sport.Code);

                team.LeagueId = league?.Id ?? 0;
                team.SportId = sport?.Id ?? 0;
                team.League = null;
                team.Sport = null;

                await _unitOfWork.Teams.AddAsync(team);
                await _unitOfWork.SaveAsync();
            }
        }

        private async Task EnsureTeamExists(string? teamId)
        {
            if (string.IsNullOrWhiteSpace(teamId) || await _unitOfWork.Teams.ExistsAsync(teamId)) return;

            var team = await _apiClient.GetTeamByIdAsync(teamId);
            if (team == null) throw new($"Referenced team '{teamId}' not found");

            var league = await EnsureLeagueExists(team.League.Code);
            var sport = await _unitOfWork.Sports.GetByCodeAsync(team.Sport.Code);

            team.LeagueId = league?.Id ?? 0;
            team.SportId = sport?.Id ?? 0;
            team.League = null;
            team.Sport = null;

            await _unitOfWork.Teams.AddAsync(team);
            await _unitOfWork.SaveAsync();
        }

        private async Task<League?> EnsureLeagueExists(string? leagueCode)
        {
            if (string.IsNullOrWhiteSpace(leagueCode)) return null;

            var existing = await _unitOfWork.Leagues.GetByCodeAsync(leagueCode);
            if (existing != null) return existing;

            var fallbackSport = await _unitOfWork.Sports.GetByCodeAsync(_sportCodes.First());
            var leagueData = new JObject { ["id"] = leagueCode, ["name"] = leagueCode };
            return await EnsureLeagueAsync(leagueData, fallbackSport);
        }

        private async Task<Sport?> EnsureSportAsync(JToken? sportToken)
        {
            var code = sportToken?["id"]?.ToString();
            if (string.IsNullOrWhiteSpace(code)) return null;

            var existing = await _unitOfWork.Sports.GetByCodeAsync(code);
            if (existing != null) return existing;

            var sport = new Sport { Code = code, Name = sportToken?["name"]?.ToString() ?? code };
            await _unitOfWork.Sports.AddAsync(sport);
            await _unitOfWork.SaveAsync();
            return sport;
        }

        private async Task<League?> EnsureLeagueAsync(JToken? leagueToken, Sport? sport)
        {
            var code = leagueToken?["id"]?.ToString();
            if (string.IsNullOrWhiteSpace(code) || sport == null) return null;

            var existing = await _unitOfWork.Leagues.GetByCodeAsync(code);
            if (existing != null) return existing;

            var region = await EnsureRegionAsync(leagueToken);
            var league = new League
            {
                Code = code,
                Name = leagueToken?["name"]?.ToString(),
                SportId = sport.Id,
                RegionId = region?.Id
            };

            await _unitOfWork.Leagues.AddAsync(league);
            await _unitOfWork.SaveAsync();
            return league;
        }

        private async Task<Region?> EnsureRegionAsync(JToken? leagueToken)
        {
            var code = leagueToken?["region_code"]?.ToString();
            var name = leagueToken?["region"]?.ToString();
            if (string.IsNullOrWhiteSpace(code)) return null;

            var existing = await _unitOfWork.Regions.GetByCodeAsync(code);
            if (existing != null) return existing;

            var region = new Region { Code = code, Name = string.IsNullOrWhiteSpace(name) ? code : name };
            await _unitOfWork.Regions.AddAsync(region);
            await _unitOfWork.SaveAsync();
            return region;
        }

        private async Task<int?> GetTeamId(JToken? competitorsToken)
        {
            var id = competitorsToken?.FirstOrDefault()?["id"]?.ToString();
            if (string.IsNullOrWhiteSpace(id)) return null;

            return (await _unitOfWork.Teams.GetByCodeAsync(id))?.Id;
        }

        private T GetTokenValue<T>(JToken token, string path, T defaultValue = default!)
        {
            try
            {
                var selectedToken = token.SelectToken(path);
                if (selectedToken == null || selectedToken.Type == JTokenType.Null)
                    return defaultValue;

                return selectedToken.ToObject<T>();
            }
            catch
            {
                return defaultValue;
            }
        }

        private int ParsePeriod(string periodKey) =>
            int.TryParse(periodKey?.Replace("period_", ""), out var num) ? num : 0;
    }
}
