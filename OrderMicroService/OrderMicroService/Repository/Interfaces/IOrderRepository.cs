using OrderMicroService.Models;

namespace OrderMicroService.Repository.Interfaces;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetOrdersAsync();
    Task<Order?> GetOrderByIdAsync(int id);
    Task<Order> CreateOrderAsync(Order order);
    Task<bool> SaveChangesAsync();
}