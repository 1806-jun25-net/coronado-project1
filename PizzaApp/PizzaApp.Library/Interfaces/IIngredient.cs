﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApp.Library
{
    public interface IIngredient
    {
        string IngredientType { get; set; }
        string IngredientName { get; set; }
        string IngredientInventoryName { get; set; }
        decimal IngredientPrice { get; set; }
        double IngredientInventoryCost { get; set; }
                
        void ParseContextString(string contextString);
        decimal CalculateIngredientPrice();
    }
}
