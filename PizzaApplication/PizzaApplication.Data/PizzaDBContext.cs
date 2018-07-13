using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzaApplication.Data
{
    public partial class PizzaDBContext : DbContext
    {
        public PizzaDBContext()
        {
        }

        public PizzaDBContext(DbContextOptions<PizzaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LocationInventory> LocationInventory { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<PizzaOrders> PizzaOrders { get; set; }
        public virtual DbSet<Pizzas> Pizzas { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Locations>(entity =>
            {
                entity.Property(e => e.Location).HasMaxLength(128);
            });

            modelBuilder.Entity<PizzaOrders>(entity =>
            {
                entity.Property(e => e.Location).HasMaxLength(128);

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<Pizzas>(entity =>
            {
                entity.Property(e => e.Cheese).HasMaxLength(128);

                entity.Property(e => e.Crust).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.Sauce).HasMaxLength(128);

                entity.Property(e => e.Topping1).HasMaxLength(128);

                entity.Property(e => e.Topping2).HasMaxLength(128);

                entity.Property(e => e.Topping3).HasMaxLength(128);

                entity.Property(e => e.Topping4).HasMaxLength(128);

                entity.Property(e => e.Topping5).HasMaxLength(128);

                entity.Property(e => e.Topping6).HasMaxLength(128);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.DefaultLocation).HasMaxLength(128);

                entity.Property(e => e.FirstName).HasMaxLength(128);

                entity.Property(e => e.LastName).HasMaxLength(128);

                entity.Property(e => e.LatestLocation).HasMaxLength(128);
            });
        }
    }
}
