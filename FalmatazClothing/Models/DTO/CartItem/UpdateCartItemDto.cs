namespace FalmatazClothing.Models.DTO.CartItem
{
    public class UpdateCartItemDto
    {
        public Guid Id { get; set; }    
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = default!;
        public string ProductImage { get; set; } = default!;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice {  get; set; }
    }
}
