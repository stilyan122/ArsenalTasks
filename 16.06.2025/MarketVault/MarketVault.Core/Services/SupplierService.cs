using MarketVault.Infrastructure.DbContexts;
using MarketVault.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketVault.Core.Services
{
    public class SupplierService
    {
        private readonly ApplicationDbContext _context;

        public SupplierService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddSupplierAsync(Supplier supplier)
        {
            try
            {
                if (supplier == null)
                    throw new ArgumentNullException(nameof(supplier));

                await _context.Suppliers.AddAsync(supplier);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Cannot add supplier!", ex);
            }
        }

        public async Task<IEnumerable<Supplier>> GetAllSuppliersAsync()
        {
            try
            {
                return await _context.Suppliers
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error fetching suppliers.", ex);
            }
        }

        public async Task UpdateSupplierAsync(Supplier supplier)
        {
            try
            {
                if (supplier == null)
                    throw new ArgumentNullException(nameof(supplier));

                _context.Suppliers.Update(supplier);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Cannot update supplier!", ex);
            }
        }

        public async Task DeleteSupplierAsync(int id)
        {
            try
            {
                var supplier = await _context.Suppliers
                    .FirstOrDefaultAsync(s => s.SupplierId == id);

                if (supplier == null)
                    throw new ArgumentException("Supplier not found!");

                _context.Suppliers.Remove(supplier);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Cannot remove supplier!", ex);
            }
        }

        public async Task<IEnumerable<Supplier>> GetSuppliersByProductAsync(int productId)
        {
            try
            {
                return await _context.ProductSuppliers
                    .Where(ps => ps.ProductId == productId)
                    .Include(ps => ps.Supplier)
                    .Select(ps => ps.Supplier)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Cannot fetch suppliers for product.", ex);
            }
        }

        public async Task<IEnumerable<Supplier>> GetSuppliersWithNoProductsAsync()
        {
            try
            {
                return await _context.Suppliers
                    .Where(s => !_context.ProductSuppliers
                        .Any(ps => ps.SupplierId == s.SupplierId))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Cannot fetch suppliers with no products.", ex);
            }
        }

        public async Task<IEnumerable<Supplier>> GetSuppliersByEmailDomainAsync(string domain)
        {
            try
            {
                return await _context.Suppliers
                    .Where(s => s.Email.EndsWith(domain))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Cannot fetch suppliers by email domain.", ex);
            }
        }
    }
}
