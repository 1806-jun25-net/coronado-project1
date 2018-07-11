using System;
using System.Collections.Generic;

namespace PizzaApplication.Data
{
    public partial class Locations
    {
        public Locations()
        {
            LocationInventory = new HashSet<LocationInventory>();
            UsersDefaultLocationNavigation = new HashSet<Users>();
            UsersLatestLocationNavigation = new HashSet<Users>();
        }

        public string Location { get; set; }
        public int? InventoryId { get; set; }

        public LocationInventory Inventory { get; set; }
        public ICollection<LocationInventory> LocationInventory { get; set; }
        public ICollection<Users> UsersDefaultLocationNavigation { get; set; }
        public ICollection<Users> UsersLatestLocationNavigation { get; set; }
    }
}
