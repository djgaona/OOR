using System;
using System.Collections.Generic;

namespace OOR.Domain.Entities;

public partial class ResultsJson
{
    public int ResultsId { get; set; }

    public string? Json { get; set; }

    public virtual Result Results { get; set; } = null!;
}
