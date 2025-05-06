using System;
using System.Collections.Generic;

namespace OOR.Domain.Entities;

public partial class Period
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public int? SportId { get; set; }

    public string? Description { get; set; }

    public virtual Sport? Sport { get; set; }
}
