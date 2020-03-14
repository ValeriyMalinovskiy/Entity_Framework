﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCrmModel.Migrations
{
    public partial class CreateCrmDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "brands (production)",
                columns: table => new
                {
                    brand_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    brand_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brands (production)", x => x.brand_id);
                });

            migrationBuilder.CreateTable(
                name: "categories (production)",
                columns: table => new
                {
                    category_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories (production)", x => x.category_id);
                });

            migrationBuilder.CreateTable(
                name: "customers (sales)",
                columns: table => new
                {
                    customer_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(nullable: true),
                    last_name = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    street = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    zip_code = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers (sales)", x => x.customer_id);
                });

            migrationBuilder.CreateTable(
                name: "stores (sales)",
                columns: table => new
                {
                    store_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    store_name = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    street = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    zip_code = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stores (sales)", x => x.store_id);
                });

            migrationBuilder.CreateTable(
                name: "products (production)",
                columns: table => new
                {
                    product_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_name = table.Column<string>(nullable: true),
                    brand_id = table.Column<int>(nullable: false),
                    category_id = table.Column<int>(nullable: false),
                    model_year = table.Column<int>(nullable: false),
                    list_price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products (production)", x => x.product_id);
                    table.ForeignKey(
                        name: "FK_products (production)_brands (production)_brand_id",
                        column: x => x.brand_id,
                        principalTable: "brands (production)",
                        principalColumn: "brand_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_products (production)_categories (production)_category_id",
                        column: x => x.category_id,
                        principalTable: "categories (production)",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "staffs (sales)",
                columns: table => new
                {
                    staff_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(nullable: true),
                    last_name = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    active = table.Column<bool>(nullable: false),
                    store_id = table.Column<int>(nullable: false),
                    manager_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_staffs (sales)", x => x.staff_id);
                    table.ForeignKey(
                        name: "FK_staffs (sales)_stores (sales)_store_id",
                        column: x => x.store_id,
                        principalTable: "stores (sales)",
                        principalColumn: "store_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "stocks (production)",
                columns: table => new
                {
                    store_id = table.Column<int>(nullable: false),
                    product_id = table.Column<int>(nullable: false),
                    quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stocks (production)", x => new { x.store_id, x.product_id });
                    table.ForeignKey(
                        name: "FK_stocks (production)_products (production)_product_id",
                        column: x => x.product_id,
                        principalTable: "products (production)",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_stocks (production)_stores (sales)_store_id",
                        column: x => x.store_id,
                        principalTable: "stores (sales)",
                        principalColumn: "store_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orders (sales)",
                columns: table => new
                {
                    order_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_id = table.Column<int>(nullable: false),
                    order_status = table.Column<string>(nullable: true),
                    order_date = table.Column<DateTime>(nullable: false),
                    required_date = table.Column<DateTime>(nullable: false),
                    shipped_date = table.Column<DateTime>(nullable: true),
                    store_id = table.Column<int>(nullable: false),
                    staff_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders (sales)", x => x.order_id);
                    table.ForeignKey(
                        name: "FK_orders (sales)_customers (sales)_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers (sales)",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders (sales)_staffs (sales)_staff_id",
                        column: x => x.staff_id,
                        principalTable: "staffs (sales)",
                        principalColumn: "staff_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders (sales)_stores (sales)_store_id",
                        column: x => x.store_id,
                        principalTable: "stores (sales)",
                        principalColumn: "store_id");
                });

            migrationBuilder.CreateTable(
                name: "order_items (sales)",
                columns: table => new
                {
                    order_id = table.Column<int>(nullable: false),
                    item_id = table.Column<int>(nullable: false),
                    product_id = table.Column<int>(nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    list_price = table.Column<decimal>(nullable: false),
                    discount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_items (sales)", x => new { x.order_id, x.item_id });
                    table.ForeignKey(
                        name: "FK_order_items (sales)_orders (sales)_order_id",
                        column: x => x.order_id,
                        principalTable: "orders (sales)",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_items (sales)_products (production)_product_id",
                        column: x => x.product_id,
                        principalTable: "products (production)",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "brands (production)",
                columns: new[] { "brand_id", "brand_name" },
                values: new object[] { 1, "Bounty" });

            migrationBuilder.InsertData(
                table: "categories (production)",
                columns: new[] { "category_id", "category_name" },
                values: new object[] { 1, "Food" });

            migrationBuilder.InsertData(
                table: "customers (sales)",
                columns: new[] { "customer_id", "city", "email", "first_name", "last_name", "phone", "state", "street", "zip_code" },
                values: new object[] { 1, "New York", "newyorker@gmail.com", "Chris", "Parker", "9023233455", "NY", "1st avenue", 12511 });

            migrationBuilder.InsertData(
                table: "stores (sales)",
                columns: new[] { "store_id", "city", "email", "store_name", "phone", "state", "street", "zip_code" },
                values: new object[] { 1, "California", "beststore@gmail.com", "Best Store", "1122334455", "CA", "Venice Beach", 90291 });

            migrationBuilder.InsertData(
                table: "products (production)",
                columns: new[] { "product_id", "brand_id", "category_id", "list_price", "model_year", "product_name" },
                values: new object[] { 1, 1, 1, 30m, 2000, "Bounty" });

            migrationBuilder.InsertData(
                table: "staffs (sales)",
                columns: new[] { "staff_id", "active", "email", "first_name", "last_name", "manager_id", "phone", "store_id" },
                values: new object[] { 1, true, "petr@gmail.com", "Petya", "Petr", 2, "1234456790", 1 });

            migrationBuilder.InsertData(
                table: "orders (sales)",
                columns: new[] { "order_id", "customer_id", "order_date", "order_status", "required_date", "shipped_date", "staff_id", "store_id" },
                values: new object[] { 1, 1, new DateTime(2020, 3, 14, 14, 6, 59, 588, DateTimeKind.Utc).AddTicks(2690), "Pending processing", new DateTime(2020, 3, 19, 14, 6, 59, 588, DateTimeKind.Utc).AddTicks(5937), null, 1, 1 });

            migrationBuilder.InsertData(
                table: "stocks (production)",
                columns: new[] { "store_id", "product_id", "quantity" },
                values: new object[] { 1, 1, 100000 });

            migrationBuilder.InsertData(
                table: "order_items (sales)",
                columns: new[] { "order_id", "item_id", "discount", "list_price", "product_id", "quantity" },
                values: new object[] { 1, 1, 0m, 12m, 1, 10 });

            migrationBuilder.CreateIndex(
                name: "IX_order_items (sales)_product_id",
                table: "order_items (sales)",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders (sales)_customer_id",
                table: "orders (sales)",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders (sales)_staff_id",
                table: "orders (sales)",
                column: "staff_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders (sales)_store_id",
                table: "orders (sales)",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "IX_products (production)_brand_id",
                table: "products (production)",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "IX_products (production)_category_id",
                table: "products (production)",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_staffs (sales)_store_id",
                table: "staffs (sales)",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "IX_stocks (production)_product_id",
                table: "stocks (production)",
                column: "product_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order_items (sales)");

            migrationBuilder.DropTable(
                name: "stocks (production)");

            migrationBuilder.DropTable(
                name: "orders (sales)");

            migrationBuilder.DropTable(
                name: "products (production)");

            migrationBuilder.DropTable(
                name: "customers (sales)");

            migrationBuilder.DropTable(
                name: "staffs (sales)");

            migrationBuilder.DropTable(
                name: "brands (production)");

            migrationBuilder.DropTable(
                name: "categories (production)");

            migrationBuilder.DropTable(
                name: "stores (sales)");
        }
    }
}
