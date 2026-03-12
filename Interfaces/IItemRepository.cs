using Captain.Entities;

namespace Captain.Interfaces;

public interface IItemRepository
{
    Task<IEnumerable<Item>> GetByIdsAsync(IEnumerable<Guid> ids);
    Task<Item?> GetByIdAsync(Guid id);
}