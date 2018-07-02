using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApplication.Library
{
    public class Crust : IIngredient
    {
        // fields
        public string IngredientType { get; set; }
        public string IngredientName { get; set; }
        public decimal IngredientPrice { get; set; }
        public string CrustSize { get; set; }
        public string CrustThickness { get; set; }
        public List<string> CrustSizeOptions = new List<string> { "Personal(8\")", "Small(10\")", "Medium(12\")", "Large(14\")" };
        public List<string> CrustThicknessOptions = new List<string> { "Thin Crust", "Regular Crust", "Thick Crust" };

        // constructor
        public Crust()
        {
            IngredientType = "Crust";
            CrustSize = CrustSizeOptions[3];
            CrustThickness = CrustThicknessOptions[1];
            IngredientName = $"{CrustSize} {CrustThickness}";
            IngredientPrice = CalculateIngredientPrice(CrustSize, CrustThickness);

        }

        public Crust(string crustSize, string crustThickness)
        {
            IngredientType = "Crust";
            CrustSize = crustSize;
            CrustThickness = crustThickness;
            IngredientName = $"{CrustSize} {CrustThickness}";
            IngredientPrice = CalculateIngredientPrice(CrustSize, CrustThickness);

        }

        // methods
        public void SetCrustSize(int i)
        {
            CrustSize = CrustSizeOptions[i];
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
                    ingredientPrice += 2.00m;
                    break;
                case "Small(10\")":
                    ingredientPrice += 4.00m;
                    break;
                case "Medium(12\")":
                    ingredientPrice += 6.00m;
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
    }
}
