using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Lib.Orders.Entities
{
    public partial class OrdersDbContext : DbContext
    {
        public OrdersDbContext()
        {
        }

        public OrdersDbContext(DbContextOptions<OrdersDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=northwind;Username=postgres;Password=mssql1Ipw");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.Property(e => e.OrderId)
                    .ValueGeneratedNever()
                    .HasColumnName("order_id");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("char")
                    .HasColumnName("customer_id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.Freight).HasColumnName("freight");

                entity.Property(e => e.OrderDate).HasColumnName("order_date");

                entity.Property(e => e.RequiredDate).HasColumnName("required_date");

                entity.Property(e => e.ShipAddress)
                    .HasMaxLength(60)
                    .HasColumnName("ship_address");

                entity.Property(e => e.ShipCity)
                    .HasMaxLength(15)
                    .HasColumnName("ship_city");

                entity.Property(e => e.ShipCountry)
                    .HasMaxLength(15)
                    .HasColumnName("ship_country");

                entity.Property(e => e.ShipName)
                    .HasMaxLength(40)
                    .HasColumnName("ship_name");

                entity.Property(e => e.ShipPostalCode)
                    .HasMaxLength(10)
                    .HasColumnName("ship_postal_code");

                entity.Property(e => e.ShipRegion)
                    .HasMaxLength(15)
                    .HasColumnName("ship_region");

                entity.Property(e => e.ShipVia).HasColumnName("ship_via");

                entity.Property(e => e.ShippedDate).HasColumnName("shipped_date");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId })
                    .HasName("order_details_pkey");

                entity.ToTable("order_details");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.UnitPrice).HasColumnName("unit_price");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("order_details_order_id_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
