using System;
using System.Collections.Generic;

namespace PizzaApplication.Data
{
    public partial class Users
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DefaultLocation { get; set; }
        public string LatestLocation { get; set; }
        public int? LatestOrderId { get; set; }
    }
}
