using Microsoft.EntityFrameworkCore;
using MoneyQuiz.Data;
using MoneyQuiz.Data.Models;

namespace MoneyQuiz.Core
{
    public class AnswerService
    {
        private readonly MoneyQuizDbContext _context;

        public AnswerService(MoneyQuizDbContext context)
        {
            _context = context;
        }

        public async Task AddAnswerAsync(int questionId, string answerText, bool isCorrect)
        {
            var answer = new Answer
            {
                QuestionId = questionId,
                AnswerText = answerText,
                IsCorrect = isCorrect
            };

            await _context.Answers.AddAsync(answer);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Answer>> GetAllAnswersAsync()
        {
            return await _context.Answers
                .Include(a => a.Question)
                .Include(a => a.PlayerAnswers)
                .ToListAsync();
        }

        public async Task<Answer> GetAnswerByIdAsync(int id)
        {
            return await _context.Answers
                .Include(a => a.Question)
                .Include(a => a.PlayerAnswers)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Answer>> GetAnswersByQuestionIdAsync(int questionId)
        {
            return await _context.Answers
                .Where(a => a.QuestionId == questionId)
                .Include(a => a.PlayerAnswers)
                .ToListAsync();
        }

        public async Task<List<Answer>> GetCorrectAnswersByQuestionIdAsync(int questionId)
        {
            return await _context.Answers
                .Where(a => a.QuestionId == questionId && a.IsCorrect)
                .Include(a => a.PlayerAnswers)
                .ToListAsync();
        }

        public async Task UpdateAnswerAsync(int id, string answerText, bool isCorrect)
        {
            var answer = await _context.Answers.FindAsync(id);
            if (answer != null)
            {
                answer.AnswerText = answerText;
                answer.IsCorrect = isCorrect;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAnswerAsync(int id)
        {
            var answer = await _context.Answers.FindAsync(id);
            if (answer != null)
            {
                _context.Answers.Remove(answer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
