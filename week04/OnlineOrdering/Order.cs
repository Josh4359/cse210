using static Utility;

public class Order
{
    List<Product> _products;

    Customer _customer;

    public Order(List<Product> products, Customer customer)
    {
        _products = products;
        _customer = customer;
    }

    float GetSubtotal()
    {
        float subtotal = 0;

        foreach (Product product in _products)
            subtotal += product.GetTotalCost();
        
        return subtotal;
    }

    float GetShipping() => _customer.InUSA() ? 5 : 35;

    float GetTotalCost()
    {
        float totalCost = GetSubtotal();
        
        totalCost += GetShipping();
        
        return totalCost;
    }

    string GetPackingLabel()
    {
        string packingLabel = string.Empty;

        int count = _products.Count;
        for (int i = 0; i < count; i++)
        {
            Product product = _products[i];

            packingLabel += $"Name: {product.GetName()}; Product ID: {product.GetProductId()}; Price: ${product.GetPrice():0.00}; Quantity: {product.GetQuantity()}; Total Price: ${product.GetTotalCost():0.00}";

            if (i < count - 1)
                packingLabel += '\n';
        }
        
        return packingLabel;
    }

    string GetShippingLabel() => $"{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";

    public void DisplayOrder()
    {
        string packingLabel = GetPackingLabel();
        Print("Packing Label:");
        Print(packingLabel);
        Print();

        string shippingLabel = GetShippingLabel();
        Print("Shipping Label: ");
        Print(shippingLabel);
        Print();

        float subtotal = GetSubtotal();
        Print($"Subtotal: ${subtotal:0.00}");

        float shipping = GetShipping();
        Print($"Shipping: ${shipping:0.00}");

        float totalCost = GetTotalCost();
        Print($"Total Cost: ${totalCost:0.00}");
    }
}