using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class initDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MangaTitles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    En = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    En_jp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    En_us = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ja_jp = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaTitles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RatingFrequencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _6 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _7 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _8 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _9 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating1 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingFrequencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MANGAS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Synopsis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitlesId = table.Column<int>(type: "int", nullable: false),
                    CanonicalTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AverageRating = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RatingFrequenciesId = table.Column<int>(type: "int", nullable: false),
                    RatingRank = table.Column<int>(type: "int", nullable: true),
                    PopularityRank = table.Column<int>(type: "int", nullable: false),
                    UserCount = table.Column<int>(type: "int", nullable: false),
                    FavoritesCount = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgeRating = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgeRatingGuide = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    VolumeCount = table.Column<int>(type: "int", nullable: false),
                    Serialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PosterImageLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoverImageLink = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MANGAS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MANGAS_MangaTitles_TitlesId",
                        column: x => x.TitlesId,
                        principalTable: "MangaTitles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MANGAS_RatingFrequencies_RatingFrequenciesId",
                        column: x => x.RatingFrequenciesId,
                        principalTable: "RatingFrequencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MANGAS_RatingFrequenciesId",
                table: "MANGAS",
                column: "RatingFrequenciesId");

            migrationBuilder.CreateIndex(
                name: "IX_MANGAS_TitlesId",
                table: "MANGAS",
                column: "TitlesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MANGAS");

            migrationBuilder.DropTable(
                name: "MangaTitles");

            migrationBuilder.DropTable(
                name: "RatingFrequencies");
        }
    }
}
