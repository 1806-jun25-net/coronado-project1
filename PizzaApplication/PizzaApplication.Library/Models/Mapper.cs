using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PizzaApplication.Data;

namespace PizzaApplication.Library
{
    public static class Mapper
    {
        public static Library.Customer Map(Data.Users user) => new Library.Customer
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            DefaultLocation = user.DefaultLocation,
            LatestLocation = user.LatestLocation,
            LatestOrder = new Order((int)user.LatestOrderId)
        };

        public static Data.Users Map(Library.Customer user) => new Data.Users
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            DefaultLocation = user.DefaultLocation,
            LatestLocation = user.LatestLocation,
            LatestOrderId = user.LatestOrder.Id
        };

        public static Library.Pizza Map(Data.Pizzas pizza) => new Library.Pizza
        {
            Id = pizza.Id,
            PizzaName = pizza.Name,
            PizzaCrust = new Crust(pizza.Crust),
            PizzaSauce = new Sauce(pizza.Sauce),
            PizzaCheese = new Cheese(pizza.Cheese),
            ToppingList = new List<Topping>
            {
                new Topping(pizza.Topping1),
                new Topping(pizza.Topping2),
                new Topping(pizza.Topping3),
                new Topping(pizza.Topping4),
                new Topping(pizza.Topping5),
                new Topping(pizza.Topping6)
            }
        };

        public static Data.Pizzas Map(Library.Pizza pizza) => new Data.Pizzas
        {
            Id = pizza.Id,
            Name = pizza.PizzaName,
            Crust = pizza.PizzaCrust.IngredientName,
            Sauce = pizza.PizzaSauce.IngredientName,
            Cheese = pizza.PizzaCheese.IngredientName,
            Topping1 = pizza.ToppingList[0].ToppingType,
            Topping2 = pizza.ToppingList[1].ToppingType,
            Topping3 = pizza.ToppingList[2].ToppingType,
            Topping4 = pizza.ToppingList[3].ToppingType,
            Topping5 = pizza.ToppingList[4].ToppingType,
            Topping6 = pizza.ToppingList[5].ToppingType
        };

        public static Library.Order Map(Data.PizzaOrders order) => new Library.Order
        {
            Id = order.Id,
            OrderLocation = order.Location,
            OrderTime = (DateTime)order.DateTime,
            OrderPrice = (decimal)order.Price,
        };

        public static Data.PizzaOrders Map(Library.Order order) => new Data.PizzaOrders
        {
            Id = order.Id,
            Location = order.OrderLocation,
            DateTime = order.OrderTime,
            Price = order.OrderPrice,
        };

        public static Library.Storefront Map(Data.Locations location) => new Library.Storefront
        {
            StoreLocation = location.Location,
            StoreInventory = new Inventory((int)location.InventoryId)
        };

        public static Data.Locations Map(Library.Storefront location) => new Data.Locations
        {
            Location = location.StoreLocation,
            InventoryId = location.StoreInventory.Id
        };

        public static Library.Inventory Map(Data.LocationInventory inventory) => new Library.Inventory
        {
            Id = inventory.Id,
            StoreLocation = inventory.Location,
            InventoryCountArray = new double[]
            {
                (double)inventory.Dough,
                (double)inventory.TomatoSauce,
                (double)inventory.WhiteSauce,
                (double)inventory.Cheese,
                (double)inventory.Pepperoni,
                (double)inventory.Ham,
                (double)inventory.Chicken,
                (double)inventory.Beef,
                (double)inventory.Sausage,
                (double)inventory.Bacon,
                (double)inventory.Anchovies,
                (double)inventory.RedPeppers,
                (double)inventory.GreenPeppers,
                (double)inventory.Pineapple,
                (double)inventory.Olives,
                (double)inventory.Mushrooms,
                (double)inventory.Garlic,
                (double)inventory.Onions,
                (double)inventory.Tomatoes,
                (double)inventory.Spinach,
                (double)inventory.Basil,
                (double)inventory.Ricotta,
                (double)inventory.Parmesan,
                (double)inventory.Feta
            }
        };

        public static Data.LocationInventory Map(Library.Inventory inventory) => new Data.LocationInventory
        {
            Id = inventory.Id,
            Location = inventory.StoreLocation,
            Dough = inventory.InventoryCountArray[0],
            TomatoSauce = inventory.InventoryCountArray[1],
            WhiteSauce = inventory.InventoryCountArray[2],
            Cheese = inventory.InventoryCountArray[3],
            Pepperoni = inventory.InventoryCountArray[4],
            Ham = inventory.InventoryCountArray[5],
            Chicken = inventory.InventoryCountArray[6],
            Beef = inventory.InventoryCountArray[7],
            Sausage = inventory.InventoryCountArray[8],
            Bacon = inventory.InventoryCountArray[9],
            Anchovies = inventory.InventoryCountArray[10],
            RedPeppers = inventory.InventoryCountArray[11],
            GreenPeppers = inventory.InventoryCountArray[12],
            Pineapple = inventory.InventoryCountArray[13],
            Olives = inventory.InventoryCountArray[14],
            Mushrooms = inventory.InventoryCountArray[15],
            Garlic = inventory.InventoryCountArray[16],
            Onions = inventory.InventoryCountArray[17],
            Tomatoes = inventory.InventoryCountArray[18],
            Spinach = inventory.InventoryCountArray[19],
            Basil = inventory.InventoryCountArray[20],
            Ricotta = inventory.InventoryCountArray[21],
            Parmesan = inventory.InventoryCountArray[22],
            Feta = inventory.InventoryCountArray[23]
        };

        public static IEnumerable<Library.Customer> Map(IEnumerable<Data.Users> users) => users.Select(Map);
        public static IEnumerable<Data.Users> Map(IEnumerable<Library.Customer> users) => users.Select(Map);

        public static IEnumerable<Library.Pizza> Map(IEnumerable<Data.Pizzas> pizzas) => pizzas.Select(Map);
        public static IEnumerable<Data.Pizzas> Map(IEnumerable<Library.Pizza> pizzas) => pizzas.Select(Map);

        public static IEnumerable<Library.Order> Map(IEnumerable<Data.PizzaOrders> orders) => orders.Select(Map);
        public static IEnumerable<Data.PizzaOrders> Map(IEnumerable<Library.Order> orders) => orders.Select(Map);

        public static IEnumerable<Library.Storefront> Map(IEnumerable<Data.Locations> locations) => locations.Select(Map);
        public static IEnumerable<Data.Locations> Map(IEnumerable<Library.Storefront> locations) => locations.Select(Map);

        public static IEnumerable<Library.Inventory> Map(IEnumerable<Data.LocationInventory> inventories) => inventories.Select(Map);
        public static IEnumerable<Data.LocationInventory> Map(IEnumerable<Library.Inventory> inventories) => inventories.Select(Map);



    }
}
