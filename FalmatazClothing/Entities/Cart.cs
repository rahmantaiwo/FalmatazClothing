namespace FalmatazClothing.Entities
{
	public class Cart : Auditability
	{
		public string UserId { get; set; } = default!;
		public User? User { get; set; }
		public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
