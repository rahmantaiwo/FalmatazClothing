namespace FalmatazClothing.Entities
{
	public class OrderItem : Auditability
	{
		public Guid ProductId { get; set; }
        public Guid OrderId { get; set; } 
        public Order Order { get; set; }
        public int Quantity { get; set; }
		public decimal UnitPrice { get; set; }
    }
}
