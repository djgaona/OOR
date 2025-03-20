using System;
using System.Collections.Generic;

namespace OOR.Domain.Entities;

public partial class SoccerPlayerStat
{
    public int Id { get; set; }

    public int? FixtureId { get; set; }

    public int? PlayerId { get; set; }

    public int? FormationPlace { get; set; }

    public int? MinutesPlayed { get; set; }

    public int? Touches { get; set; }

    public int? DuelsWon { get; set; }

    public int? DuelsLost { get; set; }

    public int? Fouls { get; set; }

    public int? FoulsWon { get; set; }

    public int? ForwardPasses { get; set; }

    public int? TotalPasses { get; set; }

    public int? SuccessfulPasses { get; set; }

    public int? UnsuccessfulPasses { get; set; }

    public int? BallRecoveries { get; set; }

    public int? Interceptions { get; set; }

    public int? Clearances { get; set; }

    public int? BlockedShots { get; set; }

    public int? ShotsOnTarget { get; set; }

    public int? ShotsOffTarget { get; set; }

    public int? Goals { get; set; }

    public int? Assists { get; set; }

    public int? YellowCards { get; set; }

    public int? RedCards { get; set; }

    public int? CornersTaken { get; set; }

    public int? CrossesTotal { get; set; }

    public int? CrossesSuccessful { get; set; }

    public int? TacklesTotal { get; set; }

    public int? TacklesSuccessful { get; set; }

    public int? TimesTackled { get; set; }

    public int? TouchesInOppositionBox { get; set; }

    public int? AerialDuelsWon { get; set; }

    public int? AerialDuelsLost { get; set; }

    public bool? Starter { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Fixture? Fixture { get; set; }

    public virtual Player? Player { get; set; }
}
