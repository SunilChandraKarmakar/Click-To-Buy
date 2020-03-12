using Microsoft.EntityFrameworkCore.Migrations;

namespace ClickToBuy.Database.Migrations
{
    public partial class Modify_Purchase_PurchasePayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchasePayments_Purchases_PurchaseId",
                table: "PurchasePayments");

            migrationBuilder.DropIndex(
                name: "IX_PurchasePayments_PurchaseId",
                table: "PurchasePayments");

            migrationBuilder.AddColumn<int>(
                name: "PurchasePaymentId",
                table: "Purchases",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_PurchasePaymentId",
                table: "Purchases",
                column: "PurchasePaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_PurchasePayments_PurchasePaymentId",
                table: "Purchases",
                column: "PurchasePaymentId",
                principalTable: "PurchasePayments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_PurchasePayments_PurchasePaymentId",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_PurchasePaymentId",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "PurchasePaymentId",
                table: "Purchases");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePayments_PurchaseId",
                table: "PurchasePayments",
                column: "PurchaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasePayments_Purchases_PurchaseId",
                table: "PurchasePayments",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
