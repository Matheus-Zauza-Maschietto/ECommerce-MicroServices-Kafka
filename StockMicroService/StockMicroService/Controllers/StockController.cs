using Microsoft.AspNetCore.Mvc;
using StockMicroService.DTOs;
using StockMicroService.Services.Interfaces;

namespace StockMicroService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StockController : ControllerBase
{
    private readonly IStockService _stockService;

    public StockController(IStockService stockService)
    {
        _stockService = stockService;
    }

    [HttpGet("Products/{id}")]
    public async Task<IActionResult> GetByProductId(int id)
    {
        try
        {
            return Ok(await _stockService.GetStockByProductIdAsync(id));
        }
        catch (ApplicationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch
        {
            return Problem("An problem was occurred, try again later !");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            return Ok(await _stockService.GetStockByIdAsync(id));
        }
        catch (ApplicationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch
        {
            return Problem("An problem was occurred, try again later !");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] StockDTO stockDto)
    {
        try
        {
            return Ok(await _stockService.CreateStockAsync(stockDto));
        }
        catch (ApplicationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch
        {
            return Problem("An problem was occurred, try again later !");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] StockDTO stockDto)
    {
        try
        {
            return Ok(await _stockService.UpdateStockByIdAsync(id, stockDto));
        }
        catch (ApplicationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch
        {
            return Problem("An problem was occurred, try again later !");
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            return Ok(await _stockService.DeleteStockByIdAsync(id));
        }
        catch (ApplicationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch
        {
            return Problem("An problem was occurred, try again later !");
        }
    }
}

