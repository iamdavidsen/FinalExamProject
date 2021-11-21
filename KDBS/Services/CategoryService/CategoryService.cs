using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KDBS.Data;
using Microsoft.EntityFrameworkCore;

namespace KDBS.Services.CategoryService
{
    internal class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<CategoryModel>> GetCategories()
        {
            return _dbContext.Categories.ToListAsync();
        }

        public Task<CategoryModel> GetCategory(string categoryId)
        {
            return _dbContext.Categories.Where(c => c.CategoryId == categoryId).FirstOrDefaultAsync();
        }

        public async Task CreateCategory(CategoryModel categoryModel)
        {
            await _dbContext.Categories.AddAsync(categoryModel);
            await _dbContext.SaveChangesAsync();
        }

        public Task EditCategory(CategoryModel categoryModel)
        {
            _dbContext.Categories.Update(categoryModel);
            return _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCategory(string categoryId)
        {
            var category = await GetCategory(categoryId);

            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();
        }
    }
}
