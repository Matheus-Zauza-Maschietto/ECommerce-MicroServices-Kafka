using OrderMicroService.Models;

namespace OrderMicroService.Repository.Interfaces;

public interface IOrderProductRepository
{
    Task<OrderProduct?> GetOrderProductByIdAsync(int id);
    Task<OrderProduct?> UpdateOrderProductAsync(OrderProduct orderProduct);
    Task<bool> SaveChangesAsync();
}