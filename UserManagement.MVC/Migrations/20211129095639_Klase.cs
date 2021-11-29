using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.MVC.Migrations
{
    public partial class Klase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategorija",
                schema: "Identity",
                columns: table => new
                {
                    KategorijaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivKategorije = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorija", x => x.KategorijaId);
                });

            migrationBuilder.CreateTable(
                name: "NacinPlacanja",
                schema: "Identity",
                columns: table => new
                {
                    NacinPlacanjaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivNacinaPlacanja = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NacinPlacanja", x => x.NacinPlacanjaId);
                });

            migrationBuilder.CreateTable(
                name: "Radnik",
                schema: "Identity",
                columns: table => new
                {
                    RadnikId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImePrezimeRadnika = table.Column<string>(nullable: true),
                    BrojTelefonaRadnika = table.Column<string>(nullable: true),
                    EmailRadnika = table.Column<string>(nullable: true),
                    PlataRadnika = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radnik", x => x.RadnikId);
                });

            migrationBuilder.CreateTable(
                name: "Utisak",
                schema: "Identity",
                columns: table => new
                {
                    UtisakId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ocjena = table.Column<decimal>(nullable: false),
                    Komentar = table.Column<string>(nullable: true),
                    Kreirano = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utisak", x => x.UtisakId);
                });

            migrationBuilder.CreateTable(
                name: "Usluga",
                schema: "Identity",
                columns: table => new
                {
                    UslugaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategorijaId = table.Column<int>(nullable: true),
                    NazivUsluge = table.Column<string>(nullable: true),
                    CijenaUsluge = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usluga", x => x.UslugaId);
                    table.ForeignKey(
                        name: "FK_Usluga_Kategorija_KategorijaId",
                        column: x => x.KategorijaId,
                        principalSchema: "Identity",
                        principalTable: "Kategorija",
                        principalColumn: "KategorijaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Narudzba",
                schema: "Identity",
                columns: table => new
                {
                    NarudzbaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UslugaId = table.Column<int>(nullable: true),
                    RadnikId = table.Column<int>(nullable: true),
                    AdresaNarudzbe = table.Column<string>(nullable: true),
                    DatumNarudzbe = table.Column<DateTime>(nullable: false),
                    VrijemePocetka = table.Column<DateTime>(nullable: true),
                    VrijemeKraja = table.Column<DateTime>(nullable: true),
                    NarudzbaPotvrdjena = table.Column<bool>(nullable: true),
                    EmailNarucioca = table.Column<string>(nullable: true),
                    BrojTelefonaNarucioca = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narudzba", x => x.NarudzbaId);
                    table.ForeignKey(
                        name: "FK_Narudzba_Radnik_RadnikId",
                        column: x => x.RadnikId,
                        principalSchema: "Identity",
                        principalTable: "Radnik",
                        principalColumn: "RadnikId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Narudzba_Usluga_UslugaId",
                        column: x => x.UslugaId,
                        principalSchema: "Identity",
                        principalTable: "Usluga",
                        principalColumn: "UslugaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Placanje",
                schema: "Identity",
                columns: table => new
                {
                    PlacanjeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NacinPlacanjaId = table.Column<int>(nullable: true),
                    NarudzbaId = table.Column<int>(nullable: true),
                    IznosPlacanja = table.Column<decimal>(nullable: false),
                    CreditCardNumber = table.Column<string>(nullable: true),
                    CreditCaredExpDate = table.Column<DateTime>(nullable: true),
                    CreditHolderName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Placanje", x => x.PlacanjeId);
                    table.ForeignKey(
                        name: "FK_Placanje_NacinPlacanja_NacinPlacanjaId",
                        column: x => x.NacinPlacanjaId,
                        principalSchema: "Identity",
                        principalTable: "NacinPlacanja",
                        principalColumn: "NacinPlacanjaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Placanje_Narudzba_NarudzbaId",
                        column: x => x.NarudzbaId,
                        principalSchema: "Identity",
                        principalTable: "Narudzba",
                        principalColumn: "NarudzbaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_RadnikId",
                schema: "Identity",
                table: "Narudzba",
                column: "RadnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_UslugaId",
                schema: "Identity",
                table: "Narudzba",
                column: "UslugaId");

            migrationBuilder.CreateIndex(
                name: "IX_Placanje_NacinPlacanjaId",
                schema: "Identity",
                table: "Placanje",
                column: "NacinPlacanjaId");

            migrationBuilder.CreateIndex(
                name: "IX_Placanje_NarudzbaId",
                schema: "Identity",
                table: "Placanje",
                column: "NarudzbaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usluga_KategorijaId",
                schema: "Identity",
                table: "Usluga",
                column: "KategorijaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Placanje",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Utisak",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "NacinPlacanja",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Narudzba",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Radnik",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Usluga",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Kategorija",
                schema: "Identity");
        }
    }
}
