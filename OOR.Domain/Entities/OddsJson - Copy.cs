using System;
using System.Collections.Generic;

namespace OOR.Domain.Entities;

public partial class FixtureResultJson
{
    public int FixtureId { get; set; }

    public string? Json { get; set; }

    public virtual Fixture? Fixture { get; set; }

}