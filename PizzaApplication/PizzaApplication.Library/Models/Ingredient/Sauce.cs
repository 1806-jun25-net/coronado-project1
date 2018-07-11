using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace PizzaApplication.Library
{
    public class Sauce : IIngredient
    {
        // fields and properties
        [XmlAttribute]
        public string IngredientType { get; set; } = "Sauce";
        public string SauceType { get; set; } = "";
        public string SauceThickness { get; set; } = "";
        [XmlIgnore]
        public string IngredientName { get; set; } = "";
        [XmlIgnore]
        public string IngredientInventoryName { get; set; }
        [XmlIgnore]
        public decimal IngredientPrice { get; set; } = 0.00m;
        [XmlIgnore]
        public double IngredientInventoryCost { get; set; } = 1.00;        
        [XmlIgnore]
        public List<string> SauceTypeOptions = new List<string> { "Tomato Sauce", "White Sauce" };
        [XmlIgnore]
        public List<string> SauceThicknessOptions = new List<string> { "Light", "Regular", "Extra" };

        // constructor
        public Sauce()
        {
            SauceType = SauceTypeOptions[0];
            SauceThickness = SauceThicknessOptions[0];
            IngredientName = $"{SauceType}({SauceThickness})";
            IngredientInventoryName = SauceType;
            IngredientPrice = CalculateIngredientPrice(SauceType, SauceThickness);
            IngredientInventoryCost = CalculateIngredientInventoryCost(SauceThickness);
        }

        public Sauce(string ingredientName)
        {
            ParseIngredientName(ingredientName);
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
        public void ParseIngredientName(string ingredientName)
        {
            IngredientName = ingredientName;
            if (ingredientName.Contains("Tomato")) SauceType = "Tomato Sauce";
            if (ingredientName.Contains("White")) SauceType = "White Sauce";
            if (ingredientName.Contains("Light")) SauceThickness = "Light";
            if (ingredientName.Contains("Regular")) SauceThickness = "Regular";
            if (ingredientName.Contains("Extra")) SauceThickness = "Extra";
        }

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
