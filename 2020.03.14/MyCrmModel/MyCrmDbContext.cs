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
            modelBuilder.Entity<Staff>().ToTable("staffs (sales)");
            modelBuilder.Entity<Order>().ToTable("orders (sales)");
            modelBuilder.Entity<OrderItem>().ToTable("order_items (sales)");
            modelBuilder.Entity<Customer>().ToTable("customers (sales)");
            modelBuilder.Entity<Store>().ToTable("stores (sales)");
            modelBuilder.Entity<Stock>().ToTable("stocks (production)");
            modelBuilder.Entity<Product>().ToTable("products (production)");
            modelBuilder.Entity<Category>().ToTable("categories (production)");
            modelBuilder.Entity<Brand>().ToTable("brands (production)");

            modelBuilder.Entity<Staff>().Property(staff => staff.Id).HasColumnName("staff_id");
            modelBuilder.Entity<Staff>().Property(staff => staff.FirstName).HasColumnName("first_name");
            modelBuilder.Entity<Staff>().Property(staff => staff.LastName).HasColumnName("last_name");
            modelBuilder.Entity<Staff>().Property(staff => staff.Email).HasColumnName("email");
            modelBuilder.Entity<Staff>().Property(staff => staff.Phone).HasColumnName("phone");
            modelBuilder.Entity<Staff>().Property(staff => staff.Active).HasColumnName("active");
            modelBuilder.Entity<Staff>().Property(staff => staff.StoreId).HasColumnName("store_id");
            modelBuilder.Entity<Staff>().Property(staff => staff.ManagerId).HasColumnName("manager_id");

            modelBuilder.Entity<Order>().Property(order => order.Id).HasColumnName("order_id");
            modelBuilder.Entity<Order>().Property(order => order.CustomerId).HasColumnName("customer_id");
            modelBuilder.Entity<Order>().Property(order => order.OrderStatus).HasColumnName("order_status");
            modelBuilder.Entity<Order>().Property(order => order.OrderDate).HasColumnName("order_date");
            modelBuilder.Entity<Order>().Property(order => order.RequiredDate).HasColumnName("required_date");
            modelBuilder.Entity<Order>().Property(order => order.ShippedDate).HasColumnName("shipped_date");
            modelBuilder.Entity<Order>().Property(order => order.StoreId).HasColumnName("store_id");
            modelBuilder.Entity<Order>().Property(order => order.StaffId).HasColumnName("staff_id");

            modelBuilder.Entity<OrderItem>().Property(orderItem => orderItem.OrderId).HasColumnName("order_id");
            modelBuilder.Entity<OrderItem>().Property(orderItem => orderItem.ItemId).HasColumnName("item_id");
            modelBuilder.Entity<OrderItem>().Property(orderItem => orderItem.ProductId).HasColumnName("product_id");
            modelBuilder.Entity<OrderItem>().Property(orderItem => orderItem.Quantity).HasColumnName("quantity");
            modelBuilder.Entity<OrderItem>().Property(orderItem => orderItem.ListPrice).HasColumnName("list_price");
            modelBuilder.Entity<OrderItem>().Property(orderItem => orderItem.Discount).HasColumnName("discount");

            modelBuilder.Entity<Store>().Property(store => store.Id).HasColumnName("store_id");
            modelBuilder.Entity<Store>().Property(store => store.Name).HasColumnName("store_name");
            modelBuilder.Entity<Store>().Property(store => store.Phone).HasColumnName("phone");
            modelBuilder.Entity<Store>().Property(store => store.Email).HasColumnName("email");
            modelBuilder.Entity<Store>().Property(store => store.Street).HasColumnName("street");
            modelBuilder.Entity<Store>().Property(store => store.City).HasColumnName("city");
            modelBuilder.Entity<Store>().Property(store => store.State).HasColumnName("state");
            modelBuilder.Entity<Store>().Property(store => store.ZipCode).HasColumnName("zip_code");

            modelBuilder.Entity<Customer>().Property(customer => customer.Id).HasColumnName("customer_id");
            modelBuilder.Entity<Customer>().Property(customer => customer.FirstName).HasColumnName("first_name");
            modelBuilder.Entity<Customer>().Property(customer => customer.LastName).HasColumnName("last_name");
            modelBuilder.Entity<Customer>().Property(customer => customer.Phone).HasColumnName("phone");
            modelBuilder.Entity<Customer>().Property(customer => customer.Email).HasColumnName("email");
            modelBuilder.Entity<Customer>().Property(customer => customer.Street).HasColumnName("street");
            modelBuilder.Entity<Customer>().Property(customer => customer.City).HasColumnName("city");
            modelBuilder.Entity<Customer>().Property(customer => customer.State).HasColumnName("state");
            modelBuilder.Entity<Customer>().Property(customer => customer.ZipCode).HasColumnName("zip_code");

            modelBuilder.Entity<Stock>().Property(stock => stock.StoreId).HasColumnName("store_id");
            modelBuilder.Entity<Stock>().Property(stock => stock.ProductId).HasColumnName("product_id");
            modelBuilder.Entity<Stock>().Property(stock => stock.Quantity).HasColumnName("quantity");

            modelBuilder.Entity<Product>().Property(product => product.Id).HasColumnName("product_id");
            modelBuilder.Entity<Product>().Property(product => product.Name).HasColumnName("product_name");
            modelBuilder.Entity<Product>().Property(product => product.BrandId).HasColumnName("brand_id");
            modelBuilder.Entity<Product>().Property(product => product.CategoryId).HasColumnName("category_id");
            modelBuilder.Entity<Product>().Property(product => product.ModelYear).HasColumnName("model_year");
            modelBuilder.Entity<Product>().Property(product => product.ListPrice).HasColumnName("list_price");

            modelBuilder.Entity<Category>().Property(category => category.Id).HasColumnName("category_id");
            modelBuilder.Entity<Category>().Property(category => category.Name).HasColumnName("category_name");

            modelBuilder.Entity<Brand>().Property(brand => brand.Id).HasColumnName("brand_id");
            modelBuilder.Entity<Brand>().Property(brand => brand.Name).HasColumnName("brand_name");

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

            modelBuilder.Entity<Order>()
                .HasOne(order => order.Store)
                .WithMany(store => store.Orders)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
