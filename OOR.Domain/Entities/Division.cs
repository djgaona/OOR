using System;
using System.Collections.Generic;

namespace OOR.Domain.Entities;

public partial class Division
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public int? ConferenceId { get; set; }

    public virtual Conference? Conference { get; set; }

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
}
