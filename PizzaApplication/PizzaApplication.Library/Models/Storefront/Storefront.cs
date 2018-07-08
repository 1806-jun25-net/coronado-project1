using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApplication.Library
{
    public class Storefront
    {
        // fields and properties
        public string StoreLocation { get; set; }
        public Inventory StoreInventory { get; set; } = new Inventory();
        public StorefrontOrderHistory StoreOrderHistory { get; set; }

        // constructors
        public Storefront(string location)
        {
            StoreLocation = location;
        }

        // methods
        public bool CheckIfInventoryIsSufficient(Order order)
        {
            var check = false;



            return check;
        }
    }
}
