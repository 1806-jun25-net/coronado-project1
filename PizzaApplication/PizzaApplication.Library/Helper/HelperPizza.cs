﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaApplication.Library
{
    public static class HelperPizza
    {
        public static bool CheckIfOptionMatchesOptionList(string option, List<string> optionList)
        {
            var check = false;

            if (optionList != null)
            {
                foreach (var item in optionList)
                {
                    if (option == item)
                    {
                        check = true;
                        break;
                    }
                }
            }

            return check;
        }

        public static string PickOptionFromOptionList(List<string> optionList)
        {
            string option;
            var loop = true;
            do
            {
                option = HelperIO.ReadLine();

                if (CheckIfOptionMatchesOptionList(option, new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" }))
                {
                    var index = ConvertIndexNumbers(option);
                    if (index < optionList.Count())
                    {
                        if (CheckIfIndexMatchesIndexList(index, new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 }))
                        {
                            option = optionList[index];
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nIncorrect input. Please try again.");
                    }

                }
                else
                {
                    option = ConvertShorthand(option);
                    if (CheckIfOptionMatchesOptionList(option, optionList))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nIncorrect input. Please try again.");
                    }
                }
            }
            while (loop);

            return option;
        }

        public static string PizzaOptionIO(string message, List<string> optionList)
        {
            Console.WriteLine($"\nSelect {message}:");
            int optionID = 1;
            foreach (var item in optionList)
            {
                Console.WriteLine($"{optionID}. {item}");
                optionID++;
            }
            Console.WriteLine("---");

            var option = PickOptionFromOptionList(optionList);

            return option;
        }

        public static string ConvertShorthand(string option)
        {
            if (option == "Y") option = "Yes";
            if (option == "N") option = "No";
            if (option == "Personal") option += "(8\")";
            if (option == "Small") option += "(10\")";
            if (option == "Medium") option += "(12\")";
            if (option == "Large") option += "(14\")";
            if (option == "8") option = "Personal(8\")";
            if (option == "10") option = "Small(10\")";
            if (option == "12") option = "Medium(12\")";
            if (option == "14") option = "Large(14\")";
            if (option == "Thin") option += " Crust";
            if (option == "Standard") option += " Crust";
            if (option == "Thick") option += " Crust";
            if (option == "Tomato") option += " Sauce";
            if (option == "White") option += " Sauce";

            return option;
        }

        public static int ConvertIndexNumbers(string option)
        {
            int index = 0;
            if (option == "1") index = 0;
            if (option == "2") index = 1;
            if (option == "3") index = 2;
            if (option == "4") index = 3;
            if (option == "5") index = 4;
            if (option == "6") index = 5;
            if (option == "7") index = 6;
            if (option == "8") index = 7;
            if (option == "9") index = 8;
            if (option == "10") index = 9;
            if (option == "11") index = 10;
            if (option == "12") index = 11;
            if (option == "13") index = 12;
            if (option == "14") index = 13;
            if (option == "15") index = 14;
            if (option == "16") index = 15;
            if (option == "17") index = 16;
            if (option == "18") index = 17;
            if (option == "19") index = 18;
            if (option == "20") index = 19;

            return index;
        }

        public static bool CheckIfIndexMatchesIndexList(int index, List<int> indexList)
        {
            var check = false;

            if (indexList != null)
            {
                foreach (var item in indexList)
                {
                    if (index == item)
                    {
                        check = true;
                        break;
                    }
                }
            }

            return check;
        }

        public static Pizza PizzaBuilder()
        {
            Console.WriteLine("\nPlace an order using the Pizza Builder:");

            // instantiate template pizza to read options from
            var templatePizza = new Pizza();

            // take user input for crust options
            var optCrustSize = PizzaOptionIO("Pizza Size", templatePizza.PizzaCrust.CrustSizeOptions);
            var optCrustThickness = PizzaOptionIO("Crust Thickness", templatePizza.PizzaCrust.CrustThicknessOptions);
            var currentCrust = new Crust(optCrustSize, optCrustThickness);

            // take user input for sauce options
            var optSauceType = PizzaOptionIO("Sauce Type", templatePizza.PizzaSauce.SauceTypeOptions);
            var optSauceThickness = PizzaOptionIO("Sauce Thickness", templatePizza.PizzaSauce.SauceThicknessOptions);
            var currentSauce = new Sauce(optSauceType, optSauceThickness);

            // take user input for cheese options
            var optCheeseThickness = PizzaOptionIO("Cheese Thickness", templatePizza.PizzaCheese.CheeseThicknessOptions);
            var currentCheese = new Cheese(optCheeseThickness);

            // take user input for topping options
            var currentToppingList = new List<Topping>();
            Console.WriteLine($"\nWould you like to add toppings? (Maximum of {templatePizza.MaxToppings})");
            Console.WriteLine("Enter: (Yes/No)");
            var optionList = new List<string> { "Yes", "No" };
            var option = PickOptionFromOptionList(optionList);

            if (option == "Yes")
            {
                // instantiate template topping to read options from
                var templateTopping = new Topping();
                string optToppingType;
                while (currentToppingList.Count() < templatePizza.MaxToppings)
                {
                    optToppingType = PizzaOptionIO("Toppings", templateTopping.ToppingTypeOptions);
                    // create new topping from user input
                    var currentTopping = new Topping(optToppingType);
                    // add new topping to topping list
                    currentToppingList.Add(currentTopping);

                    if (currentToppingList.Count() < templatePizza.MaxToppings)
                    {
                        Console.WriteLine($"Would you like to add another topping? ({currentToppingList.Count()}/{templatePizza.MaxToppings})");
                        Console.WriteLine("Enter: (Yes/No)");
                        optionList = new List<string> { "Yes", "No" };
                        option = PickOptionFromOptionList(optionList);
                        if (option == "Yes") continue;
                        else if (option == "No") break;
                    }
                    else
                    {
                        Console.WriteLine("You have reached the maximum amount of toppings.");
                    }
                }
            }

            Pizza currentPizza = new Pizza(currentCrust, currentSauce, currentCheese, currentToppingList);
            currentPizza.PrintPizza();

            return currentPizza;
        }

        public static Order OrderBuilder(Customer customer, string location)
        {
            var optionList = new List<string>();
            string option;
            var currentOrder = new Order(customer, location);

            // loop while pizza limit is below max
            while (currentOrder.OrderPizzaCount < currentOrder.OrderPizzaLimit)
            {
                // run pizza builder
                var currentPizza = PizzaBuilder();

                // check if pizza is within order price limit
                var addP = currentPizza.PizzaPrice;
                var totalP = currentOrder.OrderPrice;
                var limitP = currentOrder.OrderPriceLimit;
                bool check;
                if (totalP + addP < limitP) check = true;
                else check = false;

                if (check)
                {
                    // pizza price is within price limit
                    // add pizza to order
                    currentOrder.AddPizza(currentPizza);
                }
                else
                {
                    // pizza price not within price limit
                    var diffP = limitP - ((totalP + addP) * -1);
                    Console.WriteLine($"Your pizza exceeds the ${currentOrder.OrderPriceLimit} order limit by ${diffP}.");
                    Console.WriteLine("Please try again or complete your order.");
                }

                if (currentOrder.OrderPizzaCount < currentOrder.OrderPizzaLimit)
                {
                    // get user input about adding new pizzas
                    Console.WriteLine($"Would you like to add another pizza? ({currentOrder.OrderPizzaCount}/{currentOrder.OrderPizzaLimit})");
                    Console.WriteLine("Enter: (Yes/No)");
                    optionList = new List<string> { "Yes", "No" };
                    option = PickOptionFromOptionList(optionList);
                    if (option == "Yes") continue;
                    else if (option == "No") break;
                }
                else
                {
                    Console.WriteLine("You have reached the maximum amount of pizzas.");
                }
            }

            // finalize order
            currentOrder.BuildOrder();
            currentOrder.PrintOrder();

            return currentOrder;
        }
    }
}