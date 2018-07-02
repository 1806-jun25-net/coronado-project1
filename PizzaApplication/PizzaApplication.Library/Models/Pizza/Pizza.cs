using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PizzaApplication.Library
{
    public class Pizza : IPizza
    {
        // fields
        public Crust PizzaCrust  = new Crust();
        public Sauce PizzaSauce = new Sauce();
        public Cheese PizzaCheese = new Cheese();
        public IEnumerable<Topping> ToppingList = new List<Topping>();
        public IEnumerable<IIngredient> PizzaComposition = new List<IIngredient>();
        public decimal PizzaPrice { get; set; }

        // constructor
        public Pizza()
        {
            AssemblePizza();
            CalculatePizzaPrice();
        }

        public Pizza(Crust crust, Sauce sauce, Cheese cheese, List<Topping> toppingList)
        {
            PizzaCrust = crust;
            PizzaSauce = sauce;
            PizzaCheese = cheese;
            ToppingList = toppingList;
            AssemblePizza();
            CalculatePizzaPrice();
        }
        
        // methods
        public void SetCrust(string crustSize, string crustThickness)
        {
            PizzaCrust = new Crust(crustSize, crustThickness);
        }

        public void SetSauce(string sauceType, string sauceThickness)
        {
            PizzaSauce = new Sauce(sauceType, sauceThickness);
        }

        public void SetCheese(string cheeseType, string cheeseThickness)
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

        public void AssemblePizza()
        {
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

        }
                
        public void CalculatePizzaPrice()
        {
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
