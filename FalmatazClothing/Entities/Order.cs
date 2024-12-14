namespace FalmatazClothing.Entities
{
	public class Order : Auditability
	{
		public Guid DesignId {  get; set; }
		public Design Design { get; set; }
		public Guid InventoryId { get; set; }
		public Inventory Inventory { get; set; }

	}
}
