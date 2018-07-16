using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApp.WebApp
{
    [Serializable]
    public class User
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Default Location")]
        public int? DefaultLocation { get; set; }
        [Display(Name = "Latest Location")]
        public int? LatestLocation { get; set; }
        [Display(Name = "Latest Order")]
        public int? LatestOrderId { get; set; }

    }
}
