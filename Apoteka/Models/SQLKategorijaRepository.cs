using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apoteka.Models
{
    public class SQLKategorijaRepository : IKategorijaRepository
    {
        private readonly AppDbContext context;

        public SQLKategorijaRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Kategorija> Kategorije => context.Kategorije;

        public string vratiNazivKategorije(int KategorijaId)
        {
            return context.Kategorije.Find(KategorijaId).NazivKategorije;
        }

        public string vratiOpisKategorije(int KategorijaId)
        {
            return context.Kategorije.Find(KategorijaId).OpisKategorije;
        }
    }
}
