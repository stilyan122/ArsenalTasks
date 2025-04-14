using HotelManager.Data;
using HotelManager.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManager.Controllers
{
    public class HotelController
    {
        private readonly HotelManagerContext _context;

        public HotelController(HotelManagerContext context)
        {
            _context = context;
        }

        public async Task<List<string>> GetAllGuestNames()
        {
            return await _context.Guests
                .Select(g => $"{g.FirstName} {g.LastName}")
                .ToListAsync();
        }

        public async Task AddGuest(string firstName, string lastName, string ucn, string phone)
        {
            var guest = new Guest 
            { 
                FirstName = firstName, 
                LastName = lastName,
                Ucn = ucn,
                PhoneNumber = phone
            };

            await _context.Guests.AddAsync(guest);
            await _context.SaveChangesAsync();
        }

        public async Task<List<int>> GetRoomsByPriceRange()
        {
            return await _context.Rooms
                .Where(r => r.Price >= 80 && r.Price <= 100)
                .OrderByDescending(r => r.Price)
                .Select(r => r.Number)
                .ToListAsync();
        }

        public async Task<bool> DeleteReservation(int id)
        {
            var reservation = _context.Reservations.FirstOrDefault(r => r.Id == id);

            if (reservation == null) 
                return false;

            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<int> GetFreeRoomCount()
        {
            return await _context.Rooms
                .CountAsync(r => r.Status == "free");
        }

        public async Task<decimal> GetMinPriceByStatus(string status)
        {
            return await  _context.Rooms
                .Where(r => r.Status == status)
                .Select(r => r.Price)
                .MinAsync();
        }

        public async Task<List<int>> GetActiveReservationIds()
        {
            return await _context.Reservations
                .Where(r => r.ReleaseDate >= DateOnly.FromDateTime(DateTime.Now))
                .Select(r => r.Id)
                .ToListAsync();
        }
    }
}
