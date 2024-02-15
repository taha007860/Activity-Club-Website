using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register your DbContext with the connection string from appsettings
var connectionString = builder.Configuration.GetConnectionString("ActivityClubContext");


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

app.UseAuthorization();

// Update the route configuration to make MemberController the default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Members}/{action=Register}/{id?}");

app.Run();

