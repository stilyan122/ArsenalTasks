namespace MoneyQuiz.Data.Models
{
    public class PlayerGameSession
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int SessionId { get; set; }

        public Player Player { get; set; }
        public GameSession Session { get; set; }
        public ICollection<PlayerAnswer> PlayerAnswers { get; set; }
        public ICollection<Lifeline> Lifelines { get; set; }
    }
}
