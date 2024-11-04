using ProductMicroService.DTOs;
using ProductMicroService.Enums;

namespace ProductMicroService.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Categories Category { get; set; }
    public decimal Value { get; set; }

    public Product()
    {
        
    }

    public Product(ProductDTO productDto)   
    {
        Name = productDto.Name;
        Description = productDto.Description;
        Category = (Categories)productDto.CategoryId;
        Value = productDto.Value;
    }

    public Product Update(ProductDTO productDto)
    {
        Name = productDto.Name;
        Description = productDto.Description;
        Category = (Categories)productDto.CategoryId;
        Value = productDto.Value;
        return this;
    }
}