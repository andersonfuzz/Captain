using Captain.Dtos;
using Captain.Entities;
using Captain.Interfaces;

namespace Captain.Services;

public class ListService : IListService
{
    private readonly IListRepository _repository;
    private readonly IFactoryRepository _factoryRepository;

    public ListService(IListRepository repository, IFactoryRepository factoryRepository)
    {
        _repository = repository;
        _factoryRepository = factoryRepository;
    }

    public async Task<IEnumerable<ListResponse>> GetAllAsync()
    {
        var lists = await _repository.GetAllAsync();
        return lists.Select(l => MapToResponse(l, l.Factory?.CompanyName ?? string.Empty));
    }

    public async Task<ListResponse?> GetByIdAsync(Guid id)
    {
        var list = await _repository.GetByIdAsync(id);
        return list is null ? null : MapToResponse(list, list.Factory?.CompanyName ?? string.Empty);
    }

    public async Task<ListResponse> CreateAsync(CreateListRequest request)
    {
        var factory = await _factoryRepository.GetByIdAsync(request.FactoryId);

        if (factory is null)
            throw new InvalidOperationException($"Factory with id '{request.FactoryId}' not found.");

        var list = new Entities.List(request.Name, request.FactoryId);
        var created = await _repository.AddAsync(list);
        return MapToResponse(created, factory.CompanyName);
    }

    public async Task<ListResponse?> UpdateAsync(Guid id, UpdateListRequest request)
    {
        var list = await _repository.GetByIdAsync(id);

        if (list is null)
            return null;

        list.Update(request.Name);
        var updated = await _repository.UpdateAsync(list);
        return MapToResponse(updated, updated.Factory?.CompanyName ?? string.Empty);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var list = await _repository.GetByIdAsync(id);

        if (list is null)
            return false;

        await _repository.DeleteAsync(list);
        return true;
    }

    private static ListResponse MapToResponse(Entities.List list, string factoryName) => new(
        list.Id,
        list.Name,
        list.FactoryId,
        factoryName,
        list.Items.Select(i => new ItemDto(
            i.Id,
            i.Name,
            i.Description,
            i.Price
        )).ToList()
    );

    public async Task<ListResponse?> AddItemAsync(Guid id, CreateItemRequest request)
    {
        var list = await _repository.GetByIdAsync(id);

        if (list is null)
            return null;

        list.AddItem(request.Name, request.Description, request.Price);

        var updated = await _repository.UpdateAsync(list);
        return MapToResponse(updated, updated.Factory?.CompanyName ?? string.Empty);
    }
}