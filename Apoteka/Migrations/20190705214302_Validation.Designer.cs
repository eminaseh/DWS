﻿// <auto-generated />
using Apoteka.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Apoteka.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190705214302_Validation")]
    partial class Validation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Apoteka.Models.Kategorija", b =>
                {
                    b.Property<int>("KategorijaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NazivKategorije")
                        .HasMaxLength(50);

                    b.Property<string>("OpisKategorije")
                        .HasMaxLength(50);

                    b.HasKey("KategorijaId");

                    b.ToTable("Kategorije");

                    b.HasData(
                        new
                        {
                            KategorijaId = 6,
                            NazivKategorije = "Bez recepta",
                            OpisKategorije = "Izdaje se bez ljekarskog recepta"
                        },
                        new
                        {
                            KategorijaId = 7,
                            NazivKategorije = "Recept",
                            OpisKategorije = "Izdaje se uz ljekarski recept"
                        });
                });

            modelBuilder.Entity("Apoteka.Models.Lijek", b =>
                {
                    b.Property<int>("LijekId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cijena")
                        .HasMaxLength(10);

                    b.Property<int>("KategorijaId");

                    b.Property<bool>("NaStanju");

                    b.Property<string>("NazivLijeka")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("OblikLijeka")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PakovanjeLijeka")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Primjena")
                        .IsRequired()
                        .HasMaxLength(1024);

                    b.HasKey("LijekId");

                    b.HasIndex("KategorijaId");

                    b.ToTable("Lijekovi");

                    b.HasData(
                        new
                        {
                            LijekId = 1,
                            Cijena = 2.80m,
                            KategorijaId = 6,
                            NaStanju = true,
                            NazivLijeka = "Caffetin",
                            OblikLijeka = "Tablete",
                            PakovanjeLijeka = "12 tableta",
                            Primjena = "Kratkotrajna terapija umjerene boli"
                        },
                        new
                        {
                            LijekId = 2,
                            Cijena = 5m,
                            KategorijaId = 7,
                            NaStanju = true,
                            NazivLijeka = "Apaurin",
                            OblikLijeka = "Tablete",
                            PakovanjeLijeka = "10 tableta",
                            Primjena = "Ljekari propisuju Apaurin osobama sa simptomima anksioznosti, nemira i psihološke napetosti."
                        });
                });

            modelBuilder.Entity("Apoteka.Models.Uposlenici", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("RadnoMjesto");

                    b.Property<string>("Slika");

                    b.HasKey("Id");

                    b.ToTable("Uposlenici");

                    b.HasData(
                        new
                        {
                            Id = 13,
                            Email = "emina@gmail.com",
                            Ime = "Emina",
                            Prezime = "Šehbajraktarević",
                            RadnoMjesto = 2
                        });
                });

            modelBuilder.Entity("Apoteka.Models.Lijek", b =>
                {
                    b.HasOne("Apoteka.Models.Kategorija", "Kategorija")
                        .WithMany("Lijekovi")
                        .HasForeignKey("KategorijaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
