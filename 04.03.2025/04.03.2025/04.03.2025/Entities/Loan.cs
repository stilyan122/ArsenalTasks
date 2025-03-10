namespace _04._03._2025.Entities
{
    public class Loan
    {
        public Reader Reader { get; set; }
        public Book Book { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public Loan(Reader reader, Book book, DateTime borrowDate)
        {
            this.Reader = reader;
            this.Book = book;
            this.BorrowDate = borrowDate;
            this.ReturnDate = null;
        }
    }
}
