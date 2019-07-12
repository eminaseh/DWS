using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apoteka.Models
{
    public class MockUposleniciRepository : IUposleniciRepository
    {
        private List<Uposlenici> _uposleniciLista;
        public MockUposleniciRepository()
        {
            _uposleniciLista = new List<Uposlenici>()
            {
                new Uposlenici(){ Id = 1, Ime = "Mjerjem", Prezime = "Hodzic", Email = "merjem@gmail.com", RadnoMjesto = RadnoM.Direktor},
                new Uposlenici(){ Id = 2, Ime = "Emina", Prezime = "Seh", Email = "emina@gmail.com", RadnoMjesto = RadnoM.FarmaceutskiTehnicar}

               
            };
        }

        public Uposlenici Delete(int id)
        {
            Uposlenici uposlenik = _uposleniciLista.FirstOrDefault(e => e.Id == id);
            if(uposlenik != null)
            {
                _uposleniciLista.Remove(uposlenik);

            }
            return uposlenik;
        }

        public Uposlenici DodajUposlenika(Uposlenici uposlenik)
        {
            uposlenik.Id = _uposleniciLista.Max(e => e.Id) + 1;
            _uposleniciLista.Add(uposlenik);
            return uposlenik;
        }

        public Uposlenici Update(Uposlenici uposlenikUpdate)
        {
            Uposlenici uposlenik = _uposleniciLista.FirstOrDefault(e => e.Id == uposlenikUpdate.Id);
            if (uposlenik != null)
            {
                uposlenik.Ime = uposlenikUpdate.Ime;
                uposlenik.Prezime = uposlenikUpdate.Prezime;
                uposlenik.Email = uposlenikUpdate.Email;
                uposlenik.RadnoMjesto = uposlenikUpdate.RadnoMjesto;

            }
            return uposlenik;
        }

        public IEnumerable<Uposlenici> vratiSveUposlenike()
        {
            return _uposleniciLista;
        }

        public Uposlenici vratiUposlenika(int id)
        {
            return _uposleniciLista.FirstOrDefault(e => e.Id == id);
        }
    }
}
