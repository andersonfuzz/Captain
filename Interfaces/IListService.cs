using Captain.Dtos;

namespace Captain.Interfaces;

public interface IListService
{
    Task<IEnumerable<ListResponse>> GetAllAsync();
    Task<ListResponse?> GetByIdAsync(Guid id);
    Task<ListResponse> CreateAsync(CreateListRequest request);
    Task<ListResponse?> UpdateAsync(Guid id, UpdateListRequest request);
    Task<bool> DeleteAsync(Guid id);
    Task<ListResponse?> AddItemAsync(Guid id, CreateItemRequest request);
}