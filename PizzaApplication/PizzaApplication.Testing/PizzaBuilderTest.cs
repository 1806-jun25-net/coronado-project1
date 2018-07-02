using System;
using System.Linq;
using Xunit;
using PizzaApplication.Library;
using System.Collections.Generic;

namespace PizzaApplication.Test
{
    public class PizzaBuilderTest
    {
        [Fact]
        public void ShouldReturnTrueIfTwoDefaultPizzasMatch()
        {
            Pizza TestPizza1 = new Pizza(); // default pizza is a large regular crust, regular tomato sauce, regular cheese pizza
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
            Pizza TestPizza1 = new Pizza(); // default pizza is a large regular crust, regular tomato sauce, regular cheese pizza

            Crust defaultCrust = new Crust("Large(14\")", "Regular"); //default crust
            Sauce defaultSauce = new Sauce("Tomato Sauce", "Regular"); //default sauce
            Cheese defaultCheese = new Cheese("Cheese", "Regular"); //default crust
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
