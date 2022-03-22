using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace generic_market_csharp.Migrations
{
    public partial class AddColumnsOutput : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Amount",
                table: "Outputs",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "SaleId",
                table: "Outputs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Outputs_SaleId",
                table: "Outputs",
                column: "SaleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Outputs_Sales_SaleId",
                table: "Outputs",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Outputs_Sales_SaleId",
                table: "Outputs");

            migrationBuilder.DropIndex(
                name: "IX_Outputs_SaleId",
                table: "Outputs");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Outputs");

            migrationBuilder.DropColumn(
                name: "SaleId",
                table: "Outputs");
        }
    }
}
