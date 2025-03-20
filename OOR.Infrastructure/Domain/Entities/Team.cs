using System;
using System.Collections.Generic;

namespace OOR.Infrastructure.Domain.Entities;

public partial class Team
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public int? CityId { get; set; }

    public int? DivisionId { get; set; }

    public string? Abbreviation { get; set; }

    public string? LogoUrl { get; set; }

    public virtual City? City { get; set; }

    public virtual Division? Division { get; set; }

    public virtual ICollection<FuturesOdd> FuturesOdds { get; set; } = new List<FuturesOdd>();

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();

    public virtual ICollection<Selection> Selections { get; set; } = new List<Selection>();

    public virtual ICollection<TeamFixtureDetail> TeamFixtureDetails { get; set; } = new List<TeamFixtureDetail>();

    public virtual ICollection<TeamsLeague> TeamsLeagues { get; set; } = new List<TeamsLeague>();
}
