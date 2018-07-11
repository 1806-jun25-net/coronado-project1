using System;
using System.Collections.Generic;

namespace PizzaApplication.Data
{
    public partial class PizzaOrders
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public string Location { get; set; }
        public DateTime? DateTime { get; set; }
        public decimal? Price { get; set; }
        public int? PizzaId { get; set; }

        public Pizzas Pizza { get; set; }
    }
}
