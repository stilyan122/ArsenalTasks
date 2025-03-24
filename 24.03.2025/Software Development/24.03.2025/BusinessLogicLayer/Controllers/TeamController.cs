using DataLayer.Data;
using DataLayer.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogicLayer.Controllers
{
    public class TeamController
    {
        private TeamsContext context;

        public TeamController(TeamsContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Team>> GetAllTeams()
        {
            return await this.context
                .Teams
                .ToListAsync();
        }

        public async Task<Team?> GetTeamById(int id)
        {
            return await this.context
                .Teams
                .FirstOrDefaultAsync(t => t.TeamId == id);
        }

        public async Task<IEnumerable<Team>> GetTeamsByCountry(string country)
        {
            return await this.context
                .Teams
                .Where(t => t.Country == country)
                .ToListAsync();
        }

        public async Task<Team?> GetOldestTeam()
        {
            return await this.context
                .Teams
                .OrderBy(t => t.FoundationYear)
                .FirstOrDefaultAsync();
        }
    }
}
