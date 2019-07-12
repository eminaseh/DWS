using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServices.Models
{
    public interface IVijestRepository
    {
        IEnumerable<Vijest> Vijesti { get; }
        Vijest this[int id] { get; }
        Vijest AddVijest(Vijest vijest);
        Vijest UpdateVijest(Vijest vijest);
        void DeleteVijest(int id);
    }
}
