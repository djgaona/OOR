using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OOR.Domain.Entities;

public partial class OORDbContext : DbContext
{
    public OORDbContext()
    {
    }

    public OORDbContext(DbContextOptions<OORDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BaseballBattingStat> BaseballBattingStats { get; set; }

    public virtual DbSet<BaseballPitchingStat> BaseballPitchingStats { get; set; }

    public virtual DbSet<Broadcast> Broadcasts { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Conference> Conferences { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Division> Divisions { get; set; }

    public virtual DbSet<Fixture> Fixtures { get; set; }

    public virtual DbSet<FixtureSource> FixtureSources { get; set; }

    public virtual DbSet<Future> Futures { get; set; }

    public virtual DbSet<FuturesOdd> FuturesOdds { get; set; }

    public virtual DbSet<GraderOdd> GraderOdds { get; set; }

    public virtual DbSet<HistoricalOdd> HistoricalOdds { get; set; }

    public virtual DbSet<Injury> Injuries { get; set; }

    public virtual DbSet<League> Leagues { get; set; }

    public virtual DbSet<LineType> LineTypes { get; set; }

    public virtual DbSet<Market> Markets { get; set; }

    public virtual DbSet<MarketType> MarketTypes { get; set; }

    public virtual DbSet<Odd> Odds { get; set; }

    public virtual DbSet<OddsJson> OddsJsons { get; set; }

    public virtual DbSet<Period> Periods { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<Result> Results { get; set; }

    public virtual DbSet<ResultsJson> ResultsJsons { get; set; }

    public virtual DbSet<Season> Seasons { get; set; }

    public virtual DbSet<SeasonType> SeasonTypes { get; set; }

    public virtual DbSet<Selection> Selections { get; set; }

    public virtual DbSet<SoccerPlayerStat> SoccerPlayerStats { get; set; }

    public virtual DbSet<Sport> Sports { get; set; }

    public virtual DbSet<Sportsbook> Sportsbooks { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<TeamFixtureDetail> TeamFixtureDetails { get; set; }

    public virtual DbSet<TeamsLeague> TeamsLeagues { get; set; }

    public virtual DbSet<TennisPlayerStat> TennisPlayerStats { get; set; }

    public virtual DbSet<Tournament> Tournaments { get; set; }

    public virtual DbSet<TournamentStage> TournamentStages { get; set; }

    public virtual DbSet<Venue> Venues { get; set; }

    public virtual DbSet<WeatherCondition> WeatherConditions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=odds;Username=postgres;Password=123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BaseballBattingStat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("baseball_batting_stats_pkey");

            entity.ToTable("baseball_batting_stats");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AtBats).HasColumnName("at_bats");
            entity.Property(e => e.BattingGroundIntoDoublePlay).HasColumnName("batting_ground_into_double_play");
            entity.Property(e => e.BattingHitByPitch).HasColumnName("batting_hit_by_pitch");
            entity.Property(e => e.BattingIntentionalWalks).HasColumnName("batting_intentional_walks");
            entity.Property(e => e.BattingPickedOff).HasColumnName("batting_picked_off");
            entity.Property(e => e.BattingPlateAppearances).HasColumnName("batting_plate_appearances");
            entity.Property(e => e.BattingSacrificeFlies).HasColumnName("batting_sacrifice_flies");
            entity.Property(e => e.BattingSacrificeHits).HasColumnName("batting_sacrifice_hits");
            entity.Property(e => e.BattingStrikeouts).HasColumnName("batting_strikeouts");
            entity.Property(e => e.BattingWalks).HasColumnName("batting_walks");
            entity.Property(e => e.CaughtStealing).HasColumnName("caught_stealing");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Doubles).HasColumnName("doubles");
            entity.Property(e => e.FixtureId).HasColumnName("fixture_id");
            entity.Property(e => e.Hits).HasColumnName("hits");
            entity.Property(e => e.HomeRuns).HasColumnName("home_runs");
            entity.Property(e => e.PlayerId).HasColumnName("player_id");
            entity.Property(e => e.Rbi).HasColumnName("rbi");
            entity.Property(e => e.Runs).HasColumnName("runs");
            entity.Property(e => e.Starter).HasColumnName("starter");
            entity.Property(e => e.StolenBases).HasColumnName("stolen_bases");
            entity.Property(e => e.TotalBases).HasColumnName("total_bases");
            entity.Property(e => e.Triples).HasColumnName("triples");

            entity.HasOne(d => d.Fixture).WithMany(p => p.BaseballBattingStats)
                .HasForeignKey(d => d.FixtureId)
                .HasConstraintName("baseball_batting_stats_fixture_id_fkey");

            entity.HasOne(d => d.Player).WithMany(p => p.BaseballBattingStats)
                .HasForeignKey(d => d.PlayerId)
                .HasConstraintName("baseball_batting_stats_player_id_fkey");
        });

        modelBuilder.Entity<BaseballPitchingStat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("baseball_pitching_stats_pkey");

            entity.ToTable("baseball_pitching_stats");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BattersFaced).HasColumnName("batters_faced");
            entity.Property(e => e.BattingFlyballsAllowed).HasColumnName("batting_flyballs_allowed");
            entity.Property(e => e.BattingGroundballsAllowed).HasColumnName("batting_groundballs_allowed");
            entity.Property(e => e.BlownSavePitcher).HasColumnName("blown_save_pitcher");
            entity.Property(e => e.CompleteGame).HasColumnName("complete_game");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DoublesAllowed).HasColumnName("doubles_allowed");
            entity.Property(e => e.EarnedRuns).HasColumnName("earned_runs");
            entity.Property(e => e.FixtureId).HasColumnName("fixture_id");
            entity.Property(e => e.GroundIntoDoublePlayAllowed).HasColumnName("ground_into_double_play_allowed");
            entity.Property(e => e.HitsAllowed).HasColumnName("hits_allowed");
            entity.Property(e => e.HoldingPitcher).HasColumnName("holding_pitcher");
            entity.Property(e => e.HomeRunsAllowed).HasColumnName("home_runs_allowed");
            entity.Property(e => e.InningsPitched)
                .HasPrecision(3, 1)
                .HasColumnName("innings_pitched");
            entity.Property(e => e.LosingPitcher).HasColumnName("losing_pitcher");
            entity.Property(e => e.PitchCount).HasColumnName("pitch_count");
            entity.Property(e => e.PitchingBalks).HasColumnName("pitching_balks");
            entity.Property(e => e.PitchingBalls).HasColumnName("pitching_balls");
            entity.Property(e => e.PitchingHitBatsmen).HasColumnName("pitching_hit_batsmen");
            entity.Property(e => e.PitchingIntentionalWalks).HasColumnName("pitching_intentional_walks");
            entity.Property(e => e.PitchingNoHitter).HasColumnName("pitching_no_hitter");
            entity.Property(e => e.PitchingPerfectGame).HasColumnName("pitching_perfect_game");
            entity.Property(e => e.PitchingPickoffs).HasColumnName("pitching_pickoffs");
            entity.Property(e => e.PitchingShutout).HasColumnName("pitching_shutout");
            entity.Property(e => e.PitchingStrikes).HasColumnName("pitching_strikes");
            entity.Property(e => e.PitchingWalks).HasColumnName("pitching_walks");
            entity.Property(e => e.PitchingWildPitches).HasColumnName("pitching_wild_pitches");
            entity.Property(e => e.PlayerId).HasColumnName("player_id");
            entity.Property(e => e.RunsAllowed).HasColumnName("runs_allowed");
            entity.Property(e => e.SacrificeFliesAllowed).HasColumnName("sacrifice_flies_allowed");
            entity.Property(e => e.SacrificeHitsAllowed).HasColumnName("sacrifice_hits_allowed");
            entity.Property(e => e.SavePitcher).HasColumnName("save_pitcher");
            entity.Property(e => e.Starter).HasColumnName("starter");
            entity.Property(e => e.StolenBasesAllowed).HasColumnName("stolen_bases_allowed");
            entity.Property(e => e.Strikeouts).HasColumnName("strikeouts");
            entity.Property(e => e.TriplesAllowed).HasColumnName("triples_allowed");
            entity.Property(e => e.WinningPitcher).HasColumnName("winning_pitcher");

            entity.HasOne(d => d.Fixture).WithMany(p => p.BaseballPitchingStats)
                .HasForeignKey(d => d.FixtureId)
                .HasConstraintName("baseball_pitching_stats_fixture_id_fkey");

            entity.HasOne(d => d.Player).WithMany(p => p.BaseballPitchingStats)
                .HasForeignKey(d => d.PlayerId)
                .HasConstraintName("baseball_pitching_stats_player_id_fkey");
        });

        modelBuilder.Entity<Broadcast>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("broadcasts_pkey");

            entity.ToTable("broadcasts");

            entity.HasIndex(e => e.Code, "broadcasts_code_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(15)
                .HasColumnName("code");
            entity.Property(e => e.Network)
                .HasMaxLength(50)
                .HasColumnName("network");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cities_pkey");

            entity.ToTable("cities");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .HasColumnName("state");

            entity.HasOne(d => d.Country).WithMany(p => p.Cities)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("cities_country_id_fkey");
        });

        modelBuilder.Entity<Conference>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("conferences_pkey");

            entity.ToTable("conferences");

            entity.HasIndex(e => e.Code, "conferences_code_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(15)
                .HasColumnName("code");
            entity.Property(e => e.LeagueId).HasColumnName("league_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.League).WithMany(p => p.Conferences)
                .HasForeignKey(d => d.LeagueId)
                .HasConstraintName("conferences_league_id_fkey");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("countries_pkey");

            entity.ToTable("countries");

            entity.HasIndex(e => e.Code, "countries_code_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(15)
                .HasColumnName("code");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Division>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("divisions_pkey");

            entity.ToTable("divisions");

            entity.HasIndex(e => e.Code, "divisions_code_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(15)
                .HasColumnName("code");
            entity.Property(e => e.ConferenceId).HasColumnName("conference_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.Conference).WithMany(p => p.Divisions)
                .HasForeignKey(d => d.ConferenceId)
                .HasConstraintName("divisions_conference_id_fkey");
        });

        modelBuilder.Entity<Fixture>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("fixtures_pkey");

            entity.ToTable("fixtures");

            entity.HasIndex(e => e.Code, "fixtures_code_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(15)
                .HasColumnName("code");
            entity.Property(e => e.IsLive).HasColumnName("is_live");
            entity.Property(e => e.NumericalId).HasColumnName("numerical_id");
            entity.Property(e => e.SeasonId).HasColumnName("season_id");
            entity.Property(e => e.StartDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("start_date");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.TournamentId).HasColumnName("tournament_id");
            entity.Property(e => e.TournamentStageId).HasColumnName("tournament_stage_id");
            entity.Property(e => e.VenueId).HasColumnName("venue_id");
            entity.Property(e => e.WeatherId).HasColumnName("weather_id");

            entity.HasOne(d => d.Season).WithMany(p => p.Fixtures)
                .HasForeignKey(d => d.SeasonId)
                .HasConstraintName("fixtures_season_id_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.Fixtures)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("fixtures_status_id_fkey");

            entity.HasOne(d => d.Tournament).WithMany(p => p.Fixtures)
                .HasForeignKey(d => d.TournamentId)
                .HasConstraintName("fixtures_tournament_id_fkey");

            entity.HasOne(d => d.TournamentStage).WithMany(p => p.Fixtures)
                .HasForeignKey(d => d.TournamentStageId)
                .HasConstraintName("fixtures_tournament_stage_id_fkey");

            entity.HasOne(d => d.Venue).WithMany(p => p.Fixtures)
                .HasForeignKey(d => d.VenueId)
                .HasConstraintName("fixtures_venue_id_fkey");

            entity.HasOne(d => d.Weather).WithMany(p => p.Fixtures)
                .HasForeignKey(d => d.WeatherId)
                .HasConstraintName("fixtures_weather_id_fkey");

            entity.HasMany(d => d.Broadcasts).WithMany(p => p.Fixtures)
                .UsingEntity<Dictionary<string, object>>(
                    "FixtureBroadcast",
                    r => r.HasOne<Broadcast>().WithMany()
                        .HasForeignKey("BroadcastId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fixture_broadcasts_broadcast_id_fkey"),
                    l => l.HasOne<Fixture>().WithMany()
                        .HasForeignKey("FixtureId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fixture_broadcasts_fixture_id_fkey"),
                    j =>
                    {
                        j.HasKey("FixtureId", "BroadcastId").HasName("fixture_broadcasts_pkey");
                        j.ToTable("fixture_broadcasts");
                        j.IndexerProperty<int>("FixtureId").HasColumnName("fixture_id");
                        j.IndexerProperty<int>("BroadcastId").HasColumnName("broadcast_id");
                    });
        });

        modelBuilder.Entity<FixtureSource>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("fixture_sources_pkey");

            entity.ToTable("fixture_sources");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.FixtureId).HasColumnName("fixture_id");
            entity.Property(e => e.SourceId)
                .HasMaxLength(50)
                .HasColumnName("source_id");
            entity.Property(e => e.SourceSystem)
                .HasMaxLength(50)
                .HasColumnName("source_system");

            entity.HasOne(d => d.Fixture).WithMany(p => p.FixtureSources)
                .HasForeignKey(d => d.FixtureId)
                .HasConstraintName("fixture_sources_fixture_id_fkey");
        });

        modelBuilder.Entity<Future>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("futures_pkey");

            entity.ToTable("futures");

            entity.HasIndex(e => e.Code, "futures_code_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(15)
                .HasColumnName("code");
            entity.Property(e => e.IsLive).HasColumnName("is_live");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.StartDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("start_date");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.TournamentId).HasColumnName("tournament_id");

            entity.HasOne(d => d.Status).WithMany(p => p.Futures)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("futures_status_id_fkey");

            entity.HasOne(d => d.Tournament).WithMany(p => p.Futures)
                .HasForeignKey(d => d.TournamentId)
                .HasConstraintName("futures_tournament_id_fkey");
        });

        modelBuilder.Entity<FuturesOdd>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("futures_odds_pkey");

            entity.ToTable("futures_odds");

            entity.HasIndex(e => e.Code, "futures_odds_code_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(15)
                .HasColumnName("code");
            entity.Property(e => e.FutureId).HasColumnName("future_id");
            entity.Property(e => e.GroupKey)
                .HasMaxLength(50)
                .HasColumnName("group_key");
            entity.Property(e => e.IsLive).HasColumnName("is_live");
            entity.Property(e => e.IsMain).HasColumnName("is_main");
            entity.Property(e => e.MaxLimit).HasColumnName("max_limit");
            entity.Property(e => e.MinLimit).HasColumnName("min_limit");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.SelectionId).HasColumnName("selection_id");
            entity.Property(e => e.SportsbookId).HasColumnName("sportsbook_id");
            entity.Property(e => e.TeamId).HasColumnName("team_id");
            entity.Property(e => e.Timestamp).HasColumnName("timestamp");

            entity.HasOne(d => d.Future).WithMany(p => p.FuturesOdds)
                .HasForeignKey(d => d.FutureId)
                .HasConstraintName("futures_odds_future_id_fkey");

            entity.HasOne(d => d.Selection).WithMany(p => p.FuturesOdds)
                .HasForeignKey(d => d.SelectionId)
                .HasConstraintName("futures_odds_selection_id_fkey");

            entity.HasOne(d => d.Sportsbook).WithMany(p => p.FuturesOdds)
                .HasForeignKey(d => d.SportsbookId)
                .HasConstraintName("futures_odds_sportsbook_id_fkey");

            entity.HasOne(d => d.Team).WithMany(p => p.FuturesOdds)
                .HasForeignKey(d => d.TeamId)
                .HasConstraintName("futures_odds_team_id_fkey");
        });

        modelBuilder.Entity<GraderOdd>(entity =>
        {
            entity.HasKey(e => e.FixtureId).HasName("grader_odds_pkey");

            entity.ToTable("grader_odds");

            entity.Property(e => e.FixtureId)
                .ValueGeneratedNever()
                .HasColumnName("fixture_id");
            entity.Property(e => e.AwayScore).HasColumnName("away_score");
            entity.Property(e => e.AwayTeamDisplay)
                .HasMaxLength(50)
                .HasColumnName("away_team_display");
            entity.Property(e => e.HomeScore).HasColumnName("home_score");
            entity.Property(e => e.HomeTeamDisplay)
                .HasMaxLength(50)
                .HasColumnName("home_team_display");
            entity.Property(e => e.PlayerScore).HasColumnName("player_score");
            entity.Property(e => e.Result)
                .HasMaxLength(50)
                .HasColumnName("result");
            entity.Property(e => e.StatusId).HasColumnName("status_id");

            entity.HasOne(d => d.Fixture).WithOne(p => p.GraderOdd)
                .HasForeignKey<GraderOdd>(d => d.FixtureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("grader_odds_fixture_id_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.GraderOdds)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("grader_odds_status_id_fkey");
        });

        modelBuilder.Entity<HistoricalOdd>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("historical_odds_pkey");

            entity.ToTable("historical_odds");

            entity.HasIndex(e => e.Code, "historical_odds_code_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(15)
                .HasColumnName("code");
            entity.Property(e => e.FixtureId).HasColumnName("fixture_id");
            entity.Property(e => e.IsLive).HasColumnName("is_live");
            entity.Property(e => e.MaxLimit).HasColumnName("max_limit");
            entity.Property(e => e.MinLimit).HasColumnName("min_limit");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.SelectionId).HasColumnName("selection_id");
            entity.Property(e => e.SportsbookId).HasColumnName("sportsbook_id");
            entity.Property(e => e.Timestamp).HasColumnName("timestamp");

            entity.HasOne(d => d.Fixture).WithMany(p => p.HistoricalOdds)
                .HasForeignKey(d => d.FixtureId)
                .HasConstraintName("historical_odds_fixture_id_fkey");

            entity.HasOne(d => d.Selection).WithMany(p => p.HistoricalOdds)
                .HasForeignKey(d => d.SelectionId)
                .HasConstraintName("historical_odds_selection_id_fkey");

            entity.HasOne(d => d.Sportsbook).WithMany(p => p.HistoricalOdds)
                .HasForeignKey(d => d.SportsbookId)
                .HasConstraintName("historical_odds_sportsbook_id_fkey");
        });

        modelBuilder.Entity<Injury>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("injuries_pkey");

            entity.ToTable("injuries");

            entity.HasIndex(e => e.Code, "injuries_code_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(15)
                .HasColumnName("code");
            entity.Property(e => e.ExpectedReturnDate).HasColumnName("expected_return_date");
            entity.Property(e => e.InjuryType)
                .HasMaxLength(50)
                .HasColumnName("injury_type");
            entity.Property(e => e.PlayerId).HasColumnName("player_id");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.StatusId).HasColumnName("status_id");

            entity.HasOne(d => d.Player).WithMany(p => p.Injuries)
                .HasForeignKey(d => d.PlayerId)
                .HasConstraintName("injuries_player_id_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.Injuries)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("injuries_status_id_fkey");
        });

        modelBuilder.Entity<League>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("leagues_pkey");

            entity.ToTable("leagues");

            entity.HasIndex(e => e.Code, "leagues_code_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(15)
                .HasColumnName("code");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.Level).HasColumnName("level");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.SportId).HasColumnName("sport_id");

            entity.HasOne(d => d.Country).WithMany(p => p.Leagues)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("leagues_country_id_fkey");

            entity.HasOne(d => d.Sport).WithMany(p => p.Leagues)
                .HasForeignKey(d => d.SportId)
                .HasConstraintName("leagues_sport_id_fkey");
        });

        modelBuilder.Entity<LineType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("line_types_pkey");

            entity.ToTable("line_types");

            entity.HasIndex(e => e.Name, "line_types_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Market>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("markets_pkey");

            entity.ToTable("markets");

            entity.HasIndex(e => e.Code, "markets_code_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(15)
                .HasColumnName("code");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.MarketTypeId).HasColumnName("market_type_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.PeriodId).HasColumnName("period_id");
            entity.Property(e => e.SportId).HasColumnName("sport_id");

            entity.HasOne(d => d.MarketType).WithMany(p => p.Markets)
                .HasForeignKey(d => d.MarketTypeId)
                .HasConstraintName("markets_market_type_id_fkey");

            entity.HasOne(d => d.Period).WithMany(p => p.Markets)
                .HasForeignKey(d => d.PeriodId)
                .HasConstraintName("markets_period_id_fkey");

            entity.HasOne(d => d.Sport).WithMany(p => p.Markets)
                .HasForeignKey(d => d.SportId)
                .HasConstraintName("markets_sport_id_fkey");
        });

        modelBuilder.Entity<MarketType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("market_types_pkey");

            entity.ToTable("market_types");

            entity.HasIndex(e => e.Code, "market_types_code_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(15)
                .HasColumnName("code");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Odd>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("odds_pkey");

            entity.ToTable("odds");

            entity.HasIndex(e => e.Code, "odds_code_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(15)
                .HasColumnName("code");
            entity.Property(e => e.FixtureId).HasColumnName("fixture_id");
            entity.Property(e => e.GroupKey)
                .HasMaxLength(50)
                .HasColumnName("group_key");
            entity.Property(e => e.IsLive).HasColumnName("is_live");
            entity.Property(e => e.IsMain).HasColumnName("is_main");
            entity.Property(e => e.Locked).HasColumnName("locked");
            entity.Property(e => e.MaxLimit).HasColumnName("max_limit");
            entity.Property(e => e.MinLimit).HasColumnName("min_limit");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.SelectionId).HasColumnName("selection_id");
            entity.Property(e => e.SportsbookId).HasColumnName("sportsbook_id");
            entity.Property(e => e.Timestamp).HasColumnName("timestamp");

            entity.HasOne(d => d.Fixture).WithMany(p => p.Odds)
                .HasForeignKey(d => d.FixtureId)
                .HasConstraintName("odds_fixture_id_fkey");

            entity.HasOne(d => d.Selection).WithMany(p => p.Odds)
                .HasForeignKey(d => d.SelectionId)
                .HasConstraintName("odds_selection_id_fkey");

            entity.HasOne(d => d.Sportsbook).WithMany(p => p.Odds)
                .HasForeignKey(d => d.SportsbookId)
                .HasConstraintName("odds_sportsbook_id_fkey");
        });

        modelBuilder.Entity<OddsJson>(entity =>
        {
            entity.HasKey(e => e.OddsId).HasName("odds_stream_json_pkey");

            entity.ToTable("odds_json");

            entity.Property(e => e.OddsId)
                .ValueGeneratedNever()
                .HasColumnName("odds_id");
            entity.Property(e => e.Json)
                .HasColumnType("jsonb")
                .HasColumnName("json");

            entity.HasOne(d => d.Odds).WithOne(p => p.OddsJson)
                .HasForeignKey<OddsJson>(d => d.OddsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("odds_stream_json_odds_id_fkey");
        });

        modelBuilder.Entity<Period>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("periods_pkey");

            entity.ToTable("periods");

            entity.HasIndex(e => e.Code, "periods_code_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(15)
                .HasColumnName("code");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.SportId).HasColumnName("sport_id");

            entity.HasOne(d => d.Sport).WithMany(p => p.Periods)
                .HasForeignKey(d => d.SportId)
                .HasConstraintName("periods_sport_id_fkey");
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("players_pkey");

            entity.ToTable("players");

            entity.HasIndex(e => e.Code, "players_code_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(15)
                .HasColumnName("code");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.Position)
                .HasMaxLength(10)
                .HasColumnName("position");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.TeamId).HasColumnName("team_id");

            entity.HasOne(d => d.Status).WithMany(p => p.Players)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("players_status_id_fkey");

            entity.HasOne(d => d.Team).WithMany(p => p.Players)
                .HasForeignKey(d => d.TeamId)
                .HasConstraintName("players_team_id_fkey");
        });

        modelBuilder.Entity<Result>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("results_pkey");

            entity.ToTable("results");

            entity.HasIndex(e => e.Code, "results_code_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AwayScore).HasColumnName("away_score");
            entity.Property(e => e.Code)
                .HasMaxLength(15)
                .HasColumnName("code");
            entity.Property(e => e.FixtureId).HasColumnName("fixture_id");
            entity.Property(e => e.HomeScore).HasColumnName("home_score");
            entity.Property(e => e.StatusId).HasColumnName("status_id");

            entity.HasOne(d => d.Fixture).WithMany(p => p.Results)
                .HasForeignKey(d => d.FixtureId)
                .HasConstraintName("results_fixture_id_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.Results)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("results_status_id_fkey");
        });

        modelBuilder.Entity<ResultsJson>(entity =>
        {
            entity.HasKey(e => e.ResultsId).HasName("results_stream_json_pkey");

            entity.ToTable("results_json");

            entity.Property(e => e.ResultsId)
                .ValueGeneratedNever()
                .HasColumnName("results_id");
            entity.Property(e => e.Json)
                .HasColumnType("jsonb")
                .HasColumnName("json");

            entity.HasOne(d => d.Results).WithOne(p => p.ResultsJson)
                .HasForeignKey<ResultsJson>(d => d.ResultsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("results_stream_json_results_id_fkey");
        });

        modelBuilder.Entity<Season>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("seasons_pkey");

            entity.ToTable("seasons");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.SeasonTypeId).HasColumnName("season_type_id");
            entity.Property(e => e.Week)
                .HasMaxLength(2)
                .HasColumnName("week");
            entity.Property(e => e.Year)
                .HasMaxLength(4)
                .HasColumnName("year");

            entity.HasOne(d => d.SeasonType).WithMany(p => p.Seasons)
                .HasForeignKey(d => d.SeasonTypeId)
                .HasConstraintName("seasons_season_type_id_fkey");
        });

        modelBuilder.Entity<SeasonType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("season_types_pkey");

            entity.ToTable("season_types");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Selection>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("selections_pkey");

            entity.ToTable("selections");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IsMain).HasColumnName("is_main");
            entity.Property(e => e.LineTypeId).HasColumnName("line_type_id");
            entity.Property(e => e.MarketId).HasColumnName("market_id");
            entity.Property(e => e.PlayerId).HasColumnName("player_id");
            entity.Property(e => e.Points).HasColumnName("points");
            entity.Property(e => e.TeamId).HasColumnName("team_id");

            entity.HasOne(d => d.LineType).WithMany(p => p.Selections)
                .HasForeignKey(d => d.LineTypeId)
                .HasConstraintName("selections_line_type_id_fkey");

            entity.HasOne(d => d.Market).WithMany(p => p.Selections)
                .HasForeignKey(d => d.MarketId)
                .HasConstraintName("selections_market_id_fkey");

            entity.HasOne(d => d.Player).WithMany(p => p.Selections)
                .HasForeignKey(d => d.PlayerId)
                .HasConstraintName("selections_player_id_fkey");

            entity.HasOne(d => d.Team).WithMany(p => p.Selections)
                .HasForeignKey(d => d.TeamId)
                .HasConstraintName("selections_team_id_fkey");
        });

        modelBuilder.Entity<SoccerPlayerStat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("soccer_player_stats_pkey");

            entity.ToTable("soccer_player_stats");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AerialDuelsLost).HasColumnName("aerial_duels_lost");
            entity.Property(e => e.AerialDuelsWon).HasColumnName("aerial_duels_won");
            entity.Property(e => e.Assists).HasColumnName("assists");
            entity.Property(e => e.BallRecoveries).HasColumnName("ball_recoveries");
            entity.Property(e => e.BlockedShots).HasColumnName("blocked_shots");
            entity.Property(e => e.Clearances).HasColumnName("clearances");
            entity.Property(e => e.CornersTaken).HasColumnName("corners_taken");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CrossesSuccessful).HasColumnName("crosses_successful");
            entity.Property(e => e.CrossesTotal).HasColumnName("crosses_total");
            entity.Property(e => e.DuelsLost).HasColumnName("duels_lost");
            entity.Property(e => e.DuelsWon).HasColumnName("duels_won");
            entity.Property(e => e.FixtureId).HasColumnName("fixture_id");
            entity.Property(e => e.FormationPlace).HasColumnName("formation_place");
            entity.Property(e => e.ForwardPasses).HasColumnName("forward_passes");
            entity.Property(e => e.Fouls).HasColumnName("fouls");
            entity.Property(e => e.FoulsWon).HasColumnName("fouls_won");
            entity.Property(e => e.Goals).HasColumnName("goals");
            entity.Property(e => e.Interceptions).HasColumnName("interceptions");
            entity.Property(e => e.MinutesPlayed).HasColumnName("minutes_played");
            entity.Property(e => e.PlayerId).HasColumnName("player_id");
            entity.Property(e => e.RedCards).HasColumnName("red_cards");
            entity.Property(e => e.ShotsOffTarget).HasColumnName("shots_off_target");
            entity.Property(e => e.ShotsOnTarget).HasColumnName("shots_on_target");
            entity.Property(e => e.Starter).HasColumnName("starter");
            entity.Property(e => e.SuccessfulPasses).HasColumnName("successful_passes");
            entity.Property(e => e.TacklesSuccessful).HasColumnName("tackles_successful");
            entity.Property(e => e.TacklesTotal).HasColumnName("tackles_total");
            entity.Property(e => e.TimesTackled).HasColumnName("times_tackled");
            entity.Property(e => e.TotalPasses).HasColumnName("total_passes");
            entity.Property(e => e.Touches).HasColumnName("touches");
            entity.Property(e => e.TouchesInOppositionBox).HasColumnName("touches_in_opposition_box");
            entity.Property(e => e.UnsuccessfulPasses).HasColumnName("unsuccessful_passes");
            entity.Property(e => e.YellowCards).HasColumnName("yellow_cards");

            entity.HasOne(d => d.Fixture).WithMany(p => p.SoccerPlayerStats)
                .HasForeignKey(d => d.FixtureId)
                .HasConstraintName("soccer_player_stats_fixture_id_fkey");

            entity.HasOne(d => d.Player).WithMany(p => p.SoccerPlayerStats)
                .HasForeignKey(d => d.PlayerId)
                .HasConstraintName("soccer_player_stats_player_id_fkey");
        });

        modelBuilder.Entity<Sport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sports_pkey");

            entity.ToTable("sports");

            entity.HasIndex(e => e.Code, "sports_code_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(15)
                .HasColumnName("code");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Sportsbook>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sportsbooks_pkey");

            entity.ToTable("sportsbooks");

            entity.HasIndex(e => e.Code, "sportsbooks_code_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(15)
                .HasColumnName("code");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Website)
                .HasMaxLength(255)
                .HasColumnName("website");

            entity.HasOne(d => d.Country).WithMany(p => p.Sportsbooks)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("sportsbooks_country_id_fkey");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("status_pkey");

            entity.ToTable("status");

            entity.HasIndex(e => e.Code, "status_code_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(15)
                .HasColumnName("code");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("teams_pkey");

            entity.ToTable("teams");

            entity.HasIndex(e => e.Code, "teams_code_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Abbreviation)
                .HasMaxLength(10)
                .HasColumnName("abbreviation");
            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.Code)
                .HasMaxLength(15)
                .HasColumnName("code");
            entity.Property(e => e.DivisionId).HasColumnName("division_id");
            entity.Property(e => e.LogoUrl)
                .HasMaxLength(255)
                .HasColumnName("logo_url");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.City).WithMany(p => p.Teams)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("teams_city_id_fkey");

            entity.HasOne(d => d.Division).WithMany(p => p.Teams)
                .HasForeignKey(d => d.DivisionId)
                .HasConstraintName("teams_division_id_fkey");
        });

        modelBuilder.Entity<TeamFixtureDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("team_fixture_details_pkey");

            entity.ToTable("team_fixture_details");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FixtureId).HasColumnName("fixture_id");
            entity.Property(e => e.IsHome).HasColumnName("is_home");
            entity.Property(e => e.Record)
                .HasMaxLength(50)
                .HasColumnName("record");
            entity.Property(e => e.RotationNumber).HasColumnName("rotation_number");
            entity.Property(e => e.Seed)
                .HasMaxLength(15)
                .HasColumnName("seed");
            entity.Property(e => e.Starter)
                .HasMaxLength(50)
                .HasColumnName("starter");
            entity.Property(e => e.TeamId).HasColumnName("team_id");

            entity.HasOne(d => d.Fixture).WithMany(p => p.TeamFixtureDetails)
                .HasForeignKey(d => d.FixtureId)
                .HasConstraintName("team_fixture_details_fixture_id_fkey");

            entity.HasOne(d => d.Team).WithMany(p => p.TeamFixtureDetails)
                .HasForeignKey(d => d.TeamId)
                .HasConstraintName("team_fixture_details_team_id_fkey");
        });

        modelBuilder.Entity<TeamsLeague>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("teams_leagues_pkey");

            entity.ToTable("teams_leagues");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.LeagueId).HasColumnName("league_id");
            entity.Property(e => e.SeasonId).HasColumnName("season_id");
            entity.Property(e => e.TeamId).HasColumnName("team_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.League).WithMany(p => p.TeamsLeagues)
                .HasForeignKey(d => d.LeagueId)
                .HasConstraintName("teams_leagues_league_id_fkey");

            entity.HasOne(d => d.Season).WithMany(p => p.TeamsLeagues)
                .HasForeignKey(d => d.SeasonId)
                .HasConstraintName("teams_leagues_season_id_fkey");

            entity.HasOne(d => d.Team).WithMany(p => p.TeamsLeagues)
                .HasForeignKey(d => d.TeamId)
                .HasConstraintName("teams_leagues_team_id_fkey");
        });

        modelBuilder.Entity<TennisPlayerStat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tennis_player_stats_pkey");

            entity.ToTable("tennis_player_stats");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Aces).HasColumnName("aces");
            entity.Property(e => e.BreakPointsConverted).HasColumnName("break_points_converted");
            entity.Property(e => e.BreakPointsSaved).HasColumnName("break_points_saved");
            entity.Property(e => e.BreakPointsTotal).HasColumnName("break_points_total");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DoubleFaults).HasColumnName("double_faults");
            entity.Property(e => e.FirstServePointsTotal).HasColumnName("first_serve_points_total");
            entity.Property(e => e.FirstServePointsWon).HasColumnName("first_serve_points_won");
            entity.Property(e => e.FirstServeReturnPointsTotal).HasColumnName("first_serve_return_points_total");
            entity.Property(e => e.FirstServeReturnPointsWon).HasColumnName("first_serve_return_points_won");
            entity.Property(e => e.FirstServesIn).HasColumnName("first_serves_in");
            entity.Property(e => e.FirstServesTotal).HasColumnName("first_serves_total");
            entity.Property(e => e.FixtureId).HasColumnName("fixture_id");
            entity.Property(e => e.GamesWon).HasColumnName("games_won");
            entity.Property(e => e.MaxGamesInRow).HasColumnName("max_games_in_row");
            entity.Property(e => e.MaxPointsInRow).HasColumnName("max_points_in_row");
            entity.Property(e => e.PlayerId).HasColumnName("player_id");
            entity.Property(e => e.PointsTotal).HasColumnName("points_total");
            entity.Property(e => e.ReturnPointsWon).HasColumnName("return_points_won");
            entity.Property(e => e.SecondServePointsTotal).HasColumnName("second_serve_points_total");
            entity.Property(e => e.SecondServePointsWon).HasColumnName("second_serve_points_won");
            entity.Property(e => e.SecondServeReturnPointsTotal).HasColumnName("second_serve_return_points_total");
            entity.Property(e => e.SecondServeReturnPointsWon).HasColumnName("second_serve_return_points_won");
            entity.Property(e => e.SecondServesIn).HasColumnName("second_serves_in");
            entity.Property(e => e.SecondServesTotal).HasColumnName("second_serves_total");
            entity.Property(e => e.ServiceGamesTotal).HasColumnName("service_games_total");
            entity.Property(e => e.ServiceGamesWon).HasColumnName("service_games_won");
            entity.Property(e => e.TiebreaksWon).HasColumnName("tiebreaks_won");

            entity.HasOne(d => d.Fixture).WithMany(p => p.TennisPlayerStats)
                .HasForeignKey(d => d.FixtureId)
                .HasConstraintName("tennis_player_stats_fixture_id_fkey");

            entity.HasOne(d => d.Player).WithMany(p => p.TennisPlayerStats)
                .HasForeignKey(d => d.PlayerId)
                .HasConstraintName("tennis_player_stats_player_id_fkey");
        });

        modelBuilder.Entity<Tournament>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tournaments_pkey");

            entity.ToTable("tournaments");

            entity.HasIndex(e => e.Code, "tournaments_code_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(15)
                .HasColumnName("code");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.LeagueId).HasColumnName("league_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.StartDate).HasColumnName("start_date");

            entity.HasOne(d => d.League).WithMany(p => p.Tournaments)
                .HasForeignKey(d => d.LeagueId)
                .HasConstraintName("tournaments_league_id_fkey");
        });

        modelBuilder.Entity<TournamentStage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tournament_stages_pkey");

            entity.ToTable("tournament_stages");

            entity.HasIndex(e => e.Code, "tournament_stages_code_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(15)
                .HasColumnName("code");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.SportId).HasColumnName("sport_id");

            entity.HasOne(d => d.Sport).WithMany(p => p.TournamentStages)
                .HasForeignKey(d => d.SportId)
                .HasConstraintName("tournament_stages_sport_id_fkey");
        });

        modelBuilder.Entity<Venue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("venues_pkey");

            entity.ToTable("venues");

            entity.HasIndex(e => e.Code, "venues_code_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.Code)
                .HasMaxLength(15)
                .HasColumnName("code");
            entity.Property(e => e.IsNeutral).HasColumnName("is_neutral");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.City).WithMany(p => p.Venues)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("venues_city_id_fkey");
        });

        modelBuilder.Entity<WeatherCondition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("weather_conditions_pkey");

            entity.ToTable("weather_conditions");

            entity.HasIndex(e => e.Code, "weather_conditions_code_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(15)
                .HasColumnName("code");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Temperature).HasColumnName("temperature");
        });

        modelBuilder.Entity<Sport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sports_pkey");

            entity.ToTable("sports");

            entity.HasIndex(e => e.Code, "sports_code_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(15)
                .HasColumnName("code");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            // Seed data for the three sports
            entity.HasData(
                new Sport { Id = 1, Code = "baseball", Name = "Baseball" },
                new Sport { Id = 2, Code = "soccer", Name = "Soccer" },
                new Sport { Id = 3, Code = "tennis", Name = "Tennis" }
            );
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
