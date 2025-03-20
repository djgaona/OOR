using System;
using System.Collections.Generic;

namespace OOR.Domain.Entities;

public partial class Injury
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public int? PlayerId { get; set; }

    public string? InjuryType { get; set; }

    public int? StatusId { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? ExpectedReturnDate { get; set; }

    public virtual Player? Player { get; set; }

    public virtual Status? Status { get; set; }
}
