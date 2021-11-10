using Microsoft.EntityFrameworkCore.Migrations;

namespace KDBS.Migrations
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public partial class AddedCategoriesAndGoodsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobGoods_GoodsModel_GoodsId",
                table: "JobGoods");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_CategoryModel_CategoryId",
                table: "Jobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GoodsModel",
                table: "GoodsModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryModel",
                table: "CategoryModel");

            migrationBuilder.RenameTable(
                name: "GoodsModel",
                newName: "Goods");

            migrationBuilder.RenameTable(
                name: "CategoryModel",
                newName: "Categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Goods",
                table: "Goods",
                column: "GoodsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobGoods_Goods_GoodsId",
                table: "JobGoods",
                column: "GoodsId",
                principalTable: "Goods",
                principalColumn: "GoodsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Categories_CategoryId",
                table: "Jobs",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobGoods_Goods_GoodsId",
                table: "JobGoods");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Categories_CategoryId",
                table: "Jobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Goods",
                table: "Goods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Goods",
                newName: "GoodsModel");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "CategoryModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GoodsModel",
                table: "GoodsModel",
                column: "GoodsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryModel",
                table: "CategoryModel",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobGoods_GoodsModel_GoodsId",
                table: "JobGoods",
                column: "GoodsId",
                principalTable: "GoodsModel",
                principalColumn: "GoodsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_CategoryModel_CategoryId",
                table: "Jobs",
                column: "CategoryId",
                principalTable: "CategoryModel",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
