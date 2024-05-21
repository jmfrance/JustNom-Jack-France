using System.Collections.Generic;
public class Order
{
    public Customer Customer { get; set; }
    public bool IsDelivery { get; set; }
    public Address DeliveryAddress { get; set; }
    public List<FoodItem> Items { get; set; } = new List<FoodItem>();

    public Order(Customer customer, bool isDelivery, Address deliveryAddress)
    {
        Customer = customer;
        IsDelivery = isDelivery;
        DeliveryAddress = deliveryAddress;
    }

    public void AddItem(FoodItem item)
    {
        Items.Add(item);
    }

    public int GetTotalPrice()
    {
        int total = 0;
        foreach (FoodItem item in Items)
        {
            total += item.GetPrice();

            // Add the price of customizations (additional toppings or garnishes)
            if (item is Pizza pizza)
            {
                foreach (Topping topping in pizza.Recipe.Toppings)
                {
                    if (pizza.Customizations.Contains(topping.Name))
                    {
                        total += topping.Price;
                    }
                }
            }
            else if (item is Burger burger)
            {
                foreach (Garnish garnish in burger.Recipe.Garnishes)
                {
                    if (burger.Customizations.Contains(garnish.Name))
                    {
                        total += garnish.Price;
                    }
                }
            }
        }

        if (IsDelivery && total <= 2000)
        {
            total += 200; // Delivery charge
        }

        return total;
    }

    public override string ToString()
    {
        string itemsString = string.Join("\n", Items);
        string deliveryString = IsDelivery ? $"Delivery Address: {DeliveryAddress.Location}\n" : "";
        int totalPrice = GetTotalPrice();

        return $"Customer: {Customer.Name}\n{deliveryString}Items:\n{itemsString}\nTotal: £{totalPrice / 100.0:F2}";
    }
}
