using Microsoft.EntityFrameworkCore.Migrations;

namespace Apoteka.Migrations
{
    public partial class AddSlika : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slika",
                table: "Uposlenici",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slika",
                table: "Uposlenici");
        }
    }
}
