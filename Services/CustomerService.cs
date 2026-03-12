using Captain.Dtos;
using Captain.Dtos.Shared;
using Captain.Entities;
using Captain.Interfaces;

namespace Captain.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _repository;

    public CustomerService(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<CustomerResponse>> GetAllAsync()
    {
        var customers = await _repository.GetAllAsync();
        return customers.Select(MapToResponse);
    }

    public async Task<CustomerResponse?> GetByIdAsync(Guid id)
    {
        var customer = await _repository.GetByIdAsync(id);
        return customer is null ? null : MapToResponse(customer);
    }

    public async Task<CustomerResponse> CreateAsync(CreateCustomerRequest request)
    {
        var address = new Address(
            request.Address.Road,
            request.Address.Number,
            request.Address.District,
            request.Address.City,
            request.Address.State,
            request.Address.ZipCode
        );

        var contact = new Contact(
            request.Contact.Phone,
            request.Contact.Email
        );

        var customer = new Customer(
            request.CompanyName,
            request.Fantasy,
            request.Cnpj,
            request.StateRegistration,
            address,
            contact
        );

        var created = await _repository.AddAsync(customer);
        return MapToResponse(created);
    }

    public async Task<CustomerResponse?> UpdateAsync(Guid id, UpdateCustomerRequest request)
    {
        var customer = await _repository.GetByIdAsync(id);

        if (customer is null)
            return null;

        customer.Update(
            request.CompanyName,
            request.Fantasy,
            request.StateRegistration,
            new Address(request.Address.Road, request.Address.Number, request.Address.District, request.Address.City, request.Address.State, request.Address.ZipCode),
            new Contact(request.Contact.Phone, request.Contact.Email)
        );

        var updated = await _repository.UpdateAsync(customer);
        return MapToResponse(updated);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var customer = await _repository.GetByIdAsync(id);

        if (customer is null)
            return false;

        await _repository.DeleteAsync(customer);
        return true;
    }

    private static CustomerResponse MapToResponse(Customer customer) => new(
        customer.Id,
        customer.CompanyName,
        customer.Fantasy,
        customer.Cnpj,
        customer.StateRegistration,
        new AddressDto(customer.Address.Road, customer.Address.Number, customer.Address.District, customer.Address.City, customer.Address.State, customer.Address.ZipCode),
        new ContactDto(customer.Contact.Phone, customer.Contact.Email),
        customer.RegistrationDate
    );
}