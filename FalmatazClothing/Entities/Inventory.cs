namespace FalmatazClothing.Entities
{
	public class Inventory : Auditability
	{
		public string Fabric {  get; set; }
		public int Quantity {  get; set; }
		public decimal Price {  get; set; }
		public  string ImageFileName {  get; set; }
		public ICollection<Order>Orders { get; set; } = new HashSet<Order>();
	}
}
