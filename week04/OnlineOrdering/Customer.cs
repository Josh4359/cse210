public class Customer
{
    string _name;
    public string GetName() => _name;

    Address _address;
    public Address GetAddress() => _address;
    public bool InUSA() => _address.InUSA();

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }
}