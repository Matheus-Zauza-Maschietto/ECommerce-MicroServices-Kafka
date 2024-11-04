using Microsoft.EntityFrameworkCore;
using StockMicroService.Models;

namespace StockMicroService;

public class ApplicationDbContext : DbContext
{
    public DbSet<Stock> Stocks { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}