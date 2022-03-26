using DataRepository;
using DataRepository.DataConnection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<DapperContext>();
builder.Services.AddSingleton<IDataRepo, DataRepo>();

//get connection string
var connectionString = builder.Configuration.GetConnectionString("CommonDatabase");

// get the current assembly name
var currentAssembly = Assembly.GetExecutingAssembly().GetName().Name;

// add the IdentityDbContext for the current connectionString in the currentAssembly
builder.Services.AddDbContext<IdentityDbContext>(options => options.UseSqlServer(connectionString, obj => obj.MigrationsAssembly(currentAssembly)));

// storing user information
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<IdentityDbContext>();

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
