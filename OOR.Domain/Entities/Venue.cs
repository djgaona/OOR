using System;
using System.Collections.Generic;

namespace OOR.Domain.Entities;

public partial class Venue
{
    public int Id { get; set; }
    
    public string? Name { get; set; }

    public string? Location { get; set; }

    public bool? IsNeutral { get; set; }
    public virtual ICollection<Fixture> Fixtures { get; set; } = new List<Fixture>();
}
