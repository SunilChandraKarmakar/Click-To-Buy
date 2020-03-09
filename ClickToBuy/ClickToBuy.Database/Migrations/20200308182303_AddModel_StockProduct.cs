using Microsoft.EntityFrameworkCore.Migrations;

namespace ClickToBuy.Database.Migrations
{
    public partial class AddModel_StockProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StockProductId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StockProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockProducts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_StockProductId",
                table: "Products",
                column: "StockProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StockProducts_ProductId",
                table: "StockProducts",
                column: "ProductId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_StockProducts_StockProductId",
                table: "Products",
                column: "StockProductId",
                principalTable: "StockProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_StockProducts_StockProductId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "StockProducts");

            migrationBuilder.DropIndex(
                name: "IX_Products_StockProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "StockProductId",
                table: "Products");
        }
    }
}
