using Apoteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apoteka.ViewModels
{
    public class HomeDeleteViewModel
    {
        public int Id { get; set; }
        public Uposlenici Uposlenik { get; set; }
        public string PageTitle { get; set; }
    }
}
