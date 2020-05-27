using Microsoft.EntityFrameworkCore.Migrations;

namespace ClickToBuy.Database.Migrations
{
    public partial class UM_Slider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Sliders_PhotoName",
                table: "Sliders");

            migrationBuilder.AlterColumn<string>(
                name: "PhotoName",
                table: "Sliders",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Sliders_PhotoName",
                table: "Sliders",
                column: "PhotoName",
                unique: true,
                filter: "[PhotoName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Sliders_PhotoName",
                table: "Sliders");

            migrationBuilder.AlterColumn<string>(
                name: "PhotoName",
                table: "Sliders",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sliders_PhotoName",
                table: "Sliders",
                column: "PhotoName",
                unique: true);
        }
    }
}
