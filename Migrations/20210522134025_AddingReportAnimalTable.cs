using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjektSchronisko.Migrations
{
    public partial class AddingReportAnimalTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReportAnimal",
                columns: table => new
                {
                    IdReport = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeReport = table.Column<int>(type: "int", nullable: false),
                    AdderId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AddDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnimalName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportAnimal", x => x.IdReport);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportAnimal");
        }
    }
}
