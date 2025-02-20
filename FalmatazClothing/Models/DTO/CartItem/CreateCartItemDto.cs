using System.ComponentModel.DataAnnotations;

namespace FalmatazClothing.Models.DTO.CartItem
{
    public class CreateCartItemDto
    {
        [Required(ErrorMessage = "Guid is required")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "ProductId is required")]
        public Guid ProductId { get; set; }
        [Required(ErrorMessage = "Product name is required")]
        public string ProductName { get; set; } = default!;
        [Required(ErrorMessage = "Product image is required")]
        public string ProductImage { get; set; } = default!;

        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Total is required")]
        public decimal TotalPrice {  get; set; } 
        [Required(ErrorMessage = "Date is required")]
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
