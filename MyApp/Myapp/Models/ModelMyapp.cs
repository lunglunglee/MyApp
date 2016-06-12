namespace Myapp.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelMyapp : DbContext
    {
        public ModelMyapp()
            : base("name=ModelMyapp")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Data_Area> Data_Area { get; set; }
        public virtual DbSet<Data_City> Data_City { get; set; }
        public virtual DbSet<Data_Province> Data_Province { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeTerritory> EmployeeTerritories { get; set; }
        public virtual DbSet<Main_Employees> Main_Employees { get; set; }
        public virtual DbSet<Order_Detail> Order_Details { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.產品名稱)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Data_City>()
                .HasMany(e => e.Data_Area)
                .WithRequired(e => e.Data_City)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Data_Province>()
                .HasMany(e => e.Data_City)
                .WithRequired(e => e.Data_Province)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Main_Employees>()
                .HasOptional(e => e.EmployeeTerritory)
                .WithRequired(e => e.Main_Employees);

            modelBuilder.Entity<Main_Employees>()
                .HasMany(e => e.Main_Employees1)
                .WithOptional(e => e.Main_Employees2)
                .HasForeignKey(e => e.ReportsTo);

            modelBuilder.Entity<Order_Detail>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Order_Detail>()
                .HasMany(e => e.EmployeeTerritories)
                .WithRequired(e => e.Order_Details)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Order_Details)
                .WithRequired(e => e.Order)
                .HasForeignKey(e => e.訂購代理)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Order_Details)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.訂購貨品)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.產品名稱)
                .IsFixedLength();

            modelBuilder.Entity<Supplier>()
                .Property(e => e.採購項目)
                .IsFixedLength();

            modelBuilder.Entity<Supplier>()
                .Property(e => e.價錢)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.數量)
                .IsFixedLength();

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Supplier)
                .HasForeignKey(e => e.供應商)
                .WillCascadeOnDelete(false);
        }
    }
}
