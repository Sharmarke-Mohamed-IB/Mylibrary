using Microsoft.EntityFrameworkCore;
using MyLibrary.Models;
using MyLibrary.Data;

var builder = WebApplication.CreateBuilder(args);

// Add MVC support
builder.Services.AddControllersWithViews();

// Register SQLite with Entity Framework Core
builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("LibraryContext")));

// Enable Session support
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// 🌱 Seed database with 10 books if not already present
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<LibraryContext>();
    db.Database.EnsureCreated();         // Create DB if not exists
    DbInitializer.Seed(db);              // Seed sample books
}

// Configure middleware pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // Add HTTP Strict Transport Security
}

app.UseHttpsRedirection();
app.UseStaticFiles();    // Serve from wwwroot (e.g., /images)
app.UseRouting();
app.UseSession();        // Enable session handling
app.UseAuthorization();

// Default route setup
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
