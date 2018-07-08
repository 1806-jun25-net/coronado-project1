using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApplication.Library
{
    public class Order
    {
        // fields and properties
        public Customer OrderCustomer { get; set; }
        public string OrderName { get; set; }
        public Storefront OrderLocation { get; set; }
        public DateTime OrderTime { get; set; }
        public decimal OrderPrice { get; set; } = 0.00m;
        public decimal OrderPriceLimit { get; set; } = 150.00m; //made limit $150 because the $500 limit in the project requirements was too high for my pricing model
        public int OrderPizzaCount { get; set; } = 0;
        public int OrderPizzaLimit { get; set; } = 12;
        public IEnumerable<Pizza> PizzaList = new List<Pizza>();

        // constructors
        public Order()
        {            
        }

        public Order(Customer customer, Storefront storefront)
        {
            OrderCustomer = customer;
            OrderLocation = storefront;
            OrderTime = DateTime.Now;
            NameOrder();
        }

        // methods
        public void NameOrder()
        {            
            OrderName = $"{OrderPizzaCount} Pizza(s), ${OrderPrice}, to {OrderLocation.StoreLocation}, for {OrderCustomer.FirstName} {OrderCustomer.LastName}, at {OrderTime}";
        }

        public void AddPizza(Pizza pizza)
        {
            var pizzaList = (List<Pizza>)PizzaList;
            pizzaList.Add(pizza);
            OrderPrice += pizza.PizzaPrice;
            OrderPizzaCount++;
        }

        public void UpdateTime()
        {
            OrderTime = DateTime.Now;
        }

        public void UpdatePrice()
        {
            // reset price to $0.00 before recalculating
            OrderPrice = 0.00m;
            foreach (var pizza in PizzaList)
            {
                OrderPrice += pizza.PizzaPrice;
            }
        }

        public void BuildOrder()
        {
            UpdatePrice();
            UpdateTime();
            NameOrder();
        }

        public void PrintOrder()
        {
            Console.WriteLine($"\nOrder:" +
                $"\n{OrderName}" +
                $"\n---" +
                $"\nPizza List:" +
                $"\n---");
            foreach (var pizza in PizzaList)
            {
                pizza.PrintPizza();
            }
        }
    }
}
