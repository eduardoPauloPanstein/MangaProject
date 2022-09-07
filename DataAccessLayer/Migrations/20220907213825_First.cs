using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MangasRatingFrequencies",
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
                    table.PrimaryKey("PK_MangasRatingFrequencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MangaTitles",
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
                    table.PrimaryKey("PK_MangaTitles", x => x.Id);
                });

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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FavoritesCount = table.Column<int>(type: "int", nullable: false),
                    ReviewsCount = table.Column<int>(type: "int", nullable: false),
                    AvatarImageFileLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoverImageFileLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KeepLogged = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mangas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Synopsis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitlesId = table.Column<int>(type: "int", nullable: true),
                    CanonicalTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AverageRating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RatingFrequenciesId = table.Column<int>(type: "int", nullable: true),
                    RatingRank = table.Column<int>(type: "int", nullable: true),
                    PopularityRank = table.Column<int>(type: "int", nullable: true),
                    UserCount = table.Column<int>(type: "int", nullable: true),
                    FavoritesCount = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgeRating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgeRatingGuide = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    VolumeCount = table.Column<int>(type: "int", nullable: true),
                    Serialization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PosterImageLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverImageLink = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mangas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mangas_MangasRatingFrequencies_RatingFrequenciesId",
                        column: x => x.RatingFrequenciesId,
                        principalTable: "MangasRatingFrequencies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Mangas_MangaTitles_TitlesId",
                        column: x => x.TitlesId,
                        principalTable: "MangaTitles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserMangaItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MangaId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalRereads = table.Column<int>(type: "int", nullable: false),
                    Chapter = table.Column<int>(type: "int", nullable: false),
                    Volume = table.Column<int>(type: "int", nullable: false),
                    PrivateNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Private = table.Column<bool>(type: "bit", nullable: false),
                    Favorite = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMangaItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMangaItem_Mangas_MangaId",
                        column: x => x.MangaId,
                        principalTable: "Mangas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMangaItem_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mangas_RatingFrequenciesId",
                table: "Mangas",
                column: "RatingFrequenciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Mangas_TitlesId",
                table: "Mangas",
                column: "TitlesId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMangaItem_MangaId",
                table: "UserMangaItem",
                column: "MangaId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMangaItem_UserId",
                table: "UserMangaItem",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserMangaItem");

            migrationBuilder.DropTable(
                name: "Mangas");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "MangasRatingFrequencies");

            migrationBuilder.DropTable(
                name: "MangaTitles");
        }
    }
}
