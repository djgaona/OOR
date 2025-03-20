using System;
using System.Collections.Generic;

namespace OOR.Domain.Entities;

public partial class BaseballPitchingStat
{
    public int Id { get; set; }

    public int? FixtureId { get; set; }

    public int? PlayerId { get; set; }

    public decimal? InningsPitched { get; set; }

    public int? Strikeouts { get; set; }

    public int? EarnedRuns { get; set; }

    public int? PitchCount { get; set; }

    public int? HitsAllowed { get; set; }

    public int? RunsAllowed { get; set; }

    public bool? SavePitcher { get; set; }

    public int? BattersFaced { get; set; }

    public bool? CompleteGame { get; set; }

    public bool? WinningPitcher { get; set; }

    public bool? LosingPitcher { get; set; }

    public int? PitchingBalks { get; set; }

    public int? PitchingBalls { get; set; }

    public int? PitchingStrikes { get; set; }

    public int? PitchingWalks { get; set; }

    public int? DoublesAllowed { get; set; }

    public int? TriplesAllowed { get; set; }

    public int? HomeRunsAllowed { get; set; }

    public bool? HoldingPitcher { get; set; }

    public bool? BlownSavePitcher { get; set; }

    public bool? PitchingShutout { get; set; }

    public bool? PitchingNoHitter { get; set; }

    public bool? PitchingPerfectGame { get; set; }

    public int? PitchingHitBatsmen { get; set; }

    public int? StolenBasesAllowed { get; set; }

    public int? PitchingWildPitches { get; set; }

    public int? PitchingPickoffs { get; set; }

    public int? SacrificeHitsAllowed { get; set; }

    public int? SacrificeFliesAllowed { get; set; }

    public int? BattingFlyballsAllowed { get; set; }

    public int? BattingGroundballsAllowed { get; set; }

    public int? GroundIntoDoublePlayAllowed { get; set; }

    public int? PitchingIntentionalWalks { get; set; }

    public bool? Starter { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Fixture? Fixture { get; set; }

    public virtual Player? Player { get; set; }
}
