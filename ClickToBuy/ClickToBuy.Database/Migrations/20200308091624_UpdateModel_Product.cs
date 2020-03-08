using Microsoft.EntityFrameworkCore.Migrations;

namespace ClickToBuy.Database.Migrations
{
    public partial class UpdateModel_Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Products");
        }
    }
}
