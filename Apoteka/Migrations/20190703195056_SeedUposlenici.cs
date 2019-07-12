using Microsoft.EntityFrameworkCore.Migrations;

namespace Apoteka.Migrations
{
    public partial class SeedUposlenici : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Uposlenici",
                keyColumn: "Id",
                keyValue: 2,
                column: "Prezime",
                value: "Šehbajraktarević");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Uposlenici",
                keyColumn: "Id",
                keyValue: 2,
                column: "Prezime",
                value: "Seh");
        }
    }
}
