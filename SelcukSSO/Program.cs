using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SelcukSSO.Data;
using SelcukSSO.Models.Identity;

var builder = WebApplication.CreateBuilder(args);

// =======================================
// 1. CONTROLLERS VE OPENAPI
// =======================================

builder.Services.AddControllers();
builder.Services.AddOpenApi();

// =======================================
// 2. SQL SERVER + ENTITY FRAMEWORK CORE
// =======================================

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString(
            "DefaultConnection"));

    // OpenIddict'in 4 tablosunu EF Core'a ekler.
    options.UseOpenIddict();
});

// =======================================
// 3. ASP.NET CORE IDENTITY
// =======================================

builder.Services
    .AddIdentity<ApplicationUser, ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// =======================================
// 4. OPENIDDICT - VERITABANI
// =======================================

builder.Services.AddOpenIddict()
    .AddCore(options =>
    {
        options.UseEntityFrameworkCore()
               .UseDbContext<ApplicationDbContext>();
    });

// =======================================
// 5. AUTHORIZATION
// =======================================

builder.Services.AddAuthorization();

// =======================================
// 6. APPLICATION
// =======================================

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();