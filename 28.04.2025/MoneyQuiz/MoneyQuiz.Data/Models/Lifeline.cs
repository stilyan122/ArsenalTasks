namespace MoneyQuiz.Data.Models
{
    public class Lifeline
    {
        public int Id { get; set; }
        public int PlayerGameSessionId { get; set; }
        public string Type { get; set; }
        public int UsedOnQuestionId { get; set; }

        public PlayerGameSession PlayerGameSession { get; set; }
        public Question UsedOnQuestion { get; set; }
    }
}
