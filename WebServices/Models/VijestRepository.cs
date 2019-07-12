using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServices.Models
{
    public class VijestRepository : IVijestRepository
    {
        private Dictionary<int, Vijest> items;
        public VijestRepository()
        {
            items = new Dictionary<int, Vijest>();
            new List<Vijest> {
                new Vijest {Id=1, Naslov= "Nova linija Thalgo proizvoda", Opis = "Thalgo kolekcija Marine je potpuno na bazi vode, prekrasno, svježe miriše i čak dok je nanosite osjetite lakoću proizvoda a u isto vrijeme instantnu duboku hidrataciju" },
                new Vijest {Id=2, Naslov = "Uz Ginkolin do bolje koncentracije", Opis = "Ginkolino su kapsule na prirodnoj bazi. Glavni sastojak ovih kapsula je biljka Ginko biloba. Ginko biloba pospješuje cirkulaciju krvi do mozga, a to utiče na pospješivanje pamćenja kao i smanjenje glavobolje." },
                new Vijest {Id=3, Naslov = "Uživanje u ljetu može početi", Opis = "Kupovinom proizvoda za zaštitu kože od sunca u vrijednosti od 20KM ili više, na poklon dobijate peškir za plažu." },
            }.ForEach(v => AddVijest(v));
        }

        public Vijest this[int id] => items.ContainsKey(id) ? items[id] : null;

        public IEnumerable<Vijest> Vijesti => items.Values;

        public Vijest AddVijest(Vijest vijest)
        {
            if (vijest.Id == 0)
            {
                int key = items.Count;
                while (items.ContainsKey(key)) { key++; };
                vijest.Id = key;
            }
            items[vijest.Id] = vijest;
            return vijest;
        }

        public void DeleteVijest(int id) => items.Remove(id);
        

        public Vijest UpdateVijest(Vijest vijest) => AddVijest(vijest);

    }
}
