public class Address
{
    string _streetAddress;

    string _city;

    string _state;

    string _country;
    public bool InUSA() => _country == "USA";

    public string GetFullAddress() => $"{_streetAddress}\n{_city}, {_state}, {_country}";

    public Address(string streetAddress, string city, string state, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _state = state;
        _country = country;
    }
}