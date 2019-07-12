using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Apoteka.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Polje Email mora biti ispunjeno.")]
        [EmailAddress]
        [Remote(action: "IsEmailInUse", controller:"Account")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Polje lozinka mora biti ispunjeno.")]
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potvrdi lozinku")]
        [Compare("Password", ErrorMessage = "Polja lozinka i potvrdi lozinku se ne podudaraju.")]
        public string ConfirmPassword { get; set; }

       

        [Display(Name = "Datum rođenja")]
        [DataType(DataType.Date)]
        public DateTime DatumRodjenja { get; set; }
    }
}
