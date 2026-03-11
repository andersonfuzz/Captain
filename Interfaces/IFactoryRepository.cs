using Captain.Entities;

namespace Captain.Interfaces;

public interface IFactoryRepository
{
    Task<IEnumerable<Factory>> GetAllAsync();
    Task<Factory?> GetByIdAsync(Guid id);
    Task<Factory> AddAsync(Factory factory);
    Task<Factory> UpdateAsync(Factory factory);
    Task DeleteAsync(Factory factory);
}