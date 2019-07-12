using Apoteka.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apoteka.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Uposlenici>().HasData(
   
                new Uposlenici
                {
                    Id = 13,
                    Ime = "Emina",
                    Prezime = "Šehbajraktarević",
                    Email = "emina@gmail.com",
                    RadnoMjesto = RadnoM.FarmaceutskiTehnicar
                }

                );

            modelBuilder.Entity<Kategorija>().HasData(

                new Kategorija
                {
                    KategorijaId = 6,
                    NazivKategorije = "Bez recepta",
                    OpisKategorije = "Izdaje se bez ljekarskog recepta"
                },

                 new Kategorija
                 {
                     KategorijaId = 7,
                     NazivKategorije = "Recept",
                     OpisKategorije = "Izdaje se uz ljekarski recept"
                 }

                );

            modelBuilder.Entity<Lijek>().HasData(

              new Lijek
              {
                  LijekId = 1,
                  NazivLijeka = "Caffetin",
                  OblikLijeka = "Tablete",
                  PakovanjeLijeka = "12 tableta",
                  Cijena = 2.80M,
                  Primjena = "Kratkotrajna terapija umjerene boli",
                  NaStanju = true,
                  KategorijaId = 6
                 
              },

              new Lijek
              {
                  LijekId = 2,
                  NazivLijeka = "Apaurin",
                  OblikLijeka = "Tablete",
                  PakovanjeLijeka = "10 tableta",
                  Cijena = 5M,
                  Primjena = "Ljekari propisuju Apaurin osobama sa simptomima anksioznosti, nemira i psihološke napetosti.",
                  NaStanju = true,
                  KategorijaId = 7

              }

              );

        }
    }
}
