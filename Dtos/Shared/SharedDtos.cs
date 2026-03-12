namespace Captain.Dtos.Shared;

public record AddressDto(
    string Road,
    string Number,
    string District,
    string City,
    string State,
    string ZipCode
);

public record ContactDto(
    string Phone,
    string Email
);