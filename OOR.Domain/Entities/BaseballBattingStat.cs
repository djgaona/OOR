using System;
using System.Collections.Generic;

namespace OOR.Domain.Entities;

public partial class BaseballBattingStat
{
    public int Id { get; set; }

    public int? FixtureId { get; set; }

    public int? PlayerId { get; set; }

    public int? Hits { get; set; }

    public int? Runs { get; set; }

    public int? Rbi { get; set; }

    public int? AtBats { get; set; }

    public int? Doubles { get; set; }

    public int? Triples { get; set; }

    public int? HomeRuns { get; set; }

    public int? TotalBases { get; set; }

    public int? StolenBases { get; set; }

    public int? CaughtStealing { get; set; }

    public int? BattingWalks { get; set; }

    public int? BattingStrikeouts { get; set; }

    public int? BattingHitByPitch { get; set; }

    public int? BattingSacrificeHits { get; set; }

    public int? BattingSacrificeFlies { get; set; }

    public int? BattingIntentionalWalks { get; set; }

    public int? BattingPlateAppearances { get; set; }

    public int? BattingGroundIntoDoublePlay { get; set; }

    public int? BattingPickedOff { get; set; }

    public bool? Starter { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Fixture? Fixture { get; set; }

    public virtual Player? Player { get; set; }
}
