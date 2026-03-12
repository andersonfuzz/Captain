namespace Captain.Dtos;

public record ItemOrderDto(
    Guid ItemId,
    int Quantity
);

public record CreateOrderRequest(
    Guid CustomerId,
    Guid FactoryId,
    List<ItemOrderDto> Items
);

public record ItemOrderResponse(
    Guid ItemId,
    string Name,
    decimal UnitPrice,
    int Quantity,
    decimal Total
);

public record OrderResponse(
    Guid Id,
    Guid CustomerId,
    string CustomerName,
    Guid FactoryId,
    string FactoryName,
    List<ItemOrderResponse> Items,
    DateTime CreatedAt
);
public record UpdateOrderRequest(
    List<ItemOrderDto> Items
);