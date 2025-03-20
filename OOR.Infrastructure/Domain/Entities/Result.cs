using System;
using System.Collections.Generic;

namespace OOR.Infrastructure.Domain.Entities;

public partial class Result
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public int? FixtureId { get; set; }

    public int? HomeScore { get; set; }

    public int? AwayScore { get; set; }

    public int? StatusId { get; set; }

    public virtual Fixture? Fixture { get; set; }

    public virtual ResultsJson? ResultsJson { get; set; }

    public virtual Status? Status { get; set; }
}
