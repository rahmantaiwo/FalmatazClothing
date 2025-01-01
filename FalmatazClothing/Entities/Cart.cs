namespace FalmatazClothing.Entities
{
	public class Cart : Auditability
	{
		public ICollection<CartItem> CartItems { get; set; }
	}
}
