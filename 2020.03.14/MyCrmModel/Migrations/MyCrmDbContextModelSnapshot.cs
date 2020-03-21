﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyCrmModel;

namespace MyCrmModel.Migrations
{
    [DbContext(typeof(MyCrmDbContext))]
    partial class MyCrmDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyCrmModel.Production.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("brand_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnName("brand_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("brands (production)");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Bounty"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Pepsi"
                        });
                });

            modelBuilder.Entity("MyCrmModel.Production.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("category_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnName("category_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("categories (production)");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Food"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Beverage"
                        });
                });

            modelBuilder.Entity("MyCrmModel.Production.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("product_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandId")
                        .HasColumnName("brand_id")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnName("category_id")
                        .HasColumnType("int");

                    b.Property<decimal>("ListPrice")
                        .HasColumnName("list_price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ModelYear")
                        .HasColumnName("model_year")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnName("product_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("products (production)");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 1,
                            CategoryId = 1,
                            ListPrice = 3m,
                            ModelYear = 2000,
                            Name = "Bounty"
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 2,
                            CategoryId = 2,
                            ListPrice = 10m,
                            ModelYear = 1998,
                            Name = "Pepsi"
                        });
                });

            modelBuilder.Entity("MyCrmModel.Production.Stock", b =>
                {
                    b.Property<int>("StoreId")
                        .HasColumnName("store_id")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnName("product_id")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnName("quantity")
                        .HasColumnType("int");

                    b.HasKey("StoreId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("stocks (production)");

                    b.HasData(
                        new
                        {
                            StoreId = 1,
                            ProductId = 1,
                            Quantity = 100000
                        },
                        new
                        {
                            StoreId = 1,
                            ProductId = 2,
                            Quantity = 500000
                        });
                });

            modelBuilder.Entity("MyCrmModel.Sales.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("customer_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnName("city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnName("first_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnName("last_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnName("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnName("state")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnName("street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZipCode")
                        .HasColumnName("zip_code")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("customers (sales)");

                    b.HasData(
                        new
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
                        },
                        new
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
                        },
                        new
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
                        });
                });

            modelBuilder.Entity("MyCrmModel.Sales.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("order_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnName("customer_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnName("order_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderStatus")
                        .HasColumnName("order_status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RequiredDate")
                        .HasColumnName("required_date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ShippedDate")
                        .HasColumnName("shipped_date")
                        .HasColumnType("datetime2");

                    b.Property<int>("StaffId")
                        .HasColumnName("staff_id")
                        .HasColumnType("int");

                    b.Property<int>("StoreId")
                        .HasColumnName("store_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("StaffId");

                    b.HasIndex("StoreId");

                    b.ToTable("orders (sales)");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 1,
                            OrderDate = new DateTime(2020, 3, 18, 18, 50, 2, 530, DateTimeKind.Utc).AddTicks(1652),
                            OrderStatus = "Completed",
                            RequiredDate = new DateTime(2020, 3, 23, 18, 50, 2, 530, DateTimeKind.Utc).AddTicks(5104),
                            ShippedDate = new DateTime(2020, 3, 21, 18, 50, 2, 530, DateTimeKind.Utc).AddTicks(3973),
                            StaffId = 1,
                            StoreId = 1
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 2,
                            OrderDate = new DateTime(2020, 3, 21, 18, 50, 2, 530, DateTimeKind.Utc).AddTicks(7205),
                            OrderStatus = "Pending processing",
                            RequiredDate = new DateTime(2020, 3, 24, 18, 50, 2, 530, DateTimeKind.Utc).AddTicks(7267),
                            StaffId = 2,
                            StoreId = 2
                        },
                        new
                        {
                            Id = 3,
                            CustomerId = 1,
                            OrderDate = new DateTime(2020, 3, 20, 18, 50, 2, 530, DateTimeKind.Utc).AddTicks(7314),
                            OrderStatus = "Pending processing",
                            RequiredDate = new DateTime(2020, 3, 22, 18, 50, 2, 530, DateTimeKind.Utc).AddTicks(7317),
                            StaffId = 1,
                            StoreId = 1
                        },
                        new
                        {
                            Id = 4,
                            CustomerId = 1,
                            OrderDate = new DateTime(2020, 3, 21, 18, 50, 2, 530, DateTimeKind.Utc).AddTicks(7320),
                            OrderStatus = "Order confirmed",
                            RequiredDate = new DateTime(2020, 3, 26, 18, 50, 2, 530, DateTimeKind.Utc).AddTicks(7322),
                            StaffId = 1,
                            StoreId = 1
                        });
                });

            modelBuilder.Entity("MyCrmModel.Sales.OrderItem", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnName("order_id")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnName("item_id")
                        .HasColumnType("int");

                    b.Property<decimal>("Discount")
                        .HasColumnName("discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ListPrice")
                        .HasColumnName("list_price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductId")
                        .HasColumnName("product_id")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnName("quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "ItemId");

                    b.HasIndex("ProductId");

                    b.ToTable("order_items (sales)");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            ItemId = 1,
                            Discount = 0m,
                            ListPrice = 4m,
                            ProductId = 1,
                            Quantity = 10
                        },
                        new
                        {
                            OrderId = 2,
                            ItemId = 2,
                            Discount = 5m,
                            ListPrice = 4m,
                            ProductId = 2,
                            Quantity = 10
                        },
                        new
                        {
                            OrderId = 3,
                            ItemId = 1,
                            Discount = 2m,
                            ListPrice = 4m,
                            ProductId = 1,
                            Quantity = 8
                        },
                        new
                        {
                            OrderId = 4,
                            ItemId = 2,
                            Discount = 0m,
                            ListPrice = 4m,
                            ProductId = 2,
                            Quantity = 1
                        });
                });

            modelBuilder.Entity("MyCrmModel.Sales.Staff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("staff_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnName("active")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnName("first_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnName("last_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ManagerId")
                        .HasColumnName("manager_id")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasColumnName("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StoreId")
                        .HasColumnName("store_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StoreId");

                    b.ToTable("staffs (sales)");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            Email = "petr@gmail.com",
                            FirstName = "Petya",
                            LastName = "Petr",
                            ManagerId = 2,
                            Phone = "1234456790",
                            StoreId = 1
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            Email = "vaskvas@gmail.com",
                            FirstName = "Vasya",
                            LastName = "Kvasya",
                            ManagerId = 2,
                            Phone = "1234456999",
                            StoreId = 2
                        });
                });

            modelBuilder.Entity("MyCrmModel.Sales.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("store_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnName("city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnName("store_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnName("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnName("state")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnName("street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZipCode")
                        .HasColumnName("zip_code")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("stores (sales)");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "California",
                            Email = "beststore@gmail.com",
                            Name = "Best Store",
                            Phone = "1122334455",
                            State = "CA",
                            Street = "Venice Beach",
                            ZipCode = 90291
                        },
                        new
                        {
                            Id = 2,
                            City = "California",
                            Email = "beststore_ca@gmail.com",
                            Name = "Same Store",
                            Phone = "1122334456",
                            State = "CA",
                            Street = "St Louis Ave",
                            ZipCode = 90250
                        });
                });

            modelBuilder.Entity("MyCrmModel.Production.Product", b =>
                {
                    b.HasOne("MyCrmModel.Production.Brand", null)
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyCrmModel.Production.Category", null)
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyCrmModel.Production.Stock", b =>
                {
                    b.HasOne("MyCrmModel.Production.Product", null)
                        .WithMany("Stocks")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyCrmModel.Sales.Store", null)
                        .WithMany("Stocks")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyCrmModel.Sales.Order", b =>
                {
                    b.HasOne("MyCrmModel.Sales.Customer", null)
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyCrmModel.Sales.Staff", null)
                        .WithMany("Orders")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyCrmModel.Sales.Store", "Store")
                        .WithMany("Orders")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("MyCrmModel.Sales.OrderItem", b =>
                {
                    b.HasOne("MyCrmModel.Sales.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyCrmModel.Production.Product", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyCrmModel.Sales.Staff", b =>
                {
                    b.HasOne("MyCrmModel.Sales.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
