namespace OrderMicroService.Repository.Interfaces;

public interface IStockRepository
{
    Task<bool> StockExists(int stockId, int quantity);
}