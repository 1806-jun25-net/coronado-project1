using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PizzaApplication.Data;

namespace PizzaApplication.Library
{
    public static class Mapper
    {
        // Customer <=> Users
        public static Library.Customer Map(Data.Users user) => new Library.Customer
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            DefaultLocation = user.DefaultLocation,
            LatestLocation = user.LatestLocation,
            LatestOrderId = (int)user.LatestOrderId,
            LatestOrder = new Order((int)user.LatestOrderId)
        };

        public static Data.Users Map(Library.Customer user) => new Data.Users
        {
            //Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            DefaultLocation = user.DefaultLocation,
            LatestLocation = user.LatestLocation,
            LatestOrderId = user.LatestOrder.Id
        };

        // Pizza <=> Pizzas
        public static Library.Pizza Map(Data.Pizzas pizza) => new Library.Pizza
        {
            Id = pizza.Id,
            PizzaName = pizza.Name,
            PizzaCrust = new Crust(pizza.Crust),
            PizzaSauce = new Sauce(pizza.Sauce),
            PizzaCheese = new Cheese(pizza.Cheese),
            Topping1 = pizza.Topping1,
            Topping2 = pizza.Topping2,
            Topping3 = pizza.Topping3,
            Topping4 = pizza.Topping4,
            Topping5 = pizza.Topping5,
            Topping6 = pizza.Topping6
        };

        public static Data.Pizzas Map(Library.Pizza pizza) => new Data.Pizzas
        {
            Id = pizza.Id,
            Name = pizza.PizzaName,
            Crust = pizza.PizzaCrust.IngredientName,
            Sauce = pizza.PizzaSauce.IngredientName,
            Cheese = pizza.PizzaCheese.IngredientName,
            Topping1 = pizza.Topping1,
            Topping2 = pizza.Topping2,
            Topping3 = pizza.Topping3,
            Topping4 = pizza.Topping4,
            Topping5 = pizza.Topping5,
            Topping6 = pizza.Topping6
        };

        // Order <=> PizzaOrders
        public static Library.Order Map(Data.PizzaOrders order) => new Library.Order
        {
            Id = order.Id,
            CustomerId = (int)order.CustomerId,
            OrderLocation = order.Location,
            OrderTime = (DateTime)order.DateTime,
            OrderPrice = (decimal)order.Price,
            PizzaId = order.PizzaId,
            PizzaId2 = order.PizzaId2,
            PizzaId3 = order.PizzaId3,
            PizzaId4 = order.PizzaId4,
            PizzaId5 = order.PizzaId5,
            PizzaId6 = order.PizzaId6,
            PizzaId7 = order.PizzaId7,
            PizzaId8 = order.PizzaId8,
            PizzaId9 = order.PizzaId9,
            PizzaId10 = order.PizzaId10,
            PizzaId11 = order.PizzaId11,
            PizzaId12 = order.PizzaId12

        };

        public static Data.PizzaOrders Map(Library.Order order) => new Data.PizzaOrders
        {
            Id = order.Id,
            CustomerId = order.CustomerId,
            Location = order.OrderLocation,
            DateTime = order.OrderTime,
            Price = order.OrderPrice,
            PizzaId = order.PizzaId,
            PizzaId2 = order.PizzaId2,
            PizzaId3 = order.PizzaId3,
            PizzaId4 = order.PizzaId4,
            PizzaId5 = order.PizzaId5,
            PizzaId6 = order.PizzaId6,
            PizzaId7 = order.PizzaId7,
            PizzaId8 = order.PizzaId8,
            PizzaId9 = order.PizzaId9,
            PizzaId10 = order.PizzaId10,
            PizzaId11 = order.PizzaId11,
            PizzaId12 = order.PizzaId12
        };

        // Storefront <=> Locations
        public static Library.Storefront Map(Data.Locations location) => new Library.Storefront
        {
            StoreLocation = location.Location,
            Id = location.Id,
            StoreInventory = new Inventory((int)location.InventoryId)
        };

        public static Data.Locations Map(Library.Storefront location) => new Data.Locations
        {
            Location = location.StoreLocation,
            InventoryId = location.StoreInventory.Id
        };

        // Inventory <=> LocationInventory
        public static Library.Inventory Map(Data.LocationInventory inventory) => new Library.Inventory
        {
            Id = inventory.Id,
            StoreId = (int)inventory.StoreId,
            InventoryCountArray = new double[]
            {
                inventory.Dough,
                inventory.TomatoSauce,
                inventory.WhiteSauce,
                inventory.Cheese,
                inventory.Pepperoni,
                inventory.Ham,
                inventory.Chicken,
                inventory.Beef,
                inventory.Sausage,
                inventory.Bacon,
                inventory.Anchovies,
                inventory.RedPeppers,
                inventory.GreenPeppers,
                inventory.Pineapple,
                inventory.Olives,
                inventory.Mushrooms,
                inventory.Garlic,
                inventory.Onions,
                inventory.Tomatoes,
                inventory.Spinach,
                inventory.Basil,
                inventory.Ricotta,
                inventory.Parmesan,
                inventory.Feta
            }
        };

        public static Data.LocationInventory Map(Library.Inventory inventory) => new Data.LocationInventory
        {
            /Id = inventory.Id,
            StoreId = inventory.StoreId,
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
