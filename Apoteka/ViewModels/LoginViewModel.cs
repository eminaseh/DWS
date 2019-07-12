using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Apoteka.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Polje Email mora biti ispunjeno.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Polje lozinka mora biti ispunjeno.")]
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka")]
        public string Password { get; set; }

        [Display(Name = "Zapamti me")]
        public bool RememberMe { get; set; }
    }
}
