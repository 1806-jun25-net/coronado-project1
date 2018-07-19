using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApp.Library
{
    public class Cheese : IIngredient
    {
        // fields and properties
        public string IngredientType { get; set; } = "Cheese";
        public string CheeseThickness { get; set; }
        public string IngredientName { get; set; }
        public string IngredientInventoryName { get; set; } = "Cheese";
        public decimal IngredientPrice { get; set; } = 0.00m;
        public double IngredientInventoryCost { get; set; }
        public string CheeseType { get; set; } = "Cheese";

        private List<string> cheeseTypeOptions = new List<string> { "Cheese" };
        public List<string> CheeseTypeOptions { get => cheeseTypeOptions; set => cheeseTypeOptions = value; }

        private List<string> cheeseThicknessOptions = new List<string> { "Light", "Regular", "Extra" };
        public List<string> CheeseThicknessOptions { get => cheeseThicknessOptions; set => cheeseThicknessOptions = value; }
        
        // constructors
        public Cheese()
        {
            var random = new Random();
            int randomChoice = random.Next(CheeseThicknessOptions.Count);
            CheeseThickness = CheeseThicknessOptions[randomChoice];
            CheeseType = CheeseTypeOptions[0];
            IngredientName = $"{CheeseType}({CheeseThickness})";
            IngredientPrice = CalculateIngredientPrice(CheeseType, CheeseThickness);
            IngredientInventoryCost = CalculateIngredientInventoryCost(CheeseThickness);
        }

        public Cheese(string contextCheese)
        {
            ParseContextString(contextCheese);
            IngredientPrice = CalculateIngredientPrice(CheeseType, CheeseThickness);
            IngredientInventoryCost = CalculateIngredientInventoryCost(CheeseThickness);
        }

        public Cheese(string cheeseType, string cheeseThickness)
        {
            CheeseType = cheeseType;
            CheeseThickness = cheeseThickness;
            IngredientName = $"{CheeseType}({CheeseThickness})";
            IngredientPrice = CalculateIngredientPrice(CheeseType, CheeseThickness);
            IngredientInventoryCost = CalculateIngredientInventoryCost(CheeseThickness);
        }

        // methods       
        public void ParseContextString(string contextString)
        {
            IngredientName = contextString;
            if (contextString.Contains("Light")) CheeseThickness = "Light";
            if (contextString.Contains("Regular")) CheeseThickness = "Regular";
            if (contextString.Contains("Extra")) CheeseThickness = "Extra";
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

        public decimal CalculateIngredientPrice()
        {
            return IngredientPrice;
        }
    }
}
