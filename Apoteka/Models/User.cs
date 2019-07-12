using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Apoteka.Models
{
    public class User
    {

        
        [Required(ErrorMessage = "Polje Email mora biti ispunjeno.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Polje lozinka mora biti ispunjeno.")]
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka")]
        public string Password { get; set; }

        [Display(Name = "Datum rođenja")]
        [DataType(DataType.Date)]
        public DateTime DatumRodjenja { get; set; }
       
        
    }

   
}
