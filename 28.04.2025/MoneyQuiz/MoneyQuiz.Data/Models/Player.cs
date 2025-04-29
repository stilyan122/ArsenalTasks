namespace MoneyQuiz.Data.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public ICollection<PlayerGameSession> PlayerGameSessions { get; set; }
    }
}
