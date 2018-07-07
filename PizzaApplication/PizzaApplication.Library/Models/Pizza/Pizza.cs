using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PizzaApplication.Library
{
    public class Pizza : IPizza
    {
        // fields and properties
        public Crust PizzaCrust { get; set; } = new Crust();
        public Sauce PizzaSauce { get; set; } = new Sauce();
        public Cheese PizzaCheese { get; set; } = new Cheese();
        public IEnumerable<Topping> ToppingList = new List<Topping>();
        public int MaxToppings { get; set; } = 6;
        public IEnumerable<IIngredient> PizzaComposition = new List<IIngredient>();
        public decimal PizzaPrice { get; set; } = 0.00m;

        // constructor
        public Pizza()
        {
            BuildPizza();
        }

        public Pizza(Crust crust, Sauce sauce, Cheese cheese)
        {
            PizzaCrust = crust;
            PizzaSauce = sauce;
            PizzaCheese = cheese;
            BuildPizza();
        }

        public Pizza(Crust crust, Sauce sauce, Cheese cheese, List<Topping> toppingList)
        {
            PizzaCrust = crust;
            PizzaSauce = sauce;
            PizzaCheese = cheese;
            ToppingList = toppingList;
            BuildPizza();
        }
        
        // methods
        public void SetNewCrust(string crustSize, string crustThickness)
        {
            PizzaCrust = new Crust(crustSize, crustThickness);
        }

        public void SetNewSauce(string sauceType, string sauceThickness)
        {
            PizzaSauce = new Sauce(sauceType, sauceThickness);
        }

        public void SetNewCheese(string cheeseType, string cheeseThickness)
        {
            PizzaCheese = new Cheese(cheeseType, cheeseThickness);
        }

        private void AddIngredient(IIngredient ingredient)
        {
            if (ingredient != null)
            {
                var pizzaComposition = (List<IIngredient>)PizzaComposition;
                pizzaComposition.Add(ingredient);
            }
        }

        public void BuildPizza()
        {
            var pizzaComposition = (List<IIngredient>)PizzaComposition;
            pizzaComposition.Clear();
            AddIngredient(PizzaCrust);
            AddIngredient(PizzaSauce);
            AddIngredient(PizzaCheese);
            if (ToppingList != null)
            {
                foreach (var topping in ToppingList)
                {
                    AddIngredient(topping);
                }
            }
            CalculatePizzaPrice();
        }

        public void BuildPizza(Crust crust)
        {
            var pizzaComposition = (List<IIngredient>)PizzaComposition;
            pizzaComposition.Clear();
            AddIngredient(PizzaCrust = crust);
            CalculatePizzaPrice();
        }

        public void BuildPizza(Crust crust, Sauce sauce)
        {
            var pizzaComposition = (List<IIngredient>)PizzaComposition;
            pizzaComposition.Clear();
            AddIngredient(PizzaCrust = crust);
            AddIngredient(PizzaSauce = sauce);
            CalculatePizzaPrice();
        }

        public void BuildPizza(Crust crust, Sauce sauce, Cheese cheese)
        {
            var pizzaComposition = (List<IIngredient>)PizzaComposition;
            pizzaComposition.Clear();
            AddIngredient(PizzaCrust = crust);
            AddIngredient(PizzaSauce = sauce);
            AddIngredient(PizzaCheese = cheese);
            CalculatePizzaPrice();
        }

        public void BuildPizza(Crust crust, Sauce sauce, Cheese cheese, List<Topping> toppingList)
        {
            var pizzaComposition = (List<IIngredient>)PizzaComposition;
            pizzaComposition.Clear();
            AddIngredient(PizzaCrust = crust);
            AddIngredient(PizzaSauce = sauce);
            AddIngredient(PizzaCheese = cheese);            
            if (toppingList != null)
            {
                ToppingList = toppingList;
                foreach (var topping in toppingList)
                {
                    AddIngredient(topping);
                }
            }
            CalculatePizzaPrice();
        }

        public void PrintPizza()
        {
            Console.WriteLine($"\nPizza: " +
                $"\n{PizzaCrust.CrustSize} {PizzaCrust.CrustThickness} " +
                $"\n{PizzaSauce.SauceType}({PizzaSauce.SauceThickness}) " +
                $"\n{PizzaCheese.CheeseType}({PizzaCheese.CheeseThickness})");
            if (ToppingList.Count() > 0)
            {
                var toppingListString = "Toppings: ";
                foreach (var topping in ToppingList)
                {
                    toppingListString += $"{topping.ToppingType}, ";
                }
                toppingListString = toppingListString.Trim(' ');
                toppingListString = toppingListString.Trim(',');
                Console.WriteLine(toppingListString);
            }
            Console.WriteLine($"Price: ${PizzaPrice}");
        }

                
        public void CalculatePizzaPrice()
        {
            PizzaPrice = 0.00m; // reset price before calculating
            if (PizzaComposition != null)
            {
                foreach (var ingredient in PizzaComposition)
                {
                    PizzaPrice += ingredient.IngredientPrice;
                }
            }            
        }
    }
}
