using MarketVault.Infrastructure.DbContexts;
using MarketVault.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketVault.Core.Services
{
    public class CategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddCategoryAsync(Category category)
        {
            try
            {
                if (category == null)
                    throw new ArgumentNullException(nameof(category));

                await _context.Categories.AddAsync(category);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Cannot add category!", ex);
            }
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            try
            {
                return await _context.Categories
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error fetching categories.", ex);
            }
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            try
            {
                if (category == null)
                    throw new ArgumentNullException(nameof(category));

                _context.Categories.Update(category);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Cannot update category!", ex);
            }
        }

        public async Task DeleteCategoryAsync(int id)
        {
            try
            {
                var category = await _context.Categories
                    .FirstOrDefaultAsync(c => c.CategoryId == id);

                if (category == null)
                    throw new ArgumentException("Category not found!");

                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Cannot remove category!", ex);
            }
        }

        public async Task<IEnumerable<Category>> GetCategoriesByTotalStockAsync()
        {
            try
            {
                return await _context.Categories
                    .OrderByDescending(c => c.Products.Sum(p => p.Quantity))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Cannot fetch categories by total stock.", ex);
            }
        }
    }
}
