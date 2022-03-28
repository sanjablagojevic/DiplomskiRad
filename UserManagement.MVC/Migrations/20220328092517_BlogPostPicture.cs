using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.MVC.Migrations
{
    public partial class BlogPostPicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlogPostPicture",
                table: "Blog");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Blog",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Blog");

            migrationBuilder.AddColumn<string>(
                name: "BlogPostPicture",
                table: "Blog",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
