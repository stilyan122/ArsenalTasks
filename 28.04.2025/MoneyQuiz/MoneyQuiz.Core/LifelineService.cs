using Microsoft.EntityFrameworkCore;
using MoneyQuiz.Data;
using MoneyQuiz.Data.Models;

namespace MoneyQuiz.Core
{
    public class LifelineService
    {
        private readonly MoneyQuizDbContext _context;

        public LifelineService(MoneyQuizDbContext context)
        {
            _context = context;
        }

        public async Task AddLifelineAsync(int playerGameSessionId, string type, int usedOnQuestionId)
        {
            var lifeline = new Lifeline
            {
                PlayerGameSessionId = playerGameSessionId,
                Type = type,
                UsedOnQuestionId = usedOnQuestionId
            };

            await _context.Lifelines.AddAsync(lifeline);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Lifeline>> GetAllLifelinesAsync()
        {
            return await _context.Lifelines
                .Include(l => l.PlayerGameSession)
                .Include(l => l.UsedOnQuestion)
                .ToListAsync();
        }

        public async Task<Lifeline> GetLifelineByIdAsync(int id)
        {
            return await _context.Lifelines
                .Include(l => l.PlayerGameSession)
                .Include(l => l.UsedOnQuestion)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<List<Lifeline>> GetLifelinesByPlayerGameSessionIdAsync(int playerGameSessionId)
        {
            return await _context.Lifelines
                .Where(l => l.PlayerGameSessionId == playerGameSessionId)
                .Include(l => l.UsedOnQuestion)
                .ToListAsync();
        }

        public async Task UpdateLifelineAsync(int id, string newType)
        {
            var lifeline = await _context.Lifelines.FindAsync(id);
            if (lifeline != null)
            {
                lifeline.Type = newType;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteLifelineAsync(int id)
        {
            var lifeline = await _context.Lifelines.FindAsync(id);
            if (lifeline != null)
            {
                _context.Lifelines.Remove(lifeline);
                await _context.SaveChangesAsync();
            }
        }
    }
}
