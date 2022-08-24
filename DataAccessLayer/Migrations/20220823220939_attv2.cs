﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class attv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarImage",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CoverImage",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "AvatarImageFileLocation",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CoverImageFileLocation",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarImageFileLocation",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CoverImageFileLocation",
                table: "Users");

            migrationBuilder.AddColumn<byte[]>(
                name: "AvatarImage",
                table: "Users",
                type: "image",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "CoverImage",
                table: "Users",
                type: "image",
                nullable: true);
        }
    }
}
