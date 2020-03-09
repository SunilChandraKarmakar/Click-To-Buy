using Microsoft.EntityFrameworkCore.Migrations;

namespace ClickToBuy.Database.Migrations
{
    public partial class AddView_NonProductInStock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW NonProductInStock
                                AS
                                Select * 
                                FROM Products
                                WHERE Id NOT IN (SELECT StockProducts.ProductId FROM StockProducts)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS dbo.NonProductInStock");
        }
    }
}
