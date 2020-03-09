using Microsoft.EntityFrameworkCore.Migrations;

namespace ClickToBuy.Database.Migrations
{
    public partial class UpdateModel_StockProduct_Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_StockProducts_StockProductId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_StockProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "StockProductId",
                table: "Products");

            migrationBuilder.AddForeignKey(
                name: "FK_StockProducts_Products_ProductId",
                table: "StockProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockProducts_Products_ProductId",
                table: "StockProducts");

            migrationBuilder.AddColumn<int>(
                name: "StockProductId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_StockProductId",
                table: "Products",
                column: "StockProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_StockProducts_StockProductId",
                table: "Products",
                column: "StockProductId",
                principalTable: "StockProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
