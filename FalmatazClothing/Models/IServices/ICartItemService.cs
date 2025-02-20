using FalmatazClothing.Models.DTO.CartItem;
using FalmatazClothing.Models.DTO.Product;

namespace FalmatazClothing.Models.IServices
{
    public interface ICarItemService
    {
        public Task<BaseResponse<bool>> CreateCartItem(CreateCartItemDto request);
        Task<BaseResponse<CartItemDto>> GetCartItem(Guid id);
        public Task<BaseResponse<List<CartItemDto>>> GetAllCartItems();
        Task<BaseResponse<bool>> UpdateCartItem(Guid id, UpdateCartItemDto request);
        public Task<BaseResponse<bool>> DeleteCartItem(Guid id);
    }
}
