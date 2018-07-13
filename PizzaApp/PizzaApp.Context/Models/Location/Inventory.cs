using System;
using System.Collections.Generic;

namespace PizzaApp.Context
{
    public partial class Inventory
    {
        public Inventory()
        {
            LocationNavigation = new HashSet<Location>();
        }

        public int Id { get; set; }
        public int? LocationId { get; set; }
        public double Dough { get; set; }
        public double TomatoSauce { get; set; }
        public double WhiteSauce { get; set; }
        public double Cheese { get; set; }
        public double Pepperoni { get; set; }
        public double Ham { get; set; }
        public double Chicken { get; set; }
        public double Beef { get; set; }
        public double Sausage { get; set; }
        public double Bacon { get; set; }
        public double Anchovies { get; set; }
        public double RedPeppers { get; set; }
        public double GreenPeppers { get; set; }
        public double Pineapple { get; set; }
        public double Olives { get; set; }
        public double Mushrooms { get; set; }
        public double Garlic { get; set; }
        public double Onions { get; set; }
        public double Tomatoes { get; set; }
        public double Spinach { get; set; }
        public double Basil { get; set; }
        public double Ricotta { get; set; }
        public double Parmesan { get; set; }
        public double Feta { get; set; }

        public Location Location { get; set; }
        public ICollection<Location> LocationNavigation { get; set; }
    }
}
