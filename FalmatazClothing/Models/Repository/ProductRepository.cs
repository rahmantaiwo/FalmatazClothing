using FalmatazClothing.Entities;
using FalmatazClothing.Models.IRepository;
using Microsoft.EntityFrameworkCore;

namespace FalmatazClothing.Models.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Product>> GetAllProductAsync()
        {
            return await _dbContext.Products.Include(p => p.MaterialType). ToListAsync();
        }

        public Task<Product> GetProductAsync(Guid id)
        {
            return _dbContext.Products
                .Where(m => m.Id == id)
                .Include(m => m.MaterialType)
                .FirstOrDefaultAsync();
        }
    }
}
