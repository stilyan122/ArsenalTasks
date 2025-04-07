using Data.Models;
using Data;
using Microsoft.EntityFrameworkCore;

namespace Controllers
{
    public class MajorController
    {
        private readonly UniversityContext _context;

        public MajorController(UniversityContext context)
        {
            _context = context;
        }
        public async Task AddMajor(string name, int facultyId)
        {
            var major = new Major 
            { 
                Name = name, 
                FacultyId = facultyId 
            };

            await _context.Majors.AddAsync(major);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Major>> GetMajorsByFacultyId(int facultyId) =>
            await _context.Majors
            .Where(m => m.FacultyId == facultyId)
            .ToListAsync();

        public async Task<List<Major>> GetMajorsByName(string name) =>
            await _context.Majors
            .Where(m => m.Name == name)
            .ToListAsync();

        public async Task<Major?> GetMajorByNameAndFacultyId(string name, int facultyId) =>
            await _context.Majors
            .FirstOrDefaultAsync(m => m.Name == name && m.FacultyId == facultyId);
    }
}
