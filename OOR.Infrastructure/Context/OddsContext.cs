using System;
using Microsoft.EntityFrameworkCore;
using OOR.Domain.Entities;

namespace OOR.Infrastructure.Context;

public partial class OddsContext : DbContext
{
    public OddsContext() { }

    public OddsContext(DbContextOptions<OddsContext> options) : base(options) { }

    public virtual DbSet<BaseballBattingStat> BaseballBattingStats { get; set; }
    public virtual DbSet<BaseballPitchingStat> BaseballPitchingStats { get; set; }
    public virtual DbSet<Broadcast> Broadcasts { get; set; }
    public virtual DbSet<Conference> Conferences { get; set; }
    public virtual DbSet<Division> Divisions { get; set; }
    public virtual DbSet<Fixture> Fixtures { get; set; }
    public virtual DbSet<Future> Futures { get; set; }
    public virtual DbSet<FuturesOdd> FuturesOdds { get; set; }
    public virtual DbSet<GraderOdd> GraderOdds { get; set; }
    public virtual DbSet<HistoricalOdd> HistoricalOdds { get; set; }
    public virtual DbSet<Injury> Injurys { get; set; }
    public virtual DbSet<League> Leagues { get; set; }
    public virtual DbSet<LineType> LineTypes { get; set; }
    public virtual DbSet<Market> Markets { get; set; }
    public virtual DbSet<Odd> Odds { get; set; }
    public virtual DbSet<OddsJson> OddsJsons { get; set; }
    public virtual DbSet<Period> Periods { get; set; }
    public virtual DbSet<Player> Players { get; set; }
    public virtual DbSet<Region> Regions { get; set; }
    public virtual DbSet<Result> Results { get; set; }
    public virtual DbSet<ResultsJson> ResultsJsons { get; set; }
    public virtual DbSet<Season> Seasons { get; set; }
    public virtual DbSet<SeasonType> SeasonTypes { get; set; }
    public virtual DbSet<Selection> Selections { get; set; }
    public virtual DbSet<SoccerPlayerStat> SoccerPlayerStats { get; set; }
    public virtual DbSet<Sport> Sports { get; set; }
    public virtual DbSet<Sportsbook> Sportsbooks { get; set; }
    public virtual DbSet<Status> Statuss { get; set; }
    public virtual DbSet<Team> Teams { get; set; }
    public virtual DbSet<FixturePeriodScore> FixturePeriodScores { get; set; }
    public virtual DbSet<TennisPlayerStat> TennisPlayerStats { get; set; }
    public virtual DbSet<Tournament> Tournaments { get; set; }
    public virtual DbSet<TournamentStage> TournamentStages { get; set; }
    public virtual DbSet<Venue> Venues { get; set; }
    public virtual DbSet<WeatherCondition> WeatherConditions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    #warning To protect potentially sensitive information in your connection string, you should move it out of source code.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=odds;Username=postgres;Password=123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BaseballBattingStat>(entity =>
        {
            entity.HasKey(e => e.Id);
         
        });
        modelBuilder.Entity<BaseballPitchingStat>(entity =>
        {
            entity.HasKey(e => e.Id);
          
        });
        modelBuilder.Entity<Broadcast>(entity =>
        {
            entity.HasKey(e => e.Id);

            if (entity.Metadata.FindProperty("Code") != null)
            {
                entity.Property(e => e.Code).HasMaxLength(50).IsRequired();
                entity.HasIndex(e => e.Code).IsUnique();
            }
          
        });
       
        modelBuilder.Entity<Conference>(entity =>
        {
            entity.HasKey(e => e.Id);

            if (entity.Metadata.FindProperty("Code") != null)
            {
                entity.Property(e => e.Code).HasMaxLength(50).IsRequired();
                entity.HasIndex(e => e.Code).IsUnique();
            }

            if (entity.Metadata.FindProperty("Name") != null)
            {
                entity.Property(e => e.Name).HasMaxLength(200);
            }
        });
        modelBuilder.Entity<Division>(entity =>
        {
            entity.HasKey(e => e.Id);

            if (entity.Metadata.FindProperty("Code") != null)
            {
                entity.Property(e => e.Code).HasMaxLength(50).IsRequired();
                entity.HasIndex(e => e.Code).IsUnique();
            }

            if (entity.Metadata.FindProperty("Name") != null)
            {
                entity.Property(e => e.Name).HasMaxLength(200);
            }
        });
        modelBuilder.Entity<Fixture>(entity =>
        {
            entity.HasKey(e => e.Id);

            if (entity.Metadata.FindProperty("Code") != null)
            {
                entity.Property(e => e.Code).HasMaxLength(50).IsRequired();
                entity.HasIndex(e => e.Code).IsUnique();
            }
            
        });
        modelBuilder.Entity<FixturePeriodScore>(entity =>
        {
            entity.HasKey(e => e.Id);
          
        });
        modelBuilder.Entity<Future>(entity =>
        {
            entity.HasKey(e => e.Id);

            if (entity.Metadata.FindProperty("Code") != null)
            {
                entity.Property(e => e.Code).HasMaxLength(50).IsRequired();
                entity.HasIndex(e => e.Code).IsUnique();
            }

            if (entity.Metadata.FindProperty("Name") != null)
            {
                entity.Property(e => e.Name).HasMaxLength(200);
            }
        });
        modelBuilder.Entity<FuturesOdd>(entity =>
        {
            entity.HasKey(e => e.Id);

            if (entity.Metadata.FindProperty("Code") != null)
            {
                entity.Property(e => e.Code).HasMaxLength(50).IsRequired();
                entity.HasIndex(e => e.Code).IsUnique();
            }
          
        });
        modelBuilder.Entity<GraderOdd>(entity =>
        {
            entity.HasKey(e => new { e.FixtureId, e.SelectionId });

        });
        modelBuilder.Entity<HistoricalOdd>(entity =>
        {
            entity.HasKey(e => e.Id);

            if (entity.Metadata.FindProperty("Code") != null)
            {
                entity.Property(e => e.Code).HasMaxLength(50).IsRequired();
                entity.HasIndex(e => e.Code).IsUnique();
            }
           
        });
        modelBuilder.Entity<Injury>(entity =>
        {
            entity.HasKey(e => e.Id);

            if (entity.Metadata.FindProperty("Code") != null)
            {
                entity.Property(e => e.Code).HasMaxLength(50).IsRequired();
                entity.HasIndex(e => e.Code).IsUnique();
            }
            
        });
        modelBuilder.Entity<League>(entity =>
        {
            entity.HasKey(e => e.Id);

            if (entity.Metadata.FindProperty("Code") != null)
            {
                entity.Property(e => e.Code).HasMaxLength(50).IsRequired();
                entity.HasIndex(e => e.Code).IsUnique();
            }

            if (entity.Metadata.FindProperty("Name") != null)
            {
                entity.Property(e => e.Name).HasMaxLength(200);
            }
        });
        modelBuilder.Entity<LineType>(entity =>
        {
            entity.HasKey(e => e.Id);
            

            if (entity.Metadata.FindProperty("Name") != null)
            {
                entity.Property(e => e.Name).HasMaxLength(200);
                entity.HasIndex(e => e.Name).IsUnique(); // ✅ Enforce uniqueness

            }
        });
        modelBuilder.Entity<Market>(entity =>
        {
            entity.HasKey(e => e.Id);

            if (entity.Metadata.FindProperty("Code") != null)
            {
                entity.Property(e => e.Code).HasMaxLength(50).IsRequired();
                entity.HasIndex(e => e.Code).IsUnique();
            }

            if (entity.Metadata.FindProperty("Name") != null)
            {
                entity.Property(e => e.Name).HasMaxLength(200);
            }
        });
      
        modelBuilder.Entity<Odd>(entity =>
        {
            entity.HasKey(e => e.Id);

            if (entity.Metadata.FindProperty("Code") != null)
            {
                entity.Property(e => e.Code).HasMaxLength(200).IsRequired();
                entity.HasIndex(e => e.Code).IsUnique();
            }

        });
        modelBuilder.Entity<OddsJson>(entity =>
        {
            entity.HasKey(e => e.OddsId);
            entity.Property(e => e.Json)
                .HasColumnType("jsonb");
            entity.HasOne(e => e.Odds).WithOne(o => o.OddsJson);

        });
        modelBuilder.Entity<Period>(entity =>
        {
            entity.HasKey(e => e.Id);

            if (entity.Metadata.FindProperty("Code") != null)
            {
                entity.Property(e => e.Code).HasMaxLength(50).IsRequired();
                entity.HasIndex(e => e.Code).IsUnique();
            }

            if (entity.Metadata.FindProperty("Name") != null)
            {
                entity.Property(e => e.Name).HasMaxLength(200);
            }
        });
        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.Id);

            if (entity.Metadata.FindProperty("Code") != null)
            {
                entity.Property(e => e.Code).HasMaxLength(50).IsRequired();
                entity.HasIndex(e => e.Code).IsUnique();
            }

            if (entity.Metadata.FindProperty("Name") != null)
            {
                entity.Property(e => e.Name).HasMaxLength(200);
            }
        });
        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.Id);

            if (entity.Metadata.FindProperty("Code") != null)
            {
                entity.Property(e => e.Code).HasMaxLength(50).IsRequired();
                entity.HasIndex(e => e.Code).IsUnique();
            }

            if (entity.Metadata.FindProperty("Name") != null)
            {
                entity.Property(e => e.Name).HasMaxLength(200);
            }
        });
        modelBuilder.Entity<Result>(entity =>
        {
            entity.HasKey(e => e.Id);

            if (entity.Metadata.FindProperty("Code") != null)
            {
                entity.Property(e => e.Code).HasMaxLength(50).IsRequired();
                entity.HasIndex(e => e.Code).IsUnique();
            }
          
        });
        modelBuilder.Entity<ResultsJson>(entity =>
        {

            entity.HasKey(e => e.ResultsId);

            entity.HasOne(e => e.Results).WithOne(o => o.ResultsJson);

        });
        modelBuilder.Entity<Season>(entity =>
        {
            entity.HasKey(e => e.Id);

        });
        modelBuilder.Entity<SeasonType>(entity =>
        {
            entity.HasKey(e => e.Id);

            
            if (entity.Metadata.FindProperty("Name") != null)
            {
                entity.Property(e => e.Name).HasMaxLength(200);
            }
        });
        modelBuilder.Entity<Selection>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasIndex(e => new { e.MarketId, e.LineTypeId, e.TeamId, e.PlayerId })
                .IsUnique()
                .HasFilter("\"TeamId\" IS NOT NULL AND \"PlayerId\" IS NOT NULL AND \"LineTypeId\" IS NOT NULL");
        });
        modelBuilder.Entity<SoccerPlayerStat>(entity =>
        {
            entity.HasKey(e => e.Id);

        });
        modelBuilder.Entity<Sport>(entity =>
        {
            entity.HasKey(e => e.Id);

            if (entity.Metadata.FindProperty("Code") != null)
            {
                entity.Property(e => e.Code).HasMaxLength(50).IsRequired();
                entity.HasIndex(e => e.Code).IsUnique();
            }

            if (entity.Metadata.FindProperty("Name") != null)
            {
                entity.Property(e => e.Name).HasMaxLength(200);
            }
        });
        modelBuilder.Entity<Sportsbook>(entity =>
        {
            entity.HasKey(e => e.Id);

            if (entity.Metadata.FindProperty("Code") != null)
            {
                entity.Property(e => e.Code).HasMaxLength(50).IsRequired();
                entity.HasIndex(e => e.Code).IsUnique();
            }

            if (entity.Metadata.FindProperty("Name") != null)
            {
                entity.Property(e => e.Name).HasMaxLength(200);
            }
        });
        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id);

            if (entity.Metadata.FindProperty("Code") != null)
            {
                entity.Property(e => e.Code).HasMaxLength(50).IsRequired();
                entity.HasIndex(e => e.Code).IsUnique();
            }

            if (entity.Metadata.FindProperty("Name") != null)
            {
                entity.Property(e => e.Name).HasMaxLength(200);
            }
        });
        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.Id);

            if (entity.Metadata.FindProperty("Code") != null)
            {
                entity.Property(e => e.Code).HasMaxLength(50).IsRequired();
                entity.HasIndex(e => e.Code).IsUnique();
            }

            if (entity.Metadata.FindProperty("Name") != null)
            {
                entity.Property(e => e.Name).HasMaxLength(200);
            }
        });
        modelBuilder.Entity<FixturePeriodScore>(entity =>
        {
            entity.HasKey(e => e.Id);

           
        });
      
        modelBuilder.Entity<TennisPlayerStat>(entity =>
        {
            entity.HasKey(e => e.Id);

            
        });
        modelBuilder.Entity<Tournament>(entity =>
        {
            entity.HasKey(e => e.Id);

            if (entity.Metadata.FindProperty("Code") != null)
            {
                entity.Property(e => e.Code).HasMaxLength(50).IsRequired();
                entity.HasIndex(e => e.Code).IsUnique();
            }

            if (entity.Metadata.FindProperty("Name") != null)
            {
                entity.Property(e => e.Name).HasMaxLength(200);
            }
        });
        modelBuilder.Entity<TournamentStage>(entity =>
        {
            entity.HasKey(e => e.Id);

            if (entity.Metadata.FindProperty("Code") != null)
            {
                entity.Property(e => e.Code).HasMaxLength(50).IsRequired();
                entity.HasIndex(e => e.Code).IsUnique();
            }

            if (entity.Metadata.FindProperty("Name") != null)
            {
                entity.Property(e => e.Name).HasMaxLength(200);
            }
        });
        modelBuilder.Entity<Venue>(entity =>
        {
            entity.HasKey(e => e.Id);
            

            if (entity.Metadata.FindProperty("Name") != null)
            {
                entity.Property(e => e.Name).HasMaxLength(200);
            }
        });
        modelBuilder.Entity<WeatherCondition>(entity =>
        {
            entity.HasKey(e => e.Id);

            if (entity.Metadata.FindProperty("Code") != null)
            {
                entity.Property(e => e.Code).HasMaxLength(50).IsRequired();
                entity.HasIndex(e => e.Code).IsUnique();
            }
            
        });
    }
}
