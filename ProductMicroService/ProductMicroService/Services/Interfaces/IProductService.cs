using ProductMicroService.DTOs;
using ProductMicroService.Models;

namespace ProductMicroService.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<Product>?> GetProductsAsync();
    Task<Product?> GetProductByIdAsync(int id);
    Task<Product> CreateProductAsync(ProductDTO productDTO);
    Task<Product> DeleteProductByIdAsync(int id);
    Task<Product> UpdateProductByIdAsync(int id, ProductDTO productDTO);
}