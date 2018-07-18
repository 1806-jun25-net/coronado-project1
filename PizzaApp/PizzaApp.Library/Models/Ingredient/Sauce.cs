using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApp.Library
{
    public class Sauce : IIngredient
    {
        // fields and properties
        public string IngredientType { get; set; } = "Sauce";
        public string SauceType { get; set; }
        public string SauceThickness { get; set; }
        public string IngredientName { get; set; }
        public string IngredientInventoryName { get; set; }
        public decimal IngredientPrice { get; set; } = 0.00m;
        public double IngredientInventoryCost { get; set; } = 1.00;
        public List<string> SauceTypeOptions = new List<string> { "Tomato Sauce", "White Sauce" };
        public List<string> SauceThicknessOptions = new List<string> { "Light", "Regular", "Extra" };

        // constructors
        public Sauce()
        {
            var random = new Random();
            int randomChoice = random.Next(SauceTypeOptions.Count);
            SauceType = SauceTypeOptions[randomChoice];
            randomChoice = random.Next(SauceThicknessOptions.Count);
            SauceThickness = SauceThicknessOptions[randomChoice];
            IngredientName = $"{SauceType}({SauceThickness})";
            IngredientInventoryName = SauceType;
            IngredientPrice = CalculateIngredientPrice(SauceType, SauceThickness);
            IngredientInventoryCost = CalculateIngredientInventoryCost(SauceThickness);
        }

        public Sauce(string contextSauce)
        {
            ParseContextString(contextSauce);
            IngredientInventoryName = SauceType;
            IngredientPrice = CalculateIngredientPrice(SauceType, SauceThickness);
            IngredientInventoryCost = CalculateIngredientInventoryCost(SauceThickness);
        }

        public Sauce(string sauceType, string sauceThickness)
        {
            SauceType = sauceType;
            SauceThickness = sauceThickness;
            IngredientName = $"{SauceType}({SauceThickness})";
            IngredientInventoryName = SauceType;
            IngredientPrice = CalculateIngredientPrice(SauceType, SauceThickness);
            IngredientInventoryCost = CalculateIngredientInventoryCost(SauceThickness);
        }

        // methods
        public void ParseContextString(string contextString)
        {
            IngredientName = contextString;
            if (contextString.Contains("Tomato")) SauceType = "Tomato Sauce";
            if (contextString.Contains("White")) SauceType = "White Sauce";
            if (contextString.Contains("Light")) SauceThickness = "Light";
            if (contextString.Contains("Regular")) SauceThickness = "Regular";
            if (contextString.Contains("Extra")) SauceThickness = "Extra";
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

        public decimal CalculateIngredientPrice()
        {
            return IngredientPrice;
        }
    }
}
