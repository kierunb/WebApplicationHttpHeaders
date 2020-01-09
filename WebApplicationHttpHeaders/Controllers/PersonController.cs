using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplicationHttpHeaders.Repositories;

namespace WebApplicationHttpHeaders.Controllers
{
    
    // scenariusz:
    // bedziemy pisac test do akcji kontrollera
    // ale...
    // kontroler bedzie mial zaleznosc od repository
    // ktore komunikuje sie z baza
    // wiec bedziemy musieli zrobic protezę dla 
    // repozytorium zeby moc przetestowac kontroler 
    // w izolacji... i tutaj uzyjemy MoQ
    
    [ApiController, Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository repository;

        public PersonController(IPersonRepository repository)
        {
            this.repository = repository;
        }

        
        [HttpGet, Route("{id:int}")]
        public ActionResult GetPersonById(int id)
        {
            var person = this.repository.GetAll().FirstOrDefault();
            return Ok(person);
        }

    }
}
