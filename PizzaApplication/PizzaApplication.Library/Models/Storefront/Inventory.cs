using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Serialization;

namespace PizzaApplication.Library
{
    public class Inventory
    {
        // fields and properties
        // using two lists with equal indices instead of a dictionary because dictionary is not serializeable
        public List<string> InventoryNameList { get; set; } = new List<string>
        {
            "Dough", "Tomato Sauce", "White Sauce", "Cheese",
            "Pepperoni", "Ham", "Chicken", "Beef",
            "Sausage", "Bacon", "Anchovies", "Red Peppers",
            "Green Peppers", "Pineapple", "Olives", "Mushrooms",
            "Garlic", "Onions", "Tomatoes", "Spinach",
            "Basil", "Ricotta", "Parmesan", "Feta"
        };
        public List<double> InventoryCountList { get; set; } = new List<double>
        {
            0, 0, 0, 0,
            0, 0, 0, 0,
            0, 0, 0, 0,
            0, 0, 0, 0,
            0, 0, 0, 0,
            0, 0, 0, 0
        };
        // used to check inventory amounts before finalizing orders
        [XmlIgnore]
        public List<double> TempInventoryCountList { get; set; } = new List<double>
        {
            0, 0, 0, 0,
            0, 0, 0, 0,
            0, 0, 0, 0,
            0, 0, 0, 0,
            0, 0, 0, 0,
            0, 0, 0, 0
        };
        // used to reset inventory amounts
        [XmlIgnore]
        public List<double> InitialInventoryCountList { get; set; } = new List<double>
        {
            200, 100, 100, 200,
            50, 50, 50, 50, 50,
            50, 50, 50, 50, 50,
            50, 50, 50, 50, 50,
            50, 50, 50, 50, 50
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
            foreach (var item in InventoryNameList)
            {
                if (name == item)
                {
                    index = InventoryNameList.IndexOf(item);
                    break;
                }
            }
            return index;
        }

        public double ReturnInventoryCount(string name)
        {
            var index = MatchNameToInventoryIndex(name); // use name parameter to find the matching index
            var count = InventoryCountList[index]; // return the count at index
            return count;
        }

        public double ReturnTempInventoryCount(string name)
        {
            var index = MatchNameToInventoryIndex(name); // use name parameter to find the matching index
            var count = TempInventoryCountList[index]; // return the count at index
            return count;
        }

        public void DeductInventoryCount(string name, double amount)
        {
            var index = MatchNameToInventoryIndex(name); // use name parameter to find the matching index
            var count = InventoryCountList[index]; // return the count at index
            count -= amount; // deduct count by amount
            InventoryCountList[index] = count; //update count at index          
        }

        public void DeductTempInventoryCount(string name, double amount)
        {
            var index = MatchNameToInventoryIndex(name); // use name parameter to find the matching index
            var count = TempInventoryCountList[index]; // return the count at index
            count -= amount; // deduct count by amount
            TempInventoryCountList[index] = count; //update count at index          
        }

        public bool CheckIfInventoryIsSufficient(string name, double amount)
        {
            var check = false;
            var index = MatchNameToInventoryIndex(name); // use name parameter to find the matching index
            var count = TempInventoryCountList[index]; // return the count at index
            if (count >= amount) check = true; // if count is greater or equal to the amount to be deducted then return true

            return check;
        }

        public void CopyInventory(List<double> inventory, List<double> sourceInventory)
        {
            // sets inventory to source values
            int index;
            foreach (var item in InventoryNameList) // need to iterate through name list to find correct index
            {
                index = InventoryNameList.IndexOf(item);
                inventory[index] = sourceInventory[index];
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
