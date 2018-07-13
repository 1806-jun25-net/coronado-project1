using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using PizzaApp.Context;
using PizzaApp.Library;

namespace PizzaApp.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
      
            // initialize db access

            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = configBuilder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<PizzaDBContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("PizzaDB"));
            var options = optionsBuilder.Options;

            var dbContext = new PizzaDBContext(options);
            var pizzaRepository = new PizzaRepository(dbContext);

            // initialize list of pizzas            
            var pizzaList = new List<Library.Pizza>();

            // initialize list of orders            
            var orderList = new List<Library.Order>();

            // initialize locations
            var locationList = new List<Library.Location>();
            Library.Location Reston = new Library.Location("Reston");
            Library.Location Herndon = new Library.Location("Herndon");
            Library.Location Sterling = new Library.Location("Sterling");
            Library.Location currentLocation;

            // initialize store inventories
            var inventoryList = new List<Library.Inventory>();
            Library.Inventory RestonInventory = new Library.Inventory(Reston);
            Library.Inventory HerndonInventory = new Library.Inventory(Herndon);
            Library.Inventory SterlingInventory = new Library.Inventory(Sterling);

            // initialize customer
            Library.User currentUser;
            var userList = new List<Library.User>();

            Console.WriteLine("Attempting to load from database...\n");
            // try to load pizzas from DB
            pizzaList = pizzaRepository.GetPizzas().ToList();
            if (pizzaList.Count == 0)
            {
                Console.WriteLine("Could not load any pizzas from the database.\n");
            }

            // try to load orders from DB
            orderList = pizzaRepository.GetOrders().ToList();
            if (orderList.Count == 0)
            {
                Console.WriteLine("Could not load any orders from the database.\n");
            }

            // try to assign pizzas to matching orders
            if (pizzaList.Count != 0)
            {
                foreach (var order in orderList) // goes through all orders and assigns pizzas
                {
                    order.BuildPizzaList(pizzaList);
                }
            }

            // attempt loading store info from DB
            locationList = pizzaRepository.GetLocations().ToList();
            if (locationList.Count == 0)
            {
                Console.WriteLine("Could not load any locations from the database.\n");
            }

            Reston = new Library.Location("Reston");
            Herndon = new Library.Location("Herndon");
            Sterling = new Library.Location("Sterling");

            Reston = ProcessLocation(Reston, locationList);
            Herndon = ProcessLocation(Herndon, locationList);
            Sterling = ProcessLocation(Sterling, locationList);

            // attempt loading store inventory from DB
            inventoryList = pizzaRepository.GetInventories().ToList();
            if (inventoryList.Count == 0)
            {
                Console.WriteLine("Could not load any inventories from the database.\n");
            }

            foreach (var item in locationList)
            {
                item.SetInventoryFromList(inventoryList);
            }

            foreach (var item in inventoryList)
            {
                item.SetLocationFromList(locationList);
            }

            // attempt loading user info from DB
            userList = pizzaRepository.GetUsers().ToList();
            if (userList.Count == 0)
            {
                Console.WriteLine("Could not load any users from the database.\n");
            }

            // main ui flow
            Console.WriteLine("Welcome to the Pizza Store Console Application!");
            var loop = true;
            while (loop)
            {
                Console.WriteLine("\n--- \nMain Menu: \n---");
                var optionList = new List<string> { "Order", "Search Users", "Location Info", "Quit" };
                var option = HelperIO.SelectOptionIO("an Option", optionList);
                switch (option)
                {
                    case "Order":
                        Console.WriteLine("\nEnter your first name.\n");
                        var firstName = HelperIO.ReadLine();
                        Console.WriteLine("\nEnter your last name.\n");
                        var lastName = HelperIO.ReadLine();

                        currentUser = new Library.User(firstName, lastName);

                        var index = (MatchUserToIndex(currentUser, userList)); // check if customer already exists in customer list
                        if (index != -1) // means index was found for customer in list
                        {
                            currentUser = userList[index]; // set currentCustomer reference to the indexed Customer
                            currentLocation = ReturningUserFlow(currentUser, Reston, Herndon, Sterling);
                        }
                        else // no index found for customer, need to add new customer to the list
                        {
                            userList.Add(currentUser);
                            pizzaRepository.AddUser(currentUser);
                            pizzaRepository.Save();

                            // attempt loading user info from DB
                            //Console.WriteLine("Reloading user list");
                            //userList = pizzaRepository.GetUsers().ToList();
                            //currentUser.Id = pizzaRepository.GetId(currentUser);

                            currentLocation = NewUserFlow(currentUser, Reston, Herndon, Sterling);

                            currentUser.DefaultLocation = currentLocation.Id;
                        }

                        currentUser.LatestLocation = currentLocation.Id;

                        pizzaRepository.UpdateUser(currentUser);
                        pizzaRepository.Save();

                        // call order builder
                        // which calls pizza builder up to 12 times
                        var currentOrder = new Library.Order();
                        currentOrder = HelperIO.OrderBuilder(currentUser, currentLocation, orderList);

                        // save to DB
                        foreach (var pizza in currentOrder.PizzaList)
                        {
                            pizzaRepository.AddPizza(pizza);
                            pizzaRepository.Save();
                        }

                        pizzaRepository.AddOrder(currentOrder);
                        pizzaRepository.Save();

                        pizzaRepository.UpdateInventory(currentLocation.Inventory);
                        pizzaRepository.Save();

                        pizzaRepository.UpdateLocation(currentLocation);
                        pizzaRepository.Save();

                        break;
                    case "Search Users":
                        var searchedUser = SearchUsersByName(userList);
                        if (searchedUser != null)
                        {
                            optionList = new List<string> { "Display Latest Order", "Display Order History", "Quit" };
                            option = HelperIO.SelectOptionIO("an Option", optionList);
                            switch (option)
                            {
                                case "Display Latest Order":
                                    Console.WriteLine("\n--- \nLatest Order: \n---");
                                    foreach (var item in orderList)
                                    {
                                        if (searchedUser.LatestOrderId == item.Id) item.PrintOrder();
                                    }
                                    break;
                                case "Display Order History":

                                    optionList = new List<string> { "Earliest", "Latest", "Cheapest", "Most Expensive" };
                                    option = HelperIO.SelectOptionIO("Sorting Order", optionList);

                                    switch (option)
                                    {
                                        case "Earliest":
                                            DisplayOrderHistorySortEarliest(searchedUser, orderList);
                                            break;
                                        case "Latest":
                                            DisplayOrderHistorySortLatest(searchedUser, orderList);
                                            break;
                                        case "Cheapest":
                                            DisplayOrderHistorySortCheapest(searchedUser, orderList);
                                            break;
                                        case "Most Expensive":
                                            DisplayOrderHistorySortMostExpensive(searchedUser, orderList);
                                            break;
                                        default:
                                            DisplayOrderHistory(searchedUser, orderList);
                                            break;
                                    }
                                    break;
                                case "Display Details":
                                    Console.WriteLine(searchedUser.Id);
                                    Console.WriteLine(searchedUser.FirstName);
                                    Console.WriteLine(searchedUser.LastName);
                                    Console.WriteLine(searchedUser.DefaultLocation);
                                    Console.WriteLine(searchedUser.LatestLocation);
                                    Console.WriteLine(searchedUser.LatestOrderId);
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
                        option = HelperIO.SelectOptionIO("a Location", optionList);

                        Library.Location selectedLocation = null;
                        switch (option)
                        {
                            case "Reston":
                                selectedLocation = Reston;
                                break;
                            case "Herndon":
                                selectedLocation = Herndon;
                                break;
                            case "Sterling":
                                selectedLocation = Sterling;
                                break;
                            default:
                                selectedLocation = Reston;
                                break;
                        }

                        optionList = new List<string> { "Display Inventory", "Display Order History", "Quit" };
                        option = HelperIO.SelectOptionIO("an Option", optionList);
                        switch (option)
                        {
                            case "Display Inventory":
                                selectedLocation.Inventory.PrintInventory();
                                break;
                            case "Display Order History":
                                optionList = new List<string> { "Earliest", "Latest", "Cheapest", "Most Expensive" };
                                option = HelperIO.SelectOptionIO("Sorting Order", optionList);

                                switch (option)
                                {
                                    case "Earliest":
                                        DisplayOrderHistorySortEarliest(selectedLocation, orderList);
                                        break;
                                    case "Latest":
                                        DisplayOrderHistorySortLatest(selectedLocation, orderList);
                                        break;
                                    case "Cheapest":
                                        DisplayOrderHistorySortCheapest(selectedLocation, orderList);
                                        break;
                                    case "Most Expensive":
                                        DisplayOrderHistorySortMostExpensive(selectedLocation, orderList);
                                        break;
                                    default:
                                        DisplayOrderHistory(selectedLocation, orderList);
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
            dbContext.Dispose();
        }

        static Library.User SearchUsersByName(List<Library.User> userList)
        {
            Console.WriteLine("\nSearching List of Users...");
            Console.WriteLine("\nEnter first name.\n");
            var firstName = HelperIO.ReadLine();
            Console.WriteLine("\nEnter last name.\n");
            var lastName = HelperIO.ReadLine();
            Library.User searchedUser = null;
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

        static void DisplayOrderHistory(Library.Location location, List<Library.Order> orderList)
        {
            Console.WriteLine("\n--- \nOrder History: \n---");
            foreach (var order in orderList)
            {
                if (order.LocationId == location.Id) order.PrintOrder();
            }
        }

        static void DisplayOrderHistory(Library.User user, List<Library.Order> orderList)
        {
            Console.WriteLine("\n--- \nOrder History: \n---");
            foreach (var order in orderList)
            {
                if (order.UserId == user.Id) order.PrintOrder();
            }
        }

        static void DisplayOrderHistorySortMostExpensive(Library.Location location, List<Library.Order> orderList)
        {
            Console.WriteLine("\n--- \nOrder History: \n---");
            var expensiveHistory = orderList.OrderByDescending(o => o.Price);
            foreach (var order in expensiveHistory)
            {
                if (order.LocationId == location.Id) order.PrintOrder();
            }
        }

        static void DisplayOrderHistorySortMostExpensive(Library.User user, List<Library.Order> orderList)
        {
            Console.WriteLine("\n--- \nOrder History: \n---");
            var expensiveHistory = orderList.OrderByDescending(o => o.Price);
            foreach (var order in expensiveHistory)
            {
                if (order.UserId == user.Id) order.PrintOrder();
            }
        }

        static void DisplayOrderHistorySortCheapest(Library.Location location, List<Library.Order> orderList)
        {
            Console.WriteLine("\n--- \nOrder History: \n---");
            var cheapestHistory = orderList.OrderBy(o => o.Price);
            foreach (var order in cheapestHistory)
            {
                if (order.LocationId == location.Id) order.PrintOrder();
            }
        }

        static void DisplayOrderHistorySortCheapest(Library.User user, List<Library.Order> orderList)
        {
            Console.WriteLine("\n--- \nOrder History: \n---");
            var cheapestHistory = orderList.OrderBy(o => o.Price);
            foreach (var order in cheapestHistory)
            {
                if (order.UserId == user.Id) order.PrintOrder();
            }
        }

        static void DisplayOrderHistorySortLatest(Library.Location location, List<Library.Order> orderList)
        {
            Console.WriteLine("\n--- \nOrder History: \n---");
            var latestHistory = orderList.OrderByDescending(o => o.DateTime);
            foreach (var order in latestHistory)
            {
                if (order.LocationId == location.Id) order.PrintOrder();
            }
        }

        static void DisplayOrderHistorySortLatest(Library.User user, List<Library.Order> orderList)
        {
            Console.WriteLine("\n--- \nOrder History: \n---");
            var latestHistory = orderList.OrderByDescending(o => o.DateTime);
            foreach (var order in latestHistory)
            {
                if (order.UserId == user.Id) order.PrintOrder();
            }
        }

        static void DisplayOrderHistorySortEarliest(Library.Location location, List<Library.Order> orderList)
        {
            Console.WriteLine("\n--- \nOrder History: \n---");
            var earliestHistory = orderList.OrderBy(o => o.DateTime);
            foreach (var order in earliestHistory)
            {
                if (order.LocationId == location.Id) order.PrintOrder();
            }
        }

        static void DisplayOrderHistorySortEarliest(Library.User user, List<Library.Order> orderList)
        {
            Console.WriteLine("\n--- \nOrder History: \n---");
            var earliestHistory = orderList.OrderBy(o => o.DateTime);
            foreach (var order in earliestHistory)
            {
                if (order.UserId == user.Id) order.PrintOrder();
            }
        }

        static int MatchUserToIndex(Library.User user, List<Library.User> list)
        {
            int index = -1;

            string userName = $"{user.FirstName} {user.LastName}";
            foreach (var item in list)
            {
                string itemName = $"{item.FirstName} {item.LastName}";
                if (userName == itemName)
                {
                    index = list.IndexOf(item);
                    break;
                }
            }

            return index;
        }

        static int MatchLocationToIndex(Library.Location location, List<Library.Location> list)
        {
            int index = -1;

            foreach (var item in list)
            {
                if (location.Name == item.Name)
                {
                    index = list.IndexOf(item);
                    break;
                }
            }

            return index;
        }

        static Library.Location ProcessLocation(Library.Location location, List<Library.Location> list)
        {
            var index = (MatchLocationToIndex(location, list)); // check if storefront already exists in storefront list
            if (index != -1) // means index was found for customer in list
            {
                location = list[index]; // set currentCustomer reference to the indexed Customer
            }
            else // no index found for storefront, need to add new storefront to the list
            {
                list.Add(location);
            }
            return location;
        }

        static Library.Location PickCurrentLocation(string option, Library.Location Reston, Library.Location Herndon, Library.Location Sterling)
        {
            Library.Location currentLocation;
            switch (option)
            {
                case "Reston":
                    currentLocation = Reston;
                    break;
                case "Herndon":
                    currentLocation = Herndon;
                    break;
                case "Sterling":
                    currentLocation = Sterling;
                    break;
                default:
                    currentLocation = Reston;
                    break;
            }
            return currentLocation;
        }

        static Library.Location NewUserFlow(Library.User currentUser, Library.Location Reston, Library.Location Herndon, Library.Location Sterling)
        {
            Console.WriteLine($"\nHello, {currentUser.FirstName}!");

            Console.WriteLine("\nPlease select a store location:");
            Console.WriteLine("Reston, Herndon, Sterling");

            Library.Location currentLocation;
            var optionList = new List<string> { "Reston", "Herndon", "Sterling" };
            var option = HelperIO.PickOptionFromOptionList(optionList);

            currentLocation = PickCurrentLocation(option, Reston, Herndon, Sterling);

            currentUser.DefaultLocation = currentLocation.Id;

            Console.WriteLine($"\nOk, {option} has been set as your default location.");

            return currentLocation;
        }

        static Library.Location ReturningUserFlow(Library.User currentUser, Library.Location Reston, Library.Location Herndon, Library.Location Sterling)
        {
            Console.WriteLine($"Welcome back, {currentUser.FirstName}!");

            string defaultLocationName;
            switch (currentUser.DefaultLocation)
            {
                case 1:
                    defaultLocationName = "Reston";
                    break;
                case 2:
                    defaultLocationName = "Herndon";
                    break;
                case 3:
                    defaultLocationName = "Sterling";
                    break;
                default:
                    defaultLocationName = "Reston";
                    break;
            }

            Console.WriteLine($"\nYour current default location is {defaultLocationName}.");
            Console.WriteLine($"\nDo you want to order from here?");
            Console.WriteLine("Enter: (Yes/No)\n");

            var currentLocation = new Library.Location();
            var optionList = new List<string> { "Yes", "No" };
            var option = HelperIO.PickOptionFromOptionList(optionList);
            if (option == "Yes")
            {
                currentLocation = PickCurrentLocation(defaultLocationName, Reston, Herndon, Sterling);
                Console.WriteLine($"\nOk, you are ordering at {defaultLocationName}.");
            }
            else if (option == "No")
            {
                Console.WriteLine("\nPlease select a store location:");
                Console.WriteLine("Reston, Herndon, Sterling");

                optionList = new List<string> { "Reston", "Herndon", "Sterling" };
                var location = HelperIO.PickOptionFromOptionList(optionList);

                currentLocation = PickCurrentLocation(location, Reston, Herndon, Sterling);

                Console.WriteLine($"\nYour current default location is {defaultLocationName}.");
                Console.WriteLine($"Do you want to set {location} as your default location?");
                Console.WriteLine("Enter: (Yes/No)\n");

                optionList = new List<string> { "Yes", "No" };
                option = HelperIO.PickOptionFromOptionList(optionList);
                if (option == "Yes")
                {
                    currentUser.DefaultLocation = currentLocation.Id;
                    Console.WriteLine($"\nOk, {location} is now your default location.");
                }
                else if (option == "No")
                {
                    Console.WriteLine($"\nOk, {defaultLocationName} is still your default location.");
                }
            }
            return currentLocation;
        }
    }
}
