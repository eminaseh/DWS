using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apoteka.Models
{
    public class MockLijekRepository : ILijekRepository
    {
        private readonly IKategorijaRepository _kategorijaRepository = new MockKategorijaRepository();
       
        public IEnumerable<Lijek> Lijekovi
        {
            get
            {
                return new List<Lijek>
                {
                    new Lijek
                    {
                        LijekId=1,
                        KategorijaId=1,
                        NazivLijeka = "Caffetin",
                        OblikLijeka = "Tablete",
                        PakovanjeLijeka = "12 tableta",
                        Cijena = 2.80M,
                        Primjena = "Kratkotrajna terapija umjerene boli",
                        NaStanju=true,
                        Kategorija = _kategorijaRepository.Kategorije.First(),


                    }
                };
            }
         }

        public Lijek Add(Lijek lijek)
        {
            throw new NotImplementedException();
        }

        public Lijek Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Lijek Update(Lijek lijek)
        {
            throw new NotImplementedException();
        }

        public Lijek VratiLijek(int lijekId)
        {
            throw new NotImplementedException();
        }
      
    }
}
