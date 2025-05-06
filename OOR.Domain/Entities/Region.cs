using System;
using System.Collections.Generic;

namespace OOR.Domain.Entities;

public partial class Region
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }
    public virtual ICollection<League> Leagues { get; set; } = new List<League>();
}
