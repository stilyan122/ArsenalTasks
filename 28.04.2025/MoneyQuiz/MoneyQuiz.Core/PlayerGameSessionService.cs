using Microsoft.EntityFrameworkCore;
using MoneyQuiz.Data.Models;
using MoneyQuiz.Data;

namespace MoneyQuiz.Core
{
    public class PlayerGameSessionService
    {
        private readonly MoneyQuizDbContext _context;

        public PlayerGameSessionService(MoneyQuizDbContext context)
        {
            _context = context;
        }

        public async Task AddPlayerGameSessionAsync(int playerId, int sessionId)
        {
            var playerGameSession = new PlayerGameSession
            {
                PlayerId = playerId,
                SessionId = sessionId
            };

            await _context.PlayerGameSessions.AddAsync(playerGameSession);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PlayerGameSession>> GetAllPlayerGameSessionsAsync()
        {
            return await _context.PlayerGameSessions
                .Include(pgs => pgs.Player)
                .Include(pgs => pgs.Session)
                .Include(pgs => pgs.PlayerAnswers)
                .Include(pgs => pgs.Lifelines)
                .ToListAsync();
        }

        public async Task<PlayerGameSession> GetPlayerGameSessionByIdAsync(int id)
        {
            return await _context.PlayerGameSessions
                .Include(pgs => pgs.Player)
                .Include(pgs => pgs.Session)
                .Include(pgs => pgs.PlayerAnswers)
                .Include(pgs => pgs.Lifelines)
                .FirstOrDefaultAsync(pgs => pgs.Id == id);
        }

        public async Task UpdatePlayerGameSessionAsync(int id, int playerId, int sessionId)
        {
            var playerGameSession = await _context.PlayerGameSessions.FindAsync(id);
            if (playerGameSession != null)
            {
                playerGameSession.PlayerId = playerId;
                playerGameSession.SessionId = sessionId;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeletePlayerGameSessionAsync(int id)
        {
            var playerGameSession = await _context.PlayerGameSessions.FindAsync(id);
            if (playerGameSession != null)
            {
                _context.PlayerGameSessions.Remove(playerGameSession);
                await _context.SaveChangesAsync();
            }
        }
    }
}
