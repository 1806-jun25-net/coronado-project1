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
        // using arrays with equal indices instead of a dictionary because dictionary is not serializeable      

        public string[] InventoryNameArray { get; set; } = new string[]
        {
            "Dough", "Tomato Sauce", "White Sauce", "Cheese",
            "Pepperoni", "Ham", "Chicken", "Beef",
            "Sausage", "Bacon", "Anchovies", "Red Peppers",
            "Green Peppers", "Pineapple", "Olives", "Mushrooms",
            "Garlic", "Onions", "Tomatoes", "Spinach",
            "Basil", "Ricotta", "Parmesan", "Feta"
        };
        
        public double[] InventoryCountArray { get; set; } = new double[]
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
        public double[] TempInventoryCountArray { get; set; } = new double[]
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
        public double[] InitialInventoryCountArray { get; set; } = new double[]
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
            foreach (var item in InventoryNameArray)
            {
                if (name == item)
                {
                    index = Array.IndexOf(InventoryNameArray, item);
                    break;
                }
            }
            return index;
        }

        public double ReturnInventoryCount(string name)
        {
            var index = MatchNameToInventoryIndex(name); // use name parameter to find the matching index
            var count = InventoryCountArray[index]; // return the count at index
            return count;
        }

        public double ReturnTempInventoryCount(string name)
        {
            var index = MatchNameToInventoryIndex(name); // use name parameter to find the matching index
            var count = TempInventoryCountArray[index]; // return the count at index
            return count;
        }

        public void DeductInventoryCount(string name, double amount)
        {
            var index = MatchNameToInventoryIndex(name); // use name parameter to find the matching index
            var count = InventoryCountArray[index]; // return the count at index
            count -= amount; // deduct count by amount
            InventoryCountArray[index] = count; //update count at index          
        }

        public void DeductTempInventoryCount(string name, double amount)
        {
            var index = MatchNameToInventoryIndex(name); // use name parameter to find the matching index
            var count = TempInventoryCountArray[index]; // return the count at index
            count -= amount; // deduct count by amount
            TempInventoryCountArray[index] = count; //update count at index          
        }

        public bool CheckIfInventoryIsSufficient(string name, double amount)
        {
            var check = false;
            var index = MatchNameToInventoryIndex(name); // use name parameter to find the matching index
            var count = TempInventoryCountArray[index]; // return the count at index
            if (count >= amount) check = true; // if count is greater or equal to the amount to be deducted then return true

            return check;
        }

        public void CopyInventory(double[] inventory, double[] sourceInventory)
        {
            // sets inventory to source values
            int index;
            foreach (var item in InventoryNameArray) // need to iterate through name list to find correct index
            {
                index = Array.IndexOf(InventoryNameArray, item);
                inventory[index] = sourceInventory[index];
            }
        }

        public void SetTempInventoryToActual()
        {
            // sets temp inventory to actual values
            CopyInventory(TempInventoryCountArray, InventoryCountArray);
        }

        public void SetActualInventoryToTemp()
        {
            // sets actual inventory to temp values
            CopyInventory(InventoryCountArray, TempInventoryCountArray);
        }

        public void RefillInventory()
        {

            // sets inventory back to initial values
            CopyInventory(InventoryCountArray, InitialInventoryCountArray);

        }
    }
}
