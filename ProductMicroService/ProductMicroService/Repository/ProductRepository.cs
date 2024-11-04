using Microsoft.EntityFrameworkCore;
using ProductMicroService.Models;
using ProductMicroService.Repository.Interfaces;

namespace ProductMicroService.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ProductRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Product>?> GetProductsAsync()
    {
        return await _dbContext.Products.ToListAsync();
    }
    
    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
    }
    
    public async Task<Product> CreateProductAsync(Product product)
    {
        return (await _dbContext.Products.AddAsync(product)).Entity;
    }
    
    public async Task<Product> DeleteProductAsync(Product product)
    {
        return _dbContext.Products.Remove(product).Entity;
    }
    
    public async Task<Product> UpdateProductAsync(Product product)
    {
        return _dbContext.Update(product).Entity; 
    }

    public async Task<bool> SaveChangesAsync()
    {
        return (await _dbContext.SaveChangesAsync()) > 0;
    }
}