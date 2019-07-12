using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Apoteka.Models
{
    public class Uposlenici

    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Polje Ime mora biti ispunjeno.")]
        [MaxLength(50, ErrorMessage = "Ime ne može da sadrži više od 50 znakova.") ]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Polje Prezime mora biti ispunjeno.")]
        [MaxLength(50, ErrorMessage = "Prezime ne može da sadrži više od 50 znakova.")]
        public string Prezime { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Polje Email mora biti ispunjeno.")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Nepravilan Email.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Polje Radno mjest mora biti ispunjeno.")]
        public RadnoM RadnoMjesto { get; set; }
        public string Slika { get; set; }
    }
}
