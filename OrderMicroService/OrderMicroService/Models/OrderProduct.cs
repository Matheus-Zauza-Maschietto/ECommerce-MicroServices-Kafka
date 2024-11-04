using OrderMicroService.DTOs;

namespace OrderMicroService.Models;

public class OrderProduct
{
    public int Id { get; set; }
    public Order Order { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int ProductStockId { get; set; }
    public int Quantity { get; set; }
    public bool StockConfirmed { get; set; }

    public OrderProduct()
    {
        
    }

    public OrderProduct(OrderProductDTO orderProductDTO)
    {
        ProductId = orderProductDTO.ProductId;
        ProductStockId = orderProductDTO.ProductStockId;
        Quantity = orderProductDTO.Quantity;
    }
}