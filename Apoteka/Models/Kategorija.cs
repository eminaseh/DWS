using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Apoteka.Models
{
    public class Kategorija
    {
        public int KategorijaId { get; set; }
       
        [MaxLength(50, ErrorMessage = "Kategorija ne može da sadrži više od 50 znakova.")]
        public string NazivKategorije { get; set; }
        
        [MaxLength(50, ErrorMessage = "Opis kategorije ne može da sadrži više od 50 znakova.")]
        public string OpisKategorije { get; set; }
        public List<Lijek> Lijekovi { get; set; }
    }
}
