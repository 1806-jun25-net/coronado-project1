//using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaProject.Context
{
    public class Order
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int LocationId { get; set; }

    }
}
