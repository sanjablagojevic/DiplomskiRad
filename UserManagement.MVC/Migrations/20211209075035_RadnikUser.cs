using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.MVC.Migrations
{
    public partial class RadnikUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Narudzba",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Narudzba",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_UserId1",
                table: "Narudzba",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_User_UserId1",
                table: "Narudzba",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_User_UserId1",
                table: "Narudzba");

            migrationBuilder.DropIndex(
                name: "IX_Narudzba_UserId1",
                table: "Narudzba");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Narudzba");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Narudzba");
        }
    }
}
