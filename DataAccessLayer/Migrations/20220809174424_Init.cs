using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MANGAS_RatingFrequencies_RatingFrequenciesId",
                table: "MANGAS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RatingFrequencies",
                table: "RatingFrequencies");

            migrationBuilder.RenameTable(
                name: "RatingFrequencies",
                newName: "MangasRatingFrequencies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MangasRatingFrequencies",
                table: "MangasRatingFrequencies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MANGAS_MangasRatingFrequencies_RatingFrequenciesId",
                table: "MANGAS",
                column: "RatingFrequenciesId",
                principalTable: "MangasRatingFrequencies",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MANGAS_MangasRatingFrequencies_RatingFrequenciesId",
                table: "MANGAS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MangasRatingFrequencies",
                table: "MangasRatingFrequencies");

            migrationBuilder.RenameTable(
                name: "MangasRatingFrequencies",
                newName: "RatingFrequencies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RatingFrequencies",
                table: "RatingFrequencies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MANGAS_RatingFrequencies_RatingFrequenciesId",
                table: "MANGAS",
                column: "RatingFrequenciesId",
                principalTable: "RatingFrequencies",
                principalColumn: "Id");
        }
    }
}
