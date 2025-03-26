public class Product
{
    string _name;
    public string GetName() => _name;

    int _productId;
    public int GetProductId() => _productId;

    float _price;
    public float GetPrice() => _price;

    int _quantity;
    public int GetQuantity() => _quantity;

    public float GetTotalCost() => _price * _quantity;

    public Product(string name, int productId, float price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }
}