using FalmatazClothing.Entities;
using FalmatazClothing.Models.DTO.CartItem;

namespace FalmatazClothing.Models.DTO.Cart
{
    public class CartDto
    { 
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public ICollection<CartItemDto> CartItems { get; set; } = new List<CartItemDto>();
    }
}
