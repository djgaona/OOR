using System;
using System.Collections.Generic;

namespace OOR.Domain.Entities;

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

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();

    public virtual ICollection<Tournament> Tournaments { get; set; } = new List<Tournament>();
    public virtual ICollection<Division> Divisions { get; set; } = new List<Division>();


}
