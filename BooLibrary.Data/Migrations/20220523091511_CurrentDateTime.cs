using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BooLibrary.Data.Migrations
{
    public partial class CurrentDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CurrentDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CurrentDate",
                table: "BooksCategory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CurrentDate",
                table: "Books",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentDate",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CurrentDate",
                table: "BooksCategory");

            migrationBuilder.DropColumn(
                name: "CurrentDate",
                table: "Books");
        }
    }
}
