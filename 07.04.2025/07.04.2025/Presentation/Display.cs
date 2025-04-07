using Controllers;
using Data;

namespace Presentation
{
    public class Display
    {
        private readonly UniversityContext dbContext = new UniversityContext();

        private readonly UniversityController _universityController;
        private readonly FacultyController _facultyController;
        private readonly MajorController _majorController;

        public Display()
        {
            _universityController = new(dbContext);
            _facultyController = new(dbContext);
            _majorController = new(dbContext);
        }

        public async Task ShowMenu()
        {
            Console.WriteLine("Welcome to app!");
            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Add university");
                Console.WriteLine("2. Add faculty");
                Console.WriteLine("3. Add major");
                Console.WriteLine("4. Show all universities");
                Console.WriteLine("5. Show faculties by university ID");
                Console.WriteLine("6. Show majors by faculty ID");
                Console.WriteLine("7. Show university ID by name");
                Console.WriteLine("8. Show faculty ID and name by name");
                Console.WriteLine("9. Show major ID and name by name");
                Console.WriteLine("10. Exit");
                Console.Write("Enter choice: ");

                string? input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1": 
                        await InputUniversity(); 
                        break;
                    case "2":
                        await InputFaculty(); 
                        break;
                    case "3":
                        await InputMajor(); 
                        break;
                    case "4":
                        await GetAllUniversities(); 
                        break;
                    case "5":
                        await GetFacultiesByUniversityId(); 
                        break;
                    case "6":
                        await GetMajorsByFacultyId(); 
                        break;
                    case "7":
                        await GetUniversityIdByName(); 
                        break;
                    case "8":
                        await GetFacultyIdAndNameByName(); 
                        break;
                    case "9":
                        await GetMajorIdAndNameByName(); 
                        break;
                    case "10": 
                        return;
                    default: 
                        Console.WriteLine("Invalid option!"); 
                        break;
                }
            }
        }

        private async Task InputUniversity()
        {
            Console.Write("Enter university name: ");
            var name = Console.ReadLine();

            await _universityController.AddUniversity(name!);
        }

        private async Task InputFaculty()
        {
            Console.Write("Enter faculty name: ");
            var name = Console.ReadLine();
            Console.Write("Enter university ID: ");
            int universityId = int.Parse(Console.ReadLine()!);

            await _facultyController.AddFaculty(name!, universityId);
        }

        private async Task InputMajor()
        {
            Console.Write("Enter major name: ");
            var name = Console.ReadLine();
            Console.Write("Enter faculty ID: ");
            int facultyId = int.Parse(Console.ReadLine()!);
            await _majorController.AddMajor(name!, facultyId);
        }

        private async Task GetAllUniversities()
        {
            var universities = await _universityController.GetAllUniversities();

            foreach (var u in universities)
            {
                Console.WriteLine($"ID: {u.Id}, Name: {u.Name}");
            }
        }

        private async Task GetFacultiesByUniversityId()
        {
            Console.Write("Enter university ID: ");
            int universityId = int.Parse(Console.ReadLine()!);

            var faculties = await _facultyController
                .GetFacultiesByUniversityId(universityId);

            foreach (var f in faculties)
            {
                Console.WriteLine($"ID: {f.Id}, Name: {f.Name}");
            }
        }

        private async Task GetMajorsByFacultyId()
        {
            Console.Write("Enter faculty ID: ");
            int facultyId = int.Parse(Console.ReadLine()!);

            var majors = await _majorController.GetMajorsByFacultyId(facultyId);

            foreach (var m in majors)
            {
                Console.WriteLine($"ID: {m.Id}, Name: {m.Name}");
            }
        }

        private async Task GetUniversityIdByName()
        {
            Console.Write("Enter university name: ");
            var name = Console.ReadLine();
            var id = await _universityController.GetUniversityIdByName(name!);

            if (id == null)
            {
                Console.WriteLine("Uni with that id - not found.");
            }
            else
            {
                Console.WriteLine($"ID: {id}");
            }
        }

        private async Task GetFacultyIdAndNameByName()
        {
            Console.Write("Enter faculty name: ");
            var name = Console.ReadLine();

            var faculties = await _facultyController.GetFacultiesByName(name!);

            foreach (var f in faculties)
            {
                Console.WriteLine($"ID: {f.Id}, Name: {f.Name}");
            }
        }

        private async Task GetMajorIdAndNameByName()
        {
            Console.Write("Enter major name: ");
            var name = Console.ReadLine();

            var majors = await _majorController.GetMajorsByName(name!);

            foreach (var m in majors)
            {
                Console.WriteLine($"ID: {m.Id}, Name: {m.Name}");
            }
        }
    }
}
