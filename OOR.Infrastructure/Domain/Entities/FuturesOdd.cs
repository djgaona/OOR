using System;
using System.Collections.Generic;

namespace OOR.Infrastructure.Domain.Entities;

public partial class FuturesOdd
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public int? FutureId { get; set; }

    public int? TeamId { get; set; }

    public int? SportsbookId { get; set; }

    public decimal? Timestamp { get; set; }

    public bool? IsLive { get; set; }

    public int? SelectionId { get; set; }

    public decimal? Price { get; set; }

    public decimal? MinLimit { get; set; }

    public decimal? MaxLimit { get; set; }

    public bool? IsMain { get; set; }

    public string? GroupKey { get; set; }

    public virtual Future? Future { get; set; }

    public virtual Selection? Selection { get; set; }

    public virtual Sportsbook? Sportsbook { get; set; }

    public virtual Team? Team { get; set; }
}
