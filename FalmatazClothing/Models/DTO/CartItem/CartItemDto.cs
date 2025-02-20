using System.ComponentModel.DataAnnotations;

namespace FalmatazClothing.Models.DTO.CartItem
{
    public class CartItemDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; } 
        public string ProductName { get; set; } = default!; // foreing key
        public string ProductImage { get; set; } = default!; //Navigation property
        public int Quantity { get; set; } 
        public decimal Price { get; set; }
        public decimal TotalPrice {  get; set; }
    }
}
