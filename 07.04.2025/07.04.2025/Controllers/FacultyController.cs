using Data.Models;
using Data;
using Microsoft.EntityFrameworkCore;

namespace Controllers
{
    public class FacultyController
    {
        private readonly UniversityContext _context;

        public FacultyController(UniversityContext context)
        {
            _context = context;
        }

        public async Task AddFaculty(string name, int universityId)
        {
            var faculty = new Faculty 
            { 
                Name = name, 
                UniversityId = universityId
            };

            await _context.Faculties.AddAsync(faculty);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Faculty>> GetFacultiesByUniversityId(int universityId) =>
            await _context.Faculties
            .Where(f => f.UniversityId == universityId)
            .ToListAsync();

        public async Task<List<Faculty>> GetFacultiesByName(string name) =>
            await _context.Faculties  
            .Where(f => f.Name == name)
            .ToListAsync();

        public async Task<Faculty?> GetFacultyByNameAndUniversityId(string name, int universityId) =>
            await _context.Faculties
            .FirstOrDefaultAsync(f => f.Name == name && f.UniversityId == universityId);
    }
}