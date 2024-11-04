using Microsoft.AspNetCore.Mvc;
using OrderMicroService.DTOs;
using OrderMicroService.Services.Interfaces;

namespace OrderMicroService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            return Ok(await _orderService.GetOrdersAsync());
        }
        catch (ApplicationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return Problem("An problem was occurred, try again later !");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            return Ok(await _orderService.GetOrderByIdAsync(id));
        }
        catch (ApplicationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return Problem("An problem was occurred, try again later !");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] OrderDTO orderDto)
    {
        try
        {
            return Ok(await _orderService.CreateOrderAsync(orderDto));
        }
        catch (ApplicationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return Problem("An problem was occurred, try again later !");
        }
    }
    
}

