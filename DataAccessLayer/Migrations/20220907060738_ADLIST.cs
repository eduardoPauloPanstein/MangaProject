using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class ADLIST : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MangaUser",
                columns: table => new
                {
                    MangaIDId = table.Column<int>(type: "int", nullable: false),
                    UserIDId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaUser", x => new { x.MangaIDId, x.UserIDId });
                    table.ForeignKey(
                        name: "FK_MangaUser_Mangas_MangaIDId",
                        column: x => x.MangaIDId,
                        principalTable: "Mangas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MangaUser_Users_UserIDId",
                        column: x => x.UserIDId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MangaUser_UserIDId",
                table: "MangaUser",
                column: "UserIDId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MangaUser");

            migrationBuilder.CreateTable(
                name: "UserToManga",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MangasId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToManga", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserToManga_Mangas_MangasId",
                        column: x => x.MangasId,
                        principalTable: "Mangas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserToManga_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserToManga_MangasId",
                table: "UserToManga",
                column: "MangasId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToManga_UsersId",
                table: "UserToManga",
                column: "UsersId");
        }
    }
}
