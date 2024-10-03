namespace Models
{
       public class Score
        {
            public int Id { get; set; }
            public int PlayerId { get; set; }
            public DateTime MatchDate { get; set; } = DateTime.UtcNow;
            public int ScoreValue { get; set; }
        }
}