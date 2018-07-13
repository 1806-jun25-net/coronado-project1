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
        public int CustomerId { get; set; }
        public string OrderLocation { get; set; }
        public DateTime OrderTime { get; set; }
        public decimal OrderPrice { get; set; } = 0.00m;
        public int OrderPizzaCount { get; set; } = 0;        
        public List<Pizza> PizzaList = new List<Pizza>();
        public int? PizzaId { get; set; }
        public int? PizzaId2 { get; set; }
        public int? PizzaId3 { get; set; }
        public int? PizzaId4 { get; set; }
        public int? PizzaId5 { get; set; }
        public int? PizzaId6 { get; set; }
        public int? PizzaId7 { get; set; }
        public int? PizzaId8 { get; set; }
        public int? PizzaId9 { get; set; }
        public int? PizzaId10 { get; set; }
        public int? PizzaId11 { get; set; }
        public int? PizzaId12 { get; set; }

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
        public void CleanPizzaList()
        {
            foreach (var item in PizzaList)
            {
                if (item.PizzaName == "")
                {
                    PizzaList.Remove(item); // removes any unlabeled pizzas
                    OrderPizzaCount--;
                }
            }            
        }

        public void BuildPizzaList(List<Pizza> pizzaRepoList)
        {
            PizzaList = new List<Pizza>();
            foreach (var pizza in pizzaRepoList)
            {
                if (pizza.Id == PizzaId) PizzaList.Add(pizza);
                if (pizza.Id == PizzaId2) PizzaList.Add(pizza);
                if (pizza.Id == PizzaId3) PizzaList.Add(pizza);
                if (pizza.Id == PizzaId4) PizzaList.Add(pizza);
                if (pizza.Id == PizzaId5) PizzaList.Add(pizza);
                if (pizza.Id == PizzaId6) PizzaList.Add(pizza);
                if (pizza.Id == PizzaId7) PizzaList.Add(pizza);
                if (pizza.Id == PizzaId8) PizzaList.Add(pizza);
                if (pizza.Id == PizzaId9) PizzaList.Add(pizza);
                if (pizza.Id == PizzaId10) PizzaList.Add(pizza);
                if (pizza.Id == PizzaId11) PizzaList.Add(pizza);
                if (pizza.Id == PizzaId12) PizzaList.Add(pizza);
            }
        }

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
            CleanPizzaList();
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
            if (PizzaId != null) Console.WriteLine(PizzaId);
            if (PizzaId2 != null) Console.WriteLine(PizzaId2);
            if (PizzaId3 != null) Console.WriteLine(PizzaId3);
            if (PizzaId4 != null) Console.WriteLine(PizzaId4);
            if (PizzaId5 != null) Console.WriteLine(PizzaId5);
            if (PizzaId6 != null) Console.WriteLine(PizzaId6);
            if (PizzaId7 != null) Console.WriteLine(PizzaId7);
            if (PizzaId8 != null) Console.WriteLine(PizzaId8);
            if (PizzaId9 != null) Console.WriteLine(PizzaId9);
            if (PizzaId10 != null) Console.WriteLine(PizzaId10);
            if (PizzaId11 != null) Console.WriteLine(PizzaId11);
            if (PizzaId12 != null) Console.WriteLine(PizzaId12);
            Console.WriteLine("---");
        }
    }
}
