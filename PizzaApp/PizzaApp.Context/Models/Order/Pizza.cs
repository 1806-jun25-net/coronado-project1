using System;
using System.Collections.Generic;

namespace PizzaApp.Context
{
    public partial class Pizza
    {
        public Pizza()
        {
            OrderPizzaId10Navigation = new HashSet<Order>();
            OrderPizzaId11Navigation = new HashSet<Order>();
            OrderPizzaId12Navigation = new HashSet<Order>();
            OrderPizzaId1Navigation = new HashSet<Order>();
            OrderPizzaId2Navigation = new HashSet<Order>();
            OrderPizzaId3Navigation = new HashSet<Order>();
            OrderPizzaId4Navigation = new HashSet<Order>();
            OrderPizzaId5Navigation = new HashSet<Order>();
            OrderPizzaId6Navigation = new HashSet<Order>();
            OrderPizzaId7Navigation = new HashSet<Order>();
            OrderPizzaId8Navigation = new HashSet<Order>();
            OrderPizzaId9Navigation = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = "";
        public decimal? Price { get; set; } = 0.00m;
        public string Crust { get; set; } = "";
        public string Sauce { get; set; } = "";
        public string Cheese { get; set; } = "";
        public string Topping1 { get; set; } = "";
        public string Topping2 { get; set; } = "";
        public string Topping3 { get; set; } = "";
        public string Topping4 { get; set; } = "";
        public string Topping5 { get; set; } = "";
        public string Topping6 { get; set; } = "";

        public ICollection<Order> OrderPizzaId10Navigation { get; set; }
        public ICollection<Order> OrderPizzaId11Navigation { get; set; }
        public ICollection<Order> OrderPizzaId12Navigation { get; set; }
        public ICollection<Order> OrderPizzaId1Navigation { get; set; }
        public ICollection<Order> OrderPizzaId2Navigation { get; set; }
        public ICollection<Order> OrderPizzaId3Navigation { get; set; }
        public ICollection<Order> OrderPizzaId4Navigation { get; set; }
        public ICollection<Order> OrderPizzaId5Navigation { get; set; }
        public ICollection<Order> OrderPizzaId6Navigation { get; set; }
        public ICollection<Order> OrderPizzaId7Navigation { get; set; }
        public ICollection<Order> OrderPizzaId8Navigation { get; set; }
        public ICollection<Order> OrderPizzaId9Navigation { get; set; }
    }
}
