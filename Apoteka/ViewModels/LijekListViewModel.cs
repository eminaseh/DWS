using Apoteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apoteka.ViewModels
{
    public class LijekListViewModel
    {
        public IEnumerable<Lijek> Lijekovi { get; set; }
        public string TrenutnaKategorija { get; set; }
    }
}
