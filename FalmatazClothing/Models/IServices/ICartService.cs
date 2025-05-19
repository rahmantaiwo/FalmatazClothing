using FalmatazClothing.Entities;
using FalmatazClothing.Models.DTO.Cart;

namespace FalmatazClothing.Models.IServices
{
    public interface ICartService 
    {
        Task<BaseResponse<CartDto>> GetCartByByUserIdAsync(string UserId);
        Task<BaseResponse<CartDto>> AddToCartAsync(AddToCartDto dto);
        Task<BaseResponse<CartDto>>RemoveFromCartAsync(RemoveFromCartDto dto);
        Task<BaseResponse<CartDto>> UpdateCartItemQuantityAsync(UpdateCartItemDto dto);
    }
}
