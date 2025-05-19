using FalmatazClothing.Models.DTO.Cart;
using FalmatazClothing.Models.DTO.CartItem;

namespace FalmatazClothing.Models
{
    public class CheckoutViewModel
    {
        public CartDto Cart { get; set; }
        public string ShippingAddress { get; set; }
        public string UserId { get; set; }

        //public string UserId { get; set; }
        //public List<CartItemDto> CartItems { get; set; }
        //public decimal TotalAmount { get; set; }
        //public string ShippingAddress { get; set; }
    }
}
