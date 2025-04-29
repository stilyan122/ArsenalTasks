using Microsoft.EntityFrameworkCore;
using MoneyQuiz.Data.Models;
using MoneyQuiz.Data;

namespace MoneyQuiz.Core
{
    public class PlayerAnswerService
    {
        private readonly MoneyQuizDbContext _context;

        public PlayerAnswerService(MoneyQuizDbContext context)
        {
            _context = context;
        }

        public async Task AddPlayerAnswerAsync(int playerSessionId, int answerId, bool isCorrect)
        {
            var playerAnswer = new PlayerAnswer
            {
                PlayerSessionId = playerSessionId,
                AnswerId = answerId,
                IsCorrect = isCorrect
            };

            await _context.PlayerAnswers.AddAsync(playerAnswer);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PlayerAnswer>> GetAllPlayerAnswersAsync()
        {
            return await _context.PlayerAnswers
                .Include(pa => pa.PlayerSession)
                .Include(pa => pa.Answer)
                .ToListAsync();
        }

        public async Task<PlayerAnswer> GetPlayerAnswerByIdAsync(int id)
        {
            return await _context.PlayerAnswers
                .Include(pa => pa.PlayerSession)
                .Include(pa => pa.Answer)
                .FirstOrDefaultAsync(pa => pa.Id == id);
        }

        public async Task UpdatePlayerAnswerAsync(int id, bool isCorrect)
        {
            var playerAnswer = await _context.PlayerAnswers.FindAsync(id);
            if (playerAnswer != null)
            {
                playerAnswer.IsCorrect = isCorrect;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeletePlayerAnswerAsync(int id)
        {
            var playerAnswer = await _context.PlayerAnswers.FindAsync(id);
            if (playerAnswer != null)
            {
                _context.PlayerAnswers.Remove(playerAnswer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
