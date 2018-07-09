using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApplication.Library
{
    public class Customer
    {
        // fields and properties
        public int ID { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public Storefront Location { get; set; }
        public Storefront DefaultLocation { get; set; }
        public Order CustomerOrder = new Order();
        public CustomerOrderHistory OrderHistory = new CustomerOrderHistory();

        // methods
        public Customer()
        {

        }

        public Customer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public void AddOrder(Order order)
        {
            CustomerOrder = order;
            OrderHistory.AddOrderToHistory(order);
        }
    }
}
