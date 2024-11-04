using ProductMicroService.Models;

namespace ProductMicroService.Repository.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>?> GetProductsAsync();
    Task<Product?> GetProductByIdAsync(int id);
    Task<Product> CreateProductAsync(Product product);
    Task<Product> DeleteProductAsync(Product product);
    Task<Product> UpdateProductAsync(Product product);
    Task<bool> SaveChangesAsync();
}