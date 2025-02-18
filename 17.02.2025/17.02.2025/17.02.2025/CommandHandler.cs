using DBLayer.Models;
using LogLayer;

namespace DBLayer
{
    public class CommandHandler
    {
        private readonly DatabaseHandler _dbHandler;
        private readonly ILogger _txtLogger;
        private readonly ILogger _excelLogger;

        public CommandHandler(DatabaseHandler dbHandler, ILogger txtLogger, ILogger excelLogger)
        {
            _dbHandler = dbHandler;
            _txtLogger = txtLogger;
            _excelLogger = excelLogger;
        }

        public void ExecuteCommand(string[] commandInput)
        {
            switch (commandInput[0])
            {
                case "CreateDB":
                    ExecuteQuery("Create Database query", () => _dbHandler.CreateDatabase(commandInput[1]));
                    break;
                case "UseDB":
                    ExecuteQuery("Use Database query", () => _dbHandler.UseDatabase(commandInput[1]));
                    break;
                case "CreateTables":
                    ExecuteQuery("Create Tables query", () => _dbHandler.CreateTables());
                    break;

                case "InsertTeacher":
                    ExecuteQuery("Insert Teacher query", () => InsertTeacher());
                    break;
                case "InsertStudent":
                    ExecuteQuery("Insert Student query", () => InsertStudent());
                    break;
                case "InsertParent":
                    ExecuteQuery("Insert Parent query", () => InsertParent());
                    break;
                case "InsertClass":
                    ExecuteQuery("Insert Class query", () => InsertClass());
                    break;
                case "InsertClassSubject":
                    ExecuteQuery("Insert ClassSubject query", () => InsertClassSubject());
                    break;
                case "InsertClassroom":
                    ExecuteQuery("Insert Classroom query", () => InsertClassroom());
                    break;
                case "InsertSubject":
                    ExecuteQuery("Insert Subject query", () => InsertSubject());
                    break;
                case "InsertTeacherSubject":
                    ExecuteQuery("Insert TeacherSubject query", () => InsertTeacherSubject());
                    break;
                case "InsertStudentParent":
                    ExecuteQuery("Insert StudentParent query", () => InsertStudentParent());
                    break;

                case "1":
                    ExecuteQuery("Get Students From 11B query", () => _dbHandler.GetStudentsFrom11BClass());
                    break;
                case "2":
                    ExecuteQuery("Get Teachers And Subjects Grouped By Subject query", 
                        () => _dbHandler.GetTeachersAndSubjectsGroupedBySubject());
                    break;
                case "3":
                    ExecuteQuery("Get Classes With Class Teacher query", () => _dbHandler.GetClassesWithClassTeacher());
                    break;
                case "4":
                    ExecuteQuery("Get Subjects And Teacher Count query", () => _dbHandler.GetSubjectsAndTeacherCount());
                    break;
                case "5":
                    ExecuteQuery("Get Classrooms With More Than 26 Students query", () => _dbHandler.GetClassroomsWithMoreThan26Students());
                    break;
                case "6":
                    ExecuteQuery("Get All Students Grouped By Class query",
                        () => _dbHandler.GetAllStudentsGroupedByClass());
                    break;
                case "7":
                    GetStudentsFromClass();
                    break;
                case "8":
                    GetStudentsByBirthDate();
                    break;
                case "9":
                    GetStudentSubjectCount();
                    break;
                case "10":
                    GetTeachersForStudent();
                    break;
                case "11":
                    GetClassesByParentEmail();
                    break;

                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }

        private void ExecuteQuery(string queryName, Action queryAction)
        {
            try
            {
                ExecuteAndLogCommand($"{queryName}", () => queryAction.Invoke());
                Console.WriteLine($"Executed query {queryName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid query!");
            }
        }

        private void InsertTeacher()
        {
            Console.Write("Enter Teacher Code: ");
            string teacherCode = Console.ReadLine();
            Console.Write("Enter Full Name: ");
            string fullName = Console.ReadLine();
            Console.Write("Enter Gender: ");
            string gender = Console.ReadLine();
            DateTime dateOfBirth = GetDateInput("Enter Date of Birth (YYYY-MM-DD): ");
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();
            Console.Write("Enter Phone: ");
            string phone = Console.ReadLine();
            Console.Write("Enter Working Days (comma-separated): ");
            string workingDays = Console.ReadLine();

            var teacher = new Teacher
            {
                TeacherCode = teacherCode,
                FullName = fullName,
                Gender = gender,
                DateOfBirth = dateOfBirth,
                Email = email,
                Phone = phone,
                WorkingDays = workingDays
            };

            ExecuteAndLogCommand("Insert Teacher", () => _dbHandler.InsertTeacher(teacher));
        }

        private void InsertStudent()
        {
            Console.Write("Enter Student Code: ");
            string studentCode = Console.ReadLine();
            Console.Write("Enter Full Name: ");
            string fullName = Console.ReadLine();
            Console.Write("Enter Gender: ");
            string gender = Console.ReadLine();
            DateTime dateOfBirth = GetDateInput("Enter Date of Birth (YYYY-MM-DD): ");
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();
            Console.Write("Enter Phone: ");
            string phone = Console.ReadLine();
            int classId = GetIntInput("Enter Class ID: ");

            var student = new Student
            {
                StudentCode = studentCode,
                FullName = fullName,
                Gender = gender,
                DateOfBirth = dateOfBirth,
                Email = email,
                Phone = phone,
                ClassId = classId,
                IsActive = true
            };

            ExecuteAndLogCommand("Insert Student", () => _dbHandler.InsertStudent(student));
        }

        private void InsertParent()
        {
            Console.Write("Enter Parent Code: ");
            string parentCode = Console.ReadLine();
            Console.Write("Enter Full Name: ");
            string fullName = Console.ReadLine();
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();
            Console.Write("Enter Phone: ");
            string phone = Console.ReadLine();

            var parent = new Parent
            {
                ParentCode = parentCode,
                FullName = fullName,
                Email = email,
                Phone = phone
            };

            ExecuteAndLogCommand("Insert Parent", () => _dbHandler.InsertParent(parent));
        }

        private void InsertClass()
        {
            int classNumber = GetIntInput("Enter Class Number: ");
            Console.Write("Enter Class Letter: ");
            string classLetter = Console.ReadLine();
            int classTeacherId = GetIntInput("Enter Class Teacher ID: ");
            int classroomId = GetIntInput("Enter Classroom ID: ");

            var classroom = new Class
            {
                ClassNumber = classNumber,
                ClassLetter = classLetter,
                ClassTeacherId = classTeacherId,
                ClassroomId = classroomId
            };

            ExecuteAndLogCommand("Insert Class", () => _dbHandler.InsertClass(classroom));
        }

        private void InsertClassSubject()
        {
            int classId = GetIntInput("Enter Class ID: ");
            int subjectId = GetIntInput("Enter Subject ID: ");

            var classSubject = new ClassSubject
            {
                ClassId = classId,
                SubjectId = subjectId
            };

            ExecuteAndLogCommand("Insert Class Subject", () => _dbHandler.InsertClassSubject(classSubject));
        }

        private void InsertClassroom()
        {
            int floor = GetIntInput("Enter Floor: ");
            int capacity = GetIntInput("Enter Capacity: ");
            Console.Write("Enter Classroom Description: ");
            string description = Console.ReadLine();

            var classroom = new Classroom
            {
                Floor = floor,
                Capacity = capacity,
                Description = description
            };

            ExecuteAndLogCommand("Insert Classroom", () => _dbHandler.InsertClassroom(classroom));
        }

        private void InsertSubject()
        {
            Console.Write("Enter Subject Title: ");
            string title = Console.ReadLine();
            Console.Write("Enter Subject Level: ");
            string level = Console.ReadLine();

            var subject = new Subject
            {
                Title = title,
                Level = level
            };

            ExecuteAndLogCommand("Insert Subject", () => _dbHandler.InsertSubject(subject));
        }

        private void InsertTeacherSubject()
        {
            int teacherId = GetIntInput("Enter Teacher ID: ");
            Console.Write("Enter Subject ID: ");
            int subjectId = GetIntInput("Enter Subject ID: ");

            var teacherSubject = new TeacherSubject
            {
                TeacherId = teacherId,
                SubjectId = subjectId
            };

            ExecuteAndLogCommand("Insert Teacher Subject", () => _dbHandler.InsertTeacherSubject(teacherSubject));
        }

        private void InsertStudentParent()
        {
            int studentId = GetIntInput("Enter Student ID: ");
            int parentId = GetIntInput("Enter Parent ID: ");

            var studentParent = new StudentParent
            {
                StudentId = studentId,
                ParentId = parentId
            };

            ExecuteAndLogCommand("Insert Student Parent", () => _dbHandler.InsertStudentParent(studentParent));
        }

        private void GetStudentsFromClass()
        {
            int classNumber = GetIntInput("Enter Class Number: ");
            Console.Write("Enter Class Letter: ");
            string classLetter = Console.ReadLine();

            ExecuteAndLogCommand("Get Students From Class query", () =>
                _dbHandler.GetStudentsFromClass(classNumber, classLetter));
        }

        private void GetStudentsByBirthDate()
        {
            DateTime dateOfBirth = GetDateInput("Enter Date of Birth (YYYY-MM-DD): ");

            ExecuteAndLogCommand("Get Students By BirthDate query", () =>
                _dbHandler.GetStudentsByBirthDate(dateOfBirth));
        }

        private void GetStudentSubjectCount()
        {
            Console.Write("Enter Student Full Name: ");
            string name = Console.ReadLine();

            ExecuteAndLogCommand("Get Student Subject Count query", () =>
                _dbHandler.GetStudentSubjectCount(name));
        }

        private void GetTeachersForStudent()
        {
            Console.Write("Enter Student Full Name: ");
            string name = Console.ReadLine();

            ExecuteAndLogCommand("Get Teachers For Student query", () =>
                _dbHandler.GetTeachersForStudent(name));
        }

        private void GetClassesByParentEmail()
        {
            Console.Write("Enter Parent Email: ");
            string email = Console.ReadLine();

            ExecuteAndLogCommand("Get Classes By Parent Email query", () =>
                _dbHandler.GetClassesByParentEmail(email));
        }

        private void ExecuteAndLogCommand(string commandName, Action dbAction)
        {
            dbAction.Invoke();

            string logDirectory = "../../../logs";

            _txtLogger.Log(new List<string> { $"{commandName} executed" },
                Path.Combine(logDirectory, "DatabaseLogs.txt"));

            _excelLogger.Log(new List<string> { $"{commandName} executed" },
                Path.Combine(logDirectory, "DatabaseLogs.xlsx"));
        }
        private static int GetIntInput(string prompt)
        {
            int result;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (int.TryParse(input, out result))
                    return result;
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }

        private static DateTime GetDateInput(string prompt)
        {
            DateTime result;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (DateTime.TryParse(input, out result))
                    return result;
                Console.WriteLine("Invalid date format. Please enter a valid date.");
            }
        }
    }
}
