﻿using Microsoft.EntityFrameworkCore.Migrations;


namespace ProjektSchronisko.Migrations
{
    public partial class addPhotoURLtoAnimals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoPathURL",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoPathURL",
                table: "Animals");
        }
    }
}
