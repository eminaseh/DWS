using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Apoteka.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace Apoteka.Controllers
{
    [Authorize (Roles = "Admin , Uposlenik")]
    public class NovostiController : Controller
    {
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            List<Vijest> vijestList = new List<Vijest>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:1876/api/Vijest"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    vijestList = JsonConvert.DeserializeObject<List<Vijest>>(apiResponse);
                }
            }
            return View(vijestList);
        }
        [AllowAnonymous]
        public ViewResult GetVijest() => View();

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> GetVijest(int id)
        {
            Vijest vijest = new Vijest();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:1876/api/Vijest/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    vijest = JsonConvert.DeserializeObject<Vijest>(apiResponse);
                }
            }
            return View(vijest);
        }


        public ViewResult AddVijest() => View();

        [HttpPost]
        public async Task<IActionResult> AddVijest(Vijest vijest)
        {
            Vijest receivedVijest = new Vijest();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(vijest), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("http://localhost:1876/api/Vijest", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    receivedVijest = JsonConvert.DeserializeObject<Vijest>(apiResponse);
                }
            }
            return View(receivedVijest);
        }


        public async Task<IActionResult> UpdateVijest(int id)
        {
            Vijest vijest = new Vijest();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:1876/api/Vijest/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    vijest = JsonConvert.DeserializeObject<Vijest>(apiResponse);
                }
            }
            return View(vijest);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateVijest(Vijest vijest)
        {
            Vijest receivedVijest = new Vijest();
            using (var httpClient = new HttpClient())
            {
                var content = new MultipartFormDataContent();
                content.Add(new StringContent(vijest.Id.ToString()), "Id");
                content.Add(new StringContent(vijest.Naslov), "Naslov");
                content.Add(new StringContent(vijest.Opis), "Opis");
                

                using (var response = await httpClient.PutAsync("http://localhost:1876/api/Vijest", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    receivedVijest = JsonConvert.DeserializeObject<Vijest>(apiResponse);
                }
            }
            return View(receivedVijest);
        }




        [HttpPost]
        public async Task<IActionResult> DeleteVijest(int VijestId)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://localhost:1876/api/Vijest/" + VijestId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateVijestPatch(int id)
        {
            Vijest vijest = new Vijest();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:1876/api/Vijest/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    vijest = JsonConvert.DeserializeObject<Vijest>(apiResponse);
                }
            }
            return View(vijest);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateVijestPatch(int id, Vijest vijest)
        {
            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri("http://localhost:1876/api/Vijest/" + id),
                    Method = new HttpMethod("Patch"),
                    Content = new StringContent("[{ \"op\": \"replace\", \"path\": \"Naslov\", \"value\": \"" + vijest.Naslov + "\"}," +
                    "{ \"op\": \"replace\", \"path\":\"Opis\", \"value\": \"" + vijest.Opis + "\"}]", Encoding.UTF8, "application/json")
                };

                var response = await httpClient.SendAsync(request);
            }
            return RedirectToAction("Index");
        }


    }
}