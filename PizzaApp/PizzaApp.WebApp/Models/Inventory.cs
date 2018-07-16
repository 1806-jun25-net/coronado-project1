using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApp.WebApp
{
    [Serializable]
    public class Inventory
    {
        public int Id { get; set; }
        [Display(Name = "Location Id")]
        public int? LocationId { get; set; }
        public double Dough { get; set; }
        [Display(Name = "Tomato Sauce")]
        public double TomatoSauce { get; set; }
        [Display(Name = "White Sauce")]
        public double WhiteSauce { get; set; }
        public double Cheese { get; set; }
        public double Pepperoni { get; set; }
        public double Ham { get; set; }
        public double Chicken { get; set; }
        public double Beef { get; set; }
        public double Sausage { get; set; }
        public double Bacon { get; set; }
        public double Anchovies { get; set; }
        [Display(Name = "Red Peppers")]
        public double RedPeppers { get; set; }
        [Display(Name = "Green Peppers")]
        public double GreenPeppers { get; set; }
        public double Pineapple { get; set; }
        public double Olives { get; set; }
        public double Mushrooms { get; set; }
        public double Garlic { get; set; }
        public double Onions { get; set; }
        public double Tomatoes { get; set; }
        public double Spinach { get; set; }
        public double Basil { get; set; }
        public double Ricotta { get; set; }
        public double Parmesan { get; set; }
        public double Feta { get; set; }
    }
}
