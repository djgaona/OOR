namespace OOR.Domain.Entities
{
    public class FixturePeriodScore
    {
        public int Id { get; set; }

        // Foreign key to the Fixture (string-based Id from API)
        public int FixtureId { get; set; } = default!;

        // Period number or ID (e.g., 1 for 1st half, 2 for 2nd half, etc.)
        public int PeriodId { get; set; }

        // Foreign key to the Team
        public int TeamId { get; set; } = default!;

        // The score that this team achieved in this period
        public int Score { get; set; }

        // Navigation properties (optional)
        public Fixture? Fixture { get; set; }
        public Team? Team { get; set; }
    }
}