using System;
using System.Linq;
using System.Collections.Generic;
using PizzaApplication.Library;
using System.Xml.Serialization;
using System.IO;

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
            List<Storefront> storeList = new List<Storefront>();
            storeList.Add(RestonStorefront);
            storeList.Add(HerndonStorefront);
            storeList.Add(SterlingStorefront);

            // customer
            Customer currentCustomer;
            List<Customer> customerList = new List<Customer>();

            // variables
            var currentStorefront = RestonStorefront;

            // main ui flow
            Console.WriteLine("Welcome to the Pizza Store Console Application!");

            Console.WriteLine("\nEnter your first name.\n");
            var firstName = HelperIO.ReadLine();
            Console.WriteLine("\nEnter your last name.\n");
            var lastName = HelperIO.ReadLine();

            currentCustomer = new Customer(firstName, lastName);

            if (CheckIfCustomerIsInList(currentCustomer, customerList)) ReturningUserFlow(currentCustomer, currentStorefront, RestonStorefront, HerndonStorefront, SterlingStorefront);
            else  NewUserFlow(currentCustomer, currentStorefront, RestonStorefront, HerndonStorefront, SterlingStorefront);

            // call order builder
            // which calls pizza builder up to 12 times
            var currentOrder = HelperPizza.OrderBuilder(currentCustomer, currentStorefront);
            currentCustomer.AddOrder(currentOrder);
            currentStorefront.AddOrder(currentOrder);

            customerList.Add(currentCustomer);
            SerializeToFile(@"customer-data.xml", customerList);
            SerializeToFile(@"store-data.xml", storeList);
        }            

        static bool CheckIfCustomerIsInList(Customer customer, List<Customer> list)
        {
            var check = false;

            foreach (var item in list)
            {
                if (customer == item)
                {
                    check = true;
                    break;
                }
            }

            return check;
        }

        static void NewUserFlow(Customer currentCustomer, Storefront currentStorefront, Storefront RestonStorefront, Storefront HerndonStorefront, Storefront SterlingStorefront)
        {
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
        }

        static void ReturningUserFlow(Customer currentCustomer, Storefront currentStorefront, Storefront RestonStorefront, Storefront HerndonStorefront, Storefront SterlingStorefront)
        {           
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
            }
        }

        private static void SerializeToFile(string fileName, List<Customer> customerList)
        {
            var serializer = new XmlSerializer(typeof(List<Customer>));
            FileStream fileStream = null;

            try
            {
                fileStream = new FileStream(fileName, FileMode.Create);
                serializer.Serialize(fileStream, customerList);
            }
            catch (PathTooLongException ex)
            {
                Console.WriteLine($"Path {fileName} was too long! {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Some other error with file I/O: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                throw; // re-throws the same exception
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Dispose();
                }
            }
        }

        private static void SerializeToFile(string fileName, List<Storefront> storeList)
        {
            var serializer = new XmlSerializer(typeof(List<Storefront>));
            FileStream fileStream = null;

            try
            {
                fileStream = new FileStream(fileName, FileMode.Create);
                serializer.Serialize(fileStream, storeList);
            }
            catch (PathTooLongException ex)
            {
                Console.WriteLine($"Path {fileName} was too long! {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Some other error with file I/O: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                throw; // re-throws the same exception
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Dispose();
                }
            }
        }
    }
}
