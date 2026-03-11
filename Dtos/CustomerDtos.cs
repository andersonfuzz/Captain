namespace Captain.Dtos;

public record CreateCustomerRequest(
    string CompanyName,
    string Fantasy,
    string Cnpj,
    string StateRegistration,
    AddressDto Address,
    ContactDto Contact
);

public record UpdateCustomerRequest(
    string CompanyName,
    string Fantasy,
    string StateRegistration,
    AddressDto Address,
    ContactDto Contact
);

public record CustomerResponse(
    Guid Id,
    string CompanyName,
    string Fantasy,
    string Cnpj,
    string StateRegistration,
    AddressDto Address,
    ContactDto Contact,
    DateTime RegistrationDate
);