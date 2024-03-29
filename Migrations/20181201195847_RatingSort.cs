﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace KRWebDesign.Migrations
{
    public partial class RatingSort : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Rating",
                table: "FavoriteWebSites",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "FavoriteWebSites");
        }
    }
}
