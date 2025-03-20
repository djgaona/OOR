using System;
using System.Collections.Generic;

namespace OOR.Infrastructure.Domain.Entities;

public partial class OddsJson
{
    public int OddsId { get; set; }

    public string? Json { get; set; }

    public virtual Odd Odds { get; set; } = null!;
}
