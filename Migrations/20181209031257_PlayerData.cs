using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KRWebDesign.Migrations
{
    public partial class PlayerData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayerData",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlayerID = table.Column<string>(nullable: true),
                    TriesPerDay = table.Column<int>(nullable: false),
                    LastAttemptedPlay = table.Column<DateTime>(nullable: false),
                    GamerName = table.Column<string>(nullable: true),
                    GamerLevel = table.Column<int>(nullable: false),
                    GamePlaysToDate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerData", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerData");
        }
    }
}
