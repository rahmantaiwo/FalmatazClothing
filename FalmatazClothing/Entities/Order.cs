namespace FalmatazClothing.Entities
{
    public class Order : Auditability
    {
        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
        public decimal TotalAmount { get; set; }
    }
}
