using Captain.Dtos;
using Captain.Entities;
using Captain.Interfaces;

namespace Captain.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IItemRepository _itemRepository;

    public OrderService(IOrderRepository orderRepository, IItemRepository itemRepository)
    {
        _orderRepository = orderRepository;
        _itemRepository = itemRepository;
    }

    public async Task<IEnumerable<OrderResponse>> GetAllAsync()
    {
        var orders = await _orderRepository.GetAllAsync();
        return orders.Select(MapToResponse);
    }

    public async Task<OrderResponse?> GetByIdAsync(Guid id)
    {
        var order = await _orderRepository.GetByIdAsync(id);
        return order is null ? null : MapToResponse(order);
    }

    public async Task<OrderResponse> CreateAsync(CreateOrderRequest request)
    {
        var items = await _itemRepository.GetByIdsAsync(request.Items.Select(i => i.ItemId));

        if (items.Any(i => i.FactoryId != request.FactoryId))
            throw new InvalidOperationException("All items must belong to the same factory.");

        var order = new Order(request.CustomerId, request.FactoryId);

        foreach (var itemRequest in request.Items)
        {
            var item = items.First(i => i.Id == itemRequest.ItemId);
            order.AddItem(item, itemRequest.Quantity);
        }

        var created = await _orderRepository.AddAsync(order);
        return MapToResponse(created);
    }

    public async Task<OrderResponse?> UpdateAsync(Guid id, UpdateOrderRequest request)
    {
        var order = await _orderRepository.GetByIdAsync(id);

        if (order is null)
            return null;

        var items = await _itemRepository.GetByIdsAsync(request.Items.Select(i => i.ItemId));

        if (items.Any(i => i.FactoryId != order.FactoryId))
            throw new InvalidOperationException("All items must belong to the same factory.");

        order.UpdateItems(items, request.Items);

        var updated = await _orderRepository.UpdateAsync(order);
        return MapToResponse(updated);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var order = await _orderRepository.GetByIdAsync(id);

        if (order is null)
            return false;

        await _orderRepository.DeleteAsync(order);
        return true;
    }

    private static OrderResponse MapToResponse(Order order) => new(
        order.Id,
        order.CustomerId,
        order.Customer.CompanyName,
        order.FactoryId,
        order.Factory.CompanyName,
        order.Items.Select(oi => new ItemOrderResponse(
            oi.ItemId,
            oi.Item.Name,
            oi.UnitPrice,
            oi.Quantity,
            oi.Total
        )).ToList(),
        order.CreatedAt
    );
}