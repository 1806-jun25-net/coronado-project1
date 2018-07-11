using System;
using System.Linq;
using System.Collections.Generic;
using PizzaApplication.Library;
using System.Xml.Serialization;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using PizzaApplication.Data;

namespace PizzaApplication.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = configBuilder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<PizzaDBContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("PizzaDB"));
            var options = optionsBuilder.Options;

            var dbContext = new PizzaDBContext(options);
            var pizzaRepository = new PizzaRepository(dbContext);

            // initialize store locations
            List<Storefront> storeList = new List<Storefront>();
            Storefront RestonStorefront;
            Storefront HerndonStorefront;
            Storefront SterlingStorefront;
            Storefront currentStorefront;
            var tryLoadDatabase = false;
            var tryDeserialize = true;

            while (tryLoadDatabase)
            {
                // attempt loading store info from DB
                storeList = pizzaRepository.GetLocations().ToList();
                if (storeList.Count == 0)
                {
                    Console.WriteLine("Could not load any locations from the database.\n");
                    tryDeserialize = true;
                }
                tryLoadDatabase = false;
            }

            while (tryDeserialize)
            {
                // attempt deserialization of storefronts
                Task<IEnumerable<Storefront>> desStoreListTask = DeserializeStorefrontFromFileAsync(@"store-data.xml");
                IEnumerable<Storefront> storeResult = new List<Storefront>();
                try
                {
                    storeResult = desStoreListTask.Result; // synchronously sits around until the result is ready
                }
                catch (AggregateException)
                {
                    Console.WriteLine("store-data.xml wasn't found.\n");
                }
                storeList.AddRange(storeResult);
                tryDeserialize = false;
            }

            RestonStorefront = new Storefront("Reston");
            HerndonStorefront = new Storefront("Herndon");
            SterlingStorefront = new Storefront("Sterling");

            RestonStorefront = ProcessStorefront(RestonStorefront, storeList);
            HerndonStorefront = ProcessStorefront(HerndonStorefront, storeList);
            SterlingStorefront = ProcessStorefront(SterlingStorefront, storeList);

            // initialize customer
            Customer currentCustomer;
            List<Customer> customerList = new List<Customer>();
            tryLoadDatabase = false;
            tryDeserialize = true;

            while (tryLoadDatabase)
            {
                // attempt loading user info from DB
                customerList = pizzaRepository.GetUsers().ToList();
                if (customerList.Count == 0)
                {
                    Console.WriteLine("Could not load any users from the database.\n");
                    tryDeserialize = true;
                }
                tryLoadDatabase = false;
            }

            while (tryDeserialize)
            {
                // attempt deserialization of customers
                Task<IEnumerable<Customer>> desCustomerListTask = DeserializeCustomerFromFileAsync(@"customer-data.xml");
                IEnumerable<Customer> customerResult = new List<Customer>();
                try
                {
                    customerResult = desCustomerListTask.Result; // synchronously sits around until the result is ready
                }
                catch (AggregateException)
                {
                    Console.WriteLine("customer-data.xml wasn't found.\n");
                }
                customerList.AddRange(customerResult);
                tryDeserialize = false;
            }

            // main ui flow
            Console.WriteLine("Welcome to the Pizza Store Console Application!");
            var loop = true;
            while (loop)
            {
                Console.WriteLine("\n--- \nMain Menu: \n---");
                var optionList = new List<string> { "Order", "Search Users", "Location Info", "Quit" };
                var option = HelperPizza.PizzaOptionIO("an Option", optionList);
                switch (option)
                {
                    case "Order":
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
                        break;

                    case "Search Users":
                        var searchedUser = SearchUsersByName(customerList);
                        if (searchedUser != null)
                        {
                            optionList = new List<string> { "Display Latest Order", "Display Order History", "Quit" };
                            option = HelperPizza.PizzaOptionIO("an Option", optionList);
                            switch (option)
                            {
                                case "Display Latest Order":
                                    Console.WriteLine("\n--- \nLatest Order: \n---");
                                    searchedUser.LatestOrder.PrintOrder();
                                    break;
                                case "Display Order History":

                                    optionList = new List<string> { "Earliest", "Latest", "Cheapest", "Most Expensive" };
                                    option = HelperPizza.PizzaOptionIO("Sorting Order", optionList);

                                    switch (option)
                                    {
                                        case "Earliest":
                                            DisplayOrderHistorySortEarliest(searchedUser);
                                            break;
                                        case "Latest":
                                            DisplayOrderHistorySortLatest(searchedUser);
                                            break;
                                        case "Cheapest":
                                            DisplayOrderHistorySortCheapest(searchedUser);
                                            break;
                                        case "Most Expensive":
                                            DisplayOrderHistorySortMostExpensive(searchedUser);
                                            break;
                                        default:
                                            DisplayOrderHistory(searchedUser);
                                            break;
                                    }
                                    break;
                                case "Quit":
                                    Console.WriteLine("Returning to Main Menu...");
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;

                    case "Location Info":

                        optionList = new List<string> { "Reston", "Herndon", "Sterling" };
                        option = HelperPizza.PizzaOptionIO("a Location", optionList);

                        Storefront selectedLocation = null;
                        switch (option)
                        {
                            case "Reston":
                                selectedLocation = RestonStorefront;
                                break;
                            case "Herndon":
                                selectedLocation = HerndonStorefront;
                                break;
                            case "Sterling":
                                selectedLocation = SterlingStorefront;
                                break;
                            default:
                                selectedLocation = RestonStorefront;
                                break;
                        }

                        optionList = new List<string> { "Display Inventory", "Display Order History", "Quit" };
                        option = HelperPizza.PizzaOptionIO("an Option", optionList);
                        switch (option)
                        {
                            case "Display Inventory":
                                selectedLocation.PrintInventory();
                                break;
                            case "Display Order History":
                                optionList = new List<string> { "Earliest", "Latest", "Cheapest", "Most Expensive" };
                                option = HelperPizza.PizzaOptionIO("Sorting Order", optionList);

                                switch (option)
                                {
                                    case "Earliest":
                                        DisplayOrderHistorySortEarliest(selectedLocation);
                                        break;
                                    case "Latest":
                                        DisplayOrderHistorySortLatest(selectedLocation);
                                        break;
                                    case "Cheapest":
                                        DisplayOrderHistorySortCheapest(selectedLocation);
                                        break;
                                    case "Most Expensive":
                                        DisplayOrderHistorySortMostExpensive(selectedLocation);
                                        break;
                                    default:
                                        DisplayOrderHistory(selectedLocation);
                                        break;
                                }
                                break;
                            case "Quit":
                                Console.WriteLine("Returning to Main Menu...");
                                break;
                            default:
                                break;
                        }
                        break;

                    case "Quit":
                        loop = false;
                        break;

                    default:
                        break;
                }
                if (loop == false) break;
            }
        }

        static Customer SearchUsersByName(List<Customer> userList)
        {
            Console.WriteLine("\nSearching List of Users...");
            Console.WriteLine("\nEnter first name.\n");
            var firstName = HelperIO.ReadLine();
            Console.WriteLine("\nEnter last name.\n");
            var lastName = HelperIO.ReadLine();
            Customer searchedUser = null;
            foreach (var user in userList)
            {
                if (firstName == user.FirstName && lastName == user.LastName)
                {
                    searchedUser = user;
                    break;
                }
            }
            if (searchedUser != null)
            {
                Console.WriteLine("\n...Found user!");
            }
            else
            {
                Console.WriteLine("\n...Could not find user.");
            }

            return searchedUser;
        }

        static void DisplayOrderHistory(Storefront location)
        {
            if (location.StorefrontOrderHistory != null)
            {
                Console.WriteLine("\n--- \nOrder History: \n---");
                foreach (var order in location.StorefrontOrderHistory)
                {
                    order.PrintOrder();
                }
            }
        }

        static void DisplayOrderHistory(Customer user)
        {
            if (user.LatestOrder.OrderName != null)
            {
                Console.WriteLine("\n--- \nOrder History: \n---");
                foreach (var order in user.OrderHistory)
                {
                    order.PrintOrder();
                }
            }
        }

        static void DisplayOrderHistorySortMostExpensive(Storefront location)
        {
            if (location.StorefrontOrderHistory != null)
            {
                var expensiveHistory = location.StorefrontOrderHistory.OrderByDescending(o => o.OrderPrice);
                Console.WriteLine("\n--- \nOrder History: \n---");
                foreach (var order in expensiveHistory)
                {
                    order.PrintOrder();
                }
            }
        }

        static void DisplayOrderHistorySortMostExpensive(Customer user)
        {
            if (user.LatestOrder.OrderName != null)
            {
                var expensiveHistory = user.OrderHistory.OrderByDescending(o => o.OrderPrice);
                Console.WriteLine("\n--- \nOrder History: \n---");
                foreach (var order in expensiveHistory)
                {
                    order.PrintOrder();
                }
            }
        }

        static void DisplayOrderHistorySortCheapest(Storefront location)
        {
            if (location.StorefrontOrderHistory != null)
            {
                var cheapestHistory = location.StorefrontOrderHistory.OrderBy(o => o.OrderPrice);
                Console.WriteLine("\n--- \nOrder History: \n---");
                foreach (var order in cheapestHistory)
                {
                    order.PrintOrder();
                }
            }
        }

        static void DisplayOrderHistorySortCheapest(Customer user)
        {
            if (user.LatestOrder.OrderName != null)
            {
                var cheapestHistory = user.OrderHistory.OrderBy(o => o.OrderPrice);
                Console.WriteLine("\n--- \nOrder History: \n---");
                foreach (var order in cheapestHistory)
                {
                    order.PrintOrder();
                }
            }
        }

        static void DisplayOrderHistorySortLatest(Storefront location)
        {
            if (location.StorefrontOrderHistory != null)
            {
                var latestHistory = location.StorefrontOrderHistory.OrderByDescending(o => o.OrderTime);
                Console.WriteLine("\n--- \nOrder History: \n---");
                foreach (var order in latestHistory)
                {
                    order.PrintOrder();
                }
            }
        }

        static void DisplayOrderHistorySortLatest(Customer user)
        {
            if (user.LatestOrder.OrderName != null)
            {
                var latestHistory = user.OrderHistory.OrderByDescending(o => o.OrderTime);
                Console.WriteLine("\n--- \nOrder History: \n---");
                foreach (var order in latestHistory)
                {
                    order.PrintOrder();
                }
            }
        }

        static void DisplayOrderHistorySortEarliest(Storefront location)
        {
            if (location.StorefrontOrderHistory != null)
            {
                var earliestHistory = location.StorefrontOrderHistory.OrderBy(o => o.OrderTime);
                Console.WriteLine("\n--- \nOrder History: \n---");
                foreach (var order in earliestHistory)
                {
                    order.PrintOrder();
                }
            }
        }

        static void DisplayOrderHistorySortEarliest(Customer user)
        {
            if (user.LatestOrder.OrderName != null)
            {
                var earliestHistory = user.OrderHistory.OrderBy(o => o.OrderTime);
                Console.WriteLine("\n--- \nOrder History: \n---");
                foreach (var order in earliestHistory)
                {
                    order.PrintOrder();
                }
            }
        }

        static int MatchCustomerToIndex(Customer customer, List<Customer> list)
        {
            int index = -1;

            string customerId = $"{customer.Id}: {customer.FirstName} {customer.LastName}";
            foreach (var item in list)
            {
                string itemId = $"{item.Id}: {item.FirstName} {item.LastName}";
                if (customerId == itemId)
                {
                    index = list.IndexOf(item);
                    break;
                }
            }

            return index;
        }

        static int MatchStorefrontToIndex(Storefront storefront, List<Storefront> list)
        {
            int index = -1;

            foreach (var item in list)
            {
                if (storefront.StoreLocation == item.StoreLocation)
                {
                    index = list.IndexOf(item);
                    break;
                }
            }

            return index;
        }

        static Storefront ProcessStorefront(Storefront storefront, List<Storefront> list)
        {
            var index = (MatchStorefrontToIndex(storefront, list)); // check if storefront already exists in storefront list
            if (index != -1) // means index was found for customer in list
            {
                storefront = list[index]; // set currentCustomer reference to the indexed Customer
            }
            else // no index found for storefront, need to add new storefront to the list
            {
                list.Add(storefront);
            }
            return storefront;
        }

        static Storefront NewUserFlow(Customer currentCustomer, Storefront RestonStorefront, Storefront HerndonStorefront, Storefront SterlingStorefront)
        {
            Console.WriteLine($"\nHello, {currentCustomer.FirstName}!");

            Console.WriteLine("\nPlease select a store location:");
            Console.WriteLine("Reston, Herndon, Sterling");

            Storefront currentStorefront;
            var optionList = new List<string> { "Reston", "Herndon", "Sterling" };
            var option = HelperPizza.PickOptionFromOptionList(optionList);

            currentStorefront = PickCurrentStorefront(option, RestonStorefront, HerndonStorefront, SterlingStorefront);

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
                currentStorefront = PickCurrentStorefront(currentCustomer.DefaultLocation, RestonStorefront, HerndonStorefront, SterlingStorefront);
                Console.WriteLine($"\nOk, you are ordering at {currentCustomer.DefaultLocation}.");
            }
            else if (option == "No")
            {
                Console.WriteLine("\nPlease select a store location:");
                Console.WriteLine("Reston, Herndon, Sterling");

                optionList = new List<string> { "Reston", "Herndon", "Sterling" };
                var location = HelperPizza.PickOptionFromOptionList(optionList);

                currentStorefront = PickCurrentStorefront(location, RestonStorefront, HerndonStorefront, SterlingStorefront);

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

        static Storefront PickCurrentStorefront(string option, Storefront RestonStorefront, Storefront HerndonStorefront, Storefront SterlingStorefront)
        {
            Storefront currentStorefront;
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
                    currentStorefront = RestonStorefront;
                    break;
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
