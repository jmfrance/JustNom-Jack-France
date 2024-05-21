using System.Collections.Generic;

public class PizzaRecipe
{
    public string Name { get; set; }
    public int Price { get; set; }
    public List<Topping> Toppings { get; set; }

    public PizzaRecipe(string name, int price, List<Topping> toppings)
    {
        Name = name;
        Price = price;
        Toppings = toppings;
    }

    public override string ToString()
    {
        var toppings = string.Join(", ", Toppings);
        return $"{Name} - £{Price / 100.0:F2}, Toppings: {toppings}";
    }
}
