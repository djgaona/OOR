using System;
using System.Collections.Generic;

namespace OOR.Domain.Entities;

public partial class TournamentStage
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public int? SportId { get; set; }

    public virtual ICollection<Fixture> Fixtures { get; set; } = new List<Fixture>();

    public virtual Sport? Sport { get; set; }
}
