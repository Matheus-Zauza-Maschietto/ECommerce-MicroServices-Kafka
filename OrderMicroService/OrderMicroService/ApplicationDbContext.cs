using Microsoft.EntityFrameworkCore;
using OrderMicroService.Models;

namespace OrderMicroService;

public class ApplicationDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Order>().HasMany<OrderProduct>(p => p.OrderProducts).WithOne(o => o.Order).HasForeignKey(o => o.OrderId);
    }
}