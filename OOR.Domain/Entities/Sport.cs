using System;
using System.Collections.Generic;

namespace OOR.Domain.Entities;

public partial class Sport
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<League> Leagues { get; set; } = new List<League>();

    public virtual ICollection<Market> Markets { get; set; } = new List<Market>();

    public virtual ICollection<Period> Periods { get; set; } = new List<Period>();

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();

    public virtual ICollection<Tournament> Torunament { get; set; } = new List<Tournament>();

    public virtual ICollection<TournamentStage> TournamentStages { get; set; } = new List<TournamentStage>();
}
