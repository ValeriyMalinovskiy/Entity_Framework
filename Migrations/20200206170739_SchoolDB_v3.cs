using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity_Framework_solution.Migrations
{
    public partial class SchoolDB_v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Students",
                newName: "StudentNAME");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentNAME",
                table: "Students",
                newName: "Name");
        }
    }
}
