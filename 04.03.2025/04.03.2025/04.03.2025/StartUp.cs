using _04._03._2025.Entities;
using Azure;
using Microsoft.Data.SqlClient;
using System.Security.Principal;
using System;

namespace _04._03._2025
{
    public class StartUp
    {
        private static string connectionString = "Data Source=.;" +
            "Integrated Security=True;Trust Server Certificate=True;" +
            "Initial Catalog=Readers;";

        public static void Main()
        {
            #region SQL Raw Queries
            // Create DB and tables in SQL with query:
            //CREATE DATABASE Readers;
            //USE Readers;
            //CREATE TABLE Books(
            //    Id INT PRIMARY KEY IDENTITY,
            //    Title VARCHAR(100),
            //    Author VARCHAR(100),
            //    Genre VARCHAR(50),
            //            AvailableCopies INT,
            //    TotalTimesBorrowed INT
            //);

            //CREATE TABLE Readers(
            //    Id INT PRIMARY KEY IDENTITY,
            //    Name VARCHAR(100),
            //    Age INT
            //);

            //CREATE TABLE Loans(
            //    Id INT PRIMARY KEY IDENTITY,
            //    ReaderId INT,
            //    BookId INT,
            //    BorrowDate DATETIME,
            //    ReturnDate DATETIME,
            //    FOREIGN KEY(ReaderId) REFERENCES Readers(Id),
            //    FOREIGN KEY(BookId) REFERENCES Books(Id)
            //);
            #endregion

            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Add Reader");
                Console.WriteLine("3. Borrow Book");
                Console.WriteLine("4. Display All Books");
                Console.WriteLine("5. Display All Readers");
                Console.WriteLine("6. Display Books Borrowed by a Reader");
                Console.WriteLine("7. Display Readers with Active Loans");
                Console.WriteLine("8. Display Available Books");
                Console.WriteLine("9. Display Late Returns");
                Console.WriteLine("10. Display Most Borrowed Books");
                Console.WriteLine("11. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddBook();
                        break;
                    case "2":
                        AddReader();
                        break;
                    case "3":
                        BorrowBook();
                        break;
                    case "4":
                        DisplayAllBooks();
                        break;
                    case "5":
                        DisplayAllReaders();
                        break;
                    case "6":
                        DisplayBooksBorrowedByReader();
                        break;
                    case "7":
                        DisplayReadersWithActiveLoans();
                        break;
                    case "8":
                        DisplayAvailableBooks();
                        break;
                    case "9":
                        DisplayLateReturns();
                        break;
                    case "10":
                        DisplayMostBorrowedBooks();
                        break;
                    case "11":
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }

        static void AddBook()
        {
            Console.Write("Enter book title: ");
            string title = Console.ReadLine();
            Console.Write("Enter author: ");
            string author = Console.ReadLine();
            Console.Write("Enter genre: ");
            string genre = Console.ReadLine();
            Console.Write("Enter number of available copies: ");
            int availableCopies = int.Parse(Console.ReadLine());

            string query = "INSERT INTO Books (Title, Author, Genre, AvailableCopies, TotalTimesBorrowed) VALUES (@Title, @Author, @Genre, @AvailableCopies, 0)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@Author", author);
                cmd.Parameters.AddWithValue("@Genre", genre);
                cmd.Parameters.AddWithValue("@AvailableCopies", availableCopies);

                cmd.ExecuteNonQuery();
            }

            Console.WriteLine("Book added successfully!");
        }

        // Add a new reader to the database
        static void AddReader()
        {
            Console.Write("Enter reader name: ");
            string name = Console.ReadLine();
            Console.Write("Enter age: ");
            int age = int.Parse(Console.ReadLine());

            string query = "INSERT INTO Readers (Name, Age) VALUES (@Name, @Age)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Age", age);

