using Captain.Models.Customers;
using Microsoft.EntityFrameworkCore;

namespace Captain.Data;
public class AppDbContext : DbContext
{
    public DbSet<Customer>Customers=>Set<Customer>();
}

