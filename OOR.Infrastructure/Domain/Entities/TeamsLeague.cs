using System;
using System.Collections.Generic;

namespace OOR.Infrastructure.Domain.Entities;

public partial class TeamsLeague
{
    public int Id { get; set; }

    public int? TeamId { get; set; }

    public int? LeagueId { get; set; }

    public int? SeasonId { get; set; }

    public bool? Active { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual League? League { get; set; }

    public virtual Season? Season { get; set; }

    public virtual Team? Team { get; set; }
}
