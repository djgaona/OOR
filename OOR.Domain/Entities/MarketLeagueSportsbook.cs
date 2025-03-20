using System;
using System.Collections.Generic;

namespace OOR.Domain.Entities;

public partial class MarketLeagueSportsbook
{
    public int MarketId { get; set; }

    public int LeagueId { get; set; }

    public int SportsbookId { get; set; }

    public virtual League League { get; set; } = null!;

    public virtual Market Market { get; set; } = null!;

    public virtual Sportsbook Sportsbook { get; set; } = null!;
}
