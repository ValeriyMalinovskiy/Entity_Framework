using Microsoft.EntityFrameworkCore;
using MyCrmModel.Production;
using MyCrmModel.Sales;

namespace MyCrmModel
{
    internal class MyCrmDbContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; }

        public DbSet<Category> Categories { get; set; }
        
        public DbSet<Product> Products { get; set; }
        
        public DbSet<Stock> Stocks { get; set; }
        
        public DbSet<Customer> Customers { get; set; }
        
        public DbSet<Order> Orders { get; set; }
        
        public DbSet<OrderItem> OrderItems { get; set; }
        
        public DbSet<Staff> Staffs { get; set; }
        
        public DbSet<Store> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-J0F1AGE;Database=MyCrmDb;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stock>().HasKey(stock => new { stock.StoreId, stock.ProductId });
            modelBuilder.Entity<OrderItem>().HasKey(orderItem => new { orderItem.OrderId, orderItem.ItemId });
            modelBuilder.Entity<OrderItem>()
                .HasOne<Order>(orderItem => orderItem.Order)
                .WithMany(order => order.OrderItems)
                .HasForeignKey(orderItem => orderItem.OrderId);
            modelBuilder.Entity<OrderItem>()
                .HasOne<Product>(orderItem => orderItem.Product)
                .WithMany(product => product.OrderItems)
                .HasForeignKey(orderItem => orderItem.ProductId);
        }
    }
}
