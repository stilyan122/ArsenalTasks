using Microsoft.EntityFrameworkCore;
using System;
using TVShow.Data;
using TVShow.Data.Models;

namespace TVShow.Core.Services
{
    public class ContestantService
    {
        private readonly TVShowDbContext _context;

        public ContestantService(TVShowDbContext context)
        {
            _context = context;
        }

        public async Task<Contestant> AddAsync(Contestant contestant)
        {
            if (contestant == null)
                throw new ArgumentNullException(nameof(contestant));

            _context.Contestants.Add(contestant);
            await _context.SaveChangesAsync();
            return contestant;
        }

        public async Task<IEnumerable<Contestant>> GetAllAsync()
        {
            return await _context.Contestants
                .Include(c => c.Shows)
                .ToListAsync();
        }

        public async Task<Contestant> GetByIdAsync(int id)
        {
            return await _context.Contestants
                .Include(c => c.Shows)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Contestant contestant)
        {
            if (contestant == null)
                throw new ArgumentNullException(nameof(contestant));

            var existing = await _context.Contestants.FindAsync(contestant.Id);
            if (existing == null)
                throw new KeyNotFoundException("Contestant not found");

            existing.FullName = contestant.FullName;
            existing.Age = contestant.Age;
            existing.ContactEmail = contestant.ContactEmail;
            existing.PhoneNumber = contestant.PhoneNumber;

            _context.Contestants.Update(existing);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await _context.Contestants.FindAsync(id);
            if (existing == null)
                throw new KeyNotFoundException("Contestant not found");

            _context.Contestants.Remove(existing);
            await _context.SaveChangesAsync();
        }

        public async Task AssignToShowAsync(int contestantId, int showId)
        {
            var contestant = await _context.Contestants
                .Include(c => c.Shows)
                .FirstOrDefaultAsync(c => c.Id == contestantId);

            var show = await _context.Shows
                .Include(s => s.Contestants)
                .FirstOrDefaultAsync(s => s.Id == showId);

            if (contestant == null || show == null)
                throw new KeyNotFoundException("Contestant или Show не са намерени.");

            if (!contestant.Shows.Contains(show))
            {
                contestant.Shows.Add(show);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveFromShowAsync(int contestantId, int showId)
        {
            var contestant = await _context.Contestants
                .Include(c => c.Shows)
                .FirstOrDefaultAsync(c => c.Id == contestantId);

            var show = await _context.Shows
                .Include(s => s.Contestants)
                .FirstOrDefaultAsync(s => s.Id == showId);

            if (contestant == null || show == null)
                throw new KeyNotFoundException("Contestant или Show не са намерени.");

            if (contestant.Shows.Contains(show))
            {
                contestant.Shows.Remove(show);
                await _context.SaveChangesAsync();
            }
        }
    }
}
