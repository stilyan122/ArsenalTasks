namespace _04._03._2025.Entities
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int AvailableCopies { get; set; }
        public int TotalTimesBorrowed { get; set; }

        public Book(string title, string author, 
            string genre, int availableCopies)
        {
            this.Title = title;
            this.Author = author;
            this.Genre = genre;
            this.AvailableCopies = availableCopies;
            this.TotalTimesBorrowed = 0;
        }
    }
}
