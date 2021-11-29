using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.MVC.Migrations
{
    public partial class KorisnikUtisak : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Utisak",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Utisak_UserId",
                table: "Utisak",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Utisak_User_UserId",
                table: "Utisak",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utisak_User_UserId",
                table: "Utisak");

            migrationBuilder.DropIndex(
                name: "IX_Utisak_UserId",
                table: "Utisak");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Utisak");
        }
    }
}
