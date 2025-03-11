namespace _07._03._2025
{
    public class Book
    {
        public string Title { get; set; } = "White nights";

        public string Author { get; set; } = "Dostoevski";

        public string Genre { get; set; } = "Drama";

        public int Copies { get; set; }

        public int TotalBorrowTimes { get; set; }

        public override string ToString()
        {
            return $"Book: {this.Title}, Author: {this.Author}, Genre: {this.Genre}," +
                $" Copies: {this.Copies}, Times Borrowed: {this.TotalBorrowTimes}";
        }
    }
}
