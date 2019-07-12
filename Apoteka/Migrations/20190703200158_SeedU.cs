using Microsoft.EntityFrameworkCore.Migrations;

namespace Apoteka.Migrations
{
    public partial class SeedU : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Uposlenici",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Uposlenici",
                columns: new[] { "Id", "Email", "Ime", "Prezime", "RadnoMjesto", "Slika" },
                values: new object[] { 13, "emina@gmail.com", "Emina", "Šehbajraktarević", 2, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Uposlenici",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.InsertData(
                table: "Uposlenici",
                columns: new[] { "Id", "Email", "Ime", "Prezime", "RadnoMjesto", "Slika" },
                values: new object[] { 1, "emina@gmail.com", "Emina", "Šehbajraktarević", 2, null });
        }
    }
}
