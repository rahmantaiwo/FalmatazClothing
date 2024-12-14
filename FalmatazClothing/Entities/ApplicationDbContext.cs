using Microsoft.EntityFrameworkCore;

namespace FalmatazClothing.Entities
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		public DbSet<Cart> Carts { get; set; }
		public DbSet<Design> Designs { get; set; }
		public DbSet<Inventory> Inventories { get; set; }
		public DbSet<Order> Orders { get; set; }
	}
}
