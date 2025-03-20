using System;
using System.Collections.Generic;

namespace OOR.Infrastructure.Domain.Entities;

public partial class Status
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Fixture> Fixtures { get; set; } = new List<Fixture>();

    public virtual ICollection<Future> Futures { get; set; } = new List<Future>();

    public virtual ICollection<GraderOdd> GraderOdds { get; set; } = new List<GraderOdd>();

    public virtual ICollection<Injury> Injuries { get; set; } = new List<Injury>();

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();

    public virtual ICollection<Result> Results { get; set; } = new List<Result>();
}
