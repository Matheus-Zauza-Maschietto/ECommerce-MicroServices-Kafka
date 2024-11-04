using MassTransit;
using OrderMicroService.DTOs;
using OrderMicroService.Models;
using OrderMicroService.Repository.Interfaces;

namespace StockMicroService.Consumers;

public class OrderProductConsumer : IConsumer<OrderProductStockCheckDTO>
{
    private readonly IOrderProductRepository _orderProductRepository;
    private readonly IPublishEndpoint _publishEndpoint;
    
    public OrderProductConsumer(
        IOrderProductRepository orderProductRepository,
        IPublishEndpoint publishEndpoint
        )
    {
        _orderProductRepository = orderProductRepository;
        _publishEndpoint = publishEndpoint;
    }

    public async Task Consume(ConsumeContext<OrderProductStockCheckDTO> context)
    {
        var orderProductStock = context.Message;
        OrderProduct? orderProduct = await _orderProductRepository.GetOrderProductByIdAsync(orderProductStock.Id);
        if (orderProduct is null)
        {
            return;
        }
        
        orderProduct.StockConfirmed = orderProduct.StockConfirmed;
        _orderProductRepository.UpdateOrderProductAsync(orderProduct);
    }
}