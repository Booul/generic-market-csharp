using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace generic_market_csharp.Migrations
{
    public partial class ChangePromotionTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Promotions_Products_ProductId",
                table: "Promotions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Promotions",
                table: "Promotions");

            migrationBuilder.RenameTable(
                name: "Promotions",
                newName: "DiscountedSales");

            migrationBuilder.RenameIndex(
                name: "IX_Promotions_ProductId",
                table: "DiscountedSales",
                newName: "IX_DiscountedSales_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiscountedSales",
                table: "DiscountedSales",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DiscountedSales_Products_ProductId",
                table: "DiscountedSales",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiscountedSales_Products_ProductId",
                table: "DiscountedSales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DiscountedSales",
                table: "DiscountedSales");

            migrationBuilder.RenameTable(
                name: "DiscountedSales",
                newName: "Promotions");

            migrationBuilder.RenameIndex(
                name: "IX_DiscountedSales_ProductId",
                table: "Promotions",
                newName: "IX_Promotions_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Promotions",
                table: "Promotions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Promotions_Products_ProductId",
                table: "Promotions",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
