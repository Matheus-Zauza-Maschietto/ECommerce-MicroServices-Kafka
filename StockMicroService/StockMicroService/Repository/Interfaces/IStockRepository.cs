using StockMicroService.Models;

namespace StockMicroService.Repository.Interfaces;

public interface IStockRepository
{
    Task<IEnumerable<Stock>> GetStockByProductIdAsync(int productId);
    Task<Stock?> GetStockByIdAsync(int id);
    Task<Stock> CreateStockAsync(Stock stock);
    Task<Stock> DeleteStockAsync(Stock stock);
    Task<Stock> UpdateStockAsync(Stock stock);
    Task<bool> SaveChangesAsync();
    Task<IEnumerable<Stock>> GetStocksWithoutAvaiability(IEnumerable<(int StockId, int Quantity)> stocks);
}