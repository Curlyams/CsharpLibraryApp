using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PractiveApplication_1.Migrations
{
    /// <inheritdoc />
    public partial class borrowDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BorrowDate",
                table: "Books",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BorrowDate",
                table: "Books");
        }
    }
}
