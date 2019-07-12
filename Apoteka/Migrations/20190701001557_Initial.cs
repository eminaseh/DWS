using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Apoteka.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategorije",
                columns: table => new
                {
                    KategorijaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NazivKategorije = table.Column<string>(nullable: true),
                    OpisKategorije = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorije", x => x.KategorijaId);
                });

            migrationBuilder.CreateTable(
                name: "Uposlenici",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(maxLength: 50, nullable: false),
                    Prezime = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    RadnoMjesto = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uposlenici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lijekovi",
                columns: table => new
                {
                    LijekId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NazivLijeka = table.Column<string>(nullable: true),
                    OblikLijeka = table.Column<string>(nullable: true),
                    PakovanjeLijeka = table.Column<string>(nullable: true),
                    Cijena = table.Column<decimal>(nullable: false),
                    Primjena = table.Column<string>(nullable: true),
                    NaStanju = table.Column<bool>(nullable: false),
                    KategorijaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lijekovi", x => x.LijekId);
                    table.ForeignKey(
                        name: "FK_Lijekovi_Kategorije_KategorijaId",
                        column: x => x.KategorijaId,
                        principalTable: "Kategorije",
                        principalColumn: "KategorijaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lijekovi_KategorijaId",
                table: "Lijekovi",
                column: "KategorijaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lijekovi");

            migrationBuilder.DropTable(
                name: "Uposlenici");

            migrationBuilder.DropTable(
                name: "Kategorije");
        }
    }
}
