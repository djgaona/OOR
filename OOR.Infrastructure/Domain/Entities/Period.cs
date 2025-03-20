﻿using System;
using System.Collections.Generic;

namespace OOR.Infrastructure.Domain.Entities;

public partial class Period
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public int? SportId { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Market> Markets { get; set; } = new List<Market>();

    public virtual Sport? Sport { get; set; }
}
