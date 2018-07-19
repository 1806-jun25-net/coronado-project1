using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApp.Library
{
    public class Crust : IIngredient
    {
        // fields and properties
        public string IngredientType { get; set; } = "Crust";
        public string CrustSize { get; set; }
        public string CrustThickness { get; set; }
        public string IngredientName { get; set; }
        public string IngredientInventoryName { get; set; } = "Dough";
        public decimal IngredientPrice { get; set; } = 0.00m;
        public double IngredientInventoryCost { get; set; }
        private List<string> crustSizeOptions = new List<string> { "Personal(8\")", "Small(10\")", "Medium(12\")", "Large(14\")" };
        public List<string> CrustSizeOptions { get => crustSizeOptions; set => crustSizeOptions = value; }
        private List<string> crustThicknessOptions = new List<string> { "Thin Crust", "Standard Crust", "Thick Crust" };
        public List<string> CrustThicknessOptions { get => crustThicknessOptions; set => crustThicknessOptions = value; }        

        // constructors
        public Crust()
        {
            var random = new Random();
            int randomChoice = random.Next(CrustSizeOptions.Count);
            CrustSize = CrustSizeOptions[randomChoice];
            randomChoice = random.Next(CrustThicknessOptions.Count);
            CrustThickness = CrustThicknessOptions[randomChoice];
            IngredientName = $"{CrustSize} {CrustThickness}";
            IngredientPrice = CalculateIngredientPrice(CrustSize, CrustThickness);
            IngredientInventoryCost = CalculateIngredientInventoryCost(CrustSize, CrustThickness);
        }

        public Crust(string contextCrust)
        {
            ParseContextString(contextCrust);
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
        public void ParseContextString(string contextString)
        {
            IngredientName = contextString;
            if (contextString.Contains("Personal")) CrustSize = "Personal(8\")";
            if (contextString.Contains("Small")) CrustSize = "Small(10\")";
            if (contextString.Contains("Medium")) CrustSize = "Medium(12\")";
            if (contextString.Contains("Large")) CrustSize = "Large(14\")";
            if (contextString.Contains("Thin")) CrustThickness = "Thin Crust";
            if (contextString.Contains("Standard")) CrustThickness = "Standard Crust";
            if (contextString.Contains("Thick")) CrustThickness = "Thick Crust";
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
               
        public decimal CalculateIngredientPrice()
        {
            return IngredientPrice;
        }
    }
}
