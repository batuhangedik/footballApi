namespace Models
{
    public class MatchResultDto
    {
        public List<PlayerScoreDto> PlayerScores { get; set; }
    }

    public class PlayerScoreDto
    {
        public int PlayerId { get; set; }
        public int Score { get; set; }
    }

}