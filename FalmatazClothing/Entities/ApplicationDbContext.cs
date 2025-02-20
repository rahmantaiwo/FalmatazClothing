using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FalmatazClothing.Entities
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		public DbSet<Cart> Carts { get; set; }
		public DbSet<CartItem> CartItems { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<MaterialType> MaterialTypes { get; set; }
		public DbSet<User> Users { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            base.OnModelCreating(modelBuilder);

            // Seed an admin user
            var adminRoleId = Guid.NewGuid().ToString();
            var adminPharmacyId = Guid.NewGuid().ToString();

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "CUSTOMER",
                    NormalizedName = "CUSTOMER"
                }
            );
        }






        //public static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        //{
        //	string[] roleNames = { "Admin", "Customer" };

        //	foreach (var roleName in roleNames)
        //	{
        //		var roleExists = await roleManager.RoleExistsAsync(roleName);
        //		if(!roleExists)
        //		{
        //			await roleManager.CreateAsync(new IdentityRole(roleName));
        //		}
        //	}
        //}
    }
}
