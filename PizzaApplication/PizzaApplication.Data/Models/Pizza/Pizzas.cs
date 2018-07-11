using System;
using System.Collections.Generic;

namespace PizzaApplication.Data
{
    public partial class Pizzas
    {
        public Pizzas()
        {
            PizzaOrders = new HashSet<PizzaOrders>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Crust { get; set; }
        public string Sauce { get; set; }
        public string Cheese { get; set; }
        public string Topping1 { get; set; }
        public string Topping2 { get; set; }
        public string Topping3 { get; set; }
        public string Topping4 { get; set; }
        public string Topping5 { get; set; }
        public string Topping6 { get; set; }

        public ICollection<PizzaOrders> PizzaOrders { get; set; }
    }
}
