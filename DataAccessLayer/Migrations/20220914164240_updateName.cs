using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class updateName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddForeignKey(
                name: "FK_UserMangaItem_Users_UserId",
                table: "UserMangaItem",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMangaItem_Users_UserId",
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
    }
}
