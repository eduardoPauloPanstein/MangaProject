using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class chaptercount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccessCount",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AccessUserId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastAccess",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "AccessCount",
                table: "UserAnimeItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AccessUserId",
                table: "UserAnimeItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "UserAnimeItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "UserAnimeItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastAccess",
                table: "UserAnimeItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ChapterCount",
                table: "Mangas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "subtype",
                table: "Mangas",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AccessUserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastAccess",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AccessCount",
                table: "UserAnimeItem");

            migrationBuilder.DropColumn(
                name: "AccessUserId",
                table: "UserAnimeItem");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "UserAnimeItem");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "UserAnimeItem");

            migrationBuilder.DropColumn(
                name: "LastAccess",
                table: "UserAnimeItem");

            migrationBuilder.DropColumn(
                name: "ChapterCount",
                table: "Mangas");

            migrationBuilder.DropColumn(
                name: "subtype",
                table: "Mangas");
        }
    }
}
