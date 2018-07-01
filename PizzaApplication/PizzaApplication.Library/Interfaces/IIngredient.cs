using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApplication.Library
{
    public interface IIngredient
    {
        string IngredientType { get; set; }
        string IngredientName { get; set; }
        decimal IngredientPrice { get; set; }

        decimal CalculateIngredientPrice();
    }
}
