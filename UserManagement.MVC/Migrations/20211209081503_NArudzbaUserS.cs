using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.MVC.Migrations
{
    public partial class NArudzbaUserS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_Radnik_RadnikId",
                table: "Narudzba");

            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_User_UserId1",
                table: "Narudzba");

            migrationBuilder.DropTable(
                name: "Radnik");

            migrationBuilder.DropIndex(
                name: "IX_Narudzba_RadnikId",
                table: "Narudzba");

            migrationBuilder.DropIndex(
                name: "IX_Narudzba_UserId1",
                table: "Narudzba");

            migrationBuilder.DropColumn(
                name: "RadnikId",
                table: "Narudzba");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Narudzba");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Narudzba",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_UserId",
                table: "Narudzba",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_User_UserId",
                table: "Narudzba",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_User_UserId",
                table: "Narudzba");

            migrationBuilder.DropIndex(
                name: "IX_Narudzba_UserId",
                table: "Narudzba");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Narudzba",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RadnikId",
                table: "Narudzba",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Narudzba",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Radnik",
                columns: table => new
                {
                    RadnikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojTelefonaRadnika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailRadnika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImePrezimeRadnika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlataRadnika = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radnik", x => x.RadnikId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_RadnikId",
                table: "Narudzba",
                column: "RadnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_UserId1",
                table: "Narudzba",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_Radnik_RadnikId",
                table: "Narudzba",
                column: "RadnikId",
                principalTable: "Radnik",
                principalColumn: "RadnikId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_User_UserId1",
                table: "Narudzba",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
