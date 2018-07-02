using System;
using PizzaApplication.Library;

namespace PizzaApplication.UI
{
    class Program
    {        
        static void Main(string[] args)
        {            
            Console.WriteLine("Welcome to the Pizza Store Console Application!");
            Console.WriteLine("\nAre you a new or returning user?");
            Console.WriteLine("Enter: (New/Returning)");

            var option = HelperIO.ReadLine(); // acts as a Console.ReadLine() with a custom HelperIO.FormatString() method to format strings like so: "reTURnINg" -> "Returning"
 
            if (option == "New")
            {
                Console.WriteLine("\nEnter your first name.");
                var firstName = HelperIO.ReadLine();
                Console.WriteLine("Enter your last name.");
                var lastName = HelperIO.ReadLine();

                Customer OCustomer = new Customer(firstName, lastName);

                Console.WriteLine($"\nHello, {OCustomer.FirstName}!");

                Console.WriteLine("\nPlease select a store location:");
                Console.WriteLine("Reston, Herndon, Sterling");

                var location = HelperIO.ReadLine();

                OCustomer.DefaultLocation = location;

                Console.WriteLine($"\nOk, {location} has been set as your default location.");

            }
            else if (option == "Returning")
            {
                Console.WriteLine("\nEnter your first name.");
                var firstName = HelperIO.ReadLine();
                Console.WriteLine("Enter your last name.");
                var lastName = HelperIO.ReadLine();

                Customer OCustomer = new Customer(firstName, lastName);

                Console.WriteLine($"Welcome back, {OCustomer.FirstName}!");

                var location = HelperIO.ReadLine();

                Console.WriteLine($"\nYour current default location is {OCustomer.DefaultLocation}.");
                Console.WriteLine($"Do you want to set {location} as your default location?");
                Console.WriteLine("Enter: (Yes/No)");

                option = HelperIO.ReadLine();
                if (option == "Yes")
                {
                    OCustomer.DefaultLocation = location;
                    Console.WriteLine($"\nOk, {OCustomer.DefaultLocation} is now your default location.");
                }
                else if (option == "No")
                {
                    Console.WriteLine($"\nOk, {OCustomer.DefaultLocation} is still your default location.");
                }
            }
                        
        }
    }
}
