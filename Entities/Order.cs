namespace Captain.Entities;

public class Order
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public Guid CustomerId { get; private set; }
    public Customer Customer { get; private set; } = null!;

    public Guid FactoryId { get; private set; }
    public Factory Factory { get; private set; } = null!;

    public List<Item> Items { get; private set; } = new();

    protected Order() { }

    public Order(Guid customerId, Guid factoryId)
    {
        CustomerId = customerId;
        FactoryId = factoryId;
    }
}