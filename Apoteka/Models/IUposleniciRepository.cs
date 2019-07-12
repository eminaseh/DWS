using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apoteka.Models
{
    public interface IUposleniciRepository
    {
        Uposlenici vratiUposlenika(int id);
        IEnumerable<Uposlenici> vratiSveUposlenike();
        Uposlenici DodajUposlenika(Uposlenici uposlenik);
        Uposlenici Update(Uposlenici uposlenikUpdate);
        Uposlenici Delete(int id);
    }
}
