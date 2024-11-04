using StockMicroService.DTOs;
using StockMicroService.Enums;

namespace StockMicroService.Models;

public class Stock
{
    public int Id { get; set; }
    public string Color { get; set; }
    public int Quantity { get; set; }
    public int ProductId { get; set; }
    public Materials Material { get; set; }

    public Stock()
    {
        
    }

    public Stock(StockDTO stockDto)   
    {
        Color = stockDto.Color.Replace("#", "");
        Quantity = stockDto.Quantity;
        Material = (Materials)stockDto.Material;
        ProductId = stockDto.ProductId;
    }

    public Stock Update(StockDTO stockDto)
    {
        Color = stockDto.Color;
        Quantity = stockDto.Quantity;
        Material = (Materials)stockDto.Material;
        ProductId = stockDto.ProductId;
        return this;
    }
}