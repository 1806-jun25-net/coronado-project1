using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApplication.Library
{
    public class Sauce : IIngredient
    {
        // fields and properties
        public string IngredientType { get; set; }
        public string IngredientName { get; set; }
        public string IngredientInventoryName { get; set; }
        public decimal IngredientPrice { get; set; } = 0.00m;
        public double IngredientInventoryCost { get; set; } = 1.00;
        public string SauceType { get; set; } = "";
        public string SauceThickness { get; set; } = "";
        public List<string> SauceTypeOptions = new List<string> { "Tomato Sauce", "White Sauce" };
        public List<string> SauceThicknessOptions = new List<string> { "Light", "Regular", "Extra" };

        // constructor
        public Sauce()
        {
            IngredientType = "Sauce";
            SauceType = SauceTypeOptions[0];
            SauceThickness = SauceThicknessOptions[0];
            IngredientName = $"{SauceType}({SauceThickness})";
            IngredientInventoryName = SauceType;
            IngredientPrice = CalculateIngredientPrice(SauceType, SauceThickness);
            IngredientInventoryCost = CalculateIngredientInventoryCost(SauceThickness);
        }

        public Sauce(string sauceType, string sauceThickness)
        {
            IngredientType = "Sauce";
            SauceType = sauceType;
            SauceThickness = sauceThickness;
            IngredientName = $"{SauceType}({SauceThickness})";
            IngredientInventoryName = SauceType;
            IngredientPrice = CalculateIngredientPrice(SauceType, SauceThickness);
            IngredientInventoryCost = CalculateIngredientInventoryCost(SauceThickness);
        }

        // methods
        public decimal CalculateIngredientPrice()
        {
            return IngredientPrice;
        }

        public decimal CalculateIngredientPrice(string sauceType, string sauceThickness)
        {
            decimal ingredientPrice = 0.00m;
            switch (sauceType)
            {
                case "Tomato Sauce":
                    ingredientPrice += 1.00m;
                    break;
                case "White Sauce":
                    ingredientPrice += 1.00m;
                    break;
                default:
                    break;
            }
            switch (sauceThickness)
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

        public double CalculateIngredientInventoryCost(string sauceThickness)
        {
            double inventoryCost = 1.00; // base inventory cost

            switch (sauceThickness)
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
