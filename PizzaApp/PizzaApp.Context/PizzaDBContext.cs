using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzaApp.Context
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

        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>(entity =>
            {
                //entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Name).HasMaxLength(128);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                //entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                //entity.Property(e => e.Id).HasColumnName("Id");

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

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.FirstName).HasMaxLength(128);

                entity.Property(e => e.LastName).HasMaxLength(128);
            });
        }
    }
}
