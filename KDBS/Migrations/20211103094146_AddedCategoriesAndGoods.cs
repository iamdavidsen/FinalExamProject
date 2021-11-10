using Microsoft.EntityFrameworkCore.Migrations;

namespace KDBS.Migrations
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public partial class AddedCategoriesAndGoods : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryId",
                table: "Jobs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CategoryModel",
                columns: table => new
                {
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryModel", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "GoodsModel",
                columns: table => new
                {
                    GoodsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsModel", x => x.GoodsId);
                });

            migrationBuilder.CreateTable(
                name: "JobGoods",
                columns: table => new
                {
                    GoodsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JobsJobId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobGoods", x => new { x.GoodsId, x.JobsJobId });
                    table.ForeignKey(
                        name: "FK_JobGoods_GoodsModel_GoodsId",
                        column: x => x.GoodsId,
                        principalTable: "GoodsModel",
                        principalColumn: "GoodsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobGoods_Jobs_JobsJobId",
                        column: x => x.JobsJobId,
                        principalTable: "Jobs",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CategoryId",
                table: "Jobs",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_JobGoods_JobsJobId",
                table: "JobGoods",
                column: "JobsJobId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_CategoryModel_CategoryId",
                table: "Jobs",
                column: "CategoryId",
                principalTable: "CategoryModel",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_CategoryModel_CategoryId",
                table: "Jobs");

            migrationBuilder.DropTable(
                name: "CategoryModel");

            migrationBuilder.DropTable(
                name: "JobGoods");

            migrationBuilder.DropTable(
                name: "GoodsModel");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_CategoryId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Jobs");
        }
    }
}
