using Microsoft.EntityFrameworkCore;
using System;
using TVShow.Data;
using TVShow.Data.Models;

namespace TVShow.Core.Services
{
    public class ShowService
    {
        private readonly TVShowDbContext _context;

        public ShowService(TVShowDbContext context)
        {
            _context = context;
        }

        public async Task<Show> AddAsync(Show show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            _context.Shows.Add(show);
            await _context.SaveChangesAsync();
            return show;
        }

        public async Task<IEnumerable<Show>> GetAllAsync()
        {
            return await _context.Shows
                .Include(s => s.Quizzes)
                .Include(s => s.Contestants)
                .ToListAsync();
        }

        public async Task<Show> GetByIdAsync(int id)
        {
            return await _context.Shows
                .Include(s => s.Quizzes)
                .Include(s => s.Contestants)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task UpdateAsync(Show show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            var existing = await _context.Shows.FindAsync(show.Id);
            if (existing == null)
                throw new KeyNotFoundException("Show not found");

            existing.Name = show.Name;
            existing.AirDate = show.AirDate;
            existing.Description = show.Description;

            _context.Shows.Update(existing);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await _context.Shows.FindAsync(id);
            if (existing == null)
                throw new KeyNotFoundException("Show not found");

            _context.Shows.Remove(existing);
            await _context.SaveChangesAsync();
        }
    }
}
