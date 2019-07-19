using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KRWebDesign.Migrations
{
    public partial class FavoriteSiteMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FavoriteWebSites",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Category = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteWebSites", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteSite",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SiteURL = table.Column<string>(nullable: true),
                    Rating = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    FavoriteWebSitesID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteSite", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FavoriteSite_FavoriteWebSites_FavoriteWebSitesID",
                        column: x => x.FavoriteWebSitesID,
                        principalTable: "FavoriteWebSites",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteSite_FavoriteWebSitesID",
                table: "FavoriteSite",
                column: "FavoriteWebSitesID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteSite");

            migrationBuilder.DropTable(
                name: "FavoriteWebSites");
        }
    }
}
