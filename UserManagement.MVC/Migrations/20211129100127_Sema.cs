using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.MVC.Migrations
{
    public partial class Sema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Utisak",
                schema: "Identity",
                newName: "Utisak");

            migrationBuilder.RenameTable(
                name: "Usluga",
                schema: "Identity",
                newName: "Usluga");

            migrationBuilder.RenameTable(
                name: "UserTokens",
                schema: "Identity",
                newName: "UserTokens");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                schema: "Identity",
                newName: "UserRoles");

            migrationBuilder.RenameTable(
                name: "UserLogins",
                schema: "Identity",
                newName: "UserLogins");

            migrationBuilder.RenameTable(
                name: "UserClaims",
                schema: "Identity",
                newName: "UserClaims");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "Identity",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "RoleClaims",
                schema: "Identity",
                newName: "RoleClaims");

            migrationBuilder.RenameTable(
                name: "Role",
                schema: "Identity",
                newName: "Role");

            migrationBuilder.RenameTable(
                name: "Radnik",
                schema: "Identity",
                newName: "Radnik");

            migrationBuilder.RenameTable(
                name: "Placanje",
                schema: "Identity",
                newName: "Placanje");

            migrationBuilder.RenameTable(
                name: "Narudzba",
                schema: "Identity",
                newName: "Narudzba");

            migrationBuilder.RenameTable(
                name: "NacinPlacanja",
                schema: "Identity",
                newName: "NacinPlacanja");

            migrationBuilder.RenameTable(
                name: "Kategorija",
                schema: "Identity",
                newName: "Kategorija");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.RenameTable(
                name: "Utisak",
                newName: "Utisak",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Usluga",
                newName: "Usluga",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "UserTokens",
                newName: "UserTokens",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                newName: "UserRoles",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "UserLogins",
                newName: "UserLogins",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "UserClaims",
                newName: "UserClaims",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "User",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "RoleClaims",
                newName: "RoleClaims",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Role",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Radnik",
                newName: "Radnik",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Placanje",
                newName: "Placanje",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Narudzba",
                newName: "Narudzba",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "NacinPlacanja",
                newName: "NacinPlacanja",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Kategorija",
                newName: "Kategorija",
                newSchema: "Identity");
        }
    }
}
