using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApplication.Library
{
    public class CustomerOrderHistory : IOrderHistory
    {
        public List<Order> OrderList { get; set; } = new List<Order>();
        public Customer OrderCustomer;

        public void AddOrderToHistory(Order order)
        {            
            OrderList.Add(order);
        }
    }
}
