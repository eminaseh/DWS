using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apoteka.Models
{
    public interface ILijekRepository
    {
        IEnumerable<Lijek> Lijekovi { get; }
        Lijek VratiLijek(int lijekId);
        Lijek Add(Lijek lijek);
        Lijek Update(Lijek lijek);
        Lijek Delete(int id);
    }
}
