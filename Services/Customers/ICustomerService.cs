using Captain.Models.Customers;

namespace Captain.Services.Customers;

public interface ICustomerService
{
    Task<List<Customer>> GetAllAsync();
    Task<Customer?> GetByIdAsync(Guid id);
    Task<Customer> AddAsync(CustomerDto dto);
    Task<Customer?> EditAsync(Guid id, CustomerDto dto);
    Task<bool> DeleteByIdAsync(Guid id);
}