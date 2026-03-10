using Captain.Models;

namespace Captain.Models.Company;

public abstract class Company
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string CompanyName { get; set; } = string.Empty;
    public string Fantasy { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;
    public string StateRegistration { get; set; } = string.Empty;
    public DateTime RegistrationDate { get; private set; } = DateTime.UtcNow;
    public Address Address { get; set; } = new Address();
    public Contact Contact { get; set; } = new Contact();
}