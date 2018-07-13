using System;
using System.Collections.Generic;

namespace PizzaApp.Context
{
    public partial class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? InventoryId { get; set; }
    }
}
