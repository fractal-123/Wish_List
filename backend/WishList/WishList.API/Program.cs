using Microsoft.EntityFrameworkCore;
using WishList.API.Abstraction;
using WishList.API.Services;
using WishList.DataAccess.Postgres;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllers();


builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<WishListDbContext>();
builder.Services.AddScoped<IWishService, WishService>();



builder.Services.AddDbContext<WishListDbContext>(
    options =>
    {
        options.UseNpgsql(configuration.GetConnectionString(nameof(WishListDbContext)));
    });

var app = builder.Build();

app.UseCors("AllowFrontend");
app.UseSwagger();
app.UseSwaggerUI();
app.UseSession();
app.MapControllers();
app.Run();
