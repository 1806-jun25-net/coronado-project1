using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApplication.Library
{
    public class Storefront
    {
        // fields and properties
        public string StoreLocation { get; set; }
        public Inventory StoreInventory { get; set; }
        public StorefrontOrderHistory StoreOrderHistory { get; set; }

        // methods
        public bool CheckIfOrderCanBeFulfilled(Order order)
        {
            var check = false;



            return check;
        }
    }
}
