namespace MoneyQuiz.Data.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public decimal Amount { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}
