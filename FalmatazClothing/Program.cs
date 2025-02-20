using Microsoft.EntityFrameworkCore;
using FalmatazClothing.Entities;
using FalmatazClothing.Models.IServices;
using FalmatazClothing.Models.Services;
using FalmatazClothing.Models.IRepository;
using FalmatazClothing.Models.Repository;
using Microsoft.AspNetCore.Identity;
using AspNetCoreHero.ToastNotification;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddNotyf(config =>
{
    config.DurationInSeconds = 1;
    config.IsDismissable = true;
    config.Position = NotyfPosition.BottomRight;
}
);

var dbConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddSqlServer<ApplicationDbContext>(dbConnection);

builder.Services.AddIdentity<User, IdentityRole>(opt =>
{

})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();


//Services

builder.Services.AddScoped<IMaterialTypeService, MaterialTypeService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICarItemService, CartItemService>();

//Repository
builder.Services.AddScoped<IMaterialTypeRepository, MaterialTypeRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Auth}/{action=Login}/{id?}");

app.Run();
