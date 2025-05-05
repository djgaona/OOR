using OOR.Application.Interfaces;
using OOR.Application.Interfaces.OOR.Application.Interfaces;
using OOR.Domain.Entities;
using OOR.Infrastructure.Context;
using OOR.Infrastructure.Repositories;

namespace OOR.Infrastructure.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OddsContext _context;

        public UnitOfWork(OddsContext context)
        {
            _context = context;
            BaseballBattingStats = new Repository<BaseballBattingStat>(_context);
            BaseballPitchingStats = new Repository<BaseballPitchingStat>(_context);
            Broadcasts = new Repository<Broadcast>(_context);
            Cities = new Repository<City>(_context);
            Conferences = new Repository<Conference>(_context);
            Divisions = new Repository<Division>(_context);
            Fixtures = new Repository<Fixture>(_context);
            FixtureSources = new Repository<FixtureSource>(_context);
            Futures = new Repository<Future>(_context);
            FuturesOdds = new Repository<FuturesOdd>(_context);
            GraderOdds = new Repository<GraderOdd>(_context);
            HistoricalOdds = new Repository<HistoricalOdd>(_context);
            Injuries = new Repository<Injury>(_context);
            Leagues = new Repository<League>(_context);
            LineTypes = new Repository<LineType>(_context);
            Markets = new Repository<Market>(_context);
            MarketLeagueSportsbooks = new Repository<MarketLeagueSportsbook>(_context);
            Odds = new Repository<Odd>(_context);
            OddsJsons = new Repository<OddsJson>(_context);
            Periods = new Repository<Period>(_context);
            Players = new Repository<Player>(_context);
            Regions = new Repository<Region>(_context);
            Results = new Repository<Result>(_context);
            ResultStreamJsons = new Repository<ResultsJson>(_context);
            Seasons = new Repository<Season>(_context);
            SeasonTypes = new Repository<SeasonType>(_context);
            Selections = new Repository<Selection>(_context);
            SoccerPlayerStats = new Repository<SoccerPlayerStat>(_context);
            Sports = new Repository<Sport>(_context);
            Sportsbooks = new Repository<Sportsbook>(_context);
            Statuses = new Repository<Status>(_context);
            Teams = new Repository<Team>(_context);
            TeamFixtureDetails = new Repository<TeamFixtureDetail>(_context);
            TeamsLeagues = new Repository<TeamsLeague>(_context);
            TennisPlayerStats = new Repository<TennisPlayerStat>(_context);
            Tournaments = new Repository<Tournament>(_context);
            TournamentStages = new Repository<TournamentStage>(_context);
            Venues = new Repository<Venue>(_context);
            WeatherConditions = new Repository<WeatherCondition>(_context);
        }

        public IRepository<BaseballBattingStat> BaseballBattingStats { get; }
        public IRepository<BaseballPitchingStat> BaseballPitchingStats { get; }
        public IRepository<Broadcast> Broadcasts { get; }
        public IRepository<City> Cities { get; }
        public IRepository<Conference> Conferences { get; }
        public IRepository<Division> Divisions { get; }
        public IRepository<Fixture> Fixtures { get; }
        public IRepository<FixtureSource> FixtureSources { get; }
        public IRepository<Future> Futures { get; }
        public IRepository<FuturesOdd> FuturesOdds { get; }
        public IRepository<GraderOdd> GraderOdds { get; }
        public IRepository<HistoricalOdd> HistoricalOdds { get; }
        public IRepository<Injury> Injuries { get; }
        public IRepository<League> Leagues { get; }
        public IRepository<LineType> LineTypes { get; }
        public IRepository<Market> Markets { get; }
        public IRepository<MarketLeagueSportsbook> MarketLeagueSportsbooks { get; }
        public IRepository<Odd> Odds { get; }
        public IRepository<OddsJson> OddsJsons { get; }
        public IRepository<Period> Periods { get; }
        public IRepository<Player> Players { get; }
        public IRepository<Region> Regions { get; }
        public IRepository<Result> Results { get; }
        public IRepository<ResultsJson> ResultStreamJsons { get; }
        public IRepository<Season> Seasons { get; }
        public IRepository<SeasonType> SeasonTypes { get; }
        public IRepository<Selection> Selections { get; }
        public IRepository<SoccerPlayerStat> SoccerPlayerStats { get; }
        public IRepository<Sport> Sports { get; }
        public IRepository<Sportsbook> Sportsbooks { get; }
        public IRepository<Status> Statuses { get; }
        public IRepository<Team> Teams { get; }
        public IRepository<TeamFixtureDetail> TeamFixtureDetails { get; }
        public IRepository<TeamsLeague> TeamsLeagues { get; }
        public IRepository<TennisPlayerStat> TennisPlayerStats { get; }
        public IRepository<Tournament> Tournaments { get; }
        public IRepository<TournamentStage> TournamentStages { get; }
        public IRepository<Venue> Venues { get; }
        public IRepository<WeatherCondition> WeatherConditions { get; }

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
    }
}
