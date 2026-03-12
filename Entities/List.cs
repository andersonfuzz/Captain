namespace Captain.Entities;

public class List
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public string Name { get; private set; } = string.Empty;

    public Guid FactoryId { get; private set; }
    public Factory Factory { get; private set; } = null!;

    public List<Item> Items { get; private set; } = new();

    protected List() { }

    public List(string name, Guid factoryId)
    {
        Name = name;
        FactoryId = factoryId;
    }

    public void Update(string name)
    {
        Name = name;
    }
    public void AddItem(string name, string description, decimal price)
    {
        var item = new Item(name, description, price, FactoryId);
        Items.Add(item);
    }
}