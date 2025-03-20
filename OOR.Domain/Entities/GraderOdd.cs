using System;
using System.Collections.Generic;

namespace OOR.Domain.Entities;

public partial class GraderOdd
{
    public int FixtureId { get; set; }

    public string? AwayTeamDisplay { get; set; }

    public string? HomeTeamDisplay { get; set; }

    public int? StatusId { get; set; }

    public int? AwayScore { get; set; }

    public int? HomeScore { get; set; }

    public int? PlayerScore { get; set; }

    public string? Result { get; set; }

    public virtual Fixture Fixture { get; set; } = null!;

    public virtual Status? Status { get; set; }
}
