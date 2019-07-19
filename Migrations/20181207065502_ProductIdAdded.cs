using Microsoft.EntityFrameworkCore.Migrations;

namespace KRWebDesign.Migrations
{
    public partial class ProductIdAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beef_Products_ProductsID",
                table: "Beef");

            migrationBuilder.DropIndex(
                name: "IX_Beef_ProductsID",
                table: "Beef");

            migrationBuilder.DropColumn(
                name: "ProductsID",
                table: "Beef");

            migrationBuilder.AddColumn<string>(
                name: "Flavor",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerID",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductID",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Flavor",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductsID",
                table: "Beef",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Beef_ProductsID",
                table: "Beef",
                column: "ProductsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Beef_Products_ProductsID",
                table: "Beef",
                column: "ProductsID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
