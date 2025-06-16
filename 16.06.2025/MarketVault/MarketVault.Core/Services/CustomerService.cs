using MarketVault.Infrastructure.DbContexts;
using MarketVault.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketVault.Core.Services
{
    public class CustomerService
    {
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            try
            {
                if (customer == null)
                    throw new ArgumentNullException(nameof(customer));

                await _context.Customers.AddAsync(customer);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Cannot add customer!", ex);
            }
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            try
            {
                return await _context.Customers
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error fetching customers.", ex);
            }
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            try
            {
                if (customer == null)
                    throw new ArgumentNullException(nameof(customer));

                _context.Customers.Update(customer);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Cannot update customer!", ex);
            }
        }

        public async Task DeleteCustomerAsync(int id)
        {
            try
            {
                var customer = await _context.Customers
                    .FirstOrDefaultAsync(c => c.CustomerId == id);

                if (customer == null)
                    throw new ArgumentException("Customer not found!");

                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Cannot remove customer!", ex);
            }
        }

        public async Task<IEnumerable<Customer>> GetCustomersWithNoOrdersAsync()
        {
            try
            {
                return await _context.Customers
                    .Include(c => c.Orders)
                    .Where(c => c.Orders.Count() == 0)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Cannot fetch customers with no orders.", ex);
            }
        }
    }
}
