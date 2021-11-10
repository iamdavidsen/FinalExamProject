using Microsoft.EntityFrameworkCore.Migrations;

namespace KDBS.Migrations
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public partial class AddedLinkToCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LinkToCompany",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkToCompany",
                table: "Jobs");
        }
    }
}
