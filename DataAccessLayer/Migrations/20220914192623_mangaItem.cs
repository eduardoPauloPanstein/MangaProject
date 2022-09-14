using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class mangaItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMangaItem_Users_UserId",
                table: "UserMangaItem");

            migrationBuilder.CreateIndex(
                name: "IX_UserMangaItem_MangaId",
                table: "UserMangaItem",
                column: "MangaId");

            migrationBuilder.AddForeignKey(
                name: "fk_mangauser",
                table: "UserMangaItem",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMangaItem_Mangas_MangaId",
                table: "UserMangaItem",
                column: "MangaId",
                principalTable: "Mangas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_mangauser",
                table: "UserMangaItem");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMangaItem_Mangas_MangaId",
                table: "UserMangaItem");

            migrationBuilder.DropIndex(
                name: "IX_UserMangaItem_MangaId",
                table: "UserMangaItem");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMangaItem_Users_UserId",
                table: "UserMangaItem",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
