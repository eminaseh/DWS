using Apoteka.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apoteka.Components
{
    public class KategorijaMenu : ViewComponent
    {
        private readonly IKategorijaRepository _kategorijaRepository;

        public KategorijaMenu(IKategorijaRepository kategorijaRepository)
        {
            _kategorijaRepository = kategorijaRepository;
        }
        
        public IViewComponentResult Invoke()
        {
            var kategorije = _kategorijaRepository.Kategorije.OrderBy(e => e.NazivKategorije);
            return View(kategorije);
        }
    
}
}
