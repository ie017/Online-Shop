using Microsoft.EntityFrameworkCore;
using OrderService.Data;
using Steeltoe.Discovery.Client;
using Steeltoe.Discovery.Eureka;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddDbContext<OrderContext>(
    options => options.UseInMemoryDatabase("Orders")
);
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); // pour mapper les objets
builder.Services.AddServiceDiscovery(option => option.UseEureka());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

PreparationDb.PrepOrders(app, true);

app.Run();
