using System.Text.RegularExpressions;
using MassTransit;
using OrderMicroService.DTOs;
using OrderMicroService.Models;
using OrderMicroService.Repository.Interfaces;
using OrderMicroService.Services.Interfaces;

namespace OrderMicroService.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IPublishEndpoint _publishEndpoint;
    public OrderService(
        IOrderRepository orderRepository,
        IPublishEndpoint publishEndpoint
        )
    {
        _publishEndpoint = publishEndpoint;
        _orderRepository = orderRepository;
    }

    public async Task<IEnumerable<Order>> GetOrdersAsync()
    {
        IEnumerable<Order> orders = await _orderRepository.GetOrdersAsync();
        return orders;
    }
    
    public async Task<Order> GetOrderByIdAsync(int id)
    {
        Order? stock = await _orderRepository.GetOrderByIdAsync(id);
        if(stock is null)
            throw new ApplicationException($"Stock with id: {id} not found");
        return stock;
    }
        
    public async Task<Order> CreateOrderAsync(OrderDTO orderDto)
    {
        Order order = new Order(orderDto);
        Order createdOrder = await _orderRepository.CreateOrderAsync(order);
        bool changesAsync = await _orderRepository.SaveChangesAsync();
        if(!changesAsync)
            throw new ApplicationException("Failed to add stock");

        var orderProductStockCheckDtos =
            createdOrder.OrderProducts.Select(p => new OrderProductStockCheckDTO(p));
        foreach (var orderProductDto in orderProductStockCheckDtos)
        {
            _publishEndpoint.Publish(orderProductDto);
        }
        
        return createdOrder;
    }
    


}