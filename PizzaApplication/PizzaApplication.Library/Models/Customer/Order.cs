using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApplication.Library
{
    public class Order
    {
        public string OrderName { get; set; }
        public string OrderLocation { get; set; }
        public DateTime OrderTime { get; set; }
        public decimal OrderPrice { get; set; }
        public IEnumerable<Pizza> PizzaList { get; set; }



    }
}
