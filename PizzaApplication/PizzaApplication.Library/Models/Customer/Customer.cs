using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApplication.Library
{
    public class Customer
    {
        // field

        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Location { get; set; } = "";
        public string DefaultLocation { get; set; } = "Reston";
        public Order CustomerOrder = new Order();

        // methods
        public Customer()
        {

        }

        public Customer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

    }
}
