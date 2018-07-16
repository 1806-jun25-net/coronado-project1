using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApp.WebApp
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Inventory Id")]
        public int? InventoryId { get; set; }
    }
}
