using Captain.Entities;

namespace Captain.Interfaces;

public interface IListRepository
{
    Task<IEnumerable<Captain.Entities.List>> GetAllAsync();
    Task<Captain.Entities.List?> GetByIdAsync(Guid id);
    Task<Captain.Entities.List> AddAsync(Captain.Entities.List list);
    Task<Captain.Entities.List> UpdateAsync(Captain.Entities.List list);
    Task DeleteAsync(Captain.Entities.List list);
}