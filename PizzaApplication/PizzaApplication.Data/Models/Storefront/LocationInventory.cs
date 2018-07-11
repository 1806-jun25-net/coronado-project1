using System;
using System.Collections.Generic;

namespace PizzaApplication.Data
{
    public partial class LocationInventory
    {
        public LocationInventory()
        {
            Locations = new HashSet<Locations>();
        }

        public int Id { get; set; }
        public string Location { get; set; }
        public double? Dough { get; set; }
        public double? TomatoSauce { get; set; }
        public double? WhiteSauce { get; set; }
        public double? Cheese { get; set; }
        public double? Pepperoni { get; set; }
        public double? Ham { get; set; }
        public double? Chicken { get; set; }
        public double? Beef { get; set; }
        public double? Sausage { get; set; }
        public double? Bacon { get; set; }
        public double? Anchovies { get; set; }
        public double? RedPeppers { get; set; }
        public double? GreenPeppers { get; set; }
        public double? Pineapple { get; set; }
        public double? Olives { get; set; }
        public double? Mushrooms { get; set; }
        public double? Garlic { get; set; }
        public double? Onions { get; set; }
        public double? Tomatoes { get; set; }
        public double? Spinach { get; set; }
        public double? Basil { get; set; }
        public double? Ricotta { get; set; }
        public double? Parmesan { get; set; }
        public double? Feta { get; set; }

        public Locations LocationNavigation { get; set; }
        public ICollection<Locations> Locations { get; set; }
    }
}
