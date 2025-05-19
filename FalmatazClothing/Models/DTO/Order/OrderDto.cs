using FalmatazClothing.Enum;
using FalmatazClothing.Models.DTO.OrderItem;

namespace FalmatazClothing.Models.DTO.Order
{
    public class OrderDto
    {
        public string UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }
        public string ShipppingAddress { get; set; }
        public ICollection<OrderItemDto>OrderItems { get; set; } = new List <OrderItemDto>();
    }
}
