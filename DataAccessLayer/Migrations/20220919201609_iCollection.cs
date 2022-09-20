using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class iCollection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Mangas_MangaId",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Category_MangaId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "MangaId",
                table: "Category");

            migrationBuilder.CreateTable(
                name: "CategoryManga",
                columns: table => new
                {
                    CategoriaID = table.Column<int>(type: "int", nullable: false),
                    MangasIDId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryManga", x => new { x.CategoriaID, x.MangasIDId });
                    table.ForeignKey(
                        name: "FK_CategoryManga_Category_CategoriaID",
                        column: x => x.CategoriaID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryManga_Mangas_MangasIDId",
                        column: x => x.MangasIDId,
                        principalTable: "Mangas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryManga_MangasIDId",
                table: "CategoryManga",
                column: "MangasIDId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryManga");

            migrationBuilder.AddColumn<int>(
                name: "MangaId",
                table: "Category",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Category_MangaId",
                table: "Category",
                column: "MangaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Mangas_MangaId",
                table: "Category",
                column: "MangaId",
                principalTable: "Mangas",
                principalColumn: "Id");
        }
    }
}
