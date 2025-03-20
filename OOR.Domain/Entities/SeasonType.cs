using System;
using System.Collections.Generic;

namespace OOR.Domain.Entities;

public partial class SeasonType
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Season> Seasons { get; set; } = new List<Season>();
}
