using System;
using System.Collections.Generic;

namespace OOR.Infrastructure.Domain.Entities;

public partial class Future
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public int? TournamentId { get; set; }

    public DateTime? StartDate { get; set; }

    public int? StatusId { get; set; }

    public bool? IsLive { get; set; }

    public virtual ICollection<FuturesOdd> FuturesOdds { get; set; } = new List<FuturesOdd>();

    public virtual Status? Status { get; set; }

    public virtual Tournament? Tournament { get; set; }
}
