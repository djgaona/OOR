using System;
using System.Collections.Generic;

namespace OOR.Domain.Entities;

public partial class Broadcast
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Network { get; set; }

    public virtual ICollection<Fixture> Fixtures { get; set; } = new List<Fixture>();
}
