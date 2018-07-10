using System;
using System.Linq;
using System.Collections.Generic;
using PizzaApplication.Library;
using System.Xml.Serialization;
using System.Threading.Tasks;
using System.IO;

namespace PizzaApplication.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            // initialize objects

            // store locations
            List<Storefront> storeList = new List<Storefront>();
            var RestonStorefront = new Storefront("Reston");
            var HerndonStorefront = new Storefront("Herndon");
            var SterlingStorefront = new Storefront("Sterling");
            Storefront currentStorefront;

            // attempt deserialization of storefronts
            Task<IEnumerable<Storefront>> desStoreListTask = DeserializeStorefrontFromFileAsync(@"store-data.xml");
            IEnumerable<Storefront> storeResult = new List<Storefront>();
            try
            {
                storeResult = desStoreListTask.Result; // synchronously sits around until the result is ready
            }
            catch (AggregateException ex)
            {
                Console.WriteLine("store-data.xml wasn't found.");
                storeList.Add(RestonStorefront);
                storeList.Add(HerndonStorefront);
                storeList.Add(SterlingStorefront);
            }
            storeList.AddRange(storeResult);

            // customer
            Customer currentCustomer;
            List<Customer> customerList = new List<Customer>();

            // attempt deserialization of customers
            Task<IEnumerable<Customer>> desCustomerListTask = DeserializeCustomerFromFileAsync(@"customer-data.xml");
            IEnumerable<Customer> customerResult = new List<Customer>();
            try
            {
                customerResult = desCustomerListTask.Result; // synchronously sits around until the result is ready
            }
            catch (AggregateException ex)
            {
                Console.WriteLine("customer-data.xml wasn't found.");
            }
            customerList.AddRange(customerResult);

            // main ui flow
            Console.WriteLine("Welcome to the Pizza Store Console Application!");

            Console.WriteLine("\nEnter your first name.\n");
            var firstName = HelperIO.ReadLine();
            Console.WriteLine("\nEnter your last name.\n");
            var lastName = HelperIO.ReadLine();

            currentCustomer = new Customer(firstName, lastName);

            var index = (MatchCustomerToIndex(currentCustomer, customerList)); // check if customer already exists in customer list
            if (index != -1) // means index was found for customer in list
            {
                currentCustomer = customerList[index]; // set currentCustomer reference to the indexed Customer
                currentStorefront = ReturningUserFlow(currentCustomer, RestonStorefront, HerndonStorefront, SterlingStorefront);
            }
            else // no index found for customer, need to add new customer to the list
            {
                customerList.Add(currentCustomer);
                currentStorefront = NewUserFlow(currentCustomer, RestonStorefront, HerndonStorefront, SterlingStorefront);                
            }

            // call order builder
            // which calls pizza builder up to 12 times
            var currentOrder = HelperPizza.OrderBuilder(currentCustomer, currentStorefront);
            currentCustomer.AddOrder(currentOrder);
            currentStorefront.AddOrder(currentOrder);
            
            SerializeToFile(@"customer-data.xml", customerList);
            SerializeToFile(@"store-data.xml", storeList);
        }

        static int MatchCustomerToIndex(Customer customer, List<Customer> list)
        {
            int index = -1;

            string customerID = $"{customer.ID}: {customer.FirstName} {customer.LastName}";
            foreach (var item in list)
            {
                string itemID = $"{item.ID}: {item.FirstName} {item.LastName}";
                if (customerID == itemID)
                {
                    index = list.IndexOf(item);
                    break;
                }
            }

            return index;
        }

        static Storefront NewUserFlow(Customer currentCustomer, Storefront RestonStorefront, Storefront HerndonStorefront, Storefront SterlingStorefront)
        {
            Console.WriteLine($"\nHello, {currentCustomer.FirstName}!");

            Console.WriteLine("\nPlease select a store location:");
            Console.WriteLine("Reston, Herndon, Sterling");

            var currentStorefront = new Storefront();
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

            currentCustomer.DefaultLocation = currentStorefront.StoreLocation;

            Console.WriteLine($"\nOk, {option} has been set as your default location.");

            return currentStorefront;
        }

        static Storefront ReturningUserFlow(Customer currentCustomer, Storefront RestonStorefront, Storefront HerndonStorefront, Storefront SterlingStorefront)
        {
            Console.WriteLine($"Welcome back, {currentCustomer.FirstName}!");

            Console.WriteLine($"\nYour current default location is {currentCustomer.DefaultLocation}.");
            Console.WriteLine($"\nDo you want to order from here?");
            Console.WriteLine("Enter: (Yes/No)\n");

            var currentStorefront = new Storefront();
            var optionList = new List<string> { "Yes", "No" };
            var option = HelperPizza.PickOptionFromOptionList(optionList);
            if (option == "Yes")
            {
                switch (currentCustomer.DefaultLocation)
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
                Console.WriteLine($"\nOk, you are ordering at {currentCustomer.DefaultLocation}.");

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

                Console.WriteLine($"\nYour current default location is {currentCustomer.DefaultLocation}.");
                Console.WriteLine($"Do you want to set {location} as your default location?");
                Console.WriteLine("Enter: (Yes/No)\n");

                optionList = new List<string> { "Yes", "No" };
                option = HelperPizza.PickOptionFromOptionList(optionList);
                if (option == "Yes")
                {
                    currentCustomer.DefaultLocation = currentStorefront.StoreLocation;
                    Console.WriteLine($"\nOk, {location} is now your default location.");
                }
                else if (option == "No")
                {
                    Console.WriteLine($"\nOk, {currentCustomer.DefaultLocation} is still your default location.");
                }
            }
            return currentStorefront;
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

        private async static Task<IEnumerable<Customer>> DeserializeCustomerFromFileAsync(string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<Customer>));

            using (var memoryStream = new MemoryStream())
            {
                using (var fileStream = new FileStream(fileName, FileMode.Open))
                {
                    await fileStream.CopyToAsync(memoryStream);
                }
                memoryStream.Position = 0; // reset "cursor" of stream to beginning
                return (List<Customer>)serializer.Deserialize(memoryStream);
            }
        }

        private async static Task<IEnumerable<Storefront>> DeserializeStorefrontFromFileAsync(string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<Storefront>));

            using (var memoryStream = new MemoryStream())
            {
                using (var fileStream = new FileStream(fileName, FileMode.Open))
                {
                    await fileStream.CopyToAsync(memoryStream);
                }
                memoryStream.Position = 0; // reset "cursor" of stream to beginning
                return (List<Storefront>)serializer.Deserialize(memoryStream);
            }
        }
    }
}
