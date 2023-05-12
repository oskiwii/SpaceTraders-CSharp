namespace spacetraders.Models
{
    public class Leaderboards
    {
        public List<CreditLeaderboardEntry> mostCredits { get; set; }
        public List<ChartLeaderboardEntry> mostSubmittedCharts { get; set; }
    }
}