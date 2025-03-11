namespace _07._03._2025
{
    public class StartUp
    {
        static void Main()
        {
            Console.WriteLine("Welcome to app!");
            Console.WriteLine("01. Create Book");
            Console.WriteLine("02. Create Reader");
            Console.WriteLine("03. Create Borrow");
            Console.WriteLine("04. Show all books in app");
            Console.WriteLine("05. Show all readers in app");
            Console.WriteLine("06. Show all borrowed books by a certain reader");
            Console.WriteLine("07. Show all readers with borrowed books");
            Console.WriteLine("08. Show all available books");
            Console.WriteLine("09. Show all late returns of books");
            Console.WriteLine("10. Show 3 most borrowed books");
            Console.WriteLine("0. End app");

            List<Book> books = new List<Book>();
            List<Reader> readers = new List<Reader>();
            List<Borrow> borrows = new List<Borrow>();

            int command = int.Parse(Console.ReadLine());

            while (command != 0)
            {
                if (command == 1)
                {
                    Console.Write("Enter book title: ");
                    string title = Console.ReadLine();

                    Console.Write("Enter book author: ");
                    string author = Console.ReadLine();

                    Console.Write("Enter book genre: ");
                    string genre = Console.ReadLine();

                    Console.Write("Enter book copies: ");
                    int copies = int.Parse(Console.ReadLine());

                    Book book = new Book()
                    {
                        Title = title,
                        Author = author,
                        Copies = copies,
                        Genre = genre,
                        TotalBorrowTimes = 0
                    };

                    books.Add(book);
                    Console.WriteLine($"Book {title} created!");
                }
                else if (command == 2)
                {
                    Console.Write("Enter reader name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter reader age: ");
                    int age = int.Parse(Console.ReadLine());

                    Reader reader = new Reader()
                    {
                        Age = age,
                        Name = name,
                        Id = readers.Count + 1,
                        BorrowedBooks = new()
                    };

                    readers.Add(reader);
                    Console.WriteLine($"Reader {name} created!");
                }
                else if (command == 3)
                {
                    Console.WriteLine("Active books:");
                    foreach (var book in books)
                    {
                        Console.WriteLine(book);
                    }

                    Console.WriteLine("Active readers:");
                    foreach (var reader in readers)
                    {
                        Console.WriteLine(reader);
                    }

                    Console.Write("Enter reader name: ");
                    string readerName = Console.ReadLine();

                    Console.Write("Enter book name: ");
                    string bookName = Console.ReadLine();

                    DateTime dateOfBorrow = DateTime.Now;

                    DateTime dateOfReturn = dateOfBorrow.AddDays(20);

                    Book bookToFind = books
                        .FirstOrDefault(b => b.Title == bookName);

                    if (bookToFind == null)
                    {
                        Console.WriteLine($"Book {bookName} cannot be found.");
                    }
                    else
                    {
                        if (bookToFind.Copies > 0)
                        {
                            Reader readerToFind = readers
                            .FirstOrDefault(r => r.Name == readerName);

                            if (readerToFind == null)
                            {
                                Console.WriteLine($"Reader {readerName} cannot be found!");
                            }
                            else
                            {
                                Borrow borrow = new Borrow()
                                {
                                    Reader = readerToFind,
                                    DateOfBorrow = dateOfBorrow,
                                    DateOfReturn = dateOfReturn,
                                    Book = bookToFind
                                };

                                readerToFind.BorrowedBooks.Add(bookToFind);
                                bookToFind.TotalBorrowTimes++;
                                bookToFind.Copies--;
                                borrows.Add(borrow);

                                Console.WriteLine("Borrowed book!");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Book {bookName} is not available!");
                        }
                    }
                }
                else if (command == 4)
                {
                    Console.WriteLine("Books in library");
                    foreach (var book in books)
                    {
                        Console.WriteLine(book);
                    }
                }
                else if (command == 5)
                {
                    Console.WriteLine("Readers in app");
                    foreach (var reader in readers)
                    {
                        Console.WriteLine(reader);
                    }
                }
                else if (command == 6)
                {
                    Console.Write("Enter reader name: ");
                    string name = Console.ReadLine();

                    Reader reader = readers.FirstOrDefault(r => r.Name == name);
                    if (reader == null)
                    {
                        Console.WriteLine("No reader found!");
                    }
                    else
                    {
                        Console.WriteLine($"Reader {name}'s borrowed books");
                        foreach (var book in reader.BorrowedBooks)
                        {
                            Console.WriteLine(book.ToString());
                        }
                    }
                }
                else if (command == 7)
                {
                    var readersWithBorrowedBooks = readers.Where(r => r.BorrowedBooks.Count > 0);

                    Console.Write("Readers with borrowed books: ");
                    if (readersWithBorrowedBooks.Count() > 0)
                    {
                        Console.WriteLine();
                        foreach (var reader in readersWithBorrowedBooks)
                        {
                            Console.WriteLine(reader);
                        }
                    }
                    else
                    {
                        Console.WriteLine("None");
                    }
                }
                else if (command == 8)
                {
                    var availableBooks = books.Where(b => b.Copies > 0);
                    Console.Write("Available books: ");
                    if (availableBooks.Count() > 0)
                    {
                        Console.WriteLine();
                        foreach (var book in availableBooks)
                        {
                            Console.WriteLine(book);
                        }
                    }
                    else
                    {
                        Console.WriteLine("None");
                    }
                }
                else if (command == 9)
                {
                    var lateBooks = borrows
                        .Where(b => b.DateOfReturn < DateTime.Now)
                        .Select(b => b.Book)
                        .DistinctBy(b => b.Title);

                    Console.Write("Late books: ");
                    if (lateBooks.Count() > 0)
                    {
                        Console.WriteLine();
                        foreach (var book in lateBooks)
                        {
                            Console.WriteLine(book);
                        }
                    }
                    else
                    {
                        Console.WriteLine("None");
                    }
                }
                else if (command == 10)
                {
                    var mostBorrowedBooks = books
                        .OrderByDescending(b => b.TotalBorrowTimes)
                        .Take(3);

                    Console.WriteLine("Most borrowed books:");
                    foreach (var book in mostBorrowedBooks)
                    {
                        Console.WriteLine(book);
                    }
                }

                Console.WriteLine("01. Create Book");
                Console.WriteLine("02. Create Reader");
                Console.WriteLine("03. Create Borrow");
                Console.WriteLine("04. Show all books in app");
                Console.WriteLine("05. Show all readers in app");
                Console.WriteLine("06. Show all borrowed books by a certain reader");
                Console.WriteLine("07. Show all readers with borrowed books");
                Console.WriteLine("08. Show all available books");
                Console.WriteLine("09. Show all late returns of books");
                Console.WriteLine("10. Show 3 most borrowed books");
                Console.WriteLine("0. End app");

                command = int.Parse(Console.ReadLine());
            }
        }
    }
}
