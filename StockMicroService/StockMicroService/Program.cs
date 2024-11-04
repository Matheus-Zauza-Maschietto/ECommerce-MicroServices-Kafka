using MassTransit;
using Microsoft.EntityFrameworkCore;
using StockMicroService;
using StockMicroService.Consumers;
using StockMicroService.DTOs;
using StockMicroService.Repository;
using StockMicroService.Repository.Interfaces;
using StockMicroService.Services;
using StockMicroService.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(op => op.UseNpgsql(builder.Configuration.GetConnectionString("Database")));
builder.Services.AddSingleton<IStockRepository, StockRepository>();
builder.Services.AddScoped<IStockService, StockService>();
builder.Services.AddMassTransit(x =>
{
    x.UsingInMemory((context, cfg) => cfg.ConfigureEndpoints(context));
    x.AddRider(rider =>
    {
        x.UsingInMemory();

        rider.AddProducer<OrderProductStockCheckDTO>("order-product-processed-topic");

        rider.AddConsumer<OrderProductConsumer>();
        
        rider.UsingKafka((context, k) =>
        {
            k.Host("localhost:9092");
            k.TopicEndpoint<OrderProductConsumer>("order-product-created-topic", "", e =>
            {
                e.ConfigureConsumer<OrderProductConsumer>(context);
            });
        });
        
    });
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

