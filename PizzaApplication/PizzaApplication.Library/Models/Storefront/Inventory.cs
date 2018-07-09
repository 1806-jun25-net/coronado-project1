using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PizzaApplication.Library
{
    public class Inventory
    {
        // fields and properties
        // using two lists with equal indices instead of a dictionary because dictionary is not serializeable

        public IEnumerable<string> InventoryNameList { get; set; } = new List<string>
        {
            "Dough", "Tomato Sauce", "White Sauce", "Cheese",
            "Pepperoni", "Ham", "Chicken", "Beef",
            "Sausage", "Bacon", "Anchovies", "Red Peppers",
            "Green Peppers", "Pineapple", "Olives", "Mushrooms",
            "Garlic", "Onions", "Tomatoes", "Spinach",
            "Basil", "Ricotta", "Parmesan", "Feta"
        };

        public IEnumerable<double> InitialInventoryCountList { get; set; } = new List<double>
        {
            200, 100, 100, 200,
            50, 50, 50, 50, 50,
            50, 50, 50, 50, 50,
            50, 50, 50, 50, 50,
            50, 50, 50, 50, 50
        };

        public IEnumerable<double> InventoryCountList { get; set; } = new List<double>
        {
            0, 0, 0, 0,
            0, 0, 0, 0,
            0, 0, 0, 0,
            0, 0, 0, 0,
            0, 0, 0, 0,
            0, 0, 0, 0
        };

        // used to check inventory amounts before finalizing orders
        public IEnumerable<double> TempInventoryCountList { get; set; } = new List<double>
        {
            0, 0, 0, 0,
            0, 0, 0, 0,
            0, 0, 0, 0,
            0, 0, 0, 0,
            0, 0, 0, 0,
            0, 0, 0, 0
        };


        // constructors
        public Inventory()
        {
            RefillInventory(); // sets inventory count to initial values
            SetTempInventoryToActual(); // sets temp count list to match actual list
        }

        // methods

        public int MatchNameToInventoryIndex(string name)
        {
            int index = -1;
            var inventoryNameList = (List<string>)InventoryNameList; // downcast to use List Linq functions
            foreach (var item in inventoryNameList)
            {
                if (name == item)
                {
                    index = inventoryNameList.IndexOf(item);
                    break;
                }
            }
            return index;
        }

        public double ReturnInventoryCount(string name)
        {
            var inventoryCountList = (List<double>)InventoryCountList; // downcast to use List Linq functions
            var index = MatchNameToInventoryIndex(name); // use name parameter to find the matching index
            var count = inventoryCountList[index]; // return the count at index
            return count;
        }

        public double ReturnTempInventoryCount(string name)
        {
            var tempInventoryCountList = (List<double>)TempInventoryCountList; // downcast to use List Linq functions
            var index = MatchNameToInventoryIndex(name); // use name parameter to find the matching index
            var count = tempInventoryCountList[index]; // return the count at index
            return count;
        }

        public void DeductInventoryCount(string name, double amount)
        {
            var inventoryCountList = (List<double>)InventoryCountList; // downcast to use List Linq functions
            var index = MatchNameToInventoryIndex(name); // use name parameter to find the matching index
            var count = inventoryCountList[index]; // return the count at index
            count -= amount; // deduct count by amount
            inventoryCountList[index] = count; //update count at index          
        }

        public void DeductTempInventoryCount(string name, double amount)
        {
            var tempInventoryCountList = (List<double>)TempInventoryCountList; // downcast to use List Linq functions
            var index = MatchNameToInventoryIndex(name); // use name parameter to find the matching index
            var count = tempInventoryCountList[index]; // return the count at index
            count -= amount; // deduct count by amount
            tempInventoryCountList[index] = count; //update count at index          
        }

        public bool CheckIfInventoryIsSufficient(string name, double amount)
        {
            var check = false;
            var tempInventoryCountList = (List<double>)TempInventoryCountList; // downcast to use List Linq functions
            var index = MatchNameToInventoryIndex(name); // use name parameter to find the matching index
            var count = tempInventoryCountList[index]; // return the count at index
            if (count >= amount) check = true; // if count is greater or equal to the amount to be deducted then return true

            return check;
        }

        public void CopyInventory(IEnumerable<double> inventory, IEnumerable<double> sourceInventory)
        {
            // sets inventory to source values
            var nameList = (List<string>)InventoryNameList; // need to iterate through name list to find correct index
            var inventoryList = (List<double>)inventory;
            var sourceInventoryList = (List<double>)sourceInventory;
            int index;
            foreach (var item in nameList)
            {
                index = nameList.IndexOf(item);
                inventoryList[index] = sourceInventoryList[index];
            }
        }

        public void SetTempInventoryToActual()
        {
            // sets temp inventory to actual values
            CopyInventory(TempInventoryCountList, InventoryCountList);
        }

        public void SetActualInventoryToTemp()
        {
            // sets actual inventory to temp values
            CopyInventory(InventoryCountList, TempInventoryCountList);
        }

        public void RefillInventory()
        {
            // sets inventory back to initial values
            CopyInventory(InventoryCountList, InitialInventoryCountList);
        }
    }
}
