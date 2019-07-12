using Microsoft.EntityFrameworkCore.Migrations;

namespace Apoteka.Migrations
{
    public partial class SeedLijek : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Lijekovi",
                columns: new[] { "LijekId", "Cijena", "KategorijaId", "NaStanju", "NazivLijeka", "OblikLijeka", "PakovanjeLijeka", "Primjena" },
                values: new object[] { 2, 5m, 7, true, "Apaurin", "Tablete", "10 tableta", "Ljekari propisuju Apaurin osobama sa simptomima anksioznosti, nemira i psihološke napetosti." });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lijekovi",
                keyColumn: "LijekId",
                keyValue: 2);
        }
    }
}
