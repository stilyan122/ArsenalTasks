using Microsoft.EntityFrameworkCore;
using TVShow.Data;
using TVShow.Data.Models;

namespace TVShow.Core.Services
{
    public class QuizService
    {
        private readonly TVShowDbContext _context;

        public QuizService(TVShowDbContext context)
        {
            _context = context;
        }

        public async Task<Quiz> AddAsync(Quiz quiz)
        {
            if (quiz == null)
                throw new ArgumentNullException(nameof(quiz));

            var showExists = await _context.Shows
                .AnyAsync(s => s.Id == quiz.ShowId);

            if (!showExists)
                throw new KeyNotFoundException("Show със зададеното ID не съществува.");

            _context.Quizzes.Add(quiz);
            await _context.SaveChangesAsync();
            return quiz;
        }

        public async Task<IEnumerable<Quiz>> GetAllAsync()
        {
            return await _context.Quizzes
                .Include(q => q.Show)
                .Include(q => q.Questions)
                .ToListAsync();
        }

        public async Task<Quiz> GetByIdAsync(int id)
        {
            return await _context.Quizzes
                .Include(q => q.Show)
                .Include(q => q.Questions)
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task UpdateAsync(Quiz quiz)
        {
            if (quiz == null)
                throw new ArgumentNullException(nameof(quiz));

            var existing = await _context.Quizzes.FindAsync(quiz.Id);
            if (existing == null)
                throw new KeyNotFoundException("Quiz не е намерен.");

            existing.Title = quiz.Title;
            existing.Description = quiz.Description;

            if (existing.ShowId != quiz.ShowId)
            {
                var showExists = await _context.Shows.AnyAsync(s => s.Id == quiz.ShowId);
                if (!showExists)
                    throw new KeyNotFoundException("Show със зададеното ID не съществува.");
                existing.ShowId = quiz.ShowId;
            }

            _context.Quizzes.Update(existing);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await _context.Quizzes.FindAsync(id);
            if (existing == null)
                throw new KeyNotFoundException("Quiz не е намерен.");

            _context.Quizzes.Remove(existing);
            await _context.SaveChangesAsync();
        }
    }
}
