using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjektSchronisko.Migrations
{
    public partial class AddingEmailInConversation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email1",
                table: "Conversations",
                type: "nvarchar(max)",
                maxLength: 10000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email2",
                table: "Conversations",
                type: "nvarchar(max)",
                maxLength: 10000,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email1",
                table: "Conversations");

            migrationBuilder.DropColumn(
                name: "Email2",
                table: "Conversations");
        }
    }
}
