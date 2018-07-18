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
            // create temp inventory values to decrement for the check
            var dough = Dough;
            var tomatoSauce = TomatoSauce;
            var whiteSauce = WhiteSauce;
            var cheese = Cheese;
            var pepperoni = Pepperoni;
            var ham = Ham;
            var chicken = Chicken;
            var beef = Beef;
            var sausage = Sausage;
            var bacon = Bacon;
            var anchovies = Anchovies;
            var redPeppers = RedPeppers;
            var greenPeppers = GreenPeppers;
            var pineapple = Pineapple;
            var olives = Olives;
            var mushrooms = Mushrooms;
            var garlic = Garlic;
            var onions = Onions;
            var tomatoes = Tomatoes;
            var spinach = Spinach;
            var basil = Basil;
            var ricotta = Ricotta;
            var parmesan = Parmesan;
            var feta = Feta;

            string iName;
            double iCost;

            iName = ingredient.IngredientInventoryName;
            iCost = ingredient.IngredientInventoryCost;
            if (iName == "Dough")
            {
                if ((dough -= iCost) <= 0) check = false;
            }
            else if (iName == "Tomato Sauce")
            {
                if ((tomatoSauce -= iCost) <= 0) check = false;
            }
            else if (iName == "White Sauce")
            {
                if ((whiteSauce -= iCost) <= 0) check = false;
            }
            else if (iName == "Cheese")
            {
                if ((cheese -= iCost) <= 0) check = false;
            }
            else if (iName == "Pepperoni")
            {
                if ((pepperoni -= iCost) <= 0) check = false;
            }
            else if (iName == "Ham")
            {
                if ((ham -= iCost) <= 0) check = false;
            }
            else if (iName == "Chicken")
            {
                if ((chicken -= iCost) <= 0) check = false;
            }
            else if (iName == "Beef")
            {
                if ((beef -= iCost) <= 0) check = false;
            }
            else if (iName == "Sausage")
            {
                if ((sausage -= iCost) <= 0) check = false;
            }
            else if (iName == "Bacon")
            {
                if ((bacon -= iCost) <= 0) check = false;
            }
            else if (iName == "Anchovies")
            {
                if ((anchovies -= iCost) <= 0) check = false;
            }
            else if (iName == "Red Peppers")
            {
                if ((redPeppers -= iCost) <= 0) check = false;
            }
            else if (iName == "Green Peppers")
            {
                if ((greenPeppers -= iCost) <= 0) check = false;
            }
            else if (iName == "Pineapple")
            {
                if ((pineapple -= iCost) <= 0) check = false;
            }
            else if (iName == "Olives")
            {
                if ((olives -= iCost) <= 0) check = false;
            }
            else if (iName == "Mushrooms")
            {
                if ((mushrooms -= iCost) <= 0) check = false;
            }
            else if (iName == "Garlic")
            {
                if ((garlic -= iCost) <= 0) check = false;
            }
            else if (iName == "Onions")
            {
                if ((onions -= iCost) <= 0) check = false;
            }
            else if (iName == "Tomatoes")
            {
                if ((tomatoes -= iCost) <= 0) check = false;
            }
            else if (iName == "Spinach")
            {
                if ((spinach -= iCost) <= 0) check = false;
            }
            else if (iName == "Basil")
            {
                if ((basil -= iCost) <= 0) check = false;
            }
            else if (iName == "Ricotta")
            {
                if ((ricotta -= iCost) <= 0) check = false;
            }
            else if (iName == "Parmesan")
            {
                if ((parmesan -= iCost) <= 0) check = false;
            }
            else if (iName == "Feta")
            {
                if ((feta -= iCost) <= 0) check = false;
            }

            return check;
        }

        public void DeductInventoryCount(IIngredient ingredient)
        {
            string iName;
            double iCost;
            iName = ingredient.IngredientInventoryName;
            iCost = ingredient.IngredientInventoryCost;
            if (iName == "Dough")
            {
                Dough -= iCost;
            }
            else if (iName == "Tomato Sauce")
            {
                TomatoSauce -= iCost;
            }
            else if (iName == "White Sauce")
            {
                WhiteSauce -= iCost;
            }
            else if (iName == "Cheese")
            {
                Cheese -= iCost;
            }
            else if (iName == "Pepperoni")
            {
                Pepperoni -= iCost;
            }
            else if (iName == "Ham")
            {
                Ham -= iCost;
            }
            else if (iName == "Chicken")
            {
                Chicken -= iCost;
            }
            else if (iName == "Beef")
            {
                Beef -= iCost;
            }
            else if (iName == "Sausage")
            {
                Sausage -= iCost;
            }
            else if (iName == "Bacon")
            {
                Bacon -= iCost;
            }
            else if (iName == "Anchovies")
            {
                Anchovies -= iCost;
            }
            else if (iName == "Red Peppers")
            {
                RedPeppers -= iCost;
            }
            else if (iName == "Green Peppers")
            {
                GreenPeppers -= iCost;
            }
            else if (iName == "Pineapple")
            {
                Pineapple -= iCost;
            }
            else if (iName == "Olives")
            {
                Olives -= iCost;
            }
            else if (iName == "Mushrooms")
            {
                Mushrooms -= iCost;
            }
            else if (iName == "Garlic")
            {
                Garlic -= iCost;
            }
            else if (iName == "Onions")
            {
                Onions -= iCost;
            }
            else if (iName == "Tomatoes")
            {
                Tomatoes -= iCost;
            }
            else if (iName == "Spinach")
            {
                Spinach -= iCost;
            }
            else if (iName == "Basil")
            {
                Basil -= iCost;
            }
            else if (iName == "Ricotta")
            {
                Ricotta -= iCost;
            }
            else if (iName == "Parmesan")
            {
                Parmesan -= iCost;
            }
            else if (iName == "Feta")
            {
                Feta -= iCost;
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
