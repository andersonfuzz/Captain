using Captain.Dtos.Shared;

namespace Captain.Dtos;

public record CreateFactoryRequest(
    string CompanyName,
    string Fantasy,
    string Cnpj,
    string StateRegistration,
    AddressDto Address,
    ContactDto Contact
);

public record UpdateFactoryRequest(
    string CompanyName,
    string Fantasy,
    string StateRegistration,
    AddressDto Address,
    ContactDto Contact
);

public record FactoryResponse(
    Guid Id,
    string CompanyName,
    string Fantasy,
    string Cnpj,
    string StateRegistration,
    AddressDto Address,
    ContactDto Contact,
    DateTime RegistrationDate
);