using Microsoft.EntityFrameworkCore;
using MoneyQuiz.Data;
using MoneyQuiz.Data.Models;

namespace MoneyQuiz.Core
{
    public class QuestionService
    {
        private readonly MoneyQuizDbContext _context;

        public QuestionService(MoneyQuizDbContext context)
        {
            _context = context;
        }

        public async Task AddQuestionAsync(string questionText, decimal amount)
        {
            var question = new Question
            {
                QuestionText = questionText,
                Amount = amount
            };

            await _context.Questions.AddAsync(question);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Question>> GetAllQuestionsAsync()
        {
            return await _context.Questions
                .Include(q => q.Answers)
                .ToListAsync();
        }

        public async Task<Question> GetQuestionByIdAsync(int id)
        {
            return await _context.Questions
                .Include(q => q.Answers)
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task UpdateQuestionAsync(int id, string questionText, decimal amount)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question != null)
            {
                question.QuestionText = questionText;
                question.Amount = amount;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteQuestionAsync(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question != null)
            {
                _context.Questions.Remove(question);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Question>> GetQuestionsAboveAmountAsync(decimal amount)
        {
            return await _context.Questions
                .Where(q => q.Amount > amount)
                .Include(q => q.Answers)
                .ToListAsync();
        }

        public async Task<List<Question>> GetQuestionsByAmountWithCorrectAnswersAsync(decimal amount)
        {
            return await _context.Questions
                .Where(q => q.Amount == amount)
                .Include(q => q.Answers)
                .ToListAsync();
        }
    }
}
