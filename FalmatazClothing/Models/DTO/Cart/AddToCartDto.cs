namespace FalmatazClothing.Models.DTO.Cart
{
    public class AddToCartDto
    {
        public string UserId { get; set; }
        public Guid ProductId { get; set; }
        public int StockQuantity { get; set; }
    }
}
