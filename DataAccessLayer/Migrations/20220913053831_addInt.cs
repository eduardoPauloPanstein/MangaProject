using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class addInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMangaItem_Mangas_MangaId",
                table: "UserMangaItem");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMangaItem_Users_UserId",
                table: "UserMangaItem");

            migrationBuilder.DropIndex(
                name: "IX_UserMangaItem_MangaId",
                table: "UserMangaItem");

            migrationBuilder.RenameColumn(
                name: "MangaId",
                table: "UserMangaItem",
                newName: "User");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserMangaItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Manga",
                table: "UserMangaItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMangaItem_Users_UserId",
                table: "UserMangaItem",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMangaItem_Users_UserId",
                table: "UserMangaItem");

            migrationBuilder.DropColumn(
                name: "Manga",
                table: "UserMangaItem");

            migrationBuilder.RenameColumn(
                name: "User",
                table: "UserMangaItem",
                newName: "MangaId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserMangaItem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserMangaItem_MangaId",
                table: "UserMangaItem",
                column: "MangaId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMangaItem_Mangas_MangaId",
                table: "UserMangaItem",
                column: "MangaId",
                principalTable: "Mangas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
