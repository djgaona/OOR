using System;
using System.Collections.Generic;

namespace OOR.Infrastructure.Domain.Entities;

public partial class League
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public int? SportId { get; set; }

    public int? RegionId { get; set; }

    public int? Level { get; set; }

    public virtual ICollection<Conference> Conferences { get; set; } = new List<Conference>();

    public virtual Region? Region { get; set; }

    public virtual Sport? Sport { get; set; }

    public virtual ICollection<TeamsLeague> TeamsLeagues { get; set; } = new List<TeamsLeague>();

    public virtual ICollection<Tournament> Tournaments { get; set; } = new List<Tournament>();
}
