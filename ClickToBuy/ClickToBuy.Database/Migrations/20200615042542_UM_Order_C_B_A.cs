using Microsoft.EntityFrameworkCore.Migrations;

namespace ClickToBuy.Database.Migrations
{
    public partial class UM_Order_C_B_A : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerBillingAddressId",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerBillingAddressId",
                table: "Orders",
                column: "CustomerBillingAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_CustomerBillingAddresses_CustomerBillingAddressId",
                table: "Orders",
                column: "CustomerBillingAddressId",
                principalTable: "CustomerBillingAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_CustomerBillingAddresses_CustomerBillingAddressId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerBillingAddressId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CustomerBillingAddressId",
                table: "Orders");
        }
    }
}
