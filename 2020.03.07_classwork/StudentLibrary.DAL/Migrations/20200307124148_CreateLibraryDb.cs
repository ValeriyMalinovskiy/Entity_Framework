using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentLibrary.DAL.Migrations
{
    public partial class CreateLibraryDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    LocalAddress = table.Column<string>(nullable: true),
                    PostalCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    EntranceDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titile = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "LocalAddress", "PostalCode" },
                values: new object[] { 1, "Kharkiv", "Ukraine", "Borthenko st.5, 25", 61177 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AddressId", "DateOfBirth", "Email", "EntranceDate", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 1, 1, new DateTime(1990, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "mdfcnvsn@gmail.com", new DateTime(2008, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V", "M", "0634608651" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "StudentId", "Titile", "Year" },
                values: new object[] { 1, "Smb", 1, "Smth", 1998 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "StudentId", "Titile", "Year" },
                values: new object[] { 2, "Smb2", 1, "Smth2", 2000 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "StudentId", "Titile", "Year" },
                values: new object[] { 3, "Smb3", 1, "Smth2", 2002 });

            migrationBuilder.CreateIndex(
                name: "IX_Books_StudentId",
                table: "Books",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_AddressId",
                table: "Students",
                column: "AddressId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
