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
        [Range(0.00,200.00)]
        public double Dough { get; set; }
        [Range(0.00, 100.00)]
        [Display(Name = "Tomato Sauce")]
        public double TomatoSauce { get; set; }
        [Range(0.00, 100.00)]
        [Display(Name = "White Sauce")]        
        public double WhiteSauce { get; set; }
        [Range(0.00, 200.00)]
        public double Cheese { get; set; }
        [Range(0.00, 50.00)]
        public double Pepperoni { get; set; }
        [Range(0.00, 50.00)]
        public double Ham { get; set; }
        [Range(0.00, 50.00)]
        public double Chicken { get; set; }
        [Range(0.00, 50.00)]
        public double Beef { get; set; }
        [Range(0.00, 50.00)]
        public double Sausage { get; set; }
        [Range(0.00, 50.00)]
        public double Bacon { get; set; }
        [Range(0.00, 50.00)]
        public double Anchovies { get; set; }
        [Range(0.00, 50.00)]
        [Display(Name = "Red Peppers")]
        public double RedPeppers { get; set; }
        [Range(0.00, 50.00)]
        [Display(Name = "Green Peppers")]
        public double GreenPeppers { get; set; }
        [Range(0.00, 50.00)]
        public double Pineapple { get; set; }
        [Range(0.00, 50.00)]
        public double Olives { get; set; }
        [Range(0.00, 50.00)]
        public double Mushrooms { get; set; }
        [Range(0.00, 50.00)]
        public double Garlic { get; set; }
        [Range(0.00, 50.00)]
        public double Onions { get; set; }
        [Range(0.00, 50.00)]
        public double Tomatoes { get; set; }
        [Range(0.00, 50.00)]
        public double Spinach { get; set; }
        [Range(0.00, 50.00)]
        public double Basil { get; set; }
        [Range(0.00, 50.00)]
        public double Ricotta { get; set; }
        [Range(0.00, 50.00)]
        public double Parmesan { get; set; }
        [Range(0.00, 50.00)]
        public double Feta { get; set; }
    }
}
