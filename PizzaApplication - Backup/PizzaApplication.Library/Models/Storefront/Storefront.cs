using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace PizzaApplication.Library
{
    public class Storefront
    {
        // fields and properties
        [XmlAttribute]
        public int Id { get; set; }
        public string StoreLocation { get; set; }

        public Inventory StoreInventory { get; set; } = new Inventory();
        public List<Order> StorefrontOrderHistory { get; set; } = new List<Order>();

        // constructors
        public Storefront()
        {

        }

        public Storefront(string location)
        {
            StoreLocation = location;
        }

        // methods
        public bool CanOrderBeFulfilled(Order order)
        {
            var tempCheck = true;

            // reset temp inventory back to actual amounts before the individual deductions from the pizza builder phase
            StoreInventory.SetTempInventoryToActual();
            foreach (var pizza in order.PizzaList)
            {
                foreach (var ingredient in pizza.PizzaComposition) // deduct ingredient costs from storefront's actual inventory
                {
                    // loop through and deduct from temp inventory
                    if (StoreInventory.CheckIfInventoryIsSufficient(ingredient.IngredientInventoryName, ingredient.IngredientInventoryCost))
                    {
                        StoreInventory.DeductTempInventoryCount(ingredient.IngredientInventoryName, ingredient.IngredientInventoryCost);
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, there is not enough {ingredient.IngredientInventoryName} in the {StoreLocation} storefront's inventory.");
                        tempCheck = false;
                    }
                }
            }
            return tempCheck;
        }

        public void SetInventory(bool tempCheck)
        {
            if (tempCheck) // if temp inventory deductions pass, then deduct from actual inventory
            {
                // set actual inventory to temp inventory values
                StoreInventory.SetActualInventoryToTemp();
            }
            else
            {
                // if temp inventory deductions don't pass, reset temp inventory to actual inventory valuess
                StoreInventory.SetTempInventoryToActual();
            }
        }

        public void ProcessInventory(Order order)
        {
            var check = CanOrderBeFulfilled(order);
            SetInventory(check);
        }

        public void PrintInventory()
        {
            var nameArray = StoreInventory.InventoryNameArray;
            var countArray = StoreInventory.InventoryCountArray;
            int index;

            Console.WriteLine($"\n{StoreLocation} Storefront Inventory: \n---\n");

            foreach (var item in nameArray)
            {
                index = Array.IndexOf(nameArray, item);
                Console.WriteLine($"{item}: {countArray[index]}");
            }
        }

        public void PrintTempInventory()
        {
            var nameArray = StoreInventory.InventoryNameArray;
            var countArray = StoreInventory.TempInventoryCountArray;
            int index;

            Console.WriteLine($"\n{StoreLocation} Storefront Temp Inventory: \n---\n");

            foreach (var item in nameArray)
            {
                index = Array.IndexOf(nameArray, item);
                Console.WriteLine($"{item}: {countArray[index]}");
            }
        }

        public void AddOrder(Order order)
        {
            StorefrontOrderHistory.Add(order);
        }
    }
}
