using Microsoft.EntityFrameworkCore;
using eLibrary.Data;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Registrera databaskopplingen (använd "localDb" om det är det du skrev i appsettings.json):
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login";
    });

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    Directory.CreateDirectory(@"D:\home\data");
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

// Lägg till testdata (seed)
try
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<AppDbContext>();
        await DbInitializer.InitializeAsync(context);
    }
}
catch (Exception ex)
{
    Console.WriteLine("---------------------------------------------");
    Console.WriteLine($"FEL VID SEEDING: {ex.Message}");
    if (ex.InnerException != null)
    {
        Console.WriteLine($"DETALJER: {ex.InnerException.Message}");
    }
    Console.WriteLine("---------------------------------------------");
}

app.Run();
