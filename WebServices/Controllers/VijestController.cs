using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using WebServices.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebServices.Controllers
{
    [Route("api/[controller]")]
    public class VijestController : Controller
    {
        private readonly IVijestRepository vijestRepository;

        public VijestController(IVijestRepository vijestRepository)
        {
            this.vijestRepository = vijestRepository;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Vijest> Get() => vijestRepository.Vijesti;


        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Vijest Get(int id) => vijestRepository[id];


        //POST api/<controller>
        [HttpPost]
        public Vijest Post([FromBody]Vijest vijest) =>
            vijestRepository.AddVijest(new Vijest
            {
                Naslov = vijest.Naslov,
                Opis = vijest.Opis
            });




        // PUT api/<controller>/5
        [HttpPut]
        public Vijest Put([FromForm]Vijest vijest) => vijestRepository.UpdateVijest(vijest);


        [HttpPatch("{id}")]
        public StatusCodeResult Patch(int id, [FromBody]JsonPatchDocument<Vijest> patch)
        {
            Vijest vijest = Get(id);
            if (vijest != null)
            {
                patch.ApplyTo(vijest);
                return Ok();
            }
            return NotFound();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id) => vijestRepository.DeleteVijest(id);
        
    }
}
