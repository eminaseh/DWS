using Microsoft.EntityFrameworkCore.Migrations;

namespace Apoteka.Migrations
{
    public partial class UposleniciSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Uposlenici",
                columns: new[] { "Id", "Email", "Ime", "Prezime", "RadnoMjesto" },
                values: new object[] { 1, "merjem@gmail.com", "Mjerjem", "Hodzic", 1 });

            migrationBuilder.InsertData(
                table: "Uposlenici",
                columns: new[] { "Id", "Email", "Ime", "Prezime", "RadnoMjesto" },
                values: new object[] { 2, "emina@gmail.com", "Emina", "Seh", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Uposlenici",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Uposlenici",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
