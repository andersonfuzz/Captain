namespace Captain.Entities;

public class Address
{
    public string Road { get; private set; } = string.Empty;
    public string Number { get; private set; } = string.Empty;
    public string District { get; private set; } = string.Empty;
    public string City { get; private set; } = string.Empty;
    public string State { get; private set; } = string.Empty;
    public string ZipCode { get; private set; } = string.Empty;

    protected Address() { }

    public Address(string road, string number, string district, string city, string state, string zipCode)
    {
        Road = road;
        Number = number;
        District = district;
        City = city;
        State = state;
        ZipCode = zipCode;
    }
}