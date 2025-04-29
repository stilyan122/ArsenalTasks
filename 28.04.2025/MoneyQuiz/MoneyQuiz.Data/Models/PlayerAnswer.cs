namespace MoneyQuiz.Data.Models
{
    public class PlayerAnswer
    {
        public int Id { get; set; }
        public int PlayerSessionId { get; set; }
        public int AnswerId { get; set; }
        public bool IsCorrect { get; set; }

        public PlayerGameSession PlayerSession { get; set; }
        public Answer Answer { get; set; }
    }
}
