using StockMicroService.Models;

namespace StockMicroService.DTOs;

public record OrderProductStockCheckDTO
{
    public int Id { get; set; }
    public int StockId { get; set; }
    public int Quantity { get; set; }
    public bool? StockIsOk { get; set; }
    public OrderProductStockCheckDTO()
    {
        
    }

    public OrderProductStockCheckDTO(Stock stock)
    {
        StockId = stock.Id;
        Quantity = stock.Quantity;
    }
}