using Captain.Models.Customers;
using Captain.Models.Factories;
using Microsoft.EntityFrameworkCore;

namespace Captain.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Factory> Factories => Set<Factory>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().OwnsOne(c => c.Address);
        modelBuilder.Entity<Customer>().OwnsOne(c => c.Contact);
        modelBuilder.Entity<Factory>().OwnsOne(f => f.Address);
        modelBuilder.Entity<Factory>().OwnsOne(f => f.Contact);
    }
}