﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OOR.Domain.Entities;

public partial class Market
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? MarketTypeId { get; set; }

    public int? PeriodId { get; set; }

    public int? SportId { get; set; }

    public virtual ICollection<MarketLeagueSportsbook> MarketLeagueSportsbooks { get; set; } = new List<MarketLeagueSportsbook>();

    public virtual MarketType? MarketType { get; set; }

    public virtual Period? Period { get; set; }

    public virtual ICollection<Selection> Selections { get; set; } = new List<Selection>();

    public virtual Sport? Sport { get; set; }

    [NotMapped] // This means EF won't try to store SportCode in the database.
    public string? SportCode { get; set; }
}
