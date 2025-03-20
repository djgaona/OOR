using System;
using System.Collections.Generic;

namespace OOR.Domain.Entities;

public partial class TeamFixtureDetail
{
    public int Id { get; set; }

    public int? FixtureId { get; set; }

    public int? TeamId { get; set; }

    public bool? IsHome { get; set; }

    public string? Starter { get; set; }

    public string? Record { get; set; }

    public string? Seed { get; set; }

    public int? RotationNumber { get; set; }

    public virtual Fixture? Fixture { get; set; }

    public virtual Team? Team { get; set; }
}
