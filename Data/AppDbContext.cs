using Microsoft.EntityFrameworkCore;
using Captain.Entities;

namespace Captain.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Factory> Factories => Set<Factory>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<Entities.List> Lists => Set<Entities.List>();
    public DbSet<Item> Items => Set<Item>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.OwnsOne(c => c.Address);
            entity.OwnsOne(c => c.Contact);
        });

        modelBuilder.Entity<Factory>(entity =>
        {
            entity.HasKey(f => f.Id);
            entity.OwnsOne(f => f.Address);
            entity.OwnsOne(f => f.Contact);
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(i => i.Id);
            entity.HasOne(i => i.Factory)
                  .WithMany()
                  .HasForeignKey(i => i.FactoryId);
        });

        modelBuilder.Entity<Entities.List>(entity =>
        {
            entity.HasKey(l => l.Id);
            entity.HasOne(l => l.Factory)
                  .WithMany()
                  .HasForeignKey(l => l.FactoryId);
            entity.HasMany(l => l.Items)
                  .WithOne()
                  .HasForeignKey(i => i.FactoryId);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(o => o.Id);
            entity.HasOne(o => o.Customer)
                  .WithMany()
                  .HasForeignKey(o => o.CustomerId);
            entity.HasOne(o => o.Factory)
                  .WithMany()
                  .HasForeignKey(o => o.FactoryId);
            entity.HasMany(o => o.Items)
                  .WithOne(oi => oi.Order)
                  .HasForeignKey(oi => oi.OrderId);
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(oi => oi.Id);
            entity.HasOne(oi => oi.Item)
                  .WithMany()
                  .HasForeignKey(oi => oi.ItemId);
        });
    }
}