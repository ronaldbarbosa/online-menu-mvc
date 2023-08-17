using Microsoft.EntityFrameworkCore;
using OnlineMenu.Data;
using OnlineMenu.Models;

namespace OnlineMenu.Services
{
    public class ProductsService
    {
        private readonly OnlineMenuDbContext _dbContext;

        public ProductsService(OnlineMenuDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateProductAsync(Product product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Product> GetProductAsync(Guid id)
        {
            return await _dbContext.Products.Include(obj => obj.Category).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _dbContext.Products.Include(obj => obj.Category).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(Category category)
        {
            return await _dbContext.Products.Where(obj => obj.Category == category).ToListAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(Product product)
        {
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
        }
    }
}
