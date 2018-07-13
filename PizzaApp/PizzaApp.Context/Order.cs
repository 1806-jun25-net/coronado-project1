using System;
using System.Collections.Generic;

namespace PizzaApp.Context
{
    public partial class Order
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? LocationId { get; set; }
        public DateTime? DateTime { get; set; }
        public decimal? Price { get; set; }
        public int? PizzaId1 { get; set; }
        public int? PizzaId2 { get; set; }
        public int? PizzaId3 { get; set; }
        public int? PizzaId4 { get; set; }
        public int? PizzaId5 { get; set; }
        public int? PizzaId6 { get; set; }
        public int? PizzaId7 { get; set; }
        public int? PizzaId8 { get; set; }
        public int? PizzaId9 { get; set; }
        public int? PizzaId10 { get; set; }
        public int? PizzaId11 { get; set; }
        public int? PizzaId12 { get; set; }
    }
}