                connection.Open();
                cmd.ExecuteNonQuery();
            }

            Console.WriteLine("Reader added successfully!");
        }

        // Borrow a book from the database
        static void BorrowBook()
        {
            Console.Write("Enter reader ID: ");
            int readerId = int.Parse(Console.ReadLine());
            Console.Write("Enter book title: ");
            string title = Console.ReadLine();

            string bookQuery = "SELECT Id, AvailableCopies FROM Books WHERE Title = @Title";
            string readerQuery = "SELECT Id FROM Readers WHERE Id = @ReaderId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Check if reader exists
                SqlCommand readerCmd = new SqlCommand(readerQuery, connection);
                readerCmd.Parameters.AddWithValue("@ReaderId", readerId);
                connection.Open();
                var readerResult = readerCmd.ExecuteScalar();
                if (readerResult == null)
                {
                    Console.WriteLine("Reader not found.");
                    return;
                }

                // Check if book is available
                SqlCommand bookCmd = new SqlCommand(bookQuery, connection);
                bookCmd.Parameters.AddWithValue("@Title", title);
                var bookResult = bookCmd.ExecuteReader();

                if (bookResult.HasRows)
                {
                    bookResult.Read();
                    int bookId = bookResult.GetInt32(0);
                    int availableCopies = bookResult.GetInt32(1);

                    if (availableCopies > 0)
                    {
                        // Insert the loan record
                        string loanQuery = "INSERT INTO Loans (ReaderId, BookId, BorrowDate) VALUES (@ReaderId, @BookId, @BorrowDate)";
                        SqlCommand loanCmd = new SqlCommand(loanQuery, connection);
                        loanCmd.Parameters.AddWithValue("@ReaderId", readerId);
                        loanCmd.Parameters.AddWithValue("@BookId", bookId);
                        loanCmd.Parameters.AddWithValue("@BorrowDate", DateTime.Now);
                        loanCmd.ExecuteNonQuery();

                        // Update the available copies of the book
                        string updateBookQuery = "UPDATE Books SET AvailableCopies = AvailableCopies - 1 WHERE Id = @BookId";
                        SqlCommand updateBookCmd = new SqlCommand(updateBookQuery, connection);
                        updateBookCmd.Parameters.AddWithValue("@BookId", bookId);
                        updateBookCmd.ExecuteNonQuery();

                        Console.WriteLine("Book borrowed successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Book is not available.");
                    }
                }
                else
                {
                    Console.WriteLine("Book not found.");
                }
            }
        }

        // Display all books in the library
        static void DisplayAllBooks()
        {
            string query = "SELECT * FROM Books";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"{reader["Title"]} by {reader["Author"]}, Genre: {reader["Genre"]}, Available: {reader["AvailableCopies"]}, Borrowed: {reader["TotalTimesBorrowed"]} times");
                }
            }
        }

        // Display all readers in the library
        static void DisplayAllReaders()
        {
            string query = "SELECT * FROM Readers";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"{reader["Name"]}, Age: {reader["Age"]}");
                }
            }
        }

        static void DisplayBooksBorrowedByReader()
        {
            Console.Write("Enter reader ID: ");
            int readerId = int.Parse(Console.ReadLine());

            string query = @"
                SELECT b.Title, b.Author, l.BorrowDate, l.ReturnDate
                FROM Books b
                INNER JOIN Loans l ON b.Id = l.BookId
                WHERE l.ReaderId = @ReaderId AND l.ReturnDate IS NULL";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ReaderId", readerId);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    Console.WriteLine("No books found for this reader.");
                    return;
                }

                while (reader.Read())
                {
                    Console.WriteLine($"Title: {reader["Title"]}, Author: {reader["Author"]}, Borrowed on: {reader["BorrowDate"]}");
                }
            }
        }

        static void DisplayReadersWithActiveLoans()
        {
            string query = @"
        SELECT DISTINCT r.Name, r.Age
        FROM Readers r
        INNER JOIN Loans l ON r.Id = l.ReaderId
        WHERE l.ReturnDate IS NULL";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    Console.WriteLine("No readers have active loans.");
                    return;
                }

                while (reader.Read())
                {
                    Console.WriteLine($"Reader: {reader["Name"]}, Age: {reader["Age"]}");
                }
            }
        }

        static void DisplayAvailableBooks()
        {
            string query = "SELECT Title, Author, AvailableCopies FROM Books WHERE AvailableCopies > 0";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    Console.WriteLine("No available books.");
                    return;
                }

                while (reader.Read())
                {
                    Console.WriteLine($"Title: {reader["Title"]}, Author: {reader["Author"]}, Available Copies: {reader["AvailableCopies"]}");
                }
            }
        }

        static void DisplayLateReturns()
        {
            string query = @"
        SELECT b.Title, b.Author, l.BorrowDate
        FROM Books b
        INNER JOIN Loans l ON b.Id = l.BookId
        WHERE l.ReturnDate IS NULL AND DATEDIFF(DAY, l.BorrowDate, GETDATE()) > 30";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    Console.WriteLine("No late returns.");
                    return;
                }

                while (reader.Read())
                {
                    Console.WriteLine($"Title: {reader["Title"]}, Author: {reader["Author"]}, Borrowed on: {reader["BorrowDate"]}");
                }
            }
        }

        static void DisplayMostBorrowedBooks()
        {
            string query = @"
        SELECT TOP 5 b.Title, b.Author, COUNT(l.BookId) AS BorrowCount
        FROM Books b
        INNER JOIN Loans l ON b.Id = l.BookId
        GROUP BY b.Title, b.Author
        ORDER BY BorrowCount DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    Console.WriteLine("No borrow history found.");
                    return;
                }

                while (reader.Read())
                {
                    Console.WriteLine($"Title: {reader["Title"]}, Author: {reader["Author"]}, Borrowed: {reader["BorrowCount"]} times");
                }
            }
        }

    }

}