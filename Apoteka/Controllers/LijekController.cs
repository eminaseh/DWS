using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apoteka.Models;
using Apoteka.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Apoteka.Controllers
{
    [Authorize(Roles = "Admin, Uposlenik")]
    public class LijekController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILijekRepository _lijekRepository;
        private readonly IKategorijaRepository _kategorijaRepository;

        public LijekController(AppDbContext context, IKategorijaRepository kategorijaRepository, ILijekRepository lijekRepository)
        {
            _context = context;
            _lijekRepository = lijekRepository;
            _kategorijaRepository = kategorijaRepository;

        }



        [AllowAnonymous]
        public ViewResult Search(string searchString)
        {
            string _searchString = searchString;
            IEnumerable<Lijek> lijekovi;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(_searchString))
            {
                lijekovi = _lijekRepository.Lijekovi.OrderBy(p => p.LijekId);
            }
            else
            {
                lijekovi = _lijekRepository.Lijekovi.Where(p => p.NazivLijeka.ToLower().Contains(_searchString.ToLower()));
            }

            return View("~/Views/Lijek/List.cshtml", new LijekListViewModel { Lijekovi = lijekovi, TrenutnaKategorija = "Svi lijekovi" });
        }


        [AllowAnonymous]
        public ViewResult List(string kategorija, string searchString)
        {
            string _kategorija = kategorija;
            IEnumerable<Lijek> lijekovi;
            string trenutnaKategorija = string.Empty;

            if (string.IsNullOrEmpty(kategorija))
            {
                lijekovi = _lijekRepository.Lijekovi.OrderBy(n => n.LijekId);
                trenutnaKategorija = "Svi lijekovi";
            }
            else
            {
                if (string.Equals("Bez recepta", _kategorija, StringComparison.OrdinalIgnoreCase))
                {
                    lijekovi = _lijekRepository.Lijekovi.Where(e => e.Kategorija.NazivKategorije.Equals("Bez recepta")).OrderBy(e => e.NazivLijeka);

                }
                else
                    lijekovi = _lijekRepository.Lijekovi.Where(e => e.Kategorija.NazivKategorije.Equals("Recept")).OrderBy(e => e.NazivLijeka);

                trenutnaKategorija = _kategorija;
            }

            var lijekListViewModel = new LijekListViewModel
            {
                Lijekovi = lijekovi,
                TrenutnaKategorija = trenutnaKategorija
            };


            return View(lijekListViewModel);
        }


        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create([Bind("LijekId,NazivLijeka,OblikLijeka,PakovanjeLijeka,Cijena,Primjena,NaStanju,KategorijaId")] Lijek lijek)
        {
            KategorijeDropDownList(lijek.KategorijaId);
            Lijek noviLijek = _lijekRepository.Add(lijek);

            return RedirectToAction("details", new { id = noviLijek.LijekId });
        }

        
        private void KategorijeDropDownList(object selectedKategorija)
        {
            var kategorijaQuery = from d in _context.Kategorije
                                  select d;
            ViewBag.KategorijaId = new SelectList(kategorijaQuery, "KategorijaId", "NazivKategorije", selectedKategorija);
        }

        [AllowAnonymous]
        public ViewResult Details(int? id)
        {
            Lijek lijek = _lijekRepository.VratiLijek(id.Value);

            if (lijek == null)
            {
                Response.StatusCode = 404;
                return View("LijekNotFound", id.Value);
            }

            LijekDetailsViewModel lijekDetailsViewModel = new LijekDetailsViewModel()
            {
                Lijek = lijek,
                PageTitle = "Detalji lijeka",
                KategorijaLijeka = _kategorijaRepository.vratiOpisKategorije(_lijekRepository.VratiLijek(id ?? 1).KategorijaId)

            };

            return View(lijekDetailsViewModel);
        }


        [HttpGet]
        public ViewResult Edit(int id)
        {
            Lijek lijek = _lijekRepository.VratiLijek(id);

            LijekEditViewModel lijekEditViewModel = new LijekEditViewModel
            {
                Id = lijek.LijekId,
                NazivLijeka = lijek.NazivLijeka,
                OblikLijeka = lijek.OblikLijeka,
                PakovanjeLijeka = lijek.PakovanjeLijeka,
                Cijena = lijek.Cijena,
                NaStanju = lijek.NaStanju,
                Primjena = lijek.Primjena,
                KategorijaId = lijek.KategorijaId
            };

            return View(lijekEditViewModel);
        }


        [HttpPost]
        public IActionResult Edit(LijekEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Lijek lijek = _lijekRepository.VratiLijek(model.Id);
               
                lijek.NazivLijeka = model.NazivLijeka;
                lijek.OblikLijeka = model.OblikLijeka;
                lijek.PakovanjeLijeka = model.PakovanjeLijeka;
                lijek.Cijena = model.Cijena;
                lijek.NaStanju = model.NaStanju;
                lijek.Primjena = model.Primjena;
                lijek.KategorijaId = model.KategorijaId;

                _lijekRepository.Update(lijek);
                return RedirectToAction("list");
            }

            return View();
        }



        public IActionResult Delete(int id)
        {
            Lijek lijek = _lijekRepository.VratiLijek(id);

            LijekDeleteViewModel lijekDeleteViewModel = new LijekDeleteViewModel()
            {
                Lijek = lijek,
                PageTitle = "Izbriši lijek",
                KategorijaLijeka = _kategorijaRepository.vratiOpisKategorije(_lijekRepository.VratiLijek(id).KategorijaId)
            };

            return View(lijekDeleteViewModel);
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(LijekDeleteViewModel model)
        {
            Lijek lijek = _lijekRepository.VratiLijek(model.Id);
            _lijekRepository.Delete(lijek.LijekId);
            return RedirectToAction("list");
        }


       
    }
}