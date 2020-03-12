using Microsoft.EntityFrameworkCore.Migrations;

namespace ClickToBuy.Database.Migrations
{
    public partial class UpdateModel_PurchasePayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "PurchasePayments");

            migrationBuilder.AddColumn<float>(
                name: "DueAmount",
                table: "PurchasePayments",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "PayAmount",
                table: "PurchasePayments",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "PurchaseItems",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DueAmount",
                table: "PurchasePayments");

            migrationBuilder.DropColumn(
                name: "PayAmount",
                table: "PurchasePayments");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "PurchaseItems");

            migrationBuilder.AddColumn<float>(
                name: "Amount",
                table: "PurchasePayments",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
