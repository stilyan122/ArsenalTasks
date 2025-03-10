namespace _04._03._2025.Entities
{
    public class Reader
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Age { get; set; }
        public List<Book> BorrowedBooks { get; set; }

        public Reader(string name, int id, int age)
        {
            this.Name = name;
            this.Id = id;
            this.Age = age;
            this.BorrowedBooks = new List<Book>();
        }
    }
}
