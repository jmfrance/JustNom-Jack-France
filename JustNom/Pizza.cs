public class Pizza : FoodItem
{
    public PizzaRecipe Recipe { get; set; }

    public Pizza(string name, int price, PizzaRecipe recipe) : base(name, price)
    {
        Recipe = recipe;
    }

    public override int GetPrice()
    {
        return Price;
    }

    public override string ToString()
    {
        List<string> customizationsList = new List<string>();
        int customizationsCost = 0;

        foreach (string customization in Customizations)
        {
            Topping topping = Recipe.Toppings.Find(t => t.Name == customization);
            if (topping != null)
            {
                customizationsCost += topping.Price;
                customizationsList.Add($"{customization} - £{topping.Price / 100.0:F2}");
            }
        }

        string customizationsString = customizationsList.Count > 0 ? "\n  Customizations: " + string.Join(", ", customizationsList) : "";
        string customizationsCostString = customizationsCost > 0 ? $" (+£{customizationsCost / 100.0:F2})" : "";

        return $"{Name} - £{Price / 100.0:F2}{customizationsCostString}{customizationsString}";
    }
}