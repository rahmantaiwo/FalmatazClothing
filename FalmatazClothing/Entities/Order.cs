using FalmatazClothing.Enum;

namespace FalmatazClothing.Entities
{
    public class Order : Auditability
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }
        public string ShipppingAddress { get; set; }
        public ICollection<OrderItem> orderItems { get; set; } = new List<OrderItem>();
    }
}
