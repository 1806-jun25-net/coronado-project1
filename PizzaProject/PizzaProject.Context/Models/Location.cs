//using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaProject.Context
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int InventoryId { get; set; }

    }
}
