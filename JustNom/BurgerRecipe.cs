using System.Collections.Generic;

public class BurgerRecipe
{
    public string Name { get; set; }
    public int Price { get; set; }
    public List<Garnish> Garnishes { get; set; }

    public BurgerRecipe(string name, int price, List<Garnish> garnishes)
    {
        Name = name;
        Price = price;
        Garnishes = garnishes;
    }

    public override string ToString()
    {
        var garnishes = string.Join(", ", Garnishes);
        return $"{Name} - £{Price / 100.0:F2}, Garnishes: {garnishes}";
    }
}
