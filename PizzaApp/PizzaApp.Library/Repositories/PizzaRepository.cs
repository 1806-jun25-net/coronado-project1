using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PizzaApp.Context;
using PizzaApp.Library;
using System.Linq;

namespace PizzaApp.Library
{
    public class PizzaRepository
    {
        private readonly PizzaAppDBContext _db;

        public PizzaRepository(PizzaAppDBContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        // User
        public IEnumerable<User> GetUsers()
        {
            return Mapper.Map(_db.User);
        }

        public User GetUserById(int id)
        {
            return Mapper.Map(_db.User.First(x => x.Id == id));
        }

        public void AddUser(User user)
        {
            _db.Add(Mapper.Map(user));
        }

        public void DeleteUser(int userId)
        {
            _db.Remove(_db.User.Find(userId));
        }

        public void UpdateUser(User user)
        {
            _db.Entry(_db.User.Find(user.Id)).CurrentValues.SetValues(Mapper.Map(user));
        }

        // Pizza
        public IEnumerable<Pizza> GetPizzas()
        {
            return Mapper.Map(_db.Pizza);
        }

        
        public Pizza GetPizzaById(int id)
        {
            return Mapper.Map(_db.Pizza.First(x => x.Id == id));
        }

        public void AddPizza(Pizza pizza)
        {
            _db.Add(Mapper.Map(pizza));
        }

        public void DeletePizza(int pizzaId)
        {
            _db.Remove(_db.Pizza.Find(pizzaId));
        }

        public void UpdatePizza(Pizza pizza)
        {
            _db.Entry(_db.Pizza.Find(pizza.Id)).CurrentValues.SetValues(Mapper.Map(pizza));
        }

        // Order
        public IEnumerable<Order> GetOrders()
        {
            return Mapper.Map(_db.Order);
        }

        public Order GetOrderById(int id)
        {
            return Mapper.Map(_db.Order.First(x => x.Id == id));
        }

        public void AddOrder(Order order)
        {
            _db.Add(Mapper.Map(order));
        }

        public void DeleteOrder(int orderId)
        {
            _db.Remove(_db.Order.Find(orderId));
        }

        public void UpdateOrder(Order order)
        {
            _db.Entry(_db.Order.Find(order.Id)).CurrentValues.SetValues(Mapper.Map(order));
        }

        // order matching to location
        public List<Order> MatchOrderToModel(Location location)
        {
            var allOrders = Mapper.Map(_db.Order);
            var orders = new List<Order>();
            foreach (var order in allOrders)
            {
                if (order.LocationId == location.Id)
                {
                    orders.Add(order);
                }
            }
            return orders;
        }

        // order matching to user
        public List<Order> MatchOrderToModel(User user)
        {
            var allOrders = Mapper.Map(_db.Order);
            var orders = new List<Order>();
            foreach (var order in allOrders)
            {
                if (order.UserId == user.Id)
                {
                    orders.Add(order);
                }
            }
            return orders;
        }

        // order sorting for location
        public IEnumerable<Order> SortOrdersByEarliest(Location location)
        {
            var orders = MatchOrderToModel(location);
            var earliestOrders = orders.OrderBy(o => o.DateTime);
            return earliestOrders;
        }

        public IEnumerable<Order> SortOrdersByLatest(Location location)
        {
            var orders = MatchOrderToModel(location);
            var earliestOrders = orders.OrderByDescending(o => o.DateTime);
            return earliestOrders;
        }

        public IEnumerable<Order> SortOrdersByCheapest(Location location)
        {
            var orders = MatchOrderToModel(location);
            var earliestOrders = orders.OrderBy(o => o.Price);
            return earliestOrders;
        }

        public IEnumerable<Order> SortOrdersByMostExpensive(Location location)
        {
            var orders = MatchOrderToModel(location);
            var earliestOrders = orders.OrderByDescending(o => o.Price);
            return earliestOrders;
        }

        // order sorting for user
        public IEnumerable<Order> SortOrdersByEarliest(User user)
        {
            var orders = MatchOrderToModel(user);
            var earliestOrders = orders.OrderBy(o => o.DateTime);
            return earliestOrders;
        }

        public IEnumerable<Order> SortOrdersByLatest(User user)
        {
            var orders = MatchOrderToModel(user);
            var earliestOrders = orders.OrderByDescending(o => o.DateTime);
            return earliestOrders;
        }

        public IEnumerable<Order> SortOrdersByCheapest(User user)
        {
            var orders = MatchOrderToModel(user);
            var earliestOrders = orders.OrderBy(o => o.Price);
            return earliestOrders;
        }

        public IEnumerable<Order> SortOrdersByMostExpensive(User user)
        {
            var orders = MatchOrderToModel(user);
            var earliestOrders = orders.OrderByDescending(o => o.Price);
            return earliestOrders;
        }


        // Location
        public IEnumerable<Location> GetLocations()
        {
            return Mapper.Map(_db.Location);
        }

        public Location GetLocationById(int id)
        {
            return Mapper.Map(_db.Location.First(x => x.Id == id));
        }

        public void AddLocation(Location location)
        {
            _db.Add(Mapper.Map(location));
        }

        public void DeleteLocation(int locationId)
        {
            _db.Remove(_db.Location.Find(locationId));
        }

        public void UpdateLocation(Location location)
        {
            _db.Entry(_db.Location.Find(location.Id)).CurrentValues.SetValues(Mapper.Map(location));
        }

        // Inventory
        public IEnumerable<Inventory> GetInventories()
        {
            return Mapper.Map(_db.Inventory);
        }

        public Inventory GetInventoryById(int id)
        {
            return Mapper.Map(_db.Inventory.First(x => x.Id == id));
        }

        public void AddInventory(Inventory inventory)
        {
            _db.Add(Mapper.Map(inventory));
        }

        public void DeleteInventory(int inventoryId)
        {
            _db.Remove(_db.Inventory.Find(inventoryId));
        }

        public void UpdateInventory(Inventory inventory)
        {
            _db.Entry(_db.Inventory.Find(inventory.Id)).CurrentValues.SetValues(Mapper.Map(inventory));
        }

        // Save
        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
