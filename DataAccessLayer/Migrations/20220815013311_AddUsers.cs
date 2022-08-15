using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class AddUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MANGAS_MangasRatingFrequencies_RatingFrequenciesId",
                table: "MANGAS");

            migrationBuilder.DropForeignKey(
                name: "FK_MANGAS_MangaTitles_TitlesId",
                table: "MANGAS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MANGAS",
                table: "MANGAS");

            migrationBuilder.RenameTable(
                name: "MANGAS",
                newName: "Mangas");

            migrationBuilder.RenameIndex(
                name: "IX_MANGAS_TitlesId",
                table: "Mangas",
                newName: "IX_Mangas_TitlesId");

            migrationBuilder.RenameIndex(
                name: "IX_MANGAS_RatingFrequenciesId",
                table: "Mangas",
                newName: "IX_Mangas_RatingFrequenciesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mangas",
                table: "Mangas",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nickname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "date", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "date", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FavoritesCount = table.Column<int>(type: "int", nullable: false),
                    ReviewsCount = table.Column<int>(type: "int", nullable: false),
                    CoverImageLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvatarImageLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KeepLogged = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Mangas_MangasRatingFrequencies_RatingFrequenciesId",
                table: "Mangas",
                column: "RatingFrequenciesId",
                principalTable: "MangasRatingFrequencies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Mangas_MangaTitles_TitlesId",
                table: "Mangas",
                column: "TitlesId",
                principalTable: "MangaTitles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mangas_MangasRatingFrequencies_RatingFrequenciesId",
                table: "Mangas");

            migrationBuilder.DropForeignKey(
                name: "FK_Mangas_MangaTitles_TitlesId",
                table: "Mangas");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mangas",
                table: "Mangas");

            migrationBuilder.RenameTable(
                name: "Mangas",
                newName: "MANGAS");

            migrationBuilder.RenameIndex(
                name: "IX_Mangas_TitlesId",
                table: "MANGAS",
                newName: "IX_MANGAS_TitlesId");

            migrationBuilder.RenameIndex(
                name: "IX_Mangas_RatingFrequenciesId",
                table: "MANGAS",
                newName: "IX_MANGAS_RatingFrequenciesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MANGAS",
                table: "MANGAS",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MANGAS_MangasRatingFrequencies_RatingFrequenciesId",
                table: "MANGAS",
                column: "RatingFrequenciesId",
                principalTable: "MangasRatingFrequencies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MANGAS_MangaTitles_TitlesId",
                table: "MANGAS",
                column: "TitlesId",
                principalTable: "MangaTitles",
                principalColumn: "Id");
        }
    }
}
