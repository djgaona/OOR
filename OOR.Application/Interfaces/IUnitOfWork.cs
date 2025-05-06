using System.Collections.Generic;
using System.Threading.Tasks;
using OOR.Domain.Entities;

namespace OOR.Application.Interfaces
{
    namespace OOR.Application.Interfaces
    {
        public interface IUnitOfWork
        {
            IRepository<BaseballBattingStat> BaseballBattingStats { get; }
            IRepository<BaseballPitchingStat> BaseballPitchingStats { get; }
            IRepository<Broadcast> Broadcasts { get; }
            IRepository<Conference> Conferences { get; }
            IRepository<Division> Divisions { get; }
            IRepository<Fixture> Fixtures { get; }
            IRepository<Future> Futures { get; }
            IRepository<FuturesOdd> FuturesOdds { get; }
            IRepository<GraderOdd> GraderOdds { get; }
            IRepository<HistoricalOdd> HistoricalOdds { get; }
            IRepository<Injury> Injuries { get; }
            IRepository<League> Leagues { get; }
            IRepository<LineType> LineTypes { get; }
            IRepository<Market> Markets { get; }
            IRepository<Odd> Odds { get; }
            IRepository<OddsJson> OddsJsons { get; }
            IRepository<Period> Periods { get; }
            IRepository<Player> Players { get; }
            IRepository<Region> Regions { get; }
            IRepository<Result> Results { get; }
            IRepository<ResultsJson> ResultStreamJsons { get; }
            IRepository<Season> Seasons { get; }
            IRepository<SeasonType> SeasonTypes { get; }
            IRepository<Selection> Selections { get; }
            IRepository<SoccerPlayerStat> SoccerPlayerStats { get; }
            IRepository<Sport> Sports { get; }
            IRepository<Sportsbook> Sportsbooks { get; }
            IRepository<Status> Statuses { get; }
            IRepository<Team> Teams { get; }
            IRepository<FixturePeriodScore> FixturePeriodScores { get; }
            IRepository<TennisPlayerStat> TennisPlayerStats { get; }
            IRepository<Tournament> Tournaments { get; }
            IRepository<TournamentStage> TournamentStages { get; }
            IRepository<Venue> Venues { get; }
            IRepository<WeatherCondition> WeatherConditions { get; }
            Task<int> SaveAsync();
        }
    }
}