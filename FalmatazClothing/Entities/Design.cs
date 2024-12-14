namespace FalmatazClothing.Entities
{
	public class Design : Auditability
	{
		public string Fabric { get; set; }
		public string Style { get; set; }
		public decimal Price { get; set; }
		public string Image { get; set; }
		public ICollection<Order>Orders { get; set; } = new HashSet<Order>();
		public ICollection<Cart>Carts { get; set; } = new HashSet<Cart>();
	}
}
