using Captain.Dtos;
using Captain.Dtos.Shared;
using Captain.Entities;
using Captain.Interfaces;

namespace Captain.Services;

public class FactoryService : IFactoryService
{
    private readonly IFactoryRepository _repository;

    public FactoryService(IFactoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<FactoryResponse>> GetAllAsync()
    {
        var factories = await _repository.GetAllAsync();
        return factories.Select(MapToResponse);
    }

    public async Task<FactoryResponse?> GetByIdAsync(Guid id)
    {
        var factory = await _repository.GetByIdAsync(id);
        return factory is null ? null : MapToResponse(factory);
    }

    public async Task<FactoryResponse> CreateAsync(CreateFactoryRequest request)
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

        var factory = new Factory(
            request.CompanyName,
            request.Fantasy,
            request.Cnpj,
            request.StateRegistration,
            address,
            contact
        );

        var created = await _repository.AddAsync(factory);
        return MapToResponse(created);
    }

    public async Task<FactoryResponse?> UpdateAsync(Guid id, UpdateFactoryRequest request)
    {
        var factory = await _repository.GetByIdAsync(id);

        if (factory is null)
            return null;

        factory.Update(
            request.CompanyName,
            request.Fantasy,
            request.StateRegistration,
            new Address(request.Address.Road, request.Address.Number, request.Address.District, request.Address.City, request.Address.State, request.Address.ZipCode),
            new Contact(request.Contact.Phone, request.Contact.Email)
        );

        var updated = await _repository.UpdateAsync(factory);
        return MapToResponse(updated);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var factory = await _repository.GetByIdAsync(id);

        if (factory is null)
            return false;

        await _repository.DeleteAsync(factory);
        return true;
    }

    private static FactoryResponse MapToResponse(Factory factory) => new(
        factory.Id,
        factory.CompanyName,
        factory.Fantasy,
        factory.Cnpj,
        factory.StateRegistration,
        new AddressDto(factory.Address.Road, factory.Address.Number, factory.Address.District, factory.Address.City, factory.Address.State, factory.Address.ZipCode),
        new ContactDto(factory.Contact.Phone, factory.Contact.Email),
        factory.RegistrationDate
    );
}