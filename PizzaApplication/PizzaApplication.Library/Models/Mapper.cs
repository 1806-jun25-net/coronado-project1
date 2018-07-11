using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PizzaApplication.Data;

namespace PizzaApplication.Library
{
    public static class Mapper
    {
        public static Customer Map(Users user) => new Customer
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            DefaultLocation = user.DefaultLocation,
            LatestLocation = user.LatestLocation,
            LatestOrder = new Order((int)user.LatestOrderId)
        };

        public static Users Map(Customer user) => new Users
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            DefaultLocation = user.DefaultLocation,
            LatestLocation = user.LatestLocation,
            LatestOrderId = user.LatestOrder.Id
        };

        public static Pizza Map(Pizzas pizza) => new Pizza
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

        public static Pizzas Map(Pizza pizza) => new Pizzas
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

        public static Order Map(PizzaOrders order) => new Order
        {
            Id = order.Id,
            OrderLocation = order.Location,
            OrderTime = (DateTime)order.DateTime,
            OrderPrice = (decimal)order.Price,
        };

        public static PizzaOrders Map(Order order) => new PizzaOrders
        {
            Id = order.Id,
            Location = order.OrderLocation,
            DateTime = order.OrderTime,
            Price = order.OrderPrice,
        };

        public static Storefront Map(Locations location) => new Storefront
        {
            StoreLocation = location.Location,
            StoreInventory = new Inventory((int)location.InventoryId)
        };

        public static Locations Map(Storefront location) => new Locations
        {
            Location = location.StoreLocation,
            InventoryId = location.StoreInventory.Id
        };

        public static Inventory Map(LocationInventory inventory) => new Inventory
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

        public static LocationInventory Map(Inventory inventory) => new LocationInventory
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

    }
}
