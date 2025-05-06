using System;
using System.Collections.Generic;

namespace OOR.Domain.Entities;

public partial class Tournament
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public int? SportId { get; set; }

    public virtual ICollection<Fixture> Fixtures { get; set; } = new List<Fixture>();

    public virtual ICollection<Future> Futures { get; set; } = new List<Future>();

    public virtual Sport? Sport { get; set; }
}
