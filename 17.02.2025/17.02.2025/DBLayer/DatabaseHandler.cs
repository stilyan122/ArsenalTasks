using DBLayer.Models;
using Microsoft.Data.SqlClient;

namespace DBLayer
{
    public class DatabaseHandler
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;";
        private string oldDb = "School";

        public void ExecuteQuery(string query, Action<SqlDataReader> processResults)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (command)
                {
                    SqlDataReader reader = command.ExecuteReader();
                    processResults(reader);
                }
            }
        }

        public void ExecuteNonQuery(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void CreateDatabase(string dbName)
        {
            string query = "IF NOT EXISTS (SELECT name FROM sys.databases " +
                $"WHERE name = '{dbName}')" +
                "  BEGIN" +
                $"      CREATE DATABASE {dbName};" +
                "  END";

            ExecuteNonQuery(query);

            this.ReplaceConnectionString(dbName);
        }

        public void UseDatabase(string dbName)
        {
            this.ReplaceConnectionString(dbName);
        }

        public void CreateTables()
        {
            string query = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Parents' AND xtype = 'U')
                BEGIN
                    CREATE TABLE Parents (
                        Id INT PRIMARY KEY IDENTITY(1,1),
                        ParentCode NVARCHAR(50),
                        FullName NVARCHAR(100),
                        Email NVARCHAR(100),
                        Phone NVARCHAR(20)
                    );
                END;

                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Teachers' AND xtype = 'U')
                BEGIN
                    CREATE TABLE Teachers (
                        Id INT PRIMARY KEY IDENTITY(1,1),
                        TeacherCode NVARCHAR(50),
                        FullName NVARCHAR(100),
                        Gender NVARCHAR(10),
                        DateOfBirth DATETIME,
                        Email NVARCHAR(100),
                        Phone NVARCHAR(20),
                        WorkingDays NVARCHAR(50)
                    );
                END;

                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Students' AND xtype = 'U')
                BEGIN
                    CREATE TABLE Students (
                        Id INT PRIMARY KEY IDENTITY(1,1),
                        StudentCode NVARCHAR(50),
                        FullName NVARCHAR(100),
                        Gender NVARCHAR(10),
                        DateOfBirth DATETIME,
                        Email NVARCHAR(100),
                        Phone NVARCHAR(20),
                        ClassId INT,
                        IsActive BIT
                    );
                END;

                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Classes' AND xtype = 'U')
                BEGIN
                    CREATE TABLE Classes (
                        Id INT PRIMARY KEY IDENTITY(1,1),
                        ClassNumber INT,
                        ClassLetter NVARCHAR(10),
                        ClassTeacherId INT,
                        ClassroomId INT
                    );
                END;

                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'ClassSubjects' AND xtype = 'U')
                BEGIN
                    CREATE TABLE ClassSubjects (
                        Id INT PRIMARY KEY IDENTITY(1,1),
                        ClassId INT,
                        SubjectId INT
                    );
                END;

                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Classrooms' AND xtype = 'U')
                BEGIN
                    CREATE TABLE Classrooms (
                        Id INT PRIMARY KEY IDENTITY(1,1),
                        Floor INT,
                        Capacity INT,
                        Description NVARCHAR(200)
                    );
                END;

                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Subjects' AND xtype = 'U')
                BEGIN
                    CREATE TABLE Subjects (
                        Id INT PRIMARY KEY IDENTITY(1,1),
                        Title NVARCHAR(100),
                        Level NVARCHAR(50)
                    );
                END;

                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'TeacherSubjects' AND xtype = 'U')
                BEGIN
                    CREATE TABLE TeacherSubjects (
                        Id INT PRIMARY KEY IDENTITY(1,1),
                        TeacherId INT,
                        SubjectId INT
                    );
                END;

                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'StudentParents' AND xtype = 'U')
                BEGIN
                    CREATE TABLE StudentParents (
                        Id INT PRIMARY KEY IDENTITY(1,1),
                        StudentId INT,
                        ParentId INT
                    );
                END;
                ";

            ExecuteNonQuery(query);
        }

        public void InsertParent(Parent parent)
        {
            string query = @"
                INSERT INTO Parents (ParentCode, FullName, Email, Phone)
                VALUES (@ParentCode, @FullName, @Email, @Phone)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ParentCode", parent.ParentCode);
                command.Parameters.AddWithValue("@FullName", parent.FullName);
                command.Parameters.AddWithValue("@Email", parent.Email);
                command.Parameters.AddWithValue("@Phone", parent.Phone);

                command.ExecuteNonQuery();
            }
        }

        public void InsertTeacher(Teacher teacher)
        {
            string query = @"
                INSERT INTO Teachers (TeacherCode, FullName, Gender, DateOfBirth, Email, Phone, WorkingDays)
                VALUES (@TeacherCode, @FullName, @Gender, @DateOfBirth, @Email, @Phone, @WorkingDays)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TeacherCode", teacher.TeacherCode);
                command.Parameters.AddWithValue("@FullName", teacher.FullName);
                command.Parameters.AddWithValue("@Gender", teacher.Gender);
                command.Parameters.AddWithValue("@DateOfBirth", teacher.DateOfBirth);
                command.Parameters.AddWithValue("@Email", teacher.Email);
                command.Parameters.AddWithValue("@Phone", teacher.Phone);
                command.Parameters.AddWithValue("@WorkingDays", teacher.WorkingDays);

                command.ExecuteNonQuery();
            }
        }

        public void InsertStudent(Student student)
        {
            string query = @"
                INSERT INTO Students (StudentCode, FullName, Gender, DateOfBirth, Email, Phone, ClassId, IsActive)
                VALUES (@StudentCode, @FullName, @Gender, @DateOfBirth, @Email, @Phone, @ClassId, @IsActive)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StudentCode", student.StudentCode);
                command.Parameters.AddWithValue("@FullName", student.FullName);
                command.Parameters.AddWithValue("@Gender", student.Gender);
                command.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);
                command.Parameters.AddWithValue("@Email", student.Email);
                command.Parameters.AddWithValue("@Phone", student.Phone);
                command.Parameters.AddWithValue("@ClassId", student.ClassId);
                command.Parameters.AddWithValue("@IsActive", student.IsActive);

                command.ExecuteNonQuery();
            }
        }

        public void InsertClass(Class classEntity)
        {
            string query = @"
                INSERT INTO Classes (ClassNumber, ClassLetter, ClassTeacherId, ClassroomId)
                VALUES (@ClassNumber, @ClassLetter, @ClassTeacherId, @ClassroomId)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ClassNumber", classEntity.ClassNumber);
                command.Parameters.AddWithValue("@ClassLetter", classEntity.ClassLetter);
                command.Parameters.AddWithValue("@ClassTeacherId", classEntity.ClassTeacherId);
                command.Parameters.AddWithValue("@ClassroomId", classEntity.ClassroomId);

                command.ExecuteNonQuery();
            }
        }

        public void InsertClassSubject(ClassSubject classSubject)
        {
            string query = @"
                INSERT INTO ClassSubjects (ClassId, SubjectId)
                VALUES (@ClassId, @SubjectId)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ClassId", classSubject.ClassId);
                command.Parameters.AddWithValue("@SubjectId", classSubject.SubjectId);

                command.ExecuteNonQuery();
            }
        }

        public void InsertClassroom(Classroom classroom)
        {
            string query = @"
                INSERT INTO Classrooms (Floor, Capacity, Description)
                VALUES (@Floor, @Capacity, @Description)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Floor", classroom.Floor);
                command.Parameters.AddWithValue("@Capacity", classroom.Capacity);
                command.Parameters.AddWithValue("@Description", classroom.Description);

                command.ExecuteNonQuery();
            }
        }

        public void InsertSubject(Subject subject)
        {
            string query = @"
                INSERT INTO Subjects (Title, Level)
                VALUES (@Title, @Level)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Title", subject.Title);
                command.Parameters.AddWithValue("@Level", subject.Level);

                command.ExecuteNonQuery();
            }
        }

        public void InsertTeacherSubject(TeacherSubject teacherSubject)
        {
            string query = @"
                INSERT INTO TeacherSubjects (TeacherId, SubjectId)
                VALUES (@TeacherId, @SubjectId)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TeacherId", teacherSubject.TeacherId);
                command.Parameters.AddWithValue("@SubjectId", teacherSubject.SubjectId);

                command.ExecuteNonQuery();
            }
        }

        public void InsertStudentParent(StudentParent studentParent)
        {
            string query = @"
                INSERT INTO StudentParents (StudentId, ParentId)
                VALUES (@StudentId, @ParentId)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StudentId", studentParent.StudentId);
                command.Parameters.AddWithValue("@ParentId", studentParent.ParentId);

                command.ExecuteNonQuery();
            }
        }
 
        public void GetStudentsFrom11BClass()
        {
            string query = "SELECT s.FullName FROM Classes AS c " +
                "JOIN Students AS s ON c.Id = s.ClassId " +
                "WHERE c.ClassLetter = N'Б' AND c.ClassNumber = 11";

            ExecuteQuery(query, reader =>
            {
                while (reader.Read())
                {
                    Console.WriteLine($"Student Name: {reader[0]}");
                }
            });
        }

        public void GetTeachersAndSubjectsGroupedBySubject()
        {
            string query = @"SELECT s.Title AS [SubjectTitle], 
	                STRING_AGG(t.FullName, ', ') AS Teachers
                FROM Teachers t
                JOIN TeacherSubjects AS ts 
                ON t.Id = ts.TeacherId
                JOIN Subjects AS s 
                ON ts.SubjectId = s.Id
                GROUP BY s.Title
                ORDER BY s.Title;";

            ExecuteQuery(query, reader =>
            {
                while (reader.Read())
                {
                    Console.WriteLine($"Subject Title: {reader[0]}, " +
                        $"Teachers: {reader[1]}");
                }
            });
        }

        public void GetClassesWithClassTeacher()
        {
            string query = @"
                SELECT 
                    c.ClassNumber, 
                    c.ClassLetter, 
                    t.FullName AS ClassTeacher
                FROM 
                    Classes AS c
                JOIN 
                    Teachers AS t
                ON c.ClassTeacherId = t.Id;";

            ExecuteQuery(query, reader =>
            {
                while (reader.Read())
                {
                    Console.WriteLine($"Class Number: {reader[0]}, " +
                        $"Class Letter: {reader[1]}, Class Teacher Name: {reader[2]}");
                }
            });
        }

        public void GetSubjectsAndTeacherCount()
        {
            string query = @"SELECT 
                Subjects.Title AS Subject,
                COUNT(TeacherSubjects.TeacherId) AS TeacherCount
                    FROM 
                        Subjects
                    LEFT JOIN 
                        TeacherSubjects ON Subjects.Id = TeacherSubjects.SubjectId
                GROUP BY 
                    Subjects.Title;";

            ExecuteQuery(query, reader =>
            {
                while (reader.Read())
                {
                    Console.WriteLine($"Subject: {reader[0]} has {reader[1]} teacher(s)");
                }
            });
        }

        public void GetClassroomsWithMoreThan26Students()
        {
            string query = @"SELECT 
                    c.Id, 
                    c.Capacity
                FROM
                    Classrooms AS c
                WHERE
                    c.Capacity > 26
                ORDER BY
                    c.[Floor] ASC;";

            ExecuteQuery(query, reader =>
            {
                while (reader.Read())
                {
                    Console.WriteLine($"Classroom ID: {reader[0]}, Capacity: {reader[1]}");
                }
            });
        }

        public void GetAllStudentsGroupedByClass()
        {
            string query = @"SELECT 
                    CONCAT(c.ClassNumber, ' ', c.ClassLetter) AS 'Class',
                    STRING_AGG(s.FullName, ', ') AS 'Students'
                FROM 
                    Students AS s
                JOIN 
                    Classes AS c 
                ON s.ClassId = c.Id
                GROUP BY 
                    c.ClassNumber, 
                    c.ClassLetter
                ORDER BY 
                    c.ClassNumber, 
                    c.ClassLetter;";

            ExecuteQuery(query, reader =>
            {
                while (reader.Read())
                {
                    Console.WriteLine($"Class: {reader[0]}, Students: {reader[1]}");
                }
            });
        }

        public void GetStudentsFromClass(int classNumber, string classLetter)
        {
            string query = @"SELECT 
                    s.FullName AS StudentName
                FROM 
                    Students AS s
                JOIN 
                    Classes AS c 
                ON s.ClassId = c.Id
                WHERE 
                    c.ClassNumber = @ClassNumber 
                    AND c.ClassLetter = @ClassLetter;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ClassNumber", classNumber);
                command.Parameters.AddWithValue("@ClassLetter", classLetter);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"Student name: {reader[0]}");
                }
            }
        }

        public void GetStudentsByBirthDate(DateTime birthDate)
        {
            string query = @"SELECT 
                    s.FullName AS StudentName
                FROM 
                    Students AS s
                WHERE 
                    s.DateOfBirth = @BirthDate;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BirthDate", birthDate);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"Student name: {reader[0]}");
                }
            }
        }

        public void GetStudentSubjectCount(string studentName)
        {
            string query = @"SELECT 
                    COUNT(cs.SubjectId) AS NumberOfSubjects
                FROM 
                    Students AS s
                JOIN 
                    Classes AS c ON s.ClassId = c.Id
                JOIN 
                    ClassSubjects AS cs ON c.Id = cs.ClassId
                JOIN 
                    Subjects AS sub ON cs.SubjectId = sub.Id
                WHERE 
                    s.FullName = @StudentName;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StudentName", studentName);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"Number of subjects: {reader[0]}");
                }
            }
        }

        public void GetTeachersForStudent(string studentName)
        {
            string query = @"SELECT 
                    t.FullName AS TeacherName,
                    sub.Title AS SubjectName
                FROM 
                    Students AS s
                JOIN 
                    Classes AS c ON s.ClassId = c.Id
                JOIN 
                    ClassSubjects AS cs ON c.Id = cs.ClassId
                JOIN 
                    Subjects AS sub ON cs.SubjectId = sub.Id
                JOIN 
                    TeacherSubjects AS ts ON sub.Id = ts.SubjectId
                JOIN 
                    Teachers AS t ON ts.TeacherId = t.Id
                WHERE 
                    s.FullName = @StudentName;
                ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StudentName", studentName);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"Teacher name: {reader[0]}, " +
                        $"Subject Title: {reader[1]}");
                }
            }
        }

        public void GetClassesByParentEmail(string parentEmail)
        {
            string query = @"SELECT 
                    DISTINCT CONCAT(c.ClassNumber, ' ', c.ClassLetter) AS Class
                FROM 
                    Parents AS p
                JOIN 
                    StudentParents AS sp ON p.Id = sp.ParentId
                JOIN 
                    Students AS s ON sp.StudentId = s.Id
                JOIN 
                    Classes AS c ON s.ClassId = c.Id
                WHERE 
                    p.Email = 'svetlito@gmail.com';";

            ExecuteQuery(query, reader =>
            {
                while (reader.Read())
                {
                    Console.WriteLine($"Class: {reader[0]}");
                }
            });
        }

        private void ReplaceConnectionString(string dbName)
        {
            if (!this.connectionString.Contains("Initial Catalog"))
            {
                this.connectionString += $"Initial Catalog = {dbName}";
            }

            this.connectionString = this.connectionString
                .Replace(oldDb, dbName);

            this.oldDb = dbName;
        }
    }
}
