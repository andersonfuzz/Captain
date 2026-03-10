using Captain.Models.Factories;
namespace Captain.Services.Factories;

public interface IFactoryService{
    Task<List<Factory>> GetAllAsync();
    Task<Factory?> GetByIdAsync(Guid id);
    Task<Factory> AddAsync(CustomerDto dto);
    Task<Factory?> EditAsync(Guid id, CustomerDto dto);
    Task<bool> DeleteByIdAsync(Guid id);
}