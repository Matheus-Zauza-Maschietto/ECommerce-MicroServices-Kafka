using ProductMicroService.DTOs;
using ProductMicroService.Models;
using ProductMicroService.Repository.Interfaces;
using ProductMicroService.Services.Interfaces;

namespace ProductMicroService.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<Product>?> GetProductsAsync()
    {
        IEnumerable<Product> products = await _productRepository.GetProductsAsync();
        return products;
    }
    
    public async Task<Product?> GetProductByIdAsync(int id)
    {
        Product? product = await _productRepository.GetProductByIdAsync(id);
        if(product is null)
            throw new ApplicationException($"Product with id: {id} not found");
        return product;
    }
        
    public async Task<Product> CreateProductAsync(ProductDTO productDTO)
    {
        Product product = new Product(productDTO);
        Product createdProduct = await _productRepository.CreateProductAsync(product);
        bool changesAsync = await _productRepository.SaveChangesAsync();
        if(!changesAsync)
            throw new ApplicationException("Failed to add product");
        return createdProduct;
    }
    
    public async Task<Product> DeleteProductByIdAsync(int id)
    {
        Product? product = await GetProductByIdAsync(id);
        Product deletedProduct = await _productRepository.DeleteProductAsync(product);
        bool changesAsync = await _productRepository.SaveChangesAsync();
        if(!changesAsync)
            throw new ApplicationException("Failed to delete product"); 
        return deletedProduct;
    }
    
    public async Task<Product> UpdateProductByIdAsync(int id, ProductDTO productDTO)
    {
        Product? product = await GetProductByIdAsync(id);
        Product toUpdateProduct = product.Update(productDTO);
        Product updatedProduct = await _productRepository.UpdateProductAsync(toUpdateProduct);
        bool changesAsync = await _productRepository.SaveChangesAsync();
        if(!changesAsync)
            throw new ApplicationException("Failed to update product");
        return updatedProduct;
    }
    
}