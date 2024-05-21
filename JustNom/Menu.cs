using System.Collections.Generic;

public class Menu
{
    public List<Topping> Toppings { get; set; } = new List<Topping>();
    public List<Garnish> Garnishes { get; set; } = new List<Garnish>();
    public List<PizzaRecipe> PizzaRecipes { get; set; } = new List<PizzaRecipe>();
    public List<BurgerRecipe> BurgerRecipes { get; set; } = new List<BurgerRecipe>();
}
