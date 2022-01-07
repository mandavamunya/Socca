using Microsoft.EntityFrameworkCore.Migrations;

namespace Socca.FootballClub.Data.Migrations
{
    public partial class AddDescriptionAndImageFieldMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FootballClubs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "FootballClubs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "FootballClubs");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "FootballClubs");
        }
    }
}
