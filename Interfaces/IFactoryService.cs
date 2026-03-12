using Captain.Dtos;

namespace Captain.Interfaces;

public interface IFactoryService
{
    Task<IEnumerable<FactoryResponse>> GetAllAsync();
    Task<FactoryResponse?> GetByIdAsync(Guid id);
    Task<FactoryResponse> CreateAsync(CreateFactoryRequest request);
    Task<FactoryResponse?> UpdateAsync(Guid id, UpdateFactoryRequest request);
    Task<bool> DeleteAsync(Guid id);
}