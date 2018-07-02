using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApplication.Library
{
    public class Sauce : IIngredient
    {
        // fields
        public string IngredientType { get; set; }
        public string IngredientName { get; set; }
        public decimal IngredientPrice { get; set; }
        public string SauceType { get; set; }
        public string SauceThickness { get; set; }
        public List<string> SauceTypeOptions = new List<string> { "Tomato Sauce", "White Sauce" };
        public List<string> SauceThicknessOptions = new List<string> { "Light", "Regular", "Extra" };

        // constructor
        public Sauce()
        {
            IngredientType = "Sauce";
            SauceType = SauceTypeOptions[0];
            SauceThickness = SauceThicknessOptions[1];
            IngredientName = $"{SauceType} {SauceThickness}";
            IngredientPrice = CalculateIngredientPrice(SauceType, SauceThickness);

        }

        public Sauce(string sauceType, string sauceThickness)
        {
            IngredientType = "Sauce";
            SauceType = sauceType;
            SauceThickness = sauceThickness;
            IngredientName = $"{SauceType} {SauceThickness}";
            IngredientPrice = CalculateIngredientPrice(SauceType, SauceThickness);

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
    }
}
