namespace FalmatazClothing.Entities
{
	public class Cart : Auditability
	{
		public Guid UserId { get; set; }
		public User User { get; set; }
		public ICollection<CartItem> CartItems { get; set; }
	}
}
