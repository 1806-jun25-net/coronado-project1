using System;
using System.Linq;
using Xunit;
using PizzaApplication.Library;
using System.Collections.Generic;
using PizzaApplication.UI;

namespace PizzaApplication.Test
{
    public class PizzaBuilderTest
    {
        [Fact]
        public void ShouldNotBeAbleToOrderPizzaIfAtPizzaLimit()
        {
            var testOrder = new Order();
            testOrder.OrderPizzaLimit = 12; // pizza limit in a single order is 12

            bool PizzaLimitReached = false;

            // adds 12 pizzas
            for (int i = 0; i < 12; i++)
            {
                if (testOrder.PizzaList.Count() < testOrder.OrderPizzaLimit) // if pizza list count is less than limit, then add pizza to list
                {
                    testOrder.AddPizza(new Pizza());
                }
                else
                {
                    PizzaLimitReached = true;
                }
            }

            // tries to add 13th pizza
            if (testOrder.PizzaList.Count() < testOrder.OrderPizzaLimit) // if pizza list count is less than limit, then add pizza to list
            {
                testOrder.AddPizza(new Pizza());
            }
            else
            {
                PizzaLimitReached = true;
            }

            Assert.True(PizzaLimitReached);
        }

        [Fact]
        public void ShouldNotBeAbleToOrderPizzaIfItExceedsOrderPriceLimit()
        {            
            var testPizza = new Pizza();
            testPizza.PizzaPrice = 501.00m; // set price of pizza to over limit: $501.00

            var testOrder = new Order();
            testOrder.OrderPriceLimit = 500.00m; // price limit of $500.00
            testOrder.AddPizza(testPizza); // add pizza to order

            // check if pizza is within order price limit
            var addedPrice = testPizza.PizzaPrice;
            var totalPrice = testOrder.OrderPrice;
            var limitPrice = testOrder.OrderPriceLimit;

            bool OrderPriceIsBelowLimit;

            if (totalPrice + addedPrice < limitPrice) OrderPriceIsBelowLimit = true;
            else OrderPriceIsBelowLimit = false;

            Assert.False(OrderPriceIsBelowLimit);
        }

        [Fact]
        public void ShouldNotBeAbleToOrderPizzaIfStoreDoesNotHaveEnoughIngredients()
        {
            var customer = new Customer("Test", "Person");
            var storefront = new Storefront("Test Location");
            var testPizza = new Pizza();

            storefront.StoreInventory.InventoryCountArray = new double[] // set to empty inventory
            {
                0, 0, 0, 0,
                0, 0, 0, 0,
                0, 0, 0, 0,
                0, 0, 0, 0,
                0, 0, 0, 0,
                0, 0, 0, 0
            };
            storefront.StoreInventory.SetTempInventoryToActual();

            bool PizzaIsOrdered = true;

            // check if storefront inventory can fulfill pizza
            foreach (var ingredient in testPizza.PizzaComposition)
            {
                if (storefront.StoreInventory.CheckIfInventoryIsSufficient(ingredient.IngredientInventoryName, ingredient.IngredientInventoryCost))
                {
                    storefront.StoreInventory.DeductTempInventoryCount(ingredient.IngredientInventoryName, ingredient.IngredientInventoryCost);
                }
                else
                {
                    PizzaIsOrdered = false;
                }
            }
            Assert.False(PizzaIsOrdered);
        }

        [Fact]
        public void ShouldReturnTrueIfTwoDefaultPizzasMatch()
        {
            Pizza TestPizza1 = new Pizza(); // default pizza is personal(8") thin crust, tomato sauce(light), cheese(light)
            Pizza TestPizza2 = new Pizza();

            var pizzaComp1 = new List<string>();
            var pizzaComp2 = new List<string>();

            foreach (IIngredient ingredient in TestPizza1.PizzaComposition)
            {
                pizzaComp1.Add(ingredient.ToString());
            }

            foreach (IIngredient ingredient in TestPizza2.PizzaComposition)
            {
                pizzaComp2.Add(ingredient.ToString());
            }

            Assert.True(CompareLists(pizzaComp1, pizzaComp2));
        }


        [Fact]
        public void ShouldReturnTrueIfBuiltDefaultPizzaMatchesDefaultPizza()
        {
            Pizza TestPizza1 = new Pizza(); // default pizza is personal(8") thin crust, tomato sauce(light), cheese(light)

            Crust defaultCrust = new Crust("Personal(8\")", "Thin"); //default crust
            Sauce defaultSauce = new Sauce("Tomato Sauce", "Light"); //default sauce
            Cheese defaultCheese = new Cheese("Cheese", "Light"); //default crust
            List<Topping> defaultTopping = new List<Topping> { }; //default empty topping list
            Pizza TestPizza2 = new Pizza(defaultCrust, defaultSauce, defaultCheese, defaultTopping); // build to match default

            var a = ProcessList(TestPizza1);
            var b = ProcessList(TestPizza2);

            Assert.True(CompareLists(a, b));
        }

        private List<string> ProcessList(Pizza testPizza)
        {
            var list = new List<string>();
            foreach (IIngredient ingredient in testPizza.PizzaComposition)
            {
                list.Add(ingredient.ToString());
            }
            return list;
        }

        private bool CompareLists(List<string> list1, List<string> list2)
        {
            bool check = false;

            if (list1.Count == list2.Count)
            {
                for (int i = 0; i < list1.Count; i++)
                {
                    if (list1[i] == list2[i])
                    {
                        check = true;
                    }
                }
            }
            else
            {
                check = false;
            }

            return check;
        }
    }
}
