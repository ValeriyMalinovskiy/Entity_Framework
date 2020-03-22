using Microsoft.EntityFrameworkCore;
using MyCrmModel.Production;
using MyCrmModel.Sales;
using System;

namespace MyCrmModel
{
    public class MyCrmDbContext : DbContext
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
            optionsBuilder.UseLazyLoadingProxies().
            UseSqlServer("Server=DESKTOP-J0F1AGE;Database=MyCrmDatabase;Trusted_Connection=True");
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

            Category category1 = new Category
            {
                Id = 1,
                Name = "Food",
            };
            Category category2 = new Category
            {
                Id = 2,
                Name = "Beverage",
            };
            Brand brand1 = new Brand
            {
                Id = 1,
                Name = "Bounty",
            };
            Brand brand2 = new Brand
            {
                Id = 2,
                Name = "Pepsi",
            };
            Order order1 = new Order
            {
                Id = 1,
                OrderDate = DateTime.UtcNow.AddDays(-3),
                CustomerId = 1,
                OrderStatus = "Completed",
                ShippedDate = DateTime.UtcNow,
                RequiredDate = DateTime.UtcNow.AddDays(2),
                StaffId = 1,
                StoreId = 1,
            };
            Order order2 = new Order
            {
                Id = 2,
                OrderDate = DateTime.UtcNow,
                CustomerId = 2,
                OrderStatus = "Pending processing",
                ShippedDate = null,
                RequiredDate = DateTime.UtcNow.AddDays(3),
                StaffId = 2,
                StoreId = 2,
            };
            Order order3 = new Order
            {
                Id = 3,
                OrderDate = DateTime.UtcNow.AddDays(-1),
                CustomerId = 1,
                OrderStatus = "Pending processing",
                ShippedDate = null,
                RequiredDate = DateTime.UtcNow.AddDays(1),
                StaffId = 1,
                StoreId = 1,
            };
            Order order4 = new Order
            {
                Id = 4,
                OrderDate = DateTime.UtcNow,
                CustomerId = 3,
                OrderStatus = "Order confirmed",
                ShippedDate = null,
                RequiredDate = DateTime.UtcNow.AddDays(5),
                StaffId = 1,
                StoreId = 1,
            };
            Staff staff1 = new Staff
            {
                Id = 1,
                FirstName = "Petya",
                LastName = "Petr",
                Active = true,
                Email = "petr@gmail.com",
                ManagerId = 2,
                Phone = "1234456790",
                StoreId = 1,
            };
            Staff staff2 = new Staff
            {
                Id = 2,
                FirstName = "Vasya",
                LastName = "Kvasya",
                Active = true,
                Email = "vaskvas@gmail.com",
                ManagerId = 2,
                Phone = "1234456999",
                StoreId = 2,
            };
            Product product1 = new Product
            {
                Id = 1,
                ListPrice = 3,
                Name = "Bounty X2",
                ModelYear = 2000,
                BrandId = 1,
                CategoryId = 1,
            };
            Product product2 = new Product
            {
                Id = 2,
                ListPrice = 4,
                Name = "Pepsi 0.5",
                ModelYear = 1998,
                BrandId = 2,
                CategoryId = 2,
            };
            Product product3 = new Product
            {
                Id = 3,
                ListPrice = 5,
                Name = "Pepsi 1",
                ModelYear = 1998,
                BrandId = 2,
                CategoryId = 2,
            };
            OrderItem orderItem1 = new OrderItem
            {
                Discount = 0,
                ItemId = 1,
                ListPrice = 3,
                OrderId = 1,
                ProductId = 1,
                Quantity = 10
            };
            OrderItem orderItem2 = new OrderItem
            {
                Discount = 5,
                ItemId = 2,
                ListPrice = 4,
                OrderId = 2,
                ProductId = 2,
                Quantity = 10
            };
            OrderItem orderItem3 = new OrderItem
            {
                Discount = 2,
                ItemId = 1,
                ListPrice = 3,
                OrderId = 3,
                ProductId = 1,
                Quantity = 8
            };
            OrderItem orderItem5 = new OrderItem
            {
                Discount = 1,
                ItemId = 2,
                ListPrice = 4,
                OrderId = 3,
                ProductId = 2,
                Quantity = 6
            };
            OrderItem orderItem4 = new OrderItem
            {
                Discount = 0,
                ItemId = 2,
                ListPrice = 4,
                OrderId = 4,
                ProductId = 2,
                Quantity = 1
            };
            Stock stock1 = new Stock
            {
                ProductId = 1,
                Quantity = 100000,
                StoreId = 1
            };
            Stock stock2 = new Stock
            {
                ProductId = 2,
                Quantity = 500000,
                StoreId = 1
            };
            Stock stock3 = new Stock
            {
                ProductId = 3,
                Quantity = 60000,
                StoreId = 1
            };
            Store store1 = new Store
            {
                Email = "beststore@gmail.com",
                Phone = "1122334455",
                State = "CA",
                City = "California",
                Name = "Best Store",
                Street = "Venice Beach",
                ZipCode = 90291,
                Id = 1,
            };
            Store store2 = new Store
            {
                Email = "beststore_ca@gmail.com",
                Phone = "1122334456",
                State = "CA",
                City = "California",
                Name = "Same Store",
                Street = "St Louis Ave",
                ZipCode = 90250,
                Id = 2,
            };
            Customer customer1 = new Customer
            {
                Id = 1,
                City = "Kyiv",
                Email = "klichko@gmail.com",
                FirstName = "Vitalik",
                LastName = "Klich",
                Phone = "0934608651",
                State = "Kv",
                Street = "Kreschatic",
                ZipCode = 61022
            };
            Customer customer2 = new Customer
            {
                Id = 2,
                City = "Minneapolis",
                Email = "minneapoliser@gmail.com",
                FirstName = "Dave",
                LastName = "Lombardo",
                Phone = "9028235474",
                State = "MN",
                Street = "Nicollet Avenue",
                ZipCode = 55404
            };
            Customer customer3 = new Customer
            {
                Id = 3,
                City = "Kharkiv",
                Email = "kernes@gmail.com",
                FirstName = "Gena",
                LastName = "Kernes",
                Phone = "0634608651",
                State = "Kh",
                Street = "Nauki ave",
                ZipCode = 61022
            };
            Customer customer4 = new Customer
            {
                Id = 4,
                City = "Sumy",
                Email = "fatboy@gmail.com",
                FirstName = "Fatboy",
                LastName = "Slim",
                Phone = "0534378651",
                State = "Sm",
                Street = "Shkol'naya str",
                ZipCode = 41429
            };

