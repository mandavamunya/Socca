using Microsoft.EntityFrameworkCore.Migrations;

namespace Socca.Players.Data.Migrations
{
    public partial class AddImageFieldMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Players");
        }
    }
}
