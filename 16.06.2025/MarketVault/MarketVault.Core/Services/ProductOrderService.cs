using MarketVault.Infrastructure.DbContexts;
using MarketVault.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketVault.Core.Services
{
    public class ProductOrderService
    {
        private readonly ApplicationDbContext _context;

        public ProductOrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddProductOrderAsync(ProductOrder productOrder)
        {
            try
            {
                if (productOrder == null)
                    throw new ArgumentNullException(nameof(productOrder));

                await _context.ProductOrders.AddAsync(productOrder);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Cannot add product order!", ex);
            }
        }

        public async Task<IEnumerable<ProductOrder>> GetAllProductOrdersAsync()
        {
            try
            {
                return await _context.ProductOrders
                    .Include(po => po.Product)  
                    .Include(po => po.Order)    
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error fetching product orders.", ex);
            }
        }

        public async Task UpdateProductOrderAsync(ProductOrder productOrder)
        {
            try
            {
                if (productOrder == null)
                    throw new ArgumentNullException(nameof(productOrder));

                _context.ProductOrders.Update(productOrder);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Cannot update product order!", ex);
            }
        }

        public async Task DeleteProductOrderAsync(int id)
        {
            try
            {
                var productOrder = await _context.ProductOrders
                    .FirstOrDefaultAsync(po => po.Id == id);

                if (productOrder == null)
                    throw new ArgumentException("Product order not found!");

                _context.ProductOrders.Remove(productOrder);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Cannot remove product order!", ex);
            }
        }
    }
}
