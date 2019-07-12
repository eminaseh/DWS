using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Apoteka.Migrations
{
    public partial class ExtendIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Drzava",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Grad",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumRodjenja",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatumRodjenja",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Drzava",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Grad",
                table: "AspNetUsers",
                nullable: true);
        }
    }
}
