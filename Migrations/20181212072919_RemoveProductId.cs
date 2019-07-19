using Microsoft.EntityFrameworkCore.Migrations;

namespace KRWebDesign.Migrations
{
    public partial class RemoveProductId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductID",
                table: "Products",
                nullable: true);
        }
    }
}
