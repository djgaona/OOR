using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace OOR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Broadcasts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Network = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Broadcasts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LineTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SeasonTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeasonTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sportsbooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Website = table.Column<string>(type: "text", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sportsbooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    IsNeutral = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeatherConditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Temperature = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherConditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SeasonTypeId = table.Column<int>(type: "integer", nullable: true),
                    Year = table.Column<int>(type: "integer", nullable: true),
                    Week = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seasons_SeasonTypes_SeasonTypeId",
                        column: x => x.SeasonTypeId,
                        principalTable: "SeasonTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Leagues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    SportId = table.Column<int>(type: "integer", nullable: true),
                    RegionId = table.Column<int>(type: "integer", nullable: true),
                    Level = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leagues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leagues_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Leagues_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Markets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    SportId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Markets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Markets_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Periods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    SportId = table.Column<int>(type: "integer", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Periods_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TournamentStages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    SportId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentStages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TournamentStages_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Conferences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    LeagueId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conferences_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    SportId = table.Column<int>(type: "integer", nullable: true),
                    LeagueId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tournaments_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tournaments_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Divisions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    LeagueId = table.Column<int>(type: "integer", nullable: true),
                    ConferenceId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Divisions_Conferences_ConferenceId",
                        column: x => x.ConferenceId,
                        principalTable: "Conferences",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Divisions_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Futures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    TournamentId = table.Column<int>(type: "integer", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    StatusId = table.Column<int>(type: "integer", nullable: true),
                    IsLive = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Futures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Futures_Statuss_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuss",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Futures_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SportId = table.Column<int>(type: "integer", nullable: false),
                    LeagueId = table.Column<int>(type: "integer", nullable: false),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    CityId = table.Column<int>(type: "integer", nullable: true),
                    DivisionId = table.Column<int>(type: "integer", nullable: true),
                    Abbreviation = table.Column<string>(type: "text", nullable: true),
                    LogoUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Teams_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teams_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fixtures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    SportId = table.Column<int>(type: "integer", nullable: false),
                    LeagueId = table.Column<int>(type: "integer", nullable: false),
                    TournamentId = table.Column<int>(type: "integer", nullable: true),
                    SeasonId = table.Column<int>(type: "integer", nullable: true),
                    StatusId = table.Column<int>(type: "integer", nullable: true),
                    VenueId = table.Column<int>(type: "integer", nullable: true),
                    IsLive = table.Column<bool>(type: "boolean", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    HomeTeamId = table.Column<int>(type: "integer", nullable: true),
                    AwayTeamId = table.Column<int>(type: "integer", nullable: true),
                    HomeScoreTotal = table.Column<int>(type: "integer", nullable: true),
                    AwayScoreTotal = table.Column<int>(type: "integer", nullable: true),
                    PeriodStatus = table.Column<string>(type: "text", nullable: true),
                    BroadcastId = table.Column<int>(type: "integer", nullable: true),
                    TournamentStageId = table.Column<int>(type: "integer", nullable: true),
                    WeatherConditionId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fixtures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fixtures_Broadcasts_BroadcastId",
                        column: x => x.BroadcastId,
                        principalTable: "Broadcasts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Fixtures_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fixtures_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Fixtures_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fixtures_Statuss_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuss",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Fixtures_Teams_AwayTeamId",
                        column: x => x.AwayTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Fixtures_Teams_HomeTeamId",
                        column: x => x.HomeTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Fixtures_TournamentStages_TournamentStageId",
                        column: x => x.TournamentStageId,
                        principalTable: "TournamentStages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Fixtures_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Fixtures_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Fixtures_WeatherConditions_WeatherConditionId",
                        column: x => x.WeatherConditionId,
                        principalTable: "WeatherConditions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    TeamId = table.Column<int>(type: "integer", nullable: true),
                    Position = table.Column<string>(type: "text", nullable: true),
                    Number = table.Column<int>(type: "integer", nullable: true),
                    StatusId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Statuss_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuss",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FixturePeriodScores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FixtureId = table.Column<int>(type: "integer", nullable: false),
                    PeriodId = table.Column<int>(type: "integer", nullable: false),
                    TeamId = table.Column<int>(type: "integer", nullable: false),
                    Score = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixturePeriodScores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FixturePeriodScores_Fixtures_FixtureId",
                        column: x => x.FixtureId,
                        principalTable: "Fixtures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FixturePeriodScores_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    FixtureId = table.Column<int>(type: "integer", nullable: true),
                    HomeScore = table.Column<int>(type: "integer", nullable: true),
                    AwayScore = table.Column<int>(type: "integer", nullable: true),
                    StatusId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Results_Fixtures_FixtureId",
                        column: x => x.FixtureId,
                        principalTable: "Fixtures",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Results_Statuss_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuss",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BaseballBattingStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FixtureId = table.Column<int>(type: "integer", nullable: true),
                    PlayerId = table.Column<int>(type: "integer", nullable: true),
                    Hits = table.Column<int>(type: "integer", nullable: true),
                    Runs = table.Column<int>(type: "integer", nullable: true),
                    Rbi = table.Column<int>(type: "integer", nullable: true),
                    AtBats = table.Column<int>(type: "integer", nullable: true),
                    Doubles = table.Column<int>(type: "integer", nullable: true),
                    Triples = table.Column<int>(type: "integer", nullable: true),
                    HomeRuns = table.Column<int>(type: "integer", nullable: true),
                    TotalBases = table.Column<int>(type: "integer", nullable: true),
                    StolenBases = table.Column<int>(type: "integer", nullable: true),
                    CaughtStealing = table.Column<int>(type: "integer", nullable: true),
                    BattingWalks = table.Column<int>(type: "integer", nullable: true),
                    BattingStrikeouts = table.Column<int>(type: "integer", nullable: true),
                    BattingHitByPitch = table.Column<int>(type: "integer", nullable: true),
                    BattingSacrificeHits = table.Column<int>(type: "integer", nullable: true),
                    BattingSacrificeFlies = table.Column<int>(type: "integer", nullable: true),
                    BattingIntentionalWalks = table.Column<int>(type: "integer", nullable: true),
                    BattingPlateAppearances = table.Column<int>(type: "integer", nullable: true),
                    BattingGroundIntoDoublePlay = table.Column<int>(type: "integer", nullable: true),
                    BattingPickedOff = table.Column<int>(type: "integer", nullable: true),
                    Starter = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseballBattingStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseballBattingStats_Fixtures_FixtureId",
                        column: x => x.FixtureId,
                        principalTable: "Fixtures",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BaseballBattingStats_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BaseballPitchingStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FixtureId = table.Column<int>(type: "integer", nullable: true),
                    PlayerId = table.Column<int>(type: "integer", nullable: true),
                    InningsPitched = table.Column<decimal>(type: "numeric", nullable: true),
                    Strikeouts = table.Column<int>(type: "integer", nullable: true),
                    EarnedRuns = table.Column<int>(type: "integer", nullable: true),
                    PitchCount = table.Column<int>(type: "integer", nullable: true),
                    HitsAllowed = table.Column<int>(type: "integer", nullable: true),
                    RunsAllowed = table.Column<int>(type: "integer", nullable: true),
                    SavePitcher = table.Column<bool>(type: "boolean", nullable: true),
                    BattersFaced = table.Column<int>(type: "integer", nullable: true),
                    CompleteGame = table.Column<bool>(type: "boolean", nullable: true),
                    WinningPitcher = table.Column<bool>(type: "boolean", nullable: true),
                    LosingPitcher = table.Column<bool>(type: "boolean", nullable: true),
                    PitchingBalks = table.Column<int>(type: "integer", nullable: true),
                    PitchingBalls = table.Column<int>(type: "integer", nullable: true),
                    PitchingStrikes = table.Column<int>(type: "integer", nullable: true),
                    PitchingWalks = table.Column<int>(type: "integer", nullable: true),
                    DoublesAllowed = table.Column<int>(type: "integer", nullable: true),
                    TriplesAllowed = table.Column<int>(type: "integer", nullable: true),
                    HomeRunsAllowed = table.Column<int>(type: "integer", nullable: true),
                    HoldingPitcher = table.Column<bool>(type: "boolean", nullable: true),
                    BlownSavePitcher = table.Column<bool>(type: "boolean", nullable: true),
                    PitchingShutout = table.Column<bool>(type: "boolean", nullable: true),
                    PitchingNoHitter = table.Column<bool>(type: "boolean", nullable: true),
                    PitchingPerfectGame = table.Column<bool>(type: "boolean", nullable: true),
                    PitchingHitBatsmen = table.Column<int>(type: "integer", nullable: true),
                    StolenBasesAllowed = table.Column<int>(type: "integer", nullable: true),
                    PitchingWildPitches = table.Column<int>(type: "integer", nullable: true),
                    PitchingPickoffs = table.Column<int>(type: "integer", nullable: true),
                    SacrificeHitsAllowed = table.Column<int>(type: "integer", nullable: true),
                    SacrificeFliesAllowed = table.Column<int>(type: "integer", nullable: true),
                    BattingFlyballsAllowed = table.Column<int>(type: "integer", nullable: true),
                    BattingGroundballsAllowed = table.Column<int>(type: "integer", nullable: true),
                    GroundIntoDoublePlayAllowed = table.Column<int>(type: "integer", nullable: true),
                    PitchingIntentionalWalks = table.Column<int>(type: "integer", nullable: true),
                    Starter = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseballPitchingStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseballPitchingStats_Fixtures_FixtureId",
                        column: x => x.FixtureId,
                        principalTable: "Fixtures",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BaseballPitchingStats_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Injurys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PlayerId = table.Column<int>(type: "integer", nullable: true),
                    InjuryType = table.Column<string>(type: "text", nullable: true),
                    StatusId = table.Column<int>(type: "integer", nullable: true),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    ExpectedReturnDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Injurys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Injurys_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Injurys_Statuss_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuss",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Selections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MarketId = table.Column<int>(type: "integer", nullable: true),
                    LineTypeId = table.Column<int>(type: "integer", nullable: true),
                    TeamId = table.Column<int>(type: "integer", nullable: true),
                    PlayerId = table.Column<int>(type: "integer", nullable: true),
                    Points = table.Column<decimal>(type: "numeric", nullable: true),
                    IsMain = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Selections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Selections_LineTypes_LineTypeId",
                        column: x => x.LineTypeId,
                        principalTable: "LineTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Selections_Markets_MarketId",
                        column: x => x.MarketId,
                        principalTable: "Markets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Selections_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Selections_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SoccerPlayerStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FixtureId = table.Column<int>(type: "integer", nullable: true),
                    PlayerId = table.Column<int>(type: "integer", nullable: true),
                    FormationPlace = table.Column<int>(type: "integer", nullable: true),
                    MinutesPlayed = table.Column<int>(type: "integer", nullable: true),
                    Touches = table.Column<int>(type: "integer", nullable: true),
                    DuelsWon = table.Column<int>(type: "integer", nullable: true),
                    DuelsLost = table.Column<int>(type: "integer", nullable: true),
                    Fouls = table.Column<int>(type: "integer", nullable: true),
                    FoulsWon = table.Column<int>(type: "integer", nullable: true),
                    ForwardPasses = table.Column<int>(type: "integer", nullable: true),
                    TotalPasses = table.Column<int>(type: "integer", nullable: true),
                    SuccessfulPasses = table.Column<int>(type: "integer", nullable: true),
                    UnsuccessfulPasses = table.Column<int>(type: "integer", nullable: true),
                    BallRecoveries = table.Column<int>(type: "integer", nullable: true),
                    Interceptions = table.Column<int>(type: "integer", nullable: true),
                    Clearances = table.Column<int>(type: "integer", nullable: true),
                    BlockedShots = table.Column<int>(type: "integer", nullable: true),
                    ShotsOnTarget = table.Column<int>(type: "integer", nullable: true),
                    ShotsOffTarget = table.Column<int>(type: "integer", nullable: true),
                    Goals = table.Column<int>(type: "integer", nullable: true),
                    Assists = table.Column<int>(type: "integer", nullable: true),
                    YellowCards = table.Column<int>(type: "integer", nullable: true),
                    RedCards = table.Column<int>(type: "integer", nullable: true),
                    CornersTaken = table.Column<int>(type: "integer", nullable: true),
                    CrossesTotal = table.Column<int>(type: "integer", nullable: true),
                    CrossesSuccessful = table.Column<int>(type: "integer", nullable: true),
                    TacklesTotal = table.Column<int>(type: "integer", nullable: true),
                    TacklesSuccessful = table.Column<int>(type: "integer", nullable: true),
                    TimesTackled = table.Column<int>(type: "integer", nullable: true),
                    TouchesInOppositionBox = table.Column<int>(type: "integer", nullable: true),
                    AerialDuelsWon = table.Column<int>(type: "integer", nullable: true),
                    AerialDuelsLost = table.Column<int>(type: "integer", nullable: true),
                    Starter = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoccerPlayerStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoccerPlayerStats_Fixtures_FixtureId",
                        column: x => x.FixtureId,
                        principalTable: "Fixtures",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SoccerPlayerStats_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TennisPlayerStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FixtureId = table.Column<int>(type: "integer", nullable: true),
                    PlayerId = table.Column<int>(type: "integer", nullable: true),
                    Aces = table.Column<int>(type: "integer", nullable: true),
                    DoubleFaults = table.Column<int>(type: "integer", nullable: true),
                    FirstServesIn = table.Column<int>(type: "integer", nullable: true),
                    FirstServesTotal = table.Column<int>(type: "integer", nullable: true),
                    SecondServesIn = table.Column<int>(type: "integer", nullable: true),
                    SecondServesTotal = table.Column<int>(type: "integer", nullable: true),
                    FirstServePointsWon = table.Column<int>(type: "integer", nullable: true),
                    FirstServePointsTotal = table.Column<int>(type: "integer", nullable: true),
                    SecondServePointsWon = table.Column<int>(type: "integer", nullable: true),
                    SecondServePointsTotal = table.Column<int>(type: "integer", nullable: true),
                    FirstServeReturnPointsWon = table.Column<int>(type: "integer", nullable: true),
                    FirstServeReturnPointsTotal = table.Column<int>(type: "integer", nullable: true),
                    SecondServeReturnPointsWon = table.Column<int>(type: "integer", nullable: true),
                    SecondServeReturnPointsTotal = table.Column<int>(type: "integer", nullable: true),
                    BreakPointsSaved = table.Column<int>(type: "integer", nullable: true),
                    BreakPointsTotal = table.Column<int>(type: "integer", nullable: true),
                    BreakPointsConverted = table.Column<int>(type: "integer", nullable: true),
                    ServiceGamesWon = table.Column<int>(type: "integer", nullable: true),
                    ServiceGamesTotal = table.Column<int>(type: "integer", nullable: true),
                    ReturnPointsWon = table.Column<int>(type: "integer", nullable: true),
                    GamesWon = table.Column<int>(type: "integer", nullable: true),
                    TiebreaksWon = table.Column<int>(type: "integer", nullable: true),
                    MaxGamesInRow = table.Column<int>(type: "integer", nullable: true),
                    MaxPointsInRow = table.Column<int>(type: "integer", nullable: true),
                    PointsTotal = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TennisPlayerStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TennisPlayerStats_Fixtures_FixtureId",
                        column: x => x.FixtureId,
                        principalTable: "Fixtures",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TennisPlayerStats_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ResultsJsons",
                columns: table => new
                {
                    ResultsId = table.Column<int>(type: "integer", nullable: false),
                    Json = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultsJsons", x => x.ResultsId);
                    table.ForeignKey(
                        name: "FK_ResultsJsons_Results_ResultsId",
                        column: x => x.ResultsId,
                        principalTable: "Results",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FuturesOdds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    FutureId = table.Column<int>(type: "integer", nullable: true),
                    TeamId = table.Column<int>(type: "integer", nullable: true),
                    SportsbookId = table.Column<int>(type: "integer", nullable: true),
                    Timestamp = table.Column<decimal>(type: "numeric", nullable: true),
                    IsLive = table.Column<bool>(type: "boolean", nullable: true),
                    SelectionId = table.Column<int>(type: "integer", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: true),
                    MinLimit = table.Column<decimal>(type: "numeric", nullable: true),
                    MaxLimit = table.Column<decimal>(type: "numeric", nullable: true),
                    IsMain = table.Column<bool>(type: "boolean", nullable: true),
                    GroupKey = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuturesOdds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FuturesOdds_Futures_FutureId",
                        column: x => x.FutureId,
                        principalTable: "Futures",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FuturesOdds_Selections_SelectionId",
                        column: x => x.SelectionId,
                        principalTable: "Selections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FuturesOdds_Sportsbooks_SportsbookId",
                        column: x => x.SportsbookId,
                        principalTable: "Sportsbooks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FuturesOdds_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GraderOdds",
                columns: table => new
                {
                    FixtureId = table.Column<int>(type: "integer", nullable: false),
                    SelectionId = table.Column<int>(type: "integer", nullable: false),
                    AwayTeamDisplay = table.Column<string>(type: "text", nullable: true),
                    HomeTeamDisplay = table.Column<string>(type: "text", nullable: true),
                    StatusId = table.Column<int>(type: "integer", nullable: true),
                    AwayScore = table.Column<int>(type: "integer", nullable: true),
                    HomeScore = table.Column<int>(type: "integer", nullable: true),
                    PlayerScore = table.Column<int>(type: "integer", nullable: true),
                    Result = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GraderOdds", x => new { x.FixtureId, x.SelectionId });
                    table.ForeignKey(
                        name: "FK_GraderOdds_Fixtures_FixtureId",
                        column: x => x.FixtureId,
                        principalTable: "Fixtures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GraderOdds_Selections_SelectionId",
                        column: x => x.SelectionId,
                        principalTable: "Selections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GraderOdds_Statuss_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuss",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HistoricalOdds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    FixtureId = table.Column<int>(type: "integer", nullable: true),
                    SportsbookId = table.Column<int>(type: "integer", nullable: true),
                    Timestamp = table.Column<decimal>(type: "numeric", nullable: true),
                    IsLive = table.Column<bool>(type: "boolean", nullable: true),
                    SelectionId = table.Column<int>(type: "integer", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: true),
                    MinLimit = table.Column<decimal>(type: "numeric", nullable: true),
                    MaxLimit = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricalOdds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricalOdds_Fixtures_FixtureId",
                        column: x => x.FixtureId,
                        principalTable: "Fixtures",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HistoricalOdds_Selections_SelectionId",
                        column: x => x.SelectionId,
                        principalTable: "Selections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HistoricalOdds_Sportsbooks_SportsbookId",
                        column: x => x.SportsbookId,
                        principalTable: "Sportsbooks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Odds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    FixtureId = table.Column<int>(type: "integer", nullable: true),
                    SportsbookId = table.Column<int>(type: "integer", nullable: true),
                    Timestamp = table.Column<decimal>(type: "numeric", nullable: true),
                    IsLive = table.Column<bool>(type: "boolean", nullable: true),
                    SelectionId = table.Column<int>(type: "integer", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: true),
                    MinLimit = table.Column<decimal>(type: "numeric", nullable: true),
                    MaxLimit = table.Column<decimal>(type: "numeric", nullable: true),
                    IsMain = table.Column<bool>(type: "boolean", nullable: true),
                    Locked = table.Column<bool>(type: "boolean", nullable: true),
                    GroupKey = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Odds_Fixtures_FixtureId",
                        column: x => x.FixtureId,
                        principalTable: "Fixtures",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Odds_Selections_SelectionId",
                        column: x => x.SelectionId,
                        principalTable: "Selections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Odds_Sportsbooks_SportsbookId",
                        column: x => x.SportsbookId,
                        principalTable: "Sportsbooks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OddsJsons",
                columns: table => new
                {
                    OddsId = table.Column<int>(type: "integer", nullable: false),
                    Json = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OddsJsons", x => x.OddsId);
                    table.ForeignKey(
                        name: "FK_OddsJsons_Odds_OddsId",
                        column: x => x.OddsId,
                        principalTable: "Odds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseballBattingStats_FixtureId",
                table: "BaseballBattingStats",
                column: "FixtureId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseballBattingStats_PlayerId",
                table: "BaseballBattingStats",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseballPitchingStats_FixtureId",
                table: "BaseballPitchingStats",
                column: "FixtureId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseballPitchingStats_PlayerId",
                table: "BaseballPitchingStats",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Broadcasts_Code",
                table: "Broadcasts",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Conferences_Code",
                table: "Conferences",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Conferences_LeagueId",
                table: "Conferences",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_Code",
                table: "Divisions",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_ConferenceId",
                table: "Divisions",
                column: "ConferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_LeagueId",
                table: "Divisions",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_FixturePeriodScores_FixtureId",
                table: "FixturePeriodScores",
                column: "FixtureId");

            migrationBuilder.CreateIndex(
                name: "IX_FixturePeriodScores_TeamId",
                table: "FixturePeriodScores",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Fixtures_AwayTeamId",
                table: "Fixtures",
                column: "AwayTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Fixtures_BroadcastId",
                table: "Fixtures",
                column: "BroadcastId");

            migrationBuilder.CreateIndex(
                name: "IX_Fixtures_Code",
                table: "Fixtures",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fixtures_HomeTeamId",
                table: "Fixtures",
                column: "HomeTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Fixtures_LeagueId",
                table: "Fixtures",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_Fixtures_SeasonId",
                table: "Fixtures",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Fixtures_SportId",
                table: "Fixtures",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_Fixtures_StatusId",
                table: "Fixtures",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Fixtures_TournamentId",
                table: "Fixtures",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Fixtures_TournamentStageId",
                table: "Fixtures",
                column: "TournamentStageId");

            migrationBuilder.CreateIndex(
                name: "IX_Fixtures_VenueId",
                table: "Fixtures",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_Fixtures_WeatherConditionId",
                table: "Fixtures",
                column: "WeatherConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Futures_Code",
                table: "Futures",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Futures_StatusId",
                table: "Futures",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Futures_TournamentId",
                table: "Futures",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_FuturesOdds_Code",
                table: "FuturesOdds",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FuturesOdds_FutureId",
                table: "FuturesOdds",
                column: "FutureId");

            migrationBuilder.CreateIndex(
                name: "IX_FuturesOdds_SelectionId",
                table: "FuturesOdds",
                column: "SelectionId");

            migrationBuilder.CreateIndex(
                name: "IX_FuturesOdds_SportsbookId",
                table: "FuturesOdds",
                column: "SportsbookId");

            migrationBuilder.CreateIndex(
                name: "IX_FuturesOdds_TeamId",
                table: "FuturesOdds",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_GraderOdds_SelectionId",
                table: "GraderOdds",
                column: "SelectionId");

            migrationBuilder.CreateIndex(
                name: "IX_GraderOdds_StatusId",
                table: "GraderOdds",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalOdds_Code",
                table: "HistoricalOdds",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalOdds_FixtureId",
                table: "HistoricalOdds",
                column: "FixtureId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalOdds_SelectionId",
                table: "HistoricalOdds",
                column: "SelectionId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalOdds_SportsbookId",
                table: "HistoricalOdds",
                column: "SportsbookId");

            migrationBuilder.CreateIndex(
                name: "IX_Injurys_Code",
                table: "Injurys",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Injurys_PlayerId",
                table: "Injurys",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Injurys_StatusId",
                table: "Injurys",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Leagues_Code",
                table: "Leagues",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Leagues_RegionId",
                table: "Leagues",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Leagues_SportId",
                table: "Leagues",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_Markets_Code",
                table: "Markets",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Markets_SportId",
                table: "Markets",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_Odds_Code",
                table: "Odds",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Odds_FixtureId",
                table: "Odds",
                column: "FixtureId");

            migrationBuilder.CreateIndex(
                name: "IX_Odds_SelectionId",
                table: "Odds",
                column: "SelectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Odds_SportsbookId",
                table: "Odds",
                column: "SportsbookId");

            migrationBuilder.CreateIndex(
                name: "IX_Periods_Code",
                table: "Periods",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Periods_SportId",
                table: "Periods",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_Code",
                table: "Players",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_StatusId",
                table: "Players",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_Code",
                table: "Regions",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Results_Code",
                table: "Results",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Results_FixtureId",
                table: "Results",
                column: "FixtureId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_StatusId",
                table: "Results",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_SeasonTypeId",
                table: "Seasons",
                column: "SeasonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Selections_LineTypeId",
                table: "Selections",
                column: "LineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Selections_MarketId",
                table: "Selections",
                column: "MarketId");

            migrationBuilder.CreateIndex(
                name: "IX_Selections_PlayerId",
                table: "Selections",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Selections_TeamId",
                table: "Selections",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_SoccerPlayerStats_FixtureId",
                table: "SoccerPlayerStats",
                column: "FixtureId");

            migrationBuilder.CreateIndex(
                name: "IX_SoccerPlayerStats_PlayerId",
                table: "SoccerPlayerStats",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sports_Code",
                table: "Sports",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sportsbooks_Code",
                table: "Sportsbooks",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Statuss_Code",
                table: "Statuss",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Code",
                table: "Teams",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_DivisionId",
                table: "Teams",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_LeagueId",
                table: "Teams",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_SportId",
                table: "Teams",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_TennisPlayerStats_FixtureId",
                table: "TennisPlayerStats",
                column: "FixtureId");

            migrationBuilder.CreateIndex(
                name: "IX_TennisPlayerStats_PlayerId",
                table: "TennisPlayerStats",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_Code",
                table: "Tournaments",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_LeagueId",
                table: "Tournaments",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_SportId",
                table: "Tournaments",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentStages_Code",
                table: "TournamentStages",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TournamentStages_SportId",
                table: "TournamentStages",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherConditions_Code",
                table: "WeatherConditions",
                column: "Code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseballBattingStats");

            migrationBuilder.DropTable(
                name: "BaseballPitchingStats");

            migrationBuilder.DropTable(
                name: "FixturePeriodScores");

            migrationBuilder.DropTable(
                name: "FuturesOdds");

            migrationBuilder.DropTable(
                name: "GraderOdds");

            migrationBuilder.DropTable(
                name: "HistoricalOdds");

            migrationBuilder.DropTable(
                name: "Injurys");

            migrationBuilder.DropTable(
                name: "OddsJsons");

            migrationBuilder.DropTable(
                name: "Periods");

            migrationBuilder.DropTable(
                name: "ResultsJsons");

            migrationBuilder.DropTable(
                name: "SoccerPlayerStats");

            migrationBuilder.DropTable(
                name: "TennisPlayerStats");

            migrationBuilder.DropTable(
                name: "Futures");

            migrationBuilder.DropTable(
                name: "Odds");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "Selections");

            migrationBuilder.DropTable(
                name: "Sportsbooks");

            migrationBuilder.DropTable(
                name: "Fixtures");

            migrationBuilder.DropTable(
                name: "LineTypes");

            migrationBuilder.DropTable(
                name: "Markets");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Broadcasts");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropTable(
                name: "TournamentStages");

            migrationBuilder.DropTable(
                name: "Tournaments");

            migrationBuilder.DropTable(
                name: "Venues");

            migrationBuilder.DropTable(
                name: "WeatherConditions");

            migrationBuilder.DropTable(
                name: "Statuss");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "SeasonTypes");

            migrationBuilder.DropTable(
                name: "Divisions");

            migrationBuilder.DropTable(
                name: "Conferences");

            migrationBuilder.DropTable(
                name: "Leagues");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Sports");
        }
    }
}
