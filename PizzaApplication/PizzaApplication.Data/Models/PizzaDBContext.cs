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
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LocationInventory>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Location).HasMaxLength(128);

                entity.HasOne(d => d.LocationNavigation)
                    .WithMany(p => p.LocationInventory)
                    .HasForeignKey(d => d.Location)
                    .HasConstraintName("FK_InventoryLocations");
            });

            modelBuilder.Entity<Locations>(entity =>
            {
                entity.HasKey(e => e.Location);

                entity.HasIndex(e => e.Location)
                    .HasName("UQ__Location__E55D3B10C7C5D9D4")
                    .IsUnique();

                entity.Property(e => e.Location)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.InventoryId).HasColumnName("InventoryID");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.InventoryId)
                    .HasConstraintName("FK_LocationsInventory");
            });

            modelBuilder.Entity<PizzaOrders>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Location).HasMaxLength(128);

                entity.Property(e => e.PizzaId).HasColumnName("PizzaID");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.PizzaOrders)
                    .HasForeignKey(d => d.PizzaId)
                    .HasConstraintName("FK_OrdersPizza");
            });

            modelBuilder.Entity<Pizzas>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

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
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DefaultLocation).HasMaxLength(128);

                entity.Property(e => e.FirstName).HasMaxLength(128);

                entity.Property(e => e.LastName).HasMaxLength(128);

                entity.Property(e => e.LatestLocation).HasMaxLength(128);

                entity.Property(e => e.LatestOrderId).HasColumnName("LatestOrderID");

                entity.HasOne(d => d.DefaultLocationNavigation)
                    .WithMany(p => p.UsersDefaultLocationNavigation)
                    .HasForeignKey(d => d.DefaultLocation)
                    .HasConstraintName("FK_UsersLocations");

                entity.HasOne(d => d.LatestLocationNavigation)
                    .WithMany(p => p.UsersLatestLocationNavigation)
                    .HasForeignKey(d => d.LatestLocation)
                    .HasConstraintName("FK_UsersLatestLocation");
            });
        }
    }
}
