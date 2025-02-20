    using FalmatazClothing.Entities;
using FalmatazClothing.Enum;
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
            return await _dbContext.Products.Include(p => p.MaterialType).ToListAsync();
        }

        public async Task<Product> GetProductAsync(Guid id)
        {
            return await _dbContext.Products.Where(m => m.Id == id).Include(m => m.MaterialType).FirstOrDefaultAsync();
        }

        public async Task<Product?> GetProductTypeByNameAsync(ProductStyles style)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(c => c.Style == style);
        }
    }
}


