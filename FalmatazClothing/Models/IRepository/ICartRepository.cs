using FalmatazClothing.Entities;

namespace FalmatazClothing.Models.IRepository
{
    public interface ICartRepository
    {
        Task<Cart?> GetCartByUserIdAsync(string userId);
        //Task<Cart> CreateCartAsync(string userId);
        Task<Cart> AddToCartAsync(string userId, Guid productId, Guid quantity);
        Task<Cart> RemoveFromCartAsync(string userId, Guid productId);
    }
}
