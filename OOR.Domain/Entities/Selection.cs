using System;
using System.Collections.Generic;

namespace OOR.Domain.Entities;

public partial class Selection
{
    public int Id { get; set; }

    public int? MarketId { get; set; }

    public int? LineTypeId { get; set; }

    public int? TeamId { get; set; }

    public int? PlayerId { get; set; }

    public decimal? Points { get; set; }

    public bool? IsMain { get; set; }

    public virtual ICollection<FuturesOdd> FuturesOdds { get; set; } = new List<FuturesOdd>();

    public virtual ICollection<HistoricalOdd> HistoricalOdds { get; set; } = new List<HistoricalOdd>();

    public virtual LineType? LineType { get; set; }

    public virtual Market? Market { get; set; }

    public virtual ICollection<Odd> Odds { get; set; } = new List<Odd>();

    public virtual Player? Player { get; set; }

    public virtual Team? Team { get; set; }
}
