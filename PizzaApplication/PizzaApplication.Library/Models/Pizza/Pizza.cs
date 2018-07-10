using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Serialization;

namespace PizzaApplication.Library
{
    public class Pizza
    {
        // fields and properties
        [XmlAttribute]
        public int ID { get; set; }
        [XmlAttribute]
        public string PizzaName { get; set; }

        public Crust PizzaCrust { get; set; } = new Crust();
        public Sauce PizzaSauce { get; set; } = new Sauce();
        public Cheese PizzaCheese { get; set; } = new Cheese();
        public List<Topping> ToppingList = new List<Topping>();        
        public decimal PizzaPrice { get; set; } = 0.00m;
        [XmlIgnore]
        public int MaxToppings { get; set; } = 6;
        [XmlIgnore]
        public List<IIngredient> PizzaComposition = new List<IIngredient>();
        

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
                PizzaComposition.Add(ingredient);
            }
        }

        public void BuildPizza()
        {
            PizzaComposition.Clear();
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
            NamePizza();
        }

        public void BuildPizza(Crust crust)
        {            
            PizzaComposition.Clear();
            AddIngredient(PizzaCrust = crust);
            CalculatePizzaPrice();
            NamePizza();
        }

        public void BuildPizza(Crust crust, Sauce sauce)
        {
            PizzaComposition.Clear();
            AddIngredient(PizzaCrust = crust);
            AddIngredient(PizzaSauce = sauce);
            CalculatePizzaPrice();
            NamePizza();
        }

        public void BuildPizza(Crust crust, Sauce sauce, Cheese cheese)
        {
            PizzaComposition.Clear();
            AddIngredient(PizzaCrust = crust);
            AddIngredient(PizzaSauce = sauce);
            AddIngredient(PizzaCheese = cheese);
            CalculatePizzaPrice();
            NamePizza();
        }

        public void BuildPizza(Crust crust, Sauce sauce, Cheese cheese, List<Topping> toppingList)
        {
            PizzaComposition.Clear();
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
            NamePizza();
        }

        public void NamePizza()
        {
            PizzaName = $"{PizzaCrust.CrustSize} {PizzaCrust.CrustThickness} Pizza with {PizzaSauce.SauceType}({PizzaSauce.SauceThickness}), {PizzaCheese.CheeseType}({PizzaCheese.CheeseThickness}), ";
            if (ToppingList.Count() > 0)
            {
                var toppingListString = "";
                foreach (var topping in ToppingList)
                {
                    toppingListString += $"{topping.ToppingType}, ";
                }                
                PizzaName += toppingListString;
            }
            PizzaName = PizzaName.Trim(' ');
            PizzaName = PizzaName.Trim(',');
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
