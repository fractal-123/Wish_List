using Microsoft.EntityFrameworkCore;
using WishList.DataAccess.Postgres;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;


builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<WishListDbContext>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:5173");
        policy.AllowAnyMethod();
        policy.AllowAnyHeader();

    });
});


builder.Services.AddDbContext<WishListDbContext>(
    options =>
    {
        options.UseNpgsql(configuration.GetConnectionString(nameof(WishListDbContext)));
    });

var app = builder.Build();

app.UseCors();
app.UseSwagger();
app.UseSwaggerUI();




app.MapControllers();

app.Run();
