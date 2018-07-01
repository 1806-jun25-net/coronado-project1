using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApplication.Library
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DefaultLocation { get; set; }
        public Order CustomerOrder = new Order();
    }
}
