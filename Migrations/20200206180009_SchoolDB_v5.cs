using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity_Framework_solution.Migrations
{
    public partial class SchoolDB_v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BestStudents_Grades_GradeId",
                table: "BestStudents");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Grades_TempId",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "TempId",
                table: "Grades");

            migrationBuilder.AlterColumn<long>(
                name: "GradeId",
                table: "Grades",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_BestStudents_Grades_GradeId",
                table: "BestStudents",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "GradeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BestStudents_Grades_GradeId",
                table: "BestStudents");

            migrationBuilder.AlterColumn<int>(
                name: "GradeId",
                table: "Grades",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "TempId",
                table: "Grades",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Grades_TempId",
                table: "Grades",
                column: "TempId");

            migrationBuilder.AddForeignKey(
                name: "FK_BestStudents_Grades_GradeId",
                table: "BestStudents",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "TempId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
