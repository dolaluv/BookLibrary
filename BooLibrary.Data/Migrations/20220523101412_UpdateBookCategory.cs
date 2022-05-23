using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BooLibrary.Data.Migrations
{
    public partial class UpdateBookCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "BooksCategory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BooksCategory_BookId",
                table: "BooksCategory",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BooksCategory_Books_BookId",
                table: "BooksCategory",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BooksCategory_Books_BookId",
                table: "BooksCategory");

            migrationBuilder.DropIndex(
                name: "IX_BooksCategory_BookId",
                table: "BooksCategory");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "BooksCategory");
        }
    }
}
