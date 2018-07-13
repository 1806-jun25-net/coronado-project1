using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PizzaApp.Context;

namespace PizzaApp.Library
{
    public static class Mapper
    {
        // User Mapping
        public static Library.User Map(Context.User user) => new Library.User
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            DefaultLocation = user.DefaultLocation,
            LatestLocation = user.LatestLocation,
            LatestOrderId = user.LatestOrderId
        };

        public static Context.User Map(Library.User user) => new Context.User
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            DefaultLocation = user.DefaultLocation,
            LatestLocation = user.LatestLocation,
            LatestOrderId = user.LatestOrderId
        };

        // Location Mapping
        public static Library.Location Map(Context.Location location) => new Library.Location
        {
            Id = location.Id,
            Name = location.Name,
            InventoryId = (int)location.InventoryId
        };

        public static Context.Location Map(Library.Location location) => new Context.Location
        {
            Id = location.Id,
            Name = location.Name,
            InventoryId = location.InventoryId
        };

        // Inventory Mapping
        public static Library.Inventory Map(Context.Inventory inventory) => new Library.Inventory
        {
            Id = inventory.Id,
            LocationId = (int)inventory.LocationId,
            Dough = inventory.Dough,
            TomatoSauce = inventory.TomatoSauce,
            WhiteSauce = inventory.WhiteSauce,
            Cheese = inventory.Cheese,
            Pepperoni = inventory.Pepperoni,
            Ham = inventory.Ham,
            Chicken = inventory.Chicken,
            Beef = inventory.Beef,
            Sausage = inventory.Sausage,
            Bacon = inventory.Bacon,
            Anchovies = inventory.Anchovies,
            RedPeppers = inventory.RedPeppers,
            GreenPeppers = inventory.GreenPeppers,
            Pineapple = inventory.Pineapple,
            Olives = inventory.Olives,
            Mushrooms = inventory.Mushrooms,
            Garlic = inventory.Garlic,
            Onions = inventory.Onions,
            Tomatoes = inventory.Tomatoes,
            Spinach = inventory.Spinach,
            Basil = inventory.Basil,
            Ricotta = inventory.Ricotta,
            Parmesan = inventory.Parmesan,
            Feta = inventory.Feta
        };

        public static Context.Inventory Map(Library.Inventory inventory) => new Context.Inventory
        {
            Id = inventory.Id,
            LocationId = inventory.LocationId,
            Dough = inventory.Dough,
            TomatoSauce = inventory.TomatoSauce,
            WhiteSauce = inventory.WhiteSauce,
            Cheese = inventory.Cheese,
            Pepperoni = inventory.Pepperoni,
            Ham = inventory.Ham,
            Chicken = inventory.Chicken,
            Beef = inventory.Beef,
            Sausage = inventory.Sausage,
            Bacon = inventory.Bacon,
            Anchovies = inventory.Anchovies,
            RedPeppers = inventory.RedPeppers,
            GreenPeppers = inventory.GreenPeppers,
            Pineapple = inventory.Pineapple,
            Olives = inventory.Olives,
            Mushrooms = inventory.Mushrooms,
            Garlic = inventory.Garlic,
            Onions = inventory.Onions,
            Tomatoes = inventory.Tomatoes,
            Spinach = inventory.Spinach,
            Basil = inventory.Basil,
            Ricotta = inventory.Ricotta,
            Parmesan = inventory.Parmesan,
            Feta = inventory.Feta
        };

        // Pizza Mapping
        public static Library.Pizza Map(Context.Pizza pizza) => new Library.Pizza
        {
            Id = pizza.Id,
            Name = pizza.Name,
            Price = (decimal)pizza.Price,
            Crust = new Crust(pizza.Crust),
            Sauce = new Sauce(pizza.Sauce),
            Cheese = new Cheese(pizza.Cheese),
            Topping1 = new Topping(pizza.Topping1),
            Topping2 = new Topping(pizza.Topping2),
            Topping3 = new Topping(pizza.Topping3),
            Topping4 = new Topping(pizza.Topping4),
            Topping5 = new Topping(pizza.Topping5),
            Topping6 = new Topping(pizza.Topping6)
        };

        public static Context.Pizza Map(Library.Pizza pizza) => new Context.Pizza
        {
            Id = pizza.Id,
            Name = pizza.Name,
            Price = pizza.Price,
            Crust = pizza.Crust.IngredientName,
            Sauce = pizza.Sauce.IngredientName,
            Cheese = pizza.Cheese.IngredientName,
            Topping1 = pizza.Topping1.IngredientName,
            Topping2 = pizza.Topping2.IngredientName,
            Topping3 = pizza.Topping3.IngredientName,
            Topping4 = pizza.Topping4.IngredientName,
            Topping5 = pizza.Topping5.IngredientName,
            Topping6 = pizza.Topping6.IngredientName
        };

        // Order Mapping
        public static Library.Order Map(Context.Order order) => new Library.Order
        {
            Id = order.Id,
            UserId = order.Id,
            LocationId = order.Id,
            DateTime = (DateTime)order.DateTime,
            Price = order.Price,
            PizzaId1 = order.PizzaId1,
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

        public static Context.Order Map(Library.Order order) => new Context.Order
        {
            Id = order.Id,
            UserId = order.Id,
            LocationId = order.Id,
            DateTime = order.DateTime,
            Price = order.Price,
            PizzaId1 = order.PizzaId1,
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

        public static IEnumerable<Library.User> Map(IEnumerable<Context.User> users) => users.Select(Map);
        public static IEnumerable<Context.User> Map(IEnumerable<Library.User> users) => users.Select(Map);
        
        public static IEnumerable<Library.Location> Map(IEnumerable<Context.Location> locations) => locations.Select(Map);
        public static IEnumerable<Context.Location> Map(IEnumerable<Library.Location> locations) => locations.Select(Map);

        public static IEnumerable<Library.Inventory> Map(IEnumerable<Context.Inventory> inventories) => inventories.Select(Map);
        public static IEnumerable<Context.Inventory> Map(IEnumerable<Library.Inventory> inventories) => inventories.Select(Map);

        public static IEnumerable<Library.Pizza> Map(IEnumerable<Context.Pizza> pizzas) => pizzas.Select(Map);
        public static IEnumerable<Context.Pizza> Map(IEnumerable<Library.Pizza> pizzas) => pizzas.Select(Map);

        public static IEnumerable<Library.Order> Map(IEnumerable<Context.Order> orders) => orders.Select(Map);
        public static IEnumerable<Context.Order> Map(IEnumerable<Library.Order> orders) => orders.Select(Map);
    }
}
