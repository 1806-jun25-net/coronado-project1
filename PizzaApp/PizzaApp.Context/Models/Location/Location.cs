using System;
using System.Collections.Generic;

namespace PizzaApp.Context
{
    public partial class Location
    {
        public Location()
        {
            Inventory = new HashSet<Inventory>();
            UserDefaultLocationNavigation = new HashSet<User>();
            UserLatestLocationNavigation = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? InventoryId { get; set; }

        public Inventory InventoryNavigation { get; set; }
        public ICollection<Inventory> Inventory { get; set; }
        public ICollection<User> UserDefaultLocationNavigation { get; set; }
        public ICollection<User> UserLatestLocationNavigation { get; set; }
    }
}
