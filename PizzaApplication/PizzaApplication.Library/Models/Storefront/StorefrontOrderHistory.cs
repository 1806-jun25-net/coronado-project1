using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApplication.Library
{
    public class StorefrontOrderHistory : IOrderHistory
    {
        public List<Order> OrderList { get; set; } = new List<Order>();
        public Storefront OrderStorefront { get; set; }
        
        public void AddOrderToHistory(Order order)
        {
            OrderList.Add(order);
        }
    }
}
