namespace Captain.Entities;

public class Factory
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string CompanyName { get; private set; } = string.Empty;
    public string Fantasy { get; private set; } = string.Empty;
    public string Cnpj { get; private set; } = string.Empty;
    public string StateRegistration { get; private set; } = string.Empty;
    public DateTime RegistrationDate { get; private set; } = DateTime.UtcNow;

    public Address Address { get; private set; } = null!;
    public Contact Contact { get; private set; } = null!;

    protected Factory() { }

    public Factory(string companyName, string fantasy, string cnpj, string stateRegistration, Address address, Contact contact)
    {
        CompanyName = companyName;
        Fantasy = fantasy;
        Cnpj = cnpj;
        StateRegistration = stateRegistration;
        Address = address;
        Contact = contact;
    }

    public void Update(string companyName, string fantasy, string stateRegistration, Address address, Contact contact)
    {
        CompanyName = companyName;
        Fantasy = fantasy;
        StateRegistration = stateRegistration;
        Address = address;
        Contact = contact;
    }
}