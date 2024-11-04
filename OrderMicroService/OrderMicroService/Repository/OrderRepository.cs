using Microsoft.EntityFrameworkCore;
using OrderMicroService.Models;
using OrderMicroService.Repository.Interfaces;

namespace OrderMicroService.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _dbContext;

    public OrderRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Order>?> GetOrdersAsync()
    {
        return await _dbContext.Orders.ToListAsync();
    }
    
    public async Task<Order?> GetOrderByIdAsync(int id)
    {
        return await _dbContext.Orders.FirstOrDefaultAsync(p => p.Id == id);
    }
    
    public async Task<Order> CreateOrderAsync(Order order)
    {
        return (await _dbContext.Orders.AddAsync(order)).Entity;
    }

    public async Task<bool> SaveChangesAsync()
    {
        return (await _dbContext.SaveChangesAsync()) > 0;
    }
}