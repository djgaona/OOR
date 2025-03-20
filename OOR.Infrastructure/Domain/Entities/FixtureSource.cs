using System;
using System.Collections.Generic;

namespace OOR.Infrastructure.Domain.Entities;

public partial class FixtureSource
{
    public int Id { get; set; }

    public int? FixtureId { get; set; }

    public string? SourceSystem { get; set; }

    public string? SourceId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Fixture? Fixture { get; set; }
}
