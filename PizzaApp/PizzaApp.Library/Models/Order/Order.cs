using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApp.Library
{
    public class Order
    {
        // fields and properties
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? LocationId { get; set; }
        public DateTime DateTime { get; set; }
        public decimal? Price { get; set; }
        public int? PizzaId1 { get; set; }
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

        public string OrderName { get; set; }
        public string CustomerName { get; set; }
        public string LocationName { get; set; }
        public decimal OrderPriceLimit { get; set; } = 500.00m;
        public int OrderPizzaLimit { get; set; } = 12;
        public double OrderHourLimit { get; set; } = 2.0;
        public List<Pizza> PizzaList { get; set; } = new List<Pizza>();

        // constructors
        public Order()
        {
        }

        public Order(int id)
        {
            Id = id;
        }

        public Order(User user, Location location)
        {
            UserId = user.Id;
            LocationId = location.Id;
            CustomerName = $"{user.FirstName} {user.LastName}";
            LocationName = location.Name;
            DateTime = DateTime.Now;
        }

        // methods
        public void NameOrder()
        {
            OrderName = $"{PizzaList.Count} Pizza(s), ${Price}, to {LocationName}, for {CustomerName}, at {DateTime}";
        }

        public void AddPizza(Pizza pizza)
        {
            PizzaList.Add(pizza);
            Price += pizza.Price;
        }

        public void RemovePizza(Pizza pizza)
        {
            Price -= pizza.Price;
            PizzaList.Remove(pizza);            
        }

        public void UpdateTime()
        {
            DateTime = DateTime.Now;
        }

        public void UpdatePrice()
        {
            // reset price to $0.00 before recalculating
            Price = 0.00m;
            foreach (var pizza in PizzaList)
            {
                Price += pizza.Price;
            }
        }

        public void BuildOrder()
        {
            UpdatePrice();
            UpdateTime();
            NameOrder();
        }

        public int CountPizzas()
        {
            var count = 0;

            if (PizzaId1 != null) count++;
            if (PizzaId2 != null) count++;
            if (PizzaId3 != null) count++;
            if (PizzaId4 != null) count++;
            if (PizzaId5 != null) count++;
            if (PizzaId6 != null) count++;
            if (PizzaId7 != null) count++;
            if (PizzaId8 != null) count++;
            if (PizzaId9 != null) count++;
            if (PizzaId10 != null) count++;
            if (PizzaId11 != null) count++;
            if (PizzaId12 != null) count++;

            return count;
        }

        public void ProcessPizzaList(List<Pizza> pizzaList)
        {
            foreach (var item in pizzaList)
            {
                if (PizzaId1 == null)
                {
                    PizzaId1 = item.Id;
                }
                else if (PizzaId2 == null)
                {
                    PizzaId2 = item.Id;
                }
                else if (PizzaId3 == null)
                {
                    PizzaId3 = item.Id;
                }
                else if (PizzaId4 == null)
                {
                    PizzaId4 = item.Id;
                }
                else if (PizzaId5 == null)
                {
                    PizzaId5 = item.Id;
                }
                else if (PizzaId6 == null)
                {
                    PizzaId6 = item.Id;
                }
                else if (PizzaId7 == null)
                {
                    PizzaId7 = item.Id;
                }
                else if (PizzaId8 == null)
                {
                    PizzaId8 = item.Id;
                }
                else if (PizzaId9 == null)
                {
                    PizzaId9 = item.Id;
                }
                else if (PizzaId10 == null)
                {
                    PizzaId10 = item.Id;
                }
                else if (PizzaId11 == null)
                {
                    PizzaId11 = item.Id;
                }
                else if (PizzaId12 == null)
                {
                    PizzaId12 = item.Id;
                }
            }
        }

        public void BuildPizzaList(List<Pizza> pizzas)
        {
            PizzaList = new List<Pizza>();
            foreach (var pizza in pizzas)
            {
                if (pizza.Id == PizzaId1) PizzaList.Add(pizza);
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

        public bool CheckIfOrderWithinPriceLimit()
        {
            bool check = true;

            UpdatePrice(); // add up total order cost
            if (Price > OrderPriceLimit)
            {
                check = false;
                var difference = Price - OrderPriceLimit;
                Console.WriteLine($"Your pizza exceeds the ${OrderPriceLimit} order limit by ${difference}.");
            }

            return check;
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
            Console.WriteLine("---");
        }
    }
}
