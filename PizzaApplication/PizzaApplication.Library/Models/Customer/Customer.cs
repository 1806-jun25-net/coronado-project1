using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace PizzaApplication.Library
{
    public class Customer
    {
        // fields and properties
        [XmlAttribute]
        public int ID { get; set; }
        [XmlAttribute]        
        public string FirstName { get; set; } = "";
        [XmlAttribute]
        public string LastName { get; set; } = "";

        public Order LatestOrder = new Order();
        public List<Order> OrderHistory = new List<Order>();      
        public string LatestLocation { get; set; }
        public string DefaultLocation { get; set; }        

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
            LatestLocation = order.OrderLocation;
            LatestOrder = order;
            OrderHistory.Add(order);
        }
    }
}
