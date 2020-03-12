using Microsoft.EntityFrameworkCore.Migrations;

namespace ClickToBuy.Database.Migrations
{
    public partial class Modify_Purchase_StockProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PurchaseId",
                table: "StockProducts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockProducts_PurchaseId",
                table: "StockProducts",
                column: "PurchaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockProducts_Purchases_PurchaseId",
                table: "StockProducts",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockProducts_Purchases_PurchaseId",
                table: "StockProducts");

            migrationBuilder.DropIndex(
                name: "IX_StockProducts_PurchaseId",
                table: "StockProducts");

            migrationBuilder.DropColumn(
                name: "PurchaseId",
                table: "StockProducts");
        }
    }
}
