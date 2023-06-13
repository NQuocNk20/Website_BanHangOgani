using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using BanHangOgani.Models;
using BanHangOgani.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();




//Dependency Injection
builder.Services.AddDbContext<QuanLiBanHangContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("QuanLiBanHangDB"));

});

//DI
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<ICategoryReposistory, CategoryReposistory>();
builder.Services.AddTransient<IProductBrandRepository, ProductBrandRepository>();
builder.Services.AddSession();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.MapAreaControllerRoute(
     name: "MyAreas",
     areaName: "Admin",
     pattern: "Admin/{controller}/{action=Index}/{id?}",
     defaults: new { controller = "Dashboard", action = "Index" }
    );


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Access}/{action=Login}/{id?}");

app.Run();
