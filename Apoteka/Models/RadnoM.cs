using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Apoteka.Models
{
    public enum RadnoM
    {
        None,
        Direktor,
        [Display(Name = "Farmaceutski tehničar")]
        FarmaceutskiTehnicar,
        [Display(Name = "Magistar farmacije")]
        MagistarFarmacije
    }
}
