using System;
using System.Linq;
using System.Collections.Generic;
using PizzaApplication.Library;

namespace PizzaApplication.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            // initialize objects

            // store locations
            var RestonStorefront = new Storefront("Reston");
            var HerndonStorefront = new Storefront("Herndon");
            var SterlingStorefront = new Storefront("Sterling");

            // customer
            Customer currentCustomer = new Customer();

            // variables
            var currentStorefront = RestonStorefront;
            var optionList = new List<string>();
            string option;

            // main ui flow
            Console.WriteLine("Welcome to the Pizza Store Console Application!");
            Console.WriteLine("\nAre you a new or returning user?");
            Console.WriteLine("Enter: (New/Returning)\n");

            optionList = new List<string> { "New", "Returning" };
            option = HelperPizza.PickOptionFromOptionList(optionList);

            if (option == "New")
            {
                NewUserFlow(currentCustomer, currentStorefront, RestonStorefront, HerndonStorefront, SterlingStorefront);
            }
            else if (option == "Returning")
            {
                ReturningUserFlow(currentCustomer, currentStorefront, RestonStorefront, HerndonStorefront, SterlingStorefront);                                
            }
        }

        static void NewUserFlow(Customer currentCustomer, Storefront currentStorefront, Storefront RestonStorefront, Storefront HerndonStorefront, Storefront SterlingStorefront)
        {
            Console.WriteLine("\nWelcome, new user!" +
                    "\nEnter your first name.\n");
            var firstName = HelperIO.ReadLine();
            Console.WriteLine("\nEnter your last name.\n");
            var lastName = HelperIO.ReadLine();

            currentCustomer = new Customer(firstName, lastName);

            Console.WriteLine($"\nHello, {currentCustomer.FirstName}!");

            Console.WriteLine("\nPlease select a store location:");
            Console.WriteLine("Reston, Herndon, Sterling");

            var optionList = new List<string> { "Reston", "Herndon", "Sterling" };
            var option = HelperPizza.PickOptionFromOptionList(optionList);

            switch (option)
            {
                case "Reston":
                    currentStorefront = RestonStorefront;
                    break;
                case "Herndon":
                    currentStorefront = HerndonStorefront;
                    break;
                case "Sterling":
                    currentStorefront = SterlingStorefront;
                    break;
                default:
                    break;
            }

            currentCustomer.DefaultLocation = currentStorefront;

            Console.WriteLine($"\nOk, {option} has been set as your default location.");

            // call order builder
            // which calls pizza builder up to 12 times
            var currentOrder = HelperPizza.OrderBuilder(currentCustomer, currentStorefront);
        }

        static void ReturningUserFlow(Customer currentCustomer, Storefront currentStorefront, Storefront RestonStorefront, Storefront HerndonStorefront, Storefront SterlingStorefront)
        {
            Console.WriteLine("\nEnter your first name.\n");
            var firstName = HelperIO.ReadLine();
            Console.WriteLine("\nEnter your last name.\n");
            var lastName = HelperIO.ReadLine();

            currentCustomer = new Customer(firstName, lastName);

            // (TO DO) check if this is a valid returning user

            Console.WriteLine($"Welcome back, {currentCustomer.FirstName}!");

            Console.WriteLine($"\nYour current default location is {currentCustomer.DefaultLocation.StoreLocation}.");
            Console.WriteLine($"\nDo you want to order from here?");
            Console.WriteLine("Enter: (Yes/No)\n");

            var optionList = new List<string> { "Yes", "No" };
            var option = HelperPizza.PickOptionFromOptionList(optionList);
            if (option == "Yes")
            {
                currentStorefront = currentCustomer.DefaultLocation;
                Console.WriteLine($"\nOk, you are ordering at {currentCustomer.DefaultLocation.StoreLocation}.");

                // call order builder
                // which calls pizza builder up to 12 times
                var currentOrder = HelperPizza.OrderBuilder(currentCustomer, currentStorefront);
            }
            else if (option == "No")
            {
                Console.WriteLine("\nPlease select a store location:");
                Console.WriteLine("Reston, Herndon, Sterling");

                optionList = new List<string> { "Reston", "Herndon", "Sterling" };
                var location = HelperPizza.PickOptionFromOptionList(optionList);

                switch (location)
                {
                    case "Reston":
                        currentStorefront = RestonStorefront;
                        break;
                    case "Herndon":
                        currentStorefront = HerndonStorefront;
                        break;
                    case "Sterling":
                        currentStorefront = SterlingStorefront;
                        break;
                    default:
                        break;
                }

                Console.WriteLine($"\nYour current default location is {currentCustomer.DefaultLocation.StoreLocation}.");
                Console.WriteLine($"Do you want to set {location} as your default location?");
                Console.WriteLine("Enter: (Yes/No)\n");

                optionList = new List<string> { "Yes", "No" };
                option = HelperPizza.PickOptionFromOptionList(optionList);
                if (option == "Yes")
                {
                    currentCustomer.DefaultLocation = currentStorefront;
                    Console.WriteLine($"\nOk, {location} is now your default location.");
                }
                else if (option == "No")
                {
                    Console.WriteLine($"\nOk, {currentCustomer.DefaultLocation.StoreLocation} is still your default location.");
                }

                // call order builder
                // which calls pizza builder up to 12 times
                var currentOrder = HelperPizza.OrderBuilder(currentCustomer, currentStorefront);
                currentCustomer.CustomerOrder = currentOrder;
            }
        }
    }
}
