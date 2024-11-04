 using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroService.DTOs;
using ProductMicroService.Repository.Interfaces;
using ProductMicroService.Services.Interfaces;

namespace ProductMicroService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            return Ok(await _productService.GetProductsAsync());
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
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            return Ok(await _productService.GetProductByIdAsync(id));
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
    public async Task<IActionResult> Post([FromBody] ProductDTO productDto)
    {
        try
        {
            return Ok(await _productService.CreateProductAsync(productDto));
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

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] ProductDTO productDto)
    {
        try
        {
            return Ok(await _productService.UpdateProductByIdAsync(id, productDto));
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            return Ok(await _productService.DeleteProductByIdAsync(id));
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

