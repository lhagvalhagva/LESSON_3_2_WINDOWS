using Microsoft.EntityFrameworkCore;
using POS.Core.Models;
using POS.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task<bool> CreateCategoryAsync(Category category);
        Task<bool> UpdateCategoryAsync(Category category);
        Task<bool> DeleteCategoryAsync(int id);
    }

    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories
                .Where(c => c.IsActive)
                .ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _context.Categories
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> CreateCategoryAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            _context.Categories.Update(category);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return false;

            // Check if there are products in this category
            var hasProducts = await _context.Products.AnyAsync(p => p.CategoryId == id && p.IsActive);
            if (hasProducts)
                return false;

            // Soft delete
            category.IsActive = false;
            return await _context.SaveChangesAsync() > 0;
        }
    }
} 