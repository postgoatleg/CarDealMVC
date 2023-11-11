using CarDealMVC.Middleware;
using CarDealMVC.Models;
using CarDealMVC.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


string conStr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CarDealerContext>(options => options.UseSqlServer(conStr));
builder.Services.AddControllersWithViews();
builder.Services.AddMemoryCache();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddScoped<ICachedService<Car>, CachedCarsService>();
builder.Services.AddScoped<ICachedService<Manufacturer>, CachedManufacturersService>();
builder.Services.AddScoped<ICachedService<Employee>, CachedEmpoyeesService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseDbInitializer();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "cars",
    pattern: "{controller=CarDeal}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "manufacturers",
    pattern: "{controller=Manufactrurers}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "employees",
    pattern: "{controller=Employees}/{action=Index}/{id?}");

app.Run();
