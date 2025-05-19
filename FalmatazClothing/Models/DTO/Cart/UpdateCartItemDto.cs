namespace FalmatazClothing.Models.DTO.Cart
{
    public class UpdateCartItemDto
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
