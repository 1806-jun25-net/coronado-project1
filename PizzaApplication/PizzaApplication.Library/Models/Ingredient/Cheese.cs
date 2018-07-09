using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApplication.Library
{
    public class Cheese : IIngredient
    {
        // fields and properties
        public string IngredientType { get; set; }
        public string IngredientName { get; set; }
        public string IngredientInventoryName { get; set; } = "Cheese";
        public decimal IngredientPrice { get; set; } = 0.00m;
        public double IngredientInventoryCost { get; set; } = 1.00;
        public string CheeseType { get; set; } = "Cheese";
        public string CheeseThickness { get; set; } = "";
        public List<string> CheeseTypeOptions = new List<string> { "Cheese" };
        public List<string> CheeseThicknessOptions = new List<string> { "Light", "Regular", "Extra" };

        // constructor
        public Cheese()
        {
            IngredientType = "Cheese";
            CheeseType = CheeseTypeOptions[0];
            CheeseThickness = CheeseThicknessOptions[0];
            IngredientName = $"{CheeseType}({CheeseThickness})";
            IngredientPrice = CalculateIngredientPrice(CheeseType, CheeseThickness);
            IngredientInventoryCost = CalculateIngredientInventoryCost(CheeseThickness);
        }

        public Cheese(string cheeseThickness)
        {
            IngredientType = "Cheese";
            CheeseType = CheeseTypeOptions[0];
            CheeseThickness = cheeseThickness;
            IngredientName = $"{CheeseType}({CheeseThickness})";
            IngredientPrice = CalculateIngredientPrice(CheeseType, CheeseThickness);
            IngredientInventoryCost = CalculateIngredientInventoryCost(CheeseThickness);
        }

        public Cheese(string cheeseType, string cheeseThickness)
        {
            IngredientType = "Cheese";
            CheeseType = cheeseType;
            CheeseThickness = cheeseThickness;
            IngredientName = $"{CheeseType}({CheeseThickness})";
            IngredientPrice = CalculateIngredientPrice(CheeseType, CheeseThickness);
            IngredientInventoryCost = CalculateIngredientInventoryCost(CheeseThickness);
        }

        // methods
        public decimal CalculateIngredientPrice()
        {
            return IngredientPrice;
        }

        public decimal CalculateIngredientPrice(string cheeseType, string cheeseThickness)
        {
            decimal ingredientPrice = 0.00m;
            switch (cheeseType)
            {
                case "Cheese":
                    ingredientPrice += 1.00m;
                    break;
                default:
                    break;
            }
            switch (cheeseThickness)
            {
                case "Light":
                    ingredientPrice += 0.00m;
                    break;
                case "Regular":
                    ingredientPrice += 0.00m;
                    break;
                case "Extra":
                    ingredientPrice += 0.50m;
                    break;
                default:
                    break;
            }
            return ingredientPrice;
        }

        public double CalculateIngredientInventoryCost(string cheeseThickness)
        {
            double inventoryCost = 1.00; // base inventory cost

            switch (cheeseThickness)
            {
                case "Light":
                    inventoryCost -= 0.50; // light uses less, so reduce inventory cost
                    break;
                case "Regular":
                    inventoryCost += 0.00; // base amount, no change
                    break;
                case "Extra":
                    inventoryCost += 0.50; // extra uses more, so increase inventory cost
                    break;
                default:
                    break;
            }
            return inventoryCost;
        }
    }
}
