using Microsoft.EntityFrameworkCore.Migrations;

namespace Apoteka.Migrations
{
    public partial class SeedUposleniciTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Primjena",
                table: "Lijekovi",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PakovanjeLijeka",
                table: "Lijekovi",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OblikLijeka",
                table: "Lijekovi",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NazivLijeka",
                table: "Lijekovi",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Uposlenici",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Merjem", "Hodžić" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Primjena",
                table: "Lijekovi",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "PakovanjeLijeka",
                table: "Lijekovi",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "OblikLijeka",
                table: "Lijekovi",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "NazivLijeka",
                table: "Lijekovi",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "Uposlenici",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Mjerjem", "Hodzic" });
        }
    }
}
