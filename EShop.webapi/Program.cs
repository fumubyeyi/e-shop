using Microsoft.EntityFrameworkCore;
using EShop.webapi.Data;
using EShop.webapi.Services;
using EShop.webapi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connection = String.Empty;
if (builder.Environment.IsDevelopment())
    builder.Configuration.AddEnvironmentVariables();

connection = builder.Configuration.GetConnectionString("AzureSQLConnection");

builder.Services.AddDbContext<EshopContext>(options =>
    options.UseSqlServer(connection));
builder.Services.AddScoped<IProductsService, ProductsRepository>();
builder.Services.AddScoped<IWeatherForecastService, WeatherForecastRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseRouting();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();
