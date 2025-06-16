using MarketVault.Infrastructure.DbContexts;
using MarketVault.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketVault.Core.Services
{
    public class ProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddProductAsync(Product product)
        {
            try
            {
                if (product == null) 
                    throw new ArgumentNullException(nameof(product));

                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Cannot add product!", ex);
            }
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            try
            {
                return await _context.Products
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error fetching products!", ex);
            }
        }

        public async Task UpdateProductAsync(Product product)
        {
            try
            {
                if (product == null) 
                    throw new ArgumentNullException(nameof(product));

                _context.Products.Update(product);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Cannot update product!", ex);
            }
        }

        public async Task DeleteProductAsync(int id)
        {
            try
            {
                var product = await _context.Products
                    .FirstOrDefaultAsync(p => p.ProductId == id);

                if (product == null) 
                    throw new ArgumentException("Product not found!");

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Cannot remove product!", ex);
            }
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            try
            {
                return await _context.Products
                    .Where(p => p.CategoryId == categoryId)
                    .Include(p => p.Category)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Cannot fetch products by category.", ex);
            }
        }

        public async Task<IEnumerable<Product>> GetProductsBelowStockAsync(int threshold)
        {
            try
            {
                return await _context.Products
                    .Where(p => p.Quantity < threshold)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Cannot fetch low-stock products.", ex);
            }
        }

        public async Task<IEnumerable<Product>> GetProductsNeverOrderedAsync()
        {
            try
            {
                return await _context.Products
                    .Include(p => p.ProductOrders)
                    .Where(p => p.ProductOrders.Count() == 0)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Cannot fetch never-ordered products.", ex);
            }
        }

        public async Task<IEnumerable<Product>> GetProductsInOrderAsync(int orderId)
        {
            try
            {
                return await _context.ProductOrders
                    .Where(po => po.OrderId == orderId)
                    .Include(po => po.Product)
                    .Select(po => po.Product)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Cannot fetch products in order.", ex);
            }
        }

        public async Task<IEnumerable<Product>> GetProductsBySupplierAsync(int supplierId)
        {
            try
            {
                return await _context.ProductSuppliers
                    .Where(ps => ps.SupplierId == supplierId)
                    .Include(ps => ps.Product)
                    .Select(ps => ps.Product)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Cannot fetch products for supplier.", ex);
            }
        }
    }
}
