using System;
using static Utility;

class Program
{
    static void Main(string[] args)
    {
        List<Order> orders = new();

        // Order 1
        List<Product> products1 = new ()
        {
            new("Product 1", 1, 1, 1),
            new("Product 2", 2, 1, 2),
            new("Product 3", 3, 1, 3)
        };

        Address address1 = new("Street Address 1", "City 1", "State 1", "USA");
        Customer customer1 = new("Customer 1", address1);
        
        Order order1 = new(products1, customer1);
        orders.Add(order1);

        // Order 2
        List<Product> products2 = new ()
        {
            new("Product 1", 1, 2, 1),
            new("Product 2", 2, 2, 2),
            new("Product 3", 3, 2, 3)
        };

        Address address2 = new("Street Address 2", "City 2", "State 2", "Not USA");
        Customer customer2 = new("Customer 2", address2);
        
        Order order2 = new(products2, customer2);
        orders.Add(order2);

        // Order 3
        List<Product> products3 = new ()
        {
            new("Product 1", 1, 3, 1),
            new("Product 2", 2, 3, 2),
            new("Product 3", 3, 3, 3)
        };

        Address address3 = new("Street Address 3", "City 3", "State 3", "USA");
        Customer customer3 = new("Customer 3", address3);
        
        Order order3 = new(products3, customer3);
        orders.Add(order3);
        
        // Display
        string separator = new('-', 50);

        foreach (Order order in orders)
        {
            Print(separator);

            order.DisplayOrder();

            Print(separator);
        }
    }
}