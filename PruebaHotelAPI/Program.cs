using Microsoft.EntityFrameworkCore;
using PruebaHotelAPI.Common.Interfaces;
using PruebaHotelAPI.Context;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetService<IConfiguration>();

// Add services to the container.
builder.Services.AddMediatR(v =>
{
    v.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
});
builder.Services.AddControllers(); 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(
    //options => options.UseSqlServer(configuration.GetConnectionString("Conexion")));
    options => options.UseSqlServer("Server=LYANROCK;Database=PruebaHotel;Trusted_Connection=True;TrustServerCertificate=True;"));
builder.Services.AddScoped<IApplicationDbContext>(v => v.GetService<ApplicationDbContext>());

var app = builder.Build();

// Configure the HTTP request pipeline.0
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); 
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
