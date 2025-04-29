using MoneyQuiz.Data.Models;
using MoneyQuiz.Data;
using Microsoft.EntityFrameworkCore;

namespace MoneyQuiz.Core
{
    public class GameSessionService
    {
        private readonly MoneyQuizDbContext _context;

        public GameSessionService(MoneyQuizDbContext context)
        {
            _context = context;
        }

        public async Task AddGameSessionAsync(DateTime time, decimal finalAmount)
        {
            var gameSession = new GameSession
            {
                Time = time,
                FinalAmount = finalAmount
            };

            await _context.GameSessions.AddAsync(gameSession);
            await _context.SaveChangesAsync();
        }

        public async Task<List<GameSession>> GetAllGameSessionsAsync()
        {
            return await _context.GameSessions
                .Include(gs => gs.PlayerGameSessions)
                .ToListAsync();
        }

        public async Task<GameSession> GetGameSessionByIdAsync(int id)
        {
            return await _context.GameSessions
                .Include(gs => gs.PlayerGameSessions)
                .FirstOrDefaultAsync(gs => gs.Id == id);
        }

        public async Task UpdateGameSessionAsync(int id, DateTime? newTime, decimal newFinalAmount)
        {
            var gameSession = await _context.GameSessions.FindAsync(id);
            if (gameSession != null)
            {
                gameSession.Time = newTime.Value;
                gameSession.FinalAmount = newFinalAmount;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteGameSessionAsync(int id)
        {
            var gameSession = await _context.GameSessions.FindAsync(id);
            if (gameSession != null)
            {
                _context.GameSessions.Remove(gameSession);
                await _context.SaveChangesAsync();
            }
        }
    }
}
