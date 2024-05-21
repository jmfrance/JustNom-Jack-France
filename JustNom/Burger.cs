public class Burger : FoodItem
{
    public BurgerRecipe Recipe { get; set; }

    public Burger(string name, int price, BurgerRecipe recipe) : base(name, price)
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
            Garnish garnish = Recipe.Garnishes.Find(g => g.Name == customization);
            if (garnish != null)
            {
                customizationsCost += garnish.Price;
                customizationsList.Add($"{customization} - £{garnish.Price / 100.0:F2}");
            }
        }

        string customizationsString = customizationsList.Count > 0 ? "\n  Customizations: " + string.Join(", ", customizationsList) : "";
        string customizationsCostString = customizationsCost > 0 ? $" (+£{customizationsCost / 100.0:F2})" : "";

        return $"{Name} - £{Price / 100.0:F2}{customizationsCostString}{customizationsString}";
    }
}