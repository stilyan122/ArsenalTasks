using System.Text;

namespace _07._03._2025
{
    public class Reader
    {
        public string Name { get; set; } = "Stelko";

        public int Id { get; set; }

        public int Age { get; set; }

        public List<Book> BorrowedBooks { get; set; } = new();

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"Reader Id: {this.Id}, Name: {this.Name}, Age: {this.Age}");
            sb.Append("Books borrowed: ");

            if (BorrowedBooks.Count > 0)
            {
                sb.AppendLine();
                foreach (var book in BorrowedBooks)
                {
                    sb.AppendLine(book.ToString());
                }
            }
            else
            {
                sb.AppendLine("None");
            }

            return sb.ToString();
        }
    }
}
