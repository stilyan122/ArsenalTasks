using MarketVault.Infrastructure.DbContexts;
using MarketVault.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketVault.Core.Services
{
    public class OrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddOrderAsync(Order order)
        {
            try
            {
                if (order == null)
                    throw new ArgumentNullException(nameof(order));

                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Cannot add order!", ex);
            }
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            try
            {
                return await _context.Orders
                    .Include(o => o.Customer)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error fetching orders.", ex);
            }
        }

        public async Task UpdateOrderAsync(Order order)
        {
            try
            {
                if (order == null)
                    throw new ArgumentNullException(nameof(order));

                _context.Orders.Update(order);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Cannot update order!", ex);
            }
        }

        public async Task DeleteOrderAsync(int id)
        {
            try
            {
                var order = await _context.Orders
                    .FirstOrDefaultAsync(o => o.OrderId == id);

                if (order == null)
                    throw new ArgumentException("Order not found!");

                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Cannot remove order!", ex);
            }
        }

        public async Task<IEnumerable<Order>> GetCustomerOrdersAsync(int customerId)
        {
            try
            {
                return await _context.Orders
                    .Where(o => o.CustomerId == customerId)
                    .Include(o => o.Customer)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Cannot fetch orders for customer.", ex);
            }
        }

        public async Task<IEnumerable<Order>> GetOrdersOrderedByDateAsync()
        {
            try
            {
                return await _context.Orders
                    .OrderBy(o => o.OrderDate)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Cannot fetch orders ordered by date.", ex);
            }
        }
    }
}