using ConcultancyCRM.Models;
using ConcultancyCRM.Startup;
using ConcultancyCRM.StaticHelpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configuration
IConfiguration configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .Build();

builder.Services.AddDbContext<MyDBContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("ABCDatabase")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<MyDBContext>()
        .AddDefaultTokenProviders();

builder.Services.AddScoped<FlashBag, FlashBag>();

builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".My.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.IsEssential = true;
});



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
app.UseSession();

app.MapControllerRoute(
    name: "default",
  pattern: "{controller=Home}/{action=Index}/{id?}");


BootStrap.Init(configuration);

app.Run();
