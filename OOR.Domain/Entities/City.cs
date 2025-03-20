using System;
using System.Collections.Generic;

namespace OOR.Domain.Entities;

public partial class City
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? State { get; set; }

    public int? RegionId { get; set; }

    public virtual Region? Region { get; set; }

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();

    public virtual ICollection<Venue> Venues { get; set; } = new List<Venue>();
}
