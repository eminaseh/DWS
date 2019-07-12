using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Apoteka.Models
{
    public class Lijek
    {
        
        public int LijekId { get; set; }
        [Required(ErrorMessage = "Polje Naziv lijeka mora biti ispunjeno.")]
        [MaxLength(50, ErrorMessage = "Naziv lijeka ne može da sadrži više od 50 znakova.")]
        public string NazivLijeka { get; set; }
        [Required(ErrorMessage = "Polje Oblik lijeka mora biti ispunjeno.")]
        [MaxLength(50, ErrorMessage = "Oblik lijeka ne može da sadrži više od 50 znakova.")]
        public string OblikLijeka { get; set; }
        [Required(ErrorMessage = "Polje Pakovanje lijeka mora biti ispunjeno.")]
        [MaxLength(50, ErrorMessage = "Pakovanje lijeka ne može da sadrži više od 50 znakova.")]
        public string PakovanjeLijeka { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Cijena { get; set; }
        [Required(ErrorMessage = "Polje Primjena mora biti ispunjeno.")]
        [MaxLength(5000, ErrorMessage = "Primjena ne može da sadrži više od 5000 znakova.")]
        [MinLength(5)]
        public string Primjena { get; set; }
        public bool NaStanju { get; set; }
        public int KategorijaId { get; set; }
        public virtual Kategorija Kategorija { get; set; }
    }
}
