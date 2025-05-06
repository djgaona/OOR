using System;
using System.Collections.Generic;

namespace OOR.Domain.Entities;

public partial class Team
{
    public int Id { get; set; }

    public int SportId { get; set; }
    public int LeagueId { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public int? CityId { get; set; }

    public int? DivisionId { get; set; }

    public string? Abbreviation { get; set; }

    public string? LogoUrl { get; set; }
    
    public virtual Division? Division { get; set; }

    public virtual Sport? Sport { get; set; }

    public virtual League? League { get; set; }

    public virtual ICollection<FuturesOdd> FuturesOdds { get; set; } = new List<FuturesOdd>();

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();

    public virtual ICollection<Selection> Selections { get; set; } = new List<Selection>();
    
}
