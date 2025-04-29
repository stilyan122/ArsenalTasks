namespace MoneyQuiz.Data.Models
{
    public class GameSession
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public decimal FinalAmount { get; set; }

        public ICollection<PlayerGameSession> PlayerGameSessions { get; set; }
    }
}
