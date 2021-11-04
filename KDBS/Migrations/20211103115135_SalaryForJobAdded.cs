using Microsoft.EntityFrameworkCore.Migrations;

namespace KDBS.Migrations
{
    public partial class SalaryForJobAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Salary",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Jobs");
        }
    }
}
