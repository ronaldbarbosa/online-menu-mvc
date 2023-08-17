using Microsoft.EntityFrameworkCore;
using OnlineMenu.Data;
using OnlineMenu.Models;

namespace OnlineMenu.Services
{
    public class CategoriesService
    {
        private readonly OnlineMenuDbContext _dbContext;
        private readonly ProductsService _productsService;

        public CategoriesService(OnlineMenuDbContext dbContext, ProductsService productsService)
        {
            _dbContext = dbContext;
            _productsService = productsService;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _dbContext.Category.ToListAsync();
        }

        public async Task<Category> GetCategoryAsync(Guid id)
        {
            return await _dbContext.Category.FindAsync(id);
        }

        public async Task CreateCategoryAsync(Category category)
        {
            _dbContext.Category.Add(category);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            _dbContext.Category.Update(category);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(Category category)
        {
            var hasProducts = await CategoryHasProductsAsync(category);
            if (!hasProducts)
            {
                _dbContext.Category.Remove(category);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<bool> CategoryHasProductsAsync(Category category)
        {
            var products = await _productsService.GetProductsByCategoryAsync(category);
            if (products.Count() > 0) 
            {
                return true;
            }
            return false;
        }
    }
}
