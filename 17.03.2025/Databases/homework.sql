--00.

CREATE DATABASE LibraryDB_20;

USE LibraryDB_20;

CREATE TABLE Libraries (
    Id INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(200) NOT NULL
);

CREATE TABLE Books (
    Id INT PRIMARY KEY IDENTITY,
    Title NVARCHAR(255) NOT NULL,
    LibraryId INT FOREIGN KEY (LibraryId) REFERENCES Libraries(Id) ON DELETE SET DEFAULT
);

CREATE TABLE Readers (
    Id INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(200) NOT NULL
);

CREATE TABLE Loans (
    Id INT PRIMARY KEY IDENTITY,
    ReaderId INT FOREIGN KEY REFERENCES Readers(Id) ON DELETE CASCADE,
    BookId INT NULL FOREIGN KEY REFERENCES Books(Id)ON DELETE SET NULL,
    LoanDate DATE NOT NULL
);

INSERT INTO Readers([Name]) 
VALUES 
(N'Петър Петров'),
(N'Мария Иванова'),
(N'Георги Димитров'),
(N'Елена Стоянова');

INSERT INTO Libraries([Name])
VALUES 
(N'Централна библиотека'),
(N'Градска библиотека'),
(N'Университетска библиотека');

INSERT INTO Books (Title, LibraryId) 
VALUES 
(N'1984', 1), 
(N'Престъпление и наказание', 2), 
(N'Хари Потър', 3),
(N'Граф Монте Кристо', 1);

INSERT INTO Loans (ReaderId, BookId, LoanDate) 
VALUES 
(1, 1, '2023-05-10'),
(2, 2, '2023-06-15'),
(3, 3, '2023-07-20'),
(4, 4, '2023-08-25');

SELECT * FROM Readers;
SELECT * FROM Loans;
SELECT * FROM Libraries;
SELECT * FROM Books;

--01.
DELETE FROM Readers WHERE Id = 1;

SELECT * FROM Readers;
SELECT * FROM Loans;
SELECT * FROM Libraries;
SELECT * FROM Books;

--02.
DELETE FROM Books WHERE Title = N'Престъпление и наказание';

SELECT * FROM Readers;
SELECT * FROM Loans;
SELECT * FROM Libraries;
SELECT * FROM Books;

--03.
INSERT INTO Books([Title], [LibraryId])
VALUES
(N'Война и мир', 
(SELECT TOP 1 Id FROM Libraries WHERE [Name] = N'Университетска библиотека'));

SELECT * FROM Readers;
SELECT * FROM Loans;
SELECT * FROM Libraries;
SELECT * FROM Books;

--04.
DELETE FROM Libraries WHERE Id = 3;

SELECT * FROM Readers;
SELECT * FROM Loans;
SELECT * FROM Libraries;
SELECT * FROM Books;