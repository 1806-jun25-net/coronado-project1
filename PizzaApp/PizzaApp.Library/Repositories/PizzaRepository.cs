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
        private readonly PizzaDBContext _db;

        public PizzaRepository(PizzaDBContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        // User
        public IEnumerable<User> GetUsers()
        {
            return Mapper.Map(_db.User);
        }

        public int GetId(User user)
        {
            var searchedId = _db.User.Find(user.FirstName, user.LastName).Id;
            return searchedId;
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

        public int GetId(Pizza pizza)
        {
            var searchedId = _db.Pizza.Find(pizza.Id).Id;
            return searchedId;
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

        public int GetId(Order order)
        {
            var searchedId = _db.Order.Find(order.Id).Id;
            return searchedId;
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

        // Location
        public IEnumerable<Location> GetLocations()
        {
            return Mapper.Map(_db.Location);
        }

        public int GetId(Location location)
        {
            var searchedId = _db.Location.Find(location.Id).Id;
            return searchedId;
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

        public int GetId(Inventory inventory)
        {
            var searchedId = _db.Inventory.Find(inventory.Id).Id;
            return searchedId;
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
