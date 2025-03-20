using System;
using System.Collections.Generic;

namespace OOR.Infrastructure.Domain.Entities;

public partial class WeatherCondition
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Description { get; set; }

    public decimal? Temperature { get; set; }

    public virtual ICollection<Fixture> Fixtures { get; set; } = new List<Fixture>();
}
