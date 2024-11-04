using Microsoft.EntityFrameworkCore;
using OrderMicroService.Models;
using OrderMicroService.Repository.Interfaces;

namespace OrderMicroService.Repository;

public class OrderProductRepository : IOrderProductRepository
{
    private readonly ApplicationDbContext _dbContext;

    public OrderProductRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<OrderProduct?> GetOrderProductByIdAsync(int id)
    {
        return await _dbContext.OrderProducts.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<OrderProduct?> UpdateOrderProductAsync(OrderProduct orderProduct)
    {
        return _dbContext.Update(orderProduct).Entity;   
    }

    public async Task<bool> SaveChangesAsync()
    {
        return (await _dbContext.SaveChangesAsync()) > 0;
    }
}