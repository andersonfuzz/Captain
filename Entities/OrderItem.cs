namespace Captain.Entities;

public class OrderItem
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public Guid OrderId { get; private set; }
    public Order Order { get; private set; } = null!;

    public Guid ItemId { get; private set; }
    public Item Item { get; private set; } = null!;

    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }

    public decimal Total => Quantity * UnitPrice;

    protected OrderItem() { }

    public OrderItem(Guid orderId, Guid itemId, int quantity, decimal unitPrice)
    {
        OrderId = orderId;
        ItemId = itemId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }
}