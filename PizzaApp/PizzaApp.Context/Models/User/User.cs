using System;
using System.Collections.Generic;

namespace PizzaApp.Context
{
    public partial class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? DefaultLocation { get; set; }
        public int? LatestLocation { get; set; }
        public int? LatestOrderId { get; set; }

        public Location DefaultLocationNavigation { get; set; }
        public Location LatestLocationNavigation { get; set; }
        public Order LatestOrder { get; set; }
    }
}
