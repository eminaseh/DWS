using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Apoteka.Models;
using Apoteka.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace Apoteka.Controllers
{
    [Authorize(Roles = "Admin, Uposlenik")]
    public class HomeController : Controller

    {
        private readonly IUposleniciRepository _uposleniciRepository;
        private readonly IHostingEnvironment hostingEnvironment;
        

        public HomeController(IUposleniciRepository uposleniciRepository,
                                IHostingEnvironment hostingEnvironment)
        {
            _uposleniciRepository = uposleniciRepository;
            this.hostingEnvironment = hostingEnvironment;
            
        }
        
        [AllowAnonymous]
        public ViewResult Index()
        {
            var model =_uposleniciRepository.vratiSveUposlenike();
            return View(model);
        }

        [AllowAnonymous]
        public ViewResult Details(int? id)
        {
          
            Uposlenici uposlenik = _uposleniciRepository.vratiUposlenika(id.Value);

            if(uposlenik == null)
            {
                Response.StatusCode = 404;
                return View("UposleniciNotFound", id.Value);
            }

            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Uposlenik = uposlenik,
                PageTitle = "Detalji uposlenika"
            };
          
            return View(homeDetailsViewModel);
            
        }


        [HttpGet]
        public ViewResult Dodaj()
        {
            
            return View();
        }


        [HttpPost]
        public IActionResult Dodaj(UposleniciDodajViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);
                Uposlenici noviUposlenik = new Uposlenici
                {
                    Ime = model.Ime,
                    Prezime = model.Prezime,
                    Email = model.Email,
                    RadnoMjesto = model.RadnoMjesto,
                    Slika = uniqueFileName

                };

                _uposleniciRepository.DodajUposlenika(noviUposlenik);

                return RedirectToAction("details", new { id = noviUposlenik.Id });
            }

            return View();
        }


        [HttpGet]
        public ViewResult Edit(int id)
        {
            Uposlenici uposlenik = _uposleniciRepository.vratiUposlenika(id);

            UposleniciEditViewModel uposleniciEditViewModel = new UposleniciEditViewModel
            {
                Id = uposlenik.Id,
                Ime = uposlenik.Ime,
                Prezime = uposlenik.Prezime,
                Email = uposlenik.Email,
                RadnoMjesto = uposlenik.RadnoMjesto,
                ExistingPhotoPath = uposlenik.Slika
            };

            return View(uposleniciEditViewModel);
        }


        [HttpPost]    
        public IActionResult Edit(UposleniciEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Uposlenici uposlenik = _uposleniciRepository.vratiUposlenika(model.Id);
                uposlenik.Ime = model.Ime;
                uposlenik.Prezime = model.Prezime;
                uposlenik.Email = model.Email;
                uposlenik.RadnoMjesto = model.RadnoMjesto;
                if (model.Slika != null)
                {
                    if(model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath,
                             "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    uposlenik.Slika = UploadedFile(model);
                }

                _uposleniciRepository.Update(uposlenik);

                return RedirectToAction("index");
            }

            return View();
        }


        private string UploadedFile(UposleniciDodajViewModel model)
        {
            string uniqueFileName = null;
            if (model.Slika != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Slika.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Slika.CopyTo(fileStream);
                }

            }

            return uniqueFileName;
        }


  
        public IActionResult Delete(int id)
        {
            Uposlenici uposlenik = _uposleniciRepository.vratiUposlenika(id);

            HomeDeleteViewModel homeDeleteViewModel = new HomeDeleteViewModel()
            {
                Uposlenik = uposlenik,
                PageTitle = "Izbriši uposlenika",
            };

            return View(homeDeleteViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(HomeDeleteViewModel model)
        {
            Uposlenici uposlenik = _uposleniciRepository.vratiUposlenika(model.Id);


            _uposleniciRepository.Delete(uposlenik.Id);
            return RedirectToAction("index");

        }


        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
