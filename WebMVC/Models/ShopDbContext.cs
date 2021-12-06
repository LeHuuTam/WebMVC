using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebMVC.Models
{
    public partial class ShopDbContext : DbContext
    {
        public ShopDbContext()
            : base("name=ShopDbContext")
        {
        }

        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductInOrder> ProductInOrders { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<ShipDetail> ShipDetails { get; set; }
        public virtual DbSet<ShipMethod> ShipMethods { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Category1)
                .WithOptional(e => e.Category2)
                .HasForeignKey(e => e.ParentId);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Category1)
                .HasForeignKey(e => e.Category);

            modelBuilder.Entity<Image>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.ProductInOrders)
                .WithOptional(e => e.Order1)
                .HasForeignKey(e => e.Order);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Transactions)
                .WithOptional(e => e.Order1)
                .HasForeignKey(e => e.Order);

            modelBuilder.Entity<Product>()
                .Property(e => e.Avatar)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Carts)
                .WithOptional(e => e.Product1)
                .HasForeignKey(e => e.Product);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Images)
                .WithOptional(e => e.Product1)
                .HasForeignKey(e => e.Product);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductInOrders)
                .WithOptional(e => e.Product1)
                .HasForeignKey(e => e.Product);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.Role1)
                .HasForeignKey(e => e.Role);

            modelBuilder.Entity<ShipDetail>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<ShipDetail>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.ShipDetail1)
                .HasForeignKey(e => e.ShipDetail);

            modelBuilder.Entity<ShipMethod>()
                .HasMany(e => e.ShipDetails)
                .WithOptional(e => e.ShipMethod1)
                .HasForeignKey(e => e.ShipMethod);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Avatar)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Carts)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.User);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.User);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Transactions)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.User);
        }
    }
}
