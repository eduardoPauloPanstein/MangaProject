using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class LastANime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnimeCoverImageTopOffset",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "nsfw",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "tba",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "youtubevideo",
                table: "Anime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnimeCoverImageTopOffset",
                table: "Anime",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "nsfw",
                table: "Anime",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tba",
                table: "Anime",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "youtubevideo",
                table: "Anime",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
