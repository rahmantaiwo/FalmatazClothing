using FalmatazClothing.Entities;
using FalmatazClothing.Models.IRepository;
using Microsoft.EntityFrameworkCore;

namespace FalmatazClothing.Models.Repository
{
    public class CartItemRepository :ICartItemRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CartItemRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CartItem>> GetAllCartItemAsync()
        {
            return await _dbContext.CartItems.Include(c => c.Product).ToListAsync();
        }

        public async Task<CartItem> GetCartItemAsync(Guid id)
        {
            return await _dbContext.CartItems.Where(c => c.Id == id).FirstOrDefaultAsync();
        }
    }
}
