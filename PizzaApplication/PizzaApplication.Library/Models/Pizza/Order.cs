using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace PizzaApplication.Library
{
    public class Order
    {
        // fields and properties
        [XmlAttribute]
        public int Id { get; set; }
        [XmlAttribute]
        public string OrderName { get; set; }
        public string CustomerName { get; set; }        
        public string OrderLocation { get; set; }
        public DateTime OrderTime { get; set; }
        public decimal OrderPrice { get; set; } = 0.00m;
        public int OrderPizzaCount { get; set; } = 0;        
        public List<Pizza> PizzaList = new List<Pizza>();

        [XmlIgnore]
        public decimal OrderPriceLimit { get; set; } = 150.00m; //made limit $150 because the $500 limit in the project requirements was too high for my pricing model
        [XmlIgnore]
        public int OrderPizzaLimit { get; set; } = 12;        

        // constructors
        public Order()
        {            
        }

        public Order(int id)
        {
            Id = id;
        }

        public Order(Customer customer, Storefront storefront)
        {
            CustomerName = $"{customer.FirstName} {customer.LastName}";
            OrderLocation = storefront.StoreLocation;
            OrderTime = DateTime.Now;
            NameOrder();
        }

        // methods
        public void NameOrder()
        {            
            OrderName = $"{OrderPizzaCount} Pizza(s), ${OrderPrice}, to {OrderLocation}, for {CustomerName}, at {OrderTime}";
        }

        public void AddPizza(Pizza pizza)
        {            
            PizzaList.Add(pizza);
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
