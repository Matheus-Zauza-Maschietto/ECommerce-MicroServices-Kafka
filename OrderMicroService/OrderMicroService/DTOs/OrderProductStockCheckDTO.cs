using OrderMicroService.Models;

namespace OrderMicroService.DTOs;

public record OrderProductStockCheckDTO
{
    public int StockId { get; set; }
    public int Quantity { get; set; }
    public OrderProductStockCheckDTO()
    {
        
    }


    public OrderProductStockCheckDTO(OrderProduct orderProduct)
    {
        StockId = orderProduct.ProductStockId;
        Quantity = orderProduct.Quantity;
    }
};