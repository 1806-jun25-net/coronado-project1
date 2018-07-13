using System;
using System.Collections.Generic;

namespace PizzaApplication.Data
{
    public partial class Locations
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public int InventoryId { get; set; }
    }
}
