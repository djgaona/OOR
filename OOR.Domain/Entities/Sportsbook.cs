using System;
using System.Collections.Generic;

namespace OOR.Domain.Entities;

public partial class Sportsbook
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? Website { get; set; }

    public bool? Active { get; set; }

    public virtual ICollection<FuturesOdd> FuturesOdds { get; set; } = new List<FuturesOdd>();

    public virtual ICollection<HistoricalOdd> HistoricalOdds { get; set; } = new List<HistoricalOdd>();

    public virtual ICollection<MarketLeagueSportsbook> MarketLeagueSportsbooks { get; set; } = new List<MarketLeagueSportsbook>();

    public virtual ICollection<Odd> Odds { get; set; } = new List<Odd>();
}
