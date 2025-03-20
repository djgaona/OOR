using System;
using System.Collections.Generic;

namespace OOR.Domain.Entities;

public partial class Country
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual ICollection<League> Leagues { get; set; } = new List<League>();

    public virtual ICollection<Sportsbook> Sportsbooks { get; set; } = new List<Sportsbook>();
}
