using System;
using System.Collections.Generic;

public class JustNomApplication
{
    public string ShopName { get; set; }
    public Menu Menu { get; set; } = new Menu();
    public List<Order> Orders { get; set; } = new List<Order>();

    public JustNomApplication(string shopName)
    {
        ShopName = shopName;
    }

    public void PlaceOrder(Order order)
    {
        Orders.Add(order);
    }

    public void OutputAllOrders()
    {
        foreach (var order in Orders)
        {
            Console.WriteLine(order);
        }
    }
}
