using System;
using System.Collections.Generic;

namespace OOR.Domain.Entities;

public partial class LineType
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Selection> Selections { get; set; } = new List<Selection>();
}
