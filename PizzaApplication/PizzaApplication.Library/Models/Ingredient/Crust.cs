using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace PizzaApplication.Library
{
    public class Crust : IIngredient
    {
        // fields and properties
        [XmlAttribute]
        public string IngredientType { get; set; } = "Crust";
        public string CrustSize { get; set; } = "";
        public string CrustThickness { get; set; } = "";
        [XmlIgnore]
        public string IngredientName { get; set; } = "";
        [XmlIgnore]
        public string IngredientInventoryName { get; set; } = "Dough";
        [XmlIgnore]
        public decimal IngredientPrice { get; set; } = 0.00m;
        [XmlIgnore]
        public double IngredientInventoryCost { get; set; } = 1.00;        
        [XmlIgnore]
        public List<string> CrustSizeOptions = new List<string> { "Personal(8\")", "Small(10\")", "Medium(12\")", "Large(14\")" };
        [XmlIgnore]
        public List<string> CrustThicknessOptions = new List<string> { "Thin Crust", "Standard Crust", "Thick Crust" };

        // constructor
        public Crust()
        {
            CrustSize = CrustSizeOptions[0];
            CrustThickness = CrustThicknessOptions[0];
            IngredientName = $"{CrustSize} {CrustThickness}";
            IngredientPrice = CalculateIngredientPrice(CrustSize, CrustThickness);
            IngredientInventoryCost = CalculateIngredientInventoryCost(CrustSize, CrustThickness);
        }

        public Crust(string crustSize, string crustThickness)
        {
            CrustSize = crustSize;
            CrustThickness = crustThickness;
            IngredientName = $"{CrustSize} {CrustThickness}";
            IngredientPrice = CalculateIngredientPrice(CrustSize, CrustThickness);
            IngredientInventoryCost = CalculateIngredientInventoryCost(CrustSize, CrustThickness);
        }

        // methods
        public void SetCrustSize(string option)
        {
            CrustSize = option;
        }

        public void SetCrustThickness(string option)
        {
            CrustThickness = option;
        }

        public decimal CalculateIngredientPrice()
        {
            return IngredientPrice;
        }

        public decimal CalculateIngredientPrice(string crustSize, string crustThickness)
        {
            decimal ingredientPrice = 0.00m;
            switch (crustSize)
            {
                case "Personal(8\")":
                    ingredientPrice += 3.50m;
                    break;
                case "Small(10\")":
                    ingredientPrice += 5.50m;
                    break;
                case "Medium(12\")":
                    ingredientPrice += 7.00m;
                    break;
                case "Large(14\")":
                    ingredientPrice += 8.00m;
                    break;
                default:
                    break;
            }
            switch (crustThickness)
            {
                case "Thin Crust":
                    ingredientPrice += 0.00m;
                    break;
                case "Regular Crust":
                    ingredientPrice += 0.00m;
                    break;
                case "Thick Crust":
                    ingredientPrice += 1.00m;
                    break;
                default:
                    break;
            }
            return ingredientPrice;
        }

        public double CalculateIngredientInventoryCost(string crustSize, string crustThickness)
        {
            double inventoryCost = 1.00;
            switch (crustSize)
            {
                case "Personal(8\")":
                    inventoryCost -= 0.25;
                    break;
                case "Small(10\")":
                    inventoryCost += 0.00;
                    break;
                case "Medium(12\")":
                    inventoryCost += 0.00;
                    break;
                case "Large(14\")":
                    inventoryCost += 0.25;
                    break;
                default:
                    break;
            }
            switch (crustThickness)
            {
                case "Thin Crust":
                    inventoryCost -= 0.25;
                    break;
                case "Regular Crust":
                    inventoryCost += 0.00;
                    break;
                case "Thick Crust":
                    inventoryCost += 0.25;
                    break;
                default:
                    break;
            }
            return inventoryCost;
        }
    }
}
