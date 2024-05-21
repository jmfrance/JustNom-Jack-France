using System;
using System.Collections.Generic;
using System.Linq;

//ADD ABILITY TO PURCHASE MULTIPLE EXTRA TOPPINGS 
// ADD ABILITY TO REMOVE TOPPINGS
// FIX ENCAPSULATION AND COHESION AND POLYMORPHISM
// ADD NOTIFICATION OF DELIVERY FEE AND DEAL
// ADD ABILITY TO ORDER MORE THAN 1 ITEM PER ORDER 

class Program
{
    static void Main(string[] args)
    {
        var app = new JustNomApplication("Fast Food Emporium");

        
        var cheese = new Topping("Cheese", 80);
        var tomatoSauce = new Topping("Tomato Sauce", 40);
        var ham = new Topping("Ham", 150);
        var mushroom = new Topping("Mushroom", 80);
        var pepperoni = new Topping("Pepperoni", 120);

        var cheeseGarnish = new Garnish("Cheese", 100);
        var friedOnions = new Garnish("Fried Onions", 80);
        var bacon = new Garnish("Bacon", 150);

        
        app.Menu.Toppings.AddRange(new List<Topping> { cheese, tomatoSauce, ham, mushroom, pepperoni });
        app.Menu.Garnishes.AddRange(new List<Garnish> { cheeseGarnish, friedOnions, bacon });

        
        var margheritaRecipe = new PizzaRecipe("Margherita", 500, new List<Topping> { tomatoSauce, cheese });
        var hamAndMushroomRecipe = new PizzaRecipe("Ham and Mushroom", 650, new List<Topping> { tomatoSauce, ham, mushroom, cheese });
        var pepperoniRecipe = new PizzaRecipe("Pepperoni", 700, new List<Topping> { tomatoSauce, cheese, pepperoni });

        var plainBurgerRecipe = new BurgerRecipe("Plain Burger", 350, new List<Garnish>());
        var cheeseBurgerRecipe = new BurgerRecipe("Cheese Burger", 450, new List<Garnish> { cheeseGarnish });

        
        app.Menu.PizzaRecipes.AddRange(new List<PizzaRecipe> { margheritaRecipe, hamAndMushroomRecipe, pepperoniRecipe });
        app.Menu.BurgerRecipes.AddRange(new List<BurgerRecipe> { plainBurgerRecipe, cheeseBurgerRecipe });

        
        Console.WriteLine("Welcome to JustNom! Please enter your name:");
        string customerName = Console.ReadLine();
        var customer = new Customer(customerName);

        Console.WriteLine("Enter the name of the restaurant you're ordering from:");
        string restaurantName = Console.ReadLine();

        Console.WriteLine("Would you like to order a Pizza (1) or a Burger (2)?");
        int choice = int.Parse(Console.ReadLine());

        FoodItem selectedItem = null;
        if (choice == 1)
        {
            Console.WriteLine("Select a Pizza:");
            for (int i = 0; i < app.Menu.PizzaRecipes.Count; i++)
            {
                var recipe = app.Menu.PizzaRecipes[i];
                Console.WriteLine($"{i + 1}. {recipe.Name} - £{recipe.Price / 100.0:F2}");
            }
            int pizzaChoice = int.Parse(Console.ReadLine()) - 1;
            var selectedRecipe = app.Menu.PizzaRecipes[pizzaChoice];
            selectedItem = new Pizza(selectedRecipe.Name, selectedRecipe.Price, selectedRecipe);

            Console.WriteLine("Do you want any additional toppings? (Type the number, separated by commas if more than one, e.g. 1, 3, 4, or 'no' for none)");
            for (int i = 0; i < app.Menu.Toppings.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {app.Menu.Toppings[i]}");
            }
            string toppingInput = Console.ReadLine();
            if (toppingInput.ToLower() != "no")
            {
                try
                {
                    var toppingChoices = toppingInput.Split(',').Select(int.Parse).ToList();
                    foreach (var toppingChoice in toppingChoices)
                    {
                        if (toppingChoice > 0 && toppingChoice <= app.Menu.Toppings.Count)
                        {
                            selectedItem.Customizations.Add(app.Menu.Toppings[toppingChoice - 1].Name);
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid input for toppings. No additional toppings added.");
                }
            }
        }
        else if (choice == 2)
        {
            Console.WriteLine("Select a Burger:");
            for (int i = 0; i < app.Menu.BurgerRecipes.Count; i++)
            {
                var recipe = app.Menu.BurgerRecipes[i];
                Console.WriteLine($"{i + 1}. {recipe.Name} - £{recipe.Price / 100.0:F2}");
            }
            int burgerChoice = int.Parse(Console.ReadLine()) - 1;
            var selectedRecipe = app.Menu.BurgerRecipes[burgerChoice];
            selectedItem = new Burger(selectedRecipe.Name, selectedRecipe.Price, selectedRecipe);

            Console.WriteLine("Do you want any additional garnishes? (Type the number, separated by commas if more than one, e.g. 1, 3, 4, or 'no' for none)");
            for (int i = 0; i < app.Menu.Garnishes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {app.Menu.Garnishes[i]}");
            }
            string garnishInput = Console.ReadLine();
            if (garnishInput.ToLower() != "no")
            {
                try
                {
                    var garnishChoices = garnishInput.Split(',').Select(int.Parse).ToList();
                    foreach (var garnishChoice in garnishChoices)
                    {
                        if (garnishChoice > 0 && garnishChoice <= app.Menu.Garnishes.Count)
                        {
                            selectedItem.Customizations.Add(app.Menu.Garnishes[garnishChoice - 1].Name);
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid input for garnishes. No additional garnishes added.");
                }
            }
        }

        Console.WriteLine("Is this a delivery order? (yes/no)");
        bool isDelivery = Console.ReadLine().ToLower() == "yes";
        Address deliveryAddress = null;
        if (isDelivery)
        {
            Console.WriteLine("Enter the delivery address:");
            string address = Console.ReadLine();
            deliveryAddress = new Address(address);
        }

        var order = new Order(customer, isDelivery, deliveryAddress);
        order.AddItem(selectedItem);
        app.PlaceOrder(order);

        Console.WriteLine(order);
    }
}

