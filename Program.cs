using ASPDotnetWebApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
// Removed the session state import as it's no longer needed
// using Microsoft.AspNetCore.Http; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Removed the session support configuration

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

// Removed the session middleware

app.UseAuthorization();

// Removed the custom session validation middleware
// app.UseMiddleware<ValidateSessionMiddleware>();

// Define conventional routes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Member}/{action=Register}/{id?}");

app.Run();
