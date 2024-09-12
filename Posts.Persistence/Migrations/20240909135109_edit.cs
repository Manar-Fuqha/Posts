using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Posts.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class edit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "Id",
                keyValue: new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"),
                column: "ImageUrl",
                value: "https://api.ManarFuqha.com/uploads/articles_bg.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "Id",
                keyValue: new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"),
                column: "ImageUrl",
                value: "https://api.khalidessaadani.com/uploads/articles_bg.jpg");
        }
    }
}
