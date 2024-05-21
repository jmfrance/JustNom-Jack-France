using System.Collections.Generic;

public abstract class FoodItem
{
    public string Name { get; set; }
    public int Price { get; set; }
    public List<string> Customizations { get; set; } = new List<string>();

    public FoodItem(string name, int price)
    {
        Name = name;
        Price = price;
    }

    public virtual int GetPrice()
    {
        return Price;
    }

    public override string ToString()
    {
        return $"{Name} - £{Price / 100.0:F2}";
    }
}
