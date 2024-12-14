using Microsoft.EntityFrameworkCore;
using FalmatazClothing.Entities;
using FalmatazClothing.Models.IRepository;
using FalmatazClothing.Models.IServices;
using FalmatazClothing.Models.Services;
using FalmatazClothing.Models.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var dbConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddSqlServer<ApplicationDbContext>(dbConnection);

//Services
builder.Services.AddScoped<IInventoryServices, InventoryServices>();                                                                   
builder.Services.AddScoped<IDesignServices, DesignServices>();                                                                   
builder.Services.AddScoped<IImageService, ImageService>();                                                                   


//Repository
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<IDesignRepository, DesignRepository>();

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
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
