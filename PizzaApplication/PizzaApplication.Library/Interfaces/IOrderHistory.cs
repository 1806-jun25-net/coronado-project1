using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApplication.Library
{
    public interface IOrderHistory
    {
        List<Order> OrderList { get; set; }
        void AddOrderToHistory(Order order);
    }
}
