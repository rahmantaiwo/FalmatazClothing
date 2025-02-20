using FalmatazClothing.Entities;
using FalmatazClothing.Enum;

namespace FalmatazClothing.Models.IRepository
{
    public interface ICartItemRepository
    {
        Task<List<CartItem>> GetAllCartItemAsync();
        Task<CartItem> GetCartItemAsync(Guid id);
    }
}
