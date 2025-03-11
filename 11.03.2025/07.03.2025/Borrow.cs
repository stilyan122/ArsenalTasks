namespace _07._03._2025
{
    public class Borrow
    {
        public Reader Reader { get; set; } = new();

        public Book Book { get; set; } = new();

        public DateTime DateOfBorrow { get; set; }

        public DateTime? DateOfReturn { get; set; }
    }
}
