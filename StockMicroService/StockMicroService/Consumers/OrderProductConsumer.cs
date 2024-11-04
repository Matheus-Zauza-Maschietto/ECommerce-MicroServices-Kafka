using MassTransit;
using StockMicroService.DTOs;
using StockMicroService.Models;
using StockMicroService.Repository.Interfaces;

namespace StockMicroService.Consumers;

public class OrderProductConsumer : IConsumer<OrderProductStockCheckDTO>
{
    private readonly IStockRepository _stockRepository;
    private readonly IPublishEndpoint _publishEndpoint;
    
    public OrderProductConsumer(
        IStockRepository stockRepository,
        IPublishEndpoint publishEndpoint
        )
    {
        _stockRepository = stockRepository;
        _publishEndpoint = publishEndpoint;
    }

    public async Task Consume(ConsumeContext<OrderProductStockCheckDTO> context)
    {
        Stock? stock = await _stockRepository.GetStockByIdAsync(context.Message.StockId);
        if (stock is null)
        {
            context.Message.StockIsOk = null;
            _publishEndpoint.Publish(context.Message);
        }

        if (stock!.Quantity >= context.Message.Quantity)
        {
            stock.Quantity -= context.Message.Quantity;
            await _stockRepository.UpdateStockAsync(stock);
            context.Message.StockIsOk = true;
            _publishEndpoint.Publish(context.Message);
        }
        else
        {
            context.Message.StockIsOk = false;
            _publishEndpoint.Publish(context.Message);
        }
    }
}