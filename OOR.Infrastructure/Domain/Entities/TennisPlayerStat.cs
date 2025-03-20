using System;
using System.Collections.Generic;

namespace OOR.Infrastructure.Domain.Entities;

public partial class TennisPlayerStat
{
    public int Id { get; set; }

    public int? FixtureId { get; set; }

    public int? PlayerId { get; set; }

    public int? Aces { get; set; }

    public int? DoubleFaults { get; set; }

    public int? FirstServesIn { get; set; }

    public int? FirstServesTotal { get; set; }

    public int? SecondServesIn { get; set; }

    public int? SecondServesTotal { get; set; }

    public int? FirstServePointsWon { get; set; }

    public int? FirstServePointsTotal { get; set; }

    public int? SecondServePointsWon { get; set; }

    public int? SecondServePointsTotal { get; set; }

    public int? FirstServeReturnPointsWon { get; set; }

    public int? FirstServeReturnPointsTotal { get; set; }

    public int? SecondServeReturnPointsWon { get; set; }

    public int? SecondServeReturnPointsTotal { get; set; }

    public int? BreakPointsSaved { get; set; }

    public int? BreakPointsTotal { get; set; }

    public int? BreakPointsConverted { get; set; }

    public int? ServiceGamesWon { get; set; }

    public int? ServiceGamesTotal { get; set; }

    public int? ReturnPointsWon { get; set; }

    public int? GamesWon { get; set; }

    public int? TiebreaksWon { get; set; }

    public int? MaxGamesInRow { get; set; }

    public int? MaxPointsInRow { get; set; }

    public int? PointsTotal { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Fixture? Fixture { get; set; }

    public virtual Player? Player { get; set; }
}
