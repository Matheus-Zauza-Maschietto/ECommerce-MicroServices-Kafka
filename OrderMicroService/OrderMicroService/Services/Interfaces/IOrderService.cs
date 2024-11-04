using OrderMicroService.DTOs;
using OrderMicroService.Models;

namespace OrderMicroService.Services.Interfaces;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetOrdersAsync();
    Task<Order> GetOrderByIdAsync(int id);
    Task<Order> CreateOrderAsync(OrderDTO orderDto);

}