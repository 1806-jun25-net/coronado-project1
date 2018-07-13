using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApp.Library
{
    public class Location
    {
        // fields and properties
        public int Id { get; set; }
        public string Name { get; set; }
        public int? InventoryId { get; set; }
        public Inventory Inventory { get; set; }

        // constructors
        public Location()
        {

        }

        public Location(int id)
        {
            Id = id;
        }

        public Location(string locationName)
        {
            Name = locationName;
        }

        // methods
        public void SetInventoryFromList(List<Inventory> inventories)
        {
            foreach (var item in inventories)
            {
                if (InventoryId == item.Id) Inventory = item;
            }
        }

        public bool ProcessOrderInInventory(Order order)
        {
            var check = true;

            foreach (var pizza in order.PizzaList)
            {
                foreach (var ingredient in pizza.PizzaComposition) // deduct ingredient costs from location's inventory
                {
                    // loop through and deduct from temp inventory
                    if (Inventory.CheckIfInventoryIsSufficient(ingredient))
                    {
                        Inventory.DeductInventoryCount(ingredient);
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, there is not enough {ingredient.IngredientInventoryName} in the {Name} storefront's inventory.");
                        check = false;
                    }
                    if (check == false) break;
                }
                if (check == false) break;
            }

            return check;
        }       
    }
}
