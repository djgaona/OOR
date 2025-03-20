using System;
using System.Collections.Generic;

namespace OOR.Domain.Entities;

public partial class Fixture
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public int? NumericalId { get; set; }

    public DateTime? StartDate { get; set; }

    public int? StatusId { get; set; }

    public bool? IsLive { get; set; }

    public int? TournamentId { get; set; }

    public int? SeasonId { get; set; }

    public int? VenueId { get; set; }

    public int? WeatherId { get; set; }

    public int? TournamentStageId { get; set; }

    public virtual ICollection<BaseballBattingStat> BaseballBattingStats { get; set; } = new List<BaseballBattingStat>();

    public virtual ICollection<BaseballPitchingStat> BaseballPitchingStats { get; set; } = new List<BaseballPitchingStat>();

    public virtual ICollection<FixtureSource> FixtureSources { get; set; } = new List<FixtureSource>();

    public virtual GraderOdd? GraderOdd { get; set; }

    public virtual ICollection<HistoricalOdd> HistoricalOdds { get; set; } = new List<HistoricalOdd>();

    public virtual ICollection<Odd> Odds { get; set; } = new List<Odd>();

    public virtual ICollection<Result> Results { get; set; } = new List<Result>();

    public virtual Season? Season { get; set; }

    public virtual ICollection<SoccerPlayerStat> SoccerPlayerStats { get; set; } = new List<SoccerPlayerStat>();

    public virtual Status? Status { get; set; }

    public virtual ICollection<TeamFixtureDetail> TeamFixtureDetails { get; set; } = new List<TeamFixtureDetail>();

    public virtual ICollection<TennisPlayerStat> TennisPlayerStats { get; set; } = new List<TennisPlayerStat>();

    public virtual Tournament? Tournament { get; set; }

    public virtual TournamentStage? TournamentStage { get; set; }

    public virtual Venue? Venue { get; set; }

    public virtual WeatherCondition? Weather { get; set; }

    public virtual ICollection<Broadcast> Broadcasts { get; set; } = new List<Broadcast>();
}
