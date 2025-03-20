using System;
using System.Collections.Generic;

namespace OOR.Infrastructure.Domain.Entities;

public partial class Venue
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public int? CityId { get; set; }

    public bool? IsNeutral { get; set; }

    public virtual City? City { get; set; }

    public virtual ICollection<Fixture> Fixtures { get; set; } = new List<Fixture>();
}
