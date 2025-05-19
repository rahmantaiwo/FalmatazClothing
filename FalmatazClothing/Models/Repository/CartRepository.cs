using FalmatazClothing.Entities;
using FalmatazClothing.Models.IRepository;
using Microsoft.EntityFrameworkCore;

namespace FalmatazClothing.Models.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CartRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Cart?> GetCartByUserIdAsync(string userId)
        {
            return await _dbContext.Carts
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }

        // Fetch the cart and a specific cart item (to be updated by CartService)
        public async Task<Cart?> AddToCartAsync(string userId, Guid productId, Guid quantity)
        {
            return await _dbContext.Carts
                .Include(c => c.CartItems.Where(ci => ci.ProductId == productId)) // Filter to specific item
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }

        // Fetch the cart and a specific cart item (to be removed by CartService)
        public async Task<Cart?> RemoveFromCartAsync(string userId, Guid productId)
        {
            return await _dbContext.Carts
                .Include(c => c.CartItems.Where(ci => ci.ProductId == productId)) // Filter to specific item
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }
    }
}
