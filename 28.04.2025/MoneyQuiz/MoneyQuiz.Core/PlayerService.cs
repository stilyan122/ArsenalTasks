using Microsoft.EntityFrameworkCore;
using MoneyQuiz.Data;
using MoneyQuiz.Data.Models;

namespace MoneyQuiz.Core
{
    public class PlayerService
    {
        private readonly MoneyQuizDbContext _context;

        public PlayerService(MoneyQuizDbContext context)
        {
            _context = context;
        }

        public async Task AddPlayerAsync(string name, string email)
        {
            var player = new Player
            {
                Name = name,
                Email = email
            };

            await _context.Players.AddAsync(player);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Player>> GetAllPlayersAsync()
        {
            return await _context.Players
                .Include(p => p.PlayerGameSessions)
                .ToListAsync();
        }

        public async Task<Player> GetPlayerByIdAsync(int id)
        {
            return await _context.Players
                .Include(p => p.PlayerGameSessions)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdatePlayerAsync(int id, string newName, string newEmail)
        {
            var player = await _context.Players.FindAsync(id);
            if (player != null)
            {
                player.Name = newName;
                player.Email = newEmail;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeletePlayerAsync(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player != null)
            {
                _context.Players.Remove(player);
                await _context.SaveChangesAsync();
            }
        }
    }
}
