namespace LiveSportNotification.Models
{
    public class Team
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Logo { get; set; }

        // Navigation properties
        public virtual List<Match> HomeMatches { get; set; }
        public virtual List<Match> AwayMatches { get; set; }
    }
}
