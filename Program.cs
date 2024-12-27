using IIBS.StartupExtension;
using IIBS.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IIBS.Repository;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();
//var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
//optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddDatabaseExtensionHelper(builder.Configuration); // Database Configuration

builder.Services.AddTransient<IEmployee, EmployeeRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