            modelBuilder.Entity<Customer>().HasData(customer1);
            modelBuilder.Entity<Customer>().HasData(customer2);
            modelBuilder.Entity<Customer>().HasData(customer3);
            modelBuilder.Entity<Customer>().HasData(customer4);
            modelBuilder.Entity<Staff>().HasData(staff1);
            modelBuilder.Entity<Staff>().HasData(staff2);
            modelBuilder.Entity<Stock>().HasData(stock1);
            modelBuilder.Entity<Stock>().HasData(stock2);
            modelBuilder.Entity<Stock>().HasData(stock3);
            modelBuilder.Entity<Store>().HasData(store1);
            modelBuilder.Entity<Store>().HasData(store2);
            modelBuilder.Entity<Product>().HasData(product1);
            modelBuilder.Entity<Product>().HasData(product2);
            modelBuilder.Entity<Product>().HasData(product3);
            modelBuilder.Entity<OrderItem>().HasData(orderItem1);
            modelBuilder.Entity<OrderItem>().HasData(orderItem2);
            modelBuilder.Entity<OrderItem>().HasData(orderItem3);
            modelBuilder.Entity<OrderItem>().HasData(orderItem4);
            modelBuilder.Entity<OrderItem>().HasData(orderItem5);
            modelBuilder.Entity<Order>().HasData(order1);
            modelBuilder.Entity<Order>().HasData(order2);
            modelBuilder.Entity<Order>().HasData(order3);
            modelBuilder.Entity<Order>().HasData(order4);
            modelBuilder.Entity<Category>().HasData(category1);
            modelBuilder.Entity<Category>().HasData(category2);
            modelBuilder.Entity<Brand>().HasData(brand1);
            modelBuilder.Entity<Brand>().HasData(brand2);
        }
    }
}
