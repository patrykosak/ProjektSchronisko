using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjektSchronisko.Migrations
{
    public partial class AddDbForAdoptedAnimals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Animals",
                table: "Animals");

            migrationBuilder.RenameTable(
                name: "Animals",
                newName: "Animal");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Animal",
                table: "Animal",
                column: "IdAnimal");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Animal",
                table: "Animal");

            migrationBuilder.RenameTable(
                name: "Animal",
                newName: "Animals");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Animals",
                table: "Animals",
                column: "IdAnimal");
        }
    }
}
