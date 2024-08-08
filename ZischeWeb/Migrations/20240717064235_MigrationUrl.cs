using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZischeWeb.Migrations
{
    public partial class MigrationUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BuyUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuyUrl",
                table: "Products");
        }
    }
}
