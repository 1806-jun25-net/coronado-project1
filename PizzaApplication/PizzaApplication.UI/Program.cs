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
            Console.WriteLine("Welcome to the Pizza Store Console Application!");
            Console.WriteLine("\nAre you a new or returning user?");
            Console.WriteLine("Enter: (New/Returning)\n");

            var optionList = new List<string> { "New", "Returning" };
            var option = HelperPizza.PickOptionFromOptionList(optionList);

            if (option == "New")
            {
                Console.WriteLine("\nWelcome, new user!" +
                    "\nEnter your first name.\n");
                var firstName = HelperIO.ReadLine();
                Console.WriteLine("\nEnter your last name.\n");
                var lastName = HelperIO.ReadLine();

                Customer OCustomer = new Customer(firstName, lastName);

                Console.WriteLine($"\nHello, {OCustomer.FirstName}!");

                Console.WriteLine("\nPlease select a store location:");
                Console.WriteLine("Reston, Herndon, Sterling");

                optionList = new List<string> { "Reston", "Herndon", "Sterling" };
                var location = HelperPizza.PickOptionFromOptionList(optionList);

                OCustomer.DefaultLocation = location;

                Console.WriteLine($"\nOk, {location} has been set as your default location.");

                // call order builder
                // which calls pizza builder up to 12 times
                var currentOrder = HelperPizza.OrderBuilder(OCustomer, location);

            }
            else if (option == "Returning")
            {
                Console.WriteLine("\nEnter your first name.\n");
                var firstName = HelperIO.ReadLine();
                Console.WriteLine("\nEnter your last name.\n");
                var lastName = HelperIO.ReadLine();

                Customer OCustomer = new Customer(firstName, lastName);

                Console.WriteLine($"Welcome back, {OCustomer.FirstName}!");

                Console.WriteLine($"\nYour current default location is {OCustomer.DefaultLocation}.");
                Console.WriteLine($"\nDo you want to order from here?");
                Console.WriteLine("Enter: (Yes/No)\n");

                string location;

                optionList = new List<string> { "Yes", "No" };
                option = HelperPizza.PickOptionFromOptionList(optionList);
                if (option == "Yes")
                {
                    location = OCustomer.DefaultLocation;
                    Console.WriteLine($"\nOk, you are ordering at {location}.");

                    // call order builder
                    // which calls pizza builder up to 12 times
                    var currentOrder = HelperPizza.OrderBuilder(OCustomer, location);
                }
                else if (option == "No")
                {
                    Console.WriteLine("\nPlease select a store location:");
                    Console.WriteLine("Reston, Herndon, Sterling");

                    optionList = new List<string> { "Reston", "Herndon", "Sterling" };
                    location = HelperPizza.PickOptionFromOptionList(optionList);

                    Console.WriteLine($"\nYour current default location is {OCustomer.DefaultLocation}.");
                    Console.WriteLine($"Do you want to set {location} as your default location?");
                    Console.WriteLine("Enter: (Yes/No)\n");

                    optionList = new List<string> { "Yes", "No" };
                    option = HelperPizza.PickOptionFromOptionList(optionList);
                    if (option == "Yes")
                    {
                        OCustomer.DefaultLocation = location;
                        Console.WriteLine($"\nOk, {OCustomer.DefaultLocation} is now your default location.");
                    }
                    else if (option == "No")
                    {
                        Console.WriteLine($"\nOk, {OCustomer.DefaultLocation} is still your default location.");
                    }

                    // call order builder
                    // which calls pizza builder up to 12 times
                    var currentOrder = HelperPizza.OrderBuilder(OCustomer, location);
                    OCustomer.CustomerOrder = currentOrder;
                }                                
            }
        }
    }
}
