namespace FalmatazClothing.Models.DTO.Cart
{
    public class RemoveFromCartDto
    {
        public string UserId { get; set; }
        public Guid ProductId { get; set; }
    }
}
