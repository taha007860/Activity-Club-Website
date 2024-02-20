using ASPDotnetWebApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add session support
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // You can set the session timeout
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Register your DbContext with the connection string from appsettings
var connectionString = builder.Configuration.GetConnectionString("ConnectionString");
builder.Services.AddDbContext<ActivityClubContext>(options =>
    options.UseSqlServer(connectionString));

// Add logging
builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddConsole();
    loggingBuilder.AddDebug();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Enable session middleware
app.UseSession();

app.UseAuthorization();

// Define conventional routes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Member}/{action=Register}/{id?}");

app.Run();
