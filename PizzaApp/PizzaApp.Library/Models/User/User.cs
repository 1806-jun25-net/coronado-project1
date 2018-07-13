﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApp.Library
{
    public class User
    {
        // fields and properties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DefaultLocation { get; set; } = 0;
        public int LatestLocation { get; set; } = 0;
        public int LatestOrderId { get; set; } = 0;

        // constructors
        public User()
        {

        }

        public User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        // methods
        public void AddOrder(Order order)
        {
            LatestLocation = (int)order.LocationId;
            LatestOrderId = order.Id;
        }
    }
}
