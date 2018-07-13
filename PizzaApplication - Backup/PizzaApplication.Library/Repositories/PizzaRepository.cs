using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PizzaApplication.Data;
using System.Linq;

namespace PizzaApplication.Library
{
    public class PizzaRepository
    {
        private readonly PizzaDBContext _db;

        public PizzaRepository(PizzaDBContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        //User
        public IEnumerable<Library.Customer> GetUsers()
        {
            return Mapper.Map(_db.Users);
        }

        public void AddUser(Library.Customer user)
        {
            _db.Add(Mapper.Map(user));
        }

        public void DeleteUser(int userId)
        {
            _db.Remove(_db.Users.Find(userId));
        }

        public void UpdateUser(Library.Customer user)
        {
            _db.Entry(_db.Users.Find(user.Id)).CurrentValues.SetValues(Mapper.Map(user));
        }

        //Pizzas
        public IEnumerable<Library.Pizza> GetPizzas()
        {
            return Mapper.Map(_db.Pizzas);
        }

        public void AddPizza(Library.Pizza pizza)
        {
            _db.Add(Mapper.Map(pizza));
        }

        public void DeletePizza(int pizzaId)
        {
            _db.Remove(_db.Pizzas.Find(pizzaId));
        }

        public void UpdatePizza(Library.Pizza pizza)
        {
            _db.Entry(_db.Pizzas.Find(pizza.Id)).CurrentValues.SetValues(Mapper.Map(pizza));
        }

        //PizzaOrders
        public IEnumerable<Library.Order> GetOrders()
        {
            return Mapper.Map(_db.PizzaOrders);
        }

        public void AddOrder(Library.Order order)
        {
            _db.Add(Mapper.Map(order));
        }

        public void DeleteOrder(int orderId)
        {
            _db.Remove(_db.PizzaOrders.Find(orderId));
        }

        public void UpdateOrder(Library.Order order)
        {
            _db.Entry(_db.PizzaOrders.Find(order.Id)).CurrentValues.SetValues(Mapper.Map(order));
        }

        //Locations
        public IEnumerable<Library.Storefront> GetLocations()
        {
            return Mapper.Map(_db.Locations);
        }

        public void AddLocation(Library.Storefront location)
        {
            _db.Add(Mapper.Map(location));
        }

        public void DeleteLocation(string locationName)
        {
            _db.Remove(_db.Locations.Find(locationName));
        }

        public void UpdateLocation(Library.Storefront location)
        {
            _db.Entry(_db.Locations.Find(location.StoreLocation)).CurrentValues.SetValues(Mapper.Map(location));
        }

        // LocationInventory
        public IEnumerable<Library.Inventory> GetInventories()
        {
            return Mapper.Map(_db.LocationInventory);
        }

        public void AddInventory(Library.Inventory inventory)
        {
            _db.Add(Mapper.Map(inventory));
        }

        public void DeleteInventory(int inventoryId)
        {
            _db.Remove(_db.LocationInventory.Find(inventoryId));
        }

        public void UpdateInventory(Library.Inventory inventory)
        {
            _db.Entry(_db.LocationInventory.Find(inventory.StoreLocation)).CurrentValues.SetValues(Mapper.Map(inventory));
        }

        //Save
        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
