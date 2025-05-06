using OOR.Domain.Entities;

public class Fixture
{
    public int Id { get; set; }
    public string Code { get; set; } = null!;
    public int SportId { get; set; }
    public int LeagueId { get; set; }
    public int? TournamentId { get; set; }
    public int? SeasonId { get; set; }
    public int? StatusId { get; set; }
    public int? VenueId { get; set; }

    public bool IsLive { get; set; }
    public DateTime StartDate { get; set; }

    public int? HomeTeamId { get; set; }
    public int? AwayTeamId { get; set; }

    public int? HomeScoreTotal { get; set; }
    public int? AwayScoreTotal { get; set; }

    public string? PeriodStatus { get; set; }

    public virtual Sport Sport { get; set; } = null!;
    public virtual League League { get; set; } = null!;
    public virtual Tournament? Tournament { get; set; }
    public virtual Season? Season { get; set; }
    public virtual Team? HomeTeam { get; set; }
    public virtual Team? AwayTeam { get; set; }
    public virtual Venue? Venue { get; set; }

    public virtual ICollection<FixturePeriodScore> PeriodScores { get; set; } = new List<FixturePeriodScore>();
}