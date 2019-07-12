using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apoteka.Models
{
    public class MockKategorijaRepository:IKategorijaRepository
    {

        public IEnumerable<Kategorija> Kategorije
        {
            get
            {
                return new List<Kategorija>
                {
                    new Kategorija{ KategorijaId=1, NazivKategorije = "Bez Recepta", OpisKategorije = "Lijekovi koji se izdaju bez ljekarskog recepta" },
                    new Kategorija{ KategorijaId=2, NazivKategorije = "Recept", OpisKategorije = "Lijekovi koji se izdaju uz ljekarski recept" }

                };
            }
        }

        public string vratiNazivKategorije(int KategorijaId)
        {
            throw new NotImplementedException();
        }

        public string vratiOpisKategorije(int KategorijaId)
        {
            throw new NotImplementedException();
        }
    }
}
