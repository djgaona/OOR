using System;
using System.Collections.Generic;

namespace OOR.Domain.Entities;

public partial class Season
{
    public int Id { get; set; }

    public int? SeasonTypeId { get; set; }

    public int? Year { get; set; }

    public int? Week { get; set; }

    public virtual ICollection<Fixture> Fixtures { get; set; } = new List<Fixture>();

    public virtual SeasonType? SeasonType { get; set; }

}
