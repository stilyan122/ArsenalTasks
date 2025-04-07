using Data.Models;
using Data;
using Microsoft.EntityFrameworkCore;

namespace Controllers
{
    public class UniversityController
    {
        private readonly UniversityContext _context;

        public UniversityController(UniversityContext context)
        {
            _context = context;
        }

        public async Task AddUniversity(string name)
        {
            var university = new University 
            { 
                Name = name 
            };

            await _context.Universities.AddAsync(university);
            await _context.SaveChangesAsync();
        }

        public async Task<List<University>> GetAllUniversities() => await 
            _context.Universities
            .ToListAsync();

        public async Task<University?> GetUniversityByName(string name) =>
            await _context.Universities
            .FirstOrDefaultAsync(u => u.Name == name);

        public async Task<int?> GetUniversityIdByName(string name) 
        {
            var university = await _context.Universities
                .FirstOrDefaultAsync(u => u.Name == name);

            return university?.Id;
        }
    }
}
