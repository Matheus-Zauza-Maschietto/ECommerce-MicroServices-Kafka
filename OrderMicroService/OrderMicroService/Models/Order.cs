using OrderMicroService.DTOs;
using OrderMicroService.Enums;

namespace OrderMicroService.Models;

public class Order
{
    public int Id { get; set; }
    public IEnumerable<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    public Order()
    {
        
    }

    public Order(OrderDTO orderDto)
    {
        OrderProducts = orderDto.Products.Select(p => new OrderProduct(p));
    }


}