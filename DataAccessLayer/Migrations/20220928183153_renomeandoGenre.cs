using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class renomeandoGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryManga_Category_CategoriaID",
                table: "CategoryManga");

            migrationBuilder.RenameColumn(
                name: "CategoriaID",
                table: "CategoryManga",
                newName: "GenresID");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryManga_Category_GenresID",
                table: "CategoryManga",
                column: "GenresID",
                principalTable: "Category",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryManga_Category_GenresID",
                table: "CategoryManga");

            migrationBuilder.RenameColumn(
                name: "GenresID",
                table: "CategoryManga",
                newName: "CategoriaID");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryManga_Category_CategoriaID",
                table: "CategoryManga",
                column: "CategoriaID",
                principalTable: "Category",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
