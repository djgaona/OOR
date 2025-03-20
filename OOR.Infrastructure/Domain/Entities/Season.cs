using System;
using System.Collections.Generic;

namespace OOR.Infrastructure.Domain.Entities;

public partial class Season
{
    public int Id { get; set; }

    public int? SeasonTypeId { get; set; }

    public string? Year { get; set; }

    public string? Week { get; set; }

    public virtual ICollection<Fixture> Fixtures { get; set; } = new List<Fixture>();

    public virtual SeasonType? SeasonType { get; set; }

    public virtual ICollection<TeamsLeague> TeamsLeagues { get; set; } = new List<TeamsLeague>();
}
