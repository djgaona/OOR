using System;
using System.Collections.Generic;

namespace OOR.Domain.Entities;

public partial class Player
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public int? TeamId { get; set; }

    public string? Position { get; set; }

    public int? Number { get; set; }

    public int? StatusId { get; set; }

    public virtual ICollection<BaseballBattingStat> BaseballBattingStats { get; set; } = new List<BaseballBattingStat>();

    public virtual ICollection<BaseballPitchingStat> BaseballPitchingStats { get; set; } = new List<BaseballPitchingStat>();

    public virtual ICollection<Injury> Injuries { get; set; } = new List<Injury>();

    public virtual ICollection<Selection> Selections { get; set; } = new List<Selection>();

    public virtual ICollection<SoccerPlayerStat> SoccerPlayerStats { get; set; } = new List<SoccerPlayerStat>();

    public virtual Status? Status { get; set; }

    public virtual Team? Team { get; set; }

    public virtual ICollection<TennisPlayerStat> TennisPlayerStats { get; set; } = new List<TennisPlayerStat>();
}
