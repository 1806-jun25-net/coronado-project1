using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApp.Library
{
    public class Pizza
    {
        // fields and properties
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public decimal? Price { get; set; } = 0.00m;
        public Crust Crust { get; set; } = new Crust();
        public Sauce Sauce { get; set; } = new Sauce();
        public Cheese Cheese { get; set; } = new Cheese();
        public Topping Topping1 { get; set; } = new Topping();
        public Topping Topping2 { get; set; } = new Topping();
        public Topping Topping3 { get; set; } = new Topping();
        public Topping Topping4 { get; set; } = new Topping();
        public Topping Topping5 { get; set; } = new Topping();
        public Topping Topping6 { get; set; } = new Topping();
        public List<IIngredient> PizzaComposition { get => pizzaComposition; set => pizzaComposition = value; }

        private List<IIngredient> pizzaComposition = new List<IIngredient>();

        // constructors
        public Pizza()
        {

        }

        public Pizza(int pizzaId)
        {
            Id = pizzaId;
        }

        public Pizza(Crust crust, Sauce sauce, Cheese cheese)
        {
            Crust = crust;
            Sauce = sauce;
            Cheese = cheese;
        }

        public Pizza(Crust crust, Sauce sauce, Cheese cheese, List<Topping> toppingList)
        {
            Crust = crust;
            Sauce = sauce;
            Cheese = cheese;
            ProcessToppingList(toppingList);
        }

        // methods
        public void ProcessToppingList(List<Topping> toppingList)
        {
            foreach (var item in toppingList)
            {
                if (Topping1 == null)
                {
                    Topping1 = item;
                    break;
                }
                else if (Topping2 == null)
                {
                    Topping2 = item;
                    break;
                }
                else if (Topping3 == null)
                {
                    Topping3 = item;
                    break;
                }
                else if (Topping4 == null)
                {
                    Topping4 = item;
                    break;
                }
                else if (Topping5 == null)
                {
                    Topping5 = item;
                    break;
                }
                else if (Topping6 == null)
                {
                    Topping6 = item;
                    break;
                }
            }
        }

        public void CalculatePizzaPrice()
        {
            Price = 0.00m; // reset price before calculating
            if (PizzaComposition != null)
            {
                foreach (var ingredient in PizzaComposition)
                {
                    Price += ingredient.IngredientPrice;
                }
            }
        }

        private void AddIngredient(IIngredient ingredient)
        {
            if (ingredient != null)
            {
                PizzaComposition.Add(ingredient);
            }
        }

        public void BuildPizza()
        {
            PizzaComposition.Clear();
            AddIngredient(Crust);
            AddIngredient(Sauce);
            AddIngredient(Cheese);
            AddIngredient(Topping1);
            AddIngredient(Topping2);
            AddIngredient(Topping3);
            AddIngredient(Topping4);
            AddIngredient(Topping5);
            AddIngredient(Topping6);
            CalculatePizzaPrice();
            NamePizza();
        }

        public void NamePizza()
        {
            Name = $"{Crust.CrustSize} {Crust.CrustThickness} Pizza with {Sauce.SauceType}({Sauce.SauceThickness}), {Cheese.CheeseType}({Cheese.CheeseThickness}), ";
            var toppingListString = "";
            if (Topping1.ToppingType != "") toppingListString += $"{Topping1.ToppingType}, ";
            if (Topping2.ToppingType != "") toppingListString += $"{Topping2.ToppingType}, ";
            if (Topping3.ToppingType != "") toppingListString += $"{Topping3.ToppingType}, ";
            if (Topping4.ToppingType != "") toppingListString += $"{Topping4.ToppingType}, ";
            if (Topping5.ToppingType != "") toppingListString += $"{Topping5.ToppingType}, ";
            if (Topping6.ToppingType != "") toppingListString += $"{Topping6.ToppingType}, ";
            toppingListString = toppingListString.Trim(' ');
            toppingListString = toppingListString.Trim(',');
            Name += toppingListString;
            Name = Name.Trim(' ');
            Name = Name.Trim(',');
        }

        public void PrintPizza()
        {
            Console.WriteLine($"\nPizza: " +
                $"\n{Crust.CrustSize} {Crust.CrustThickness} " +
                $"\n{Sauce.SauceType}({Sauce.SauceThickness}) " +
                $"\n{Cheese.CheeseType}({Cheese.CheeseThickness})");
            var toppingListString = "Toppings: ";
            if (Topping1.ToppingType != "") toppingListString += $"{Topping1.ToppingType}, ";
            if (Topping2.ToppingType != "") toppingListString += $"{Topping2.ToppingType}, ";
            if (Topping3.ToppingType != "") toppingListString += $"{Topping3.ToppingType}, ";
            if (Topping4.ToppingType != "") toppingListString += $"{Topping4.ToppingType}, ";
            if (Topping5.ToppingType != "") toppingListString += $"{Topping5.ToppingType}, ";
            if (Topping6.ToppingType != "") toppingListString += $"{Topping6.ToppingType}, ";
            toppingListString += toppingListString;
            toppingListString = toppingListString.Trim(' ');
            toppingListString = toppingListString.Trim(',');
            Console.WriteLine(toppingListString);
            Console.WriteLine($"Price: ${Price}");
        }
    }
}
