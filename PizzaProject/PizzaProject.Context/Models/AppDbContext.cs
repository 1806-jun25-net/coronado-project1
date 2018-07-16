using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaProject.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        { }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        public DbSet<Order> Order { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Pizza> Pizza { get; set; }
        public DbSet<User> User { get; set; }
    }
}