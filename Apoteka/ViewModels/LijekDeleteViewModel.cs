using Apoteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apoteka.ViewModels
{
    public class LijekDeleteViewModel
    {
        public Lijek Lijek { get; set; }
        public string PageTitle { get; set; }
        public string KategorijaLijeka { get; set; }
        public int KategorijaId { get; set; }
        public int Id { get; set; }

    }
}
