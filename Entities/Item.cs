namespace Captain.Entities;

public class Item
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public decimal Price { get; private set; }

    public Guid FactoryId { get; private set; }
    public Factory Factory { get; private set; } = null!;

    protected Item() { }

    public Item(string name, string description, decimal price, Guid factoryId)
    {
        Name = name;
        Description = description;
        Price = price;
        FactoryId = factoryId;
    }
}