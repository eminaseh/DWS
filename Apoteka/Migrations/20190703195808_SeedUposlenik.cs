using Microsoft.EntityFrameworkCore.Migrations;

namespace Apoteka.Migrations
{
    public partial class SeedUposlenik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Uposlenici",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Uposlenici",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Ime", "Prezime", "RadnoMjesto" },
                values: new object[] { "emina@gmail.com", "Emina", "Šehbajraktarević", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Uposlenici",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Ime", "Prezime", "RadnoMjesto" },
                values: new object[] { "merjem@gmail.com", "Merjem", "Hodžić", 1 });

            migrationBuilder.InsertData(
                table: "Uposlenici",
                columns: new[] { "Id", "Email", "Ime", "Prezime", "RadnoMjesto", "Slika" },
                values: new object[] { 2, "emina@gmail.com", "Emina", "Šehbajraktarević", 2, null });
        }
    }
}
