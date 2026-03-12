using Captain.Dtos;
using Captain.Entities;
using Captain.Interfaces;

namespace Captain.Services;

public class ListService : IListService
{
    private readonly IListRepository _repository;

    public ListService(IListRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ListResponse>> GetAllAsync()
    {
        var lists = await _repository.GetAllAsync();
        return lists.Select(MapToResponse);
    }

    public async Task<ListResponse?> GetByIdAsync(Guid id)
    {
        var list = await _repository.GetByIdAsync(id);
        return list is null ? null : MapToResponse(list);
    }

    public async Task<ListResponse> CreateAsync(CreateListRequest request)
    {
        var list = new Entities.List(request.Name, request.FactoryId);
        var created = await _repository.AddAsync(list);
        return MapToResponse(created);
    }

    public async Task<ListResponse?> UpdateAsync(Guid id, UpdateListRequest request)
    {
        var list = await _repository.GetByIdAsync(id);

        if (list is null)
            return null;

        list.Update(request.Name);
        var updated = await _repository.UpdateAsync(list);
        return MapToResponse(updated);
    }

    public async Task<ListResponse?> AddItemAsync(Guid id, CreateItemRequest request)
    {
        var list = await _repository.GetByIdAsync(id);

        if (list is null)
            return null;

        list.AddItem(request.Name, request.Description, request.Price);
        var updated = await _repository.UpdateAsync(list);
        return MapToResponse(updated);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var list = await _repository.GetByIdAsync(id);

        if (list is null)
            return false;

        await _repository.DeleteAsync(list);
        return true;
    }

    private static ListResponse MapToResponse(Entities.List list) => new(
        list.Id,
        list.Name,
        list.FactoryId,
        list.Factory.CompanyName,
        list.Items.Select(i => new ItemDto(
            i.Id,
            i.Name,
            i.Description,
            i.Price
        )).ToList()
    );
}