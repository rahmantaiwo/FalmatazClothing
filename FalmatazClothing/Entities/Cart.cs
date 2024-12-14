namespace FalmatazClothing.Entities
{
	public class Cart : Auditability
	{
		public Guid DesignId { get; set; }
		public Design Design { get; set; }

	}
}
