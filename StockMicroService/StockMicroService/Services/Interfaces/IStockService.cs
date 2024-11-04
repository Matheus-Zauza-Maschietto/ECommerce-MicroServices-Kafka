using StockMicroService.DTOs;
using StockMicroService.Models;

namespace StockMicroService.Services.Interfaces;

public interface IStockService
{
    Task<IEnumerable<Stock>> GetStockByProductIdAsync(int productId);
    Task<Stock> GetStockByIdAsync(int id);
    Task<Stock> CreateStockAsync(StockDTO stockDto);
    Task<Stock> DeleteStockByIdAsync(int id);
    Task<Stock> UpdateStockByIdAsync(int id, StockDTO stockDto);
}