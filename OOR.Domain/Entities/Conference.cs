using System;
using System.Collections.Generic;

namespace OOR.Domain.Entities;

public partial class Conference
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public int? LeagueId { get; set; }

    public virtual ICollection<Division> Divisions { get; set; } = new List<Division>();

    public virtual League? League { get; set; }
}
