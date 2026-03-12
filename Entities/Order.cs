using Captain.Dtos;

namespace Captain.Entities;

public class Order
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public Guid CustomerId { get; private set; }
    public Customer Customer { get; private set; } = null!;

    public Guid FactoryId { get; private set; }
    public Factory Factory { get; private set; } = null!;

    public List<OrderItem> Items { get; private set; } = new();

    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    protected Order() { }

    public Order(Guid customerId, Guid factoryId)
    {
        CustomerId = customerId;
        FactoryId = factoryId;
    }

    public void AddItem(Item item, int quantity)
    {
        var orderItem = new OrderItem(Id, item.Id, quantity, item.Price);
        Items.Add(orderItem);
    }

    public void UpdateItems(IEnumerable<Item> items, IEnumerable<ItemOrderDto> itemRequests)
    {
        Items.Clear();
        foreach (var itemRequest in itemRequests)
        {
            var item = items.First(i => i.Id == itemRequest.ItemId);
            AddItem(item, itemRequest.Quantity);
        }
    }
}