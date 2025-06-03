using Microsoft.EntityFrameworkCore;
using System;
using TVShow.Data;
using TVShow.Data.Models;

namespace TVShow.Core.Services
{
    public class QuestionService
    {
        private readonly TVShowDbContext _context;

        public QuestionService(TVShowDbContext context)
        {
            _context = context;
        }

        public async Task<Question> AddAsync(Question question)
        {
            if (question == null)
                throw new ArgumentNullException(nameof(question));

            var quizExists = await _context.Quizzes
                .AnyAsync(q => q.Id == question.QuizId);

            if (!quizExists)
                throw new KeyNotFoundException("Quiz със зададеното ID не съществува.");

            _context.Questions.Add(question);
            await _context.SaveChangesAsync();
            return question;
        }

        public async Task<IEnumerable<Question>> GetAllAsync()
        {
            return await _context.Questions
                .Include(q => q.Quiz)
                .ToListAsync();
        }

        public async Task<Question> GetByIdAsync(int id)
        {
            return await _context.Questions
                .Include(q => q.Quiz)
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task UpdateAsync(Question question)
        {
            if (question == null)
                throw new ArgumentNullException(nameof(question));

            var existing = await _context.Questions.FindAsync(question.Id);
            if (existing == null)
                throw new KeyNotFoundException("Question не е намерен.");

            existing.Text = question.Text;
            existing.OptionA = question.OptionA;
            existing.OptionB = question.OptionB;
            existing.OptionC = question.OptionC;
            existing.OptionD = question.OptionD;
            existing.CorrectAnswer = question.CorrectAnswer;

            if (existing.QuizId != question.QuizId)
            {
                var quizExists = await _context.Quizzes
                    .AnyAsync(q => q.Id == question.QuizId);

                if (!quizExists)
                    throw new KeyNotFoundException("Quiz със зададеното ID не съществува.");
                existing.QuizId = question.QuizId;
            }

            _context.Questions.Update(existing);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await _context.Questions.FindAsync(id);
            if (existing == null)
                throw new KeyNotFoundException("Question не е намерен.");

            _context.Questions.Remove(existing);
            await _context.SaveChangesAsync();
        }
    }
}
