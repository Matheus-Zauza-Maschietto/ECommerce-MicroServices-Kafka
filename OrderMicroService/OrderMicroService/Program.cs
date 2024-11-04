using MassTransit;
using OrderMicroService;
using OrderMicroService.DTOs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddHttpClient("StockApi", client => client.BaseAddress = new Uri(builder.Configuration["StockApi:Url"]));
builder.Services.AddMassTransit(x =>
{
    x.UsingInMemory((context, cfg) => cfg.ConfigureEndpoints(context));
    x.AddRider(rider =>
    {
        x.UsingInMemory();

        rider.UsingKafka((context, k) =>
        {
            k.Host("localhost:9092");
        });
        
        rider.AddProducer<OrderProductStockCheckDTO>("order-product-created-topic");

        // rider.AddConsumer<ProductCreatedConsumer>(c =>
        // {
        //     c.TopicName = "product-created-topic";
        // });
        //
        // rider.AddConsumer<SaleCompletedConsumer>(c =>
        // {
        //     c.TopicName = "sale-completed-topic";
        // });
        //
        // rider.AddConsumer<StockUpdatedConsumer>(c =>
        // {
        //     c.TopicName = "stock-updated-topic";
        // });
    });
});

builder.Services.AddMassTransitHostedService(true);
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
