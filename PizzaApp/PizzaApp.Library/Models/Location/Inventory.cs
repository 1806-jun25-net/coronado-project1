using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApp.Library
{
    public class Inventory
    {
        // fields and properties
        public int Id { get; set; }
        public int? LocationId { get; set; }
        public double Dough { get; set; }
        public double TomatoSauce { get; set; }
        public double WhiteSauce { get; set; }
        public double Cheese { get; set; }
        public double Pepperoni { get; set; }
        public double Ham { get; set; }
        public double Chicken { get; set; }
        public double Beef { get; set; }
        public double Sausage { get; set; }
        public double Bacon { get; set; }
        public double Anchovies { get; set; }
        public double RedPeppers { get; set; }
        public double GreenPeppers { get; set; }
        public double Pineapple { get; set; }
        public double Olives { get; set; }
        public double Mushrooms { get; set; }
        public double Garlic { get; set; }
        public double Onions { get; set; }
        public double Tomatoes { get; set; }
        public double Spinach { get; set; }
        public double Basil { get; set; }
        public double Ricotta { get; set; }
        public double Parmesan { get; set; }
        public double Feta { get; set; }
        public Location Location { get; set; }

        // constructors
        public Inventory()
        {

        }

        public Inventory(int id)
        {
            Id = id;
        }

        public Inventory(Location location)
        {
            Location = location;
        }

        // methods
        public void SetLocationFromList(List<Location> locations)
        {
            foreach (var item in locations)
            {
                if (LocationId == item.Id) Location = item;
            }
        }

        public bool CheckIfInventoryIsSufficient(IIngredient ingredient)
        {
            bool check = true;

            string iName;
            iName = ingredient.IngredientInventoryName;
            switch (iName)
            {
                case "Dough":
                    if (Dough <= 0) check = false;
                    break;
                case "Tomato Sauce":
                    if (TomatoSauce <= 0) check = false;
                    break;
                case "White Sauce":
                    if (WhiteSauce <= 0) check = false;
                    break;
                case "Cheese":
                    if (Cheese <= 0) check = false;
                    break;
                case "Pepperoni":
                    if (Pepperoni <= 0) check = false;
                    break;
                case "Ham":
                    if (Ham <= 0) check = false;
                    break;
                case "Chicken":
                    if (Chicken <= 0) check = false;
                    break;
                case "Beef":
                    if (Beef <= 0) check = false;
                    break;
                case "Sausage":
                    if (Sausage <= 0) check = false;
                    break;
                case "Bacon":
                    if (Bacon <= 0) check = false;
                    break;
                case "Anchovies":
                    if (Anchovies <= 0) check = false;
                    break;
                case "Red Peppers":
                    if (RedPeppers <= 0) check = false;
                    break;
                case "Green Peppers":
                    if (GreenPeppers <= 0) check = false;
                    break;
                case "Pineapple":
                    if (Pineapple <= 0) check = false;
                    break;
                case "Olives":
                    if (Olives <= 0) check = false;
                    break;
                case "Mushrooms":
                    if (Mushrooms <= 0) check = false;
                    break;
                case "Garlic":
                    if (Garlic <= 0) check = false;
                    break;
                case "Onions":
                    if (Onions <= 0) check = false;
                    break;
                case "Tomatoes":
                    if (Tomatoes <= 0) check = false;
                    break;
                case "Spinach":
                    if (Spinach <= 0) check = false;
                    break;
                case "Basil":
                    if (Basil <= 0) check = false;
                    break;
                case "Ricotta":
                    if (Ricotta <= 0) check = false;
                    break;
                case "Parmesan":
                    if (Parmesan <= 0) check = false;
                    break;
                case "Feta":
                    if (Feta <= 0) check = false;
                    break;
                default:
                    break;
            }

            return check;
        }

        public void DeductInventoryCount(IIngredient ingredient)
        {
            string iName;
            double iCost;
            iName = ingredient.IngredientInventoryName;
            iCost = ingredient.IngredientInventoryCost;
            switch (iName)
            {
                case "Dough":
                    Dough -= iCost;
                    break;
                case "Tomato Sauce":
                    TomatoSauce -= iCost;
                    break;
                case "White Sauce":
                    WhiteSauce -= iCost;
                    break;
                case "Cheese":
                    Cheese -= iCost;
                    break;
                case "Pepperoni":
                    Pepperoni -= iCost;
                    break;
                case "Ham":
                    Ham -= iCost;
                    break;
                case "Chicken":
                    Chicken -= iCost;
                    break;
                case "Beef":
                    Beef -= iCost;
                    break;
                case "Sausage":
                    Sausage -= iCost;
                    break;
                case "Bacon":
                    Bacon -= iCost;
                    break;
                case "Anchovies":
                    Anchovies -= iCost;
                    break;
                case "Red Peppers":
                    RedPeppers -= iCost;
                    break;
                case "Green Peppers":
                    GreenPeppers -= iCost;
                    break;
                case "Pineapple":
                    Pineapple -= iCost;
                    break;
                case "Olives":
                    Olives -= iCost;
                    break;
                case "Mushrooms":
                    Mushrooms -= iCost;
                    break;
                case "Garlic":
                    Garlic -= iCost;
                    break;
                case "Onions":
                    Onions -= iCost;
                    break;
                case "Tomatoes":
                    Tomatoes -= iCost;
                    break;
                case "Spinach":
                    Spinach -= iCost;
                    break;
                case "Basil":
                    Basil -= iCost;
                    break;
                case "Ricotta":
                    Ricotta -= iCost;
                    break;
                case "Parmesan":
                    Parmesan -= iCost;
                    break;
                case "Feta":
                    Feta -= iCost;
                    break;
                default:
                    break;
            }
        }

        public void PrintInventory()
        {
            Console.WriteLine($"\n{Location.Name} Store's Inventory: \n" +
                $"Dough: {Dough}\n" +
                $"TomatoSauce: {TomatoSauce}\n" +
                $"WhiteSauce: {WhiteSauce}\n" +
                $"Cheese: {Cheese}\n" +
                $"Pepperoni: {Pepperoni}\n" +
                $"Ham: {Ham}\n" +
                $"Chicken: {Chicken}\n" +
                $"Beef: {Beef}\n" +
                $"Sausage: {Sausage}\n" +
                $"Bacon: {Bacon}\n" +
                $"Anchovies: {Anchovies}\n" +
                $"RedPeppers: {RedPeppers}\n" +
                $"GreenPeppers: {GreenPeppers}\n" +
                $"Pineapple: {Pineapple}\n" +
                $"Olives: {Olives}\n" +
                $"Mushrooms: {Mushrooms}\n" +
                $"Garlic: {Garlic}\n" +
                $"Onions: {Onions}\n" +
                $"Tomatoes: {Tomatoes}\n" +
                $"Spinach: {Spinach}\n" +
                $"Basil: {Basil}\n" +
                $"Ricotta: {Ricotta}\n" +
                $"Parmesan: {Parmesan}\n" +
                $"Feta: {Feta}");
        }
    }
}
