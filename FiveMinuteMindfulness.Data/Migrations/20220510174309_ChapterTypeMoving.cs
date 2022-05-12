using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiveMinuteMindfulness.Data.Migrations
{
    public partial class ChapterTypeMoving : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChapterType",
                table: "Chapters");

            migrationBuilder.AddColumn<int>(
                name: "ChapterType",
                table: "Sections",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChapterType",
                table: "Sections");

            migrationBuilder.AddColumn<int>(
                name: "ChapterType",
                table: "Chapters",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
