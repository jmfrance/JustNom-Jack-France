public class Topping
{
    public string Name { get; set; }
    public int Price { get; set; }

    public Topping(string name, int price)
    {
        Name = name;
        Price = price;
    }

    public override string ToString()
    {
        return $"{Name} - £{Price / 100.0:F2}";
    }
}
