using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BooLibrary.Data.Migrations
{
    public partial class removeColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BooksCategory_Books_bookId",
                table: "BooksCategory");

            migrationBuilder.DropIndex(
                name: "IX_BooksCategory_bookId",
                table: "BooksCategory");

            migrationBuilder.DropColumn(
                name: "BoodId",
                table: "BooksCategory");

            migrationBuilder.DropColumn(
                name: "bookId",
                table: "BooksCategory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BoodId",
                table: "BooksCategory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "bookId",
                table: "BooksCategory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BooksCategory_bookId",
                table: "BooksCategory",
                column: "bookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BooksCategory_Books_bookId",
                table: "BooksCategory",
                column: "bookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
