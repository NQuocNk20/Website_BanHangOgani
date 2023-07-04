using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using BanHangOgani.Models;
using BanHangOgani.Repository;
using Microsoft.AspNetCore.Identity;
using BanHangOgani.Data;
using BanHangOgani.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();




//Dependency Injection
builder.Services.AddDbContext<QuanLiBanHangContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("QuanLiBanHangDB"));

});

builder.Services.AddDbContext<BanHangOganiDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BanHangOganiDB"));

});

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<BanHangOganiDBContext>();

builder.Services.Configure<IdentityOptions>(options => {
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
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
app.UseAuthentication();;

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
