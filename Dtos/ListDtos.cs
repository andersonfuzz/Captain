namespace Captain.Dtos;

public record ItemDto(
    Guid Id,
    string Name,
    string Description,
    decimal Price
);

public record CreateListRequest(
    string Name,
    Guid FactoryId
);

public record UpdateListRequest(
    string Name
);

public record ListResponse(
    Guid Id,
    string Name,
    Guid FactoryId,
    string FactoryName,
    List<ItemDto> Items
);