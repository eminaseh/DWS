using Microsoft.EntityFrameworkCore.Migrations;

namespace Apoteka.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Kategorije",
                columns: new[] { "KategorijaId", "NazivKategorije", "OpisKategorije" },
                values: new object[] { 6, "Bez recepta", "Izdaje se bez ljekarskog recepta" });

            migrationBuilder.InsertData(
                table: "Kategorije",
                columns: new[] { "KategorijaId", "NazivKategorije", "OpisKategorije" },
                values: new object[] { 7, "Recept", "Izdaje se uz ljekarski recept" });

            migrationBuilder.InsertData(
                table: "Lijekovi",
                columns: new[] { "LijekId", "Cijena", "KategorijaId", "NaStanju", "NazivLijeka", "OblikLijeka", "PakovanjeLijeka", "Primjena" },
                values: new object[] { 1, 2.80m, 6, true, "Caffetin", "Tablete", "12 tableta", "Kratkotrajna terapija umjerene boli" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Kategorije",
                keyColumn: "KategorijaId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Lijekovi",
                keyColumn: "LijekId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Kategorije",
                keyColumn: "KategorijaId",
                keyValue: 6);
        }
    }
}
