using Microsoft.EntityFrameworkCore.Migrations;

namespace KRWebDesign.Migrations
{
    public partial class MembershipType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "MembershipTypeId",
                table: "PlayerData",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<int>(
                name: "TotalGems",
                table: "PlayerData",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MembershipType",
                columns: table => new
                {
                    ID = table.Column<byte>(nullable: false),
                    SignUpFee = table.Column<int>(nullable: false),
                    DurationInMonths = table.Column<byte>(nullable: false),
                    DiscountRate = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipType", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerData_MembershipTypeId",
                table: "PlayerData",
                column: "MembershipTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerData_MembershipType_MembershipTypeId",
                table: "PlayerData",
                column: "MembershipTypeId",
                principalTable: "MembershipType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerData_MembershipType_MembershipTypeId",
                table: "PlayerData");

            migrationBuilder.DropTable(
                name: "MembershipType");

            migrationBuilder.DropIndex(
                name: "IX_PlayerData_MembershipTypeId",
                table: "PlayerData");

            migrationBuilder.DropColumn(
                name: "MembershipTypeId",
                table: "PlayerData");

            migrationBuilder.DropColumn(
                name: "TotalGems",
                table: "PlayerData");
        }
    }
}
