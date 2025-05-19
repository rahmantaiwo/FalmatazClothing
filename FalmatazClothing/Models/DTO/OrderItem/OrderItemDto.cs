namespace FalmatazClothing.Models.DTO.OrderItem
{
    public class OrderItemDto
    {
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
