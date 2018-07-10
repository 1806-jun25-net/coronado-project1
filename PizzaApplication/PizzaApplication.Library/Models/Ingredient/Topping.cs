﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace PizzaApplication.Library
{
    public class Topping : IIngredient
    {
        // fields and properties
        [XmlAttribute]
        public string IngredientType { get; set; } = "Topping";
        public string ToppingType { get; set; } = "";
        [XmlIgnore]
        public string IngredientName { get; set; } = "";
        [XmlIgnore]
        public string IngredientInventoryName { get; set; }
        [XmlIgnore]
        public decimal IngredientPrice { get; set; } = 0.00m;
        [XmlIgnore]
        public double IngredientInventoryCost { get; set; } = 1.00;        
        [XmlIgnore]
        public List<string> ToppingTypeOptions = new List<string>
        {
            "Pepperoni", "Ham", "Chicken", "Beef",
            "Sausage", "Bacon", "Anchovies", "Red Peppers",
            "Green Peppers", "Pineapple", "Olives", "Mushrooms",
            "Garlic", "Onions", "Tomatoes", "Spinach",
            "Basil", "Ricotta", "Parmesan", "Feta"
        };

        // constructor
        public Topping()
        {            
            ToppingType = ToppingTypeOptions[0];
            IngredientName = $"{ToppingType}";
            IngredientInventoryName = $"{ToppingType}";
            IngredientPrice = CalculateIngredientPrice(ToppingType);
        }

        public Topping(string toppingType)
        {
            ToppingType = toppingType;
            IngredientName = $"{ToppingType}";
            IngredientInventoryName = $"{ToppingType}";
            IngredientPrice = CalculateIngredientPrice(ToppingType);
        }

        // methods
        public decimal CalculateIngredientPrice()
        {
            return IngredientPrice;
        }

        public decimal CalculateIngredientPrice(string toppingType)
        {
            decimal ingredientPrice = 0.00m;
            switch (toppingType)
            {
                case "Pepperoni":
                    ingredientPrice = 0.50m;
                    break;
                case "Ham":
                    ingredientPrice = 0.50m;
                    break;
                case "Chicken":
                    ingredientPrice = 0.50m;
                    break;
                case "Beef":
                    ingredientPrice = 0.50m;
                    break;
                case "Sausage":
                    ingredientPrice = 0.50m;
                    break;
                case "Bacon":
                    ingredientPrice = 0.50m;
                    break;
                case "Anchovies":
                    ingredientPrice = 0.50m;
                    break;
                case "Red Peppers":
                    ingredientPrice = 0.25m;
                    break;
                case "Green Peppers":
                    ingredientPrice = 0.25m;
                    break;
                case "Pineapple":
                    ingredientPrice = 0.25m;
                    break;
                case "Olives":
                    ingredientPrice = 0.25m;
                    break;
                case "Mushrooms":
                    ingredientPrice = 0.25m;
                    break;
                case "Garlic":
                    ingredientPrice = 0.25m;
                    break;
                case "Onions":
                    ingredientPrice = 0.25m;
                    break;
                case "Tomatoes":
                    ingredientPrice = 0.25m;                    
                    break;
                case "Spinach":
                    ingredientPrice = 0.25m;
                    break;
                case "Basil":
                    ingredientPrice = 0.25m;
                    break;
                case "Ricotta":
                    ingredientPrice = 0.50m;
                    break;
                case "Parmesan":
                    ingredientPrice = 0.50m;
                    break;
                case "Feta":
                    ingredientPrice = 0.50m;
                    break;
                default:
                    break;
            }
            return ingredientPrice;
        }
    }
}
