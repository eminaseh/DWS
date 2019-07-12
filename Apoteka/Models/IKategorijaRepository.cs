using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apoteka.Models
{
   public interface IKategorijaRepository
    {
        IEnumerable<Kategorija> Kategorije { get; }
        string vratiNazivKategorije(int KategorijaId);
        string vratiOpisKategorije(int KategorijaId);
    }
}
