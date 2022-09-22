using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class AnimeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnimeRatingFrequencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _9 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _10 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeRatingFrequencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnimeSTitles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    En = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    En_jp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    En_us = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ja_jp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeSTitles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Anime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    synopsis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnimeCoverImageTopOffset = table.Column<int>(type: "int", nullable: true),
                    AnimeTitlesId = table.Column<int>(type: "int", nullable: true),
                    canonicalTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    averageRating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnimeRatingFrequenciesId = table.Column<int>(type: "int", nullable: true),
                    userCount = table.Column<int>(type: "int", nullable: true),
                    favoritesCount = table.Column<int>(type: "int", nullable: true),
                    startDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    endDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    popularityRank = table.Column<int>(type: "int", nullable: true),
                    ratingRank = table.Column<int>(type: "int", nullable: true),
                    ageRating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ageRatingGuide = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    subtype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<int>(type: "int", nullable: true),
                    tba = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnimePosterImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnimeCoverImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    episodeCount = table.Column<int>(type: "int", nullable: true),
                    episodeLength = table.Column<int>(type: "int", nullable: true),
                    totalLength = table.Column<int>(type: "int", nullable: true),
                    youtubeVideoId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    showType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nsfw = table.Column<bool>(type: "bit", nullable: true),
                    youtubevideo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Anime_AnimeRatingFrequencies_AnimeRatingFrequenciesId",
                        column: x => x.AnimeRatingFrequenciesId,
                        principalTable: "AnimeRatingFrequencies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Anime_AnimeSTitles_AnimeTitlesId",
                        column: x => x.AnimeTitlesId,
                        principalTable: "AnimeSTitles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AnimeCategory",
                columns: table => new
                {
                    AnimesIDId = table.Column<int>(type: "int", nullable: false),
                    CategoriesID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeCategory", x => new { x.AnimesIDId, x.CategoriesID });
                    table.ForeignKey(
                        name: "FK_AnimeCategory_Anime_AnimesIDId",
                        column: x => x.AnimesIDId,
                        principalTable: "Anime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeCategory_Category_CategoriesID",
                        column: x => x.CategoriesID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anime_AnimeRatingFrequenciesId",
                table: "Anime",
                column: "AnimeRatingFrequenciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Anime_AnimeTitlesId",
                table: "Anime",
                column: "AnimeTitlesId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeCategory_CategoriesID",
                table: "AnimeCategory",
                column: "CategoriesID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimeCategory");

            migrationBuilder.DropTable(
                name: "Anime");

            migrationBuilder.DropTable(
                name: "AnimeRatingFrequencies");

            migrationBuilder.DropTable(
                name: "AnimeSTitles");
        }
    }
}
