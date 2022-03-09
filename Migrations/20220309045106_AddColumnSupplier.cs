using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace generic_market_csharp.Migrations
{
    public partial class AddColumnSupplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Suppliers",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Suppliers");
        }
    }
}
