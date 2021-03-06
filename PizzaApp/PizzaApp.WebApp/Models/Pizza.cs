﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApp.WebApp
{
    [Serializable]
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public decimal? Price { get; set; } = 0.00m;
        public string Crust { get; set; } = "";
        public string Sauce { get; set; } = "";
        public string Cheese { get; set; } = "";
        public string Topping1 { get; set; } = "";
        public string Topping2 { get; set; } = "";
        public string Topping3 { get; set; } = "";
        public string Topping4 { get; set; } = "";
        public string Topping5 { get; set; } = "";
        public string Topping6 { get; set; } = "";
    }
}
