using DataLayer.Data;
using DataLayer.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogicLayer.Controllers
{
    public class DriverController
    {
        private TeamsContext context;

        public DriverController(TeamsContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Driver>> GetAllDrivers()
        {
            return await this.context
                .Drivers
                .Include(d => d.Team)
                .ToListAsync();
        }

        public async Task<Driver?> GetDriverById(int id)
        {
            return await this.context
                .Drivers
                .Include(d => d.Team)
                .FirstOrDefaultAsync(d => d.DriverId == id);
        }

        public async Task<Driver?> GetDriverByLastName(string lastName)
        {
            return await this.context
                .Drivers
                .Include(d => d.Team)
                .FirstOrDefaultAsync(d => d.LastName == lastName);
        }

        public async Task<IEnumerable<Driver>> GetDriversByNationality(string 
            nationality)
        {
            return await this.context
                .Drivers
                .Include(d => d.Team)
                .Where(d => d.Nationality == nationality)
                .ToListAsync();
        }
    }
}
