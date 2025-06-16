using MarketVault.Infrastructure.DbContexts;
using MarketVault.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketVault.Core.Services
{
    public class ProductSupplierService
    {
        private readonly ApplicationDbContext _context;

        public ProductSupplierService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddProductSupplierAsync(ProductSupplier productSupplier)
        {
            try
            {
                if (productSupplier == null)
                    throw new ArgumentNullException(nameof(productSupplier));

                await _context.ProductSuppliers.AddAsync(productSupplier);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Cannot add product supplier!", ex);
            }
        }

        public async Task<IEnumerable<ProductSupplier>> GetAllProductSuppliersAsync()
        {
            try
            {
                return await _context.ProductSuppliers
                    .Include(ps => ps.Product)   
                    .Include(ps => ps.Supplier) 
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error fetching product suppliers.", ex);
            }
        }

        public async Task UpdateProductSupplierAsync(ProductSupplier productSupplier)
        {
            try
            {
                if (productSupplier == null)
                    throw new ArgumentNullException(nameof(productSupplier));

                _context.ProductSuppliers.Update(productSupplier);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Cannot update product supplier!", ex);
            }
        }

        public async Task DeleteProductSupplierAsync(int id)
        {
            try
            {
                var productSupplier = await _context.ProductSuppliers
                    .FirstOrDefaultAsync(ps => ps.Id == id);

                if (productSupplier == null)
                    throw new ArgumentException("Product supplier not found!");

                _context.ProductSuppliers.Remove(productSupplier);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Cannot remove product supplier!", ex);
            }
        }
    }
}
