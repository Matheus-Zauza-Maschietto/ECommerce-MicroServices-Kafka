using Microsoft.EntityFrameworkCore;
using StockMicroService.DTOs;
using StockMicroService.Models;
using StockMicroService.Repository.Interfaces;

namespace StockMicroService.Repository;

public class StockRepository : IStockRepository
{
    private readonly ApplicationDbContext _dbContext;

    public StockRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Stock>?> GetStockByProductIdAsync(int productId)
    {
        return await _dbContext.Stocks.Where(p => p.ProductId == productId).ToListAsync();
    }
    
    public async Task<Stock?> GetStockByIdAsync(int id)
    {
        return await _dbContext.Stocks.FirstOrDefaultAsync(p => p.Id == id);
    }
    
    public async Task<Stock> CreateStockAsync(Stock stock)
    {
        return (await _dbContext.Stocks.AddAsync(stock)).Entity;
    }
    
    public async Task<Stock> DeleteStockAsync(Stock stock)
    {
        return _dbContext.Stocks.Remove(stock).Entity;
    }
    
    public async Task<Stock> UpdateStockAsync(Stock stock)
    {
        return _dbContext.Update(stock).Entity; 
    }
    

    public async Task<bool> SaveChangesAsync()
    {
        return (await _dbContext.SaveChangesAsync()) > 0;
    }
}