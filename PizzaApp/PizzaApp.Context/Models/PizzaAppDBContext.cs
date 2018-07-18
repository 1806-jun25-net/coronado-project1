using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzaApp.Context
{
    public partial class PizzaAppDBContext : DbContext
    {
        public PizzaAppDBContext()
        {
        }

        public PizzaAppDBContext(DbContextOptions<PizzaAppDBContext> options)
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
            // put connection string in secrets.json
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_InventoryLocation");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.InventoryNavigation)
                    .WithMany(p => p.LocationNavigation)
                    .HasForeignKey(d => d.InventoryId)
                    .HasConstraintName("FK_LocationInventory");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.PizzaId1Navigation)
                    .WithMany(p => p.OrderPizzaId1Navigation)
                    .HasForeignKey(d => d.PizzaId1)
                    .HasConstraintName("FK_OrderPizza1");

                entity.HasOne(d => d.PizzaId10Navigation)
                    .WithMany(p => p.OrderPizzaId10Navigation)
                    .HasForeignKey(d => d.PizzaId10)
                    .HasConstraintName("FK_OrderPizza10");

                entity.HasOne(d => d.PizzaId11Navigation)
                    .WithMany(p => p.OrderPizzaId11Navigation)
                    .HasForeignKey(d => d.PizzaId11)
                    .HasConstraintName("FK_OrderPizza11");

                entity.HasOne(d => d.PizzaId12Navigation)
                    .WithMany(p => p.OrderPizzaId12Navigation)
                    .HasForeignKey(d => d.PizzaId12)
                    .HasConstraintName("FK_OrderPizza12");

                entity.HasOne(d => d.PizzaId2Navigation)
                    .WithMany(p => p.OrderPizzaId2Navigation)
                    .HasForeignKey(d => d.PizzaId2)
                    .HasConstraintName("FK_OrderPizza2");

                entity.HasOne(d => d.PizzaId3Navigation)
                    .WithMany(p => p.OrderPizzaId3Navigation)
                    .HasForeignKey(d => d.PizzaId3)
                    .HasConstraintName("FK_OrderPizza3");

                entity.HasOne(d => d.PizzaId4Navigation)
                    .WithMany(p => p.OrderPizzaId4Navigation)
                    .HasForeignKey(d => d.PizzaId4)
                    .HasConstraintName("FK_OrderPizza4");

                entity.HasOne(d => d.PizzaId5Navigation)
                    .WithMany(p => p.OrderPizzaId5Navigation)
                    .HasForeignKey(d => d.PizzaId5)
                    .HasConstraintName("FK_OrderPizza5");

                entity.HasOne(d => d.PizzaId6Navigation)
                    .WithMany(p => p.OrderPizzaId6Navigation)
                    .HasForeignKey(d => d.PizzaId6)
                    .HasConstraintName("FK_OrderPizza6");

                entity.HasOne(d => d.PizzaId7Navigation)
                    .WithMany(p => p.OrderPizzaId7Navigation)
                    .HasForeignKey(d => d.PizzaId7)
                    .HasConstraintName("FK_OrderPizza7");

                entity.HasOne(d => d.PizzaId8Navigation)
                    .WithMany(p => p.OrderPizzaId8Navigation)
                    .HasForeignKey(d => d.PizzaId8)
                    .HasConstraintName("FK_OrderPizza8");

                entity.HasOne(d => d.PizzaId9Navigation)
                    .WithMany(p => p.OrderPizzaId9Navigation)
                    .HasForeignKey(d => d.PizzaId9)
                    .HasConstraintName("FK_OrderPizza9");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.HasKey(e => e.Id);
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
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName).HasMaxLength(128);

                entity.Property(e => e.LastName).HasMaxLength(128);

                entity.HasOne(d => d.DefaultLocationNavigation)
                    .WithMany(p => p.UserDefaultLocationNavigation)
                    .HasForeignKey(d => d.DefaultLocation)
                    .HasConstraintName("FK_UserDefaultLocation");

                entity.HasOne(d => d.LatestLocationNavigation)
                    .WithMany(p => p.UserLatestLocationNavigation)
                    .HasForeignKey(d => d.LatestLocation)
                    .HasConstraintName("FK_UserLatestLocation");

                entity.HasOne(d => d.LatestOrder)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.LatestOrderId)
                    .HasConstraintName("FK_UserLatestOrder");
            });
        }
    }
}
