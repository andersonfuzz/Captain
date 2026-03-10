using Captain.Data;
using Captain.Models.Customers;
using Captain.Services.Customers;
using Microsoft.EntityFrameworkCore;

namespace Captain.Services.Customers;

public class CustomerService : ICustomerService
{
    private readonly AppDbContext _context;

    public CustomerService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Customer> AddAsync(CustomerDto dto)
    {
        var customer = new Customer()
        {
            CompanyName = dto.CompanyName,
            Fantasy = dto.Fantasy,
            Cnpj = dto.Cnpj,
            StateRegistration = dto.StateRegistration,
            Address = dto.Address,
            Contact = dto.Contact
        };
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
        return customer;
    }

    public async Task<bool> DeleteByIdAsync(Guid id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer is null) return false;
        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Customer?> EditAsync(Guid id, CustomerDto dto)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer is null) return null;
        customer.CompanyName = dto.CompanyName;
        customer.Fantasy = dto.Fantasy;
        customer.Cnpj = dto.Cnpj;
        customer.StateRegistration = dto.StateRegistration;
        customer.Address = dto.Address;
        customer.Contact = dto.Contact;
        await _context.SaveChangesAsync();
        return customer;
    }

    public async Task<List<Customer>> GetAllAsync()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task<Customer?> GetByIdAsync(Guid id)
    {
        return await _context.Customers.FindAsync(id);
    }
}