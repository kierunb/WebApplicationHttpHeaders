using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WebApplicationHttpHeaders.Repositories;

namespace WebApplicationHttpHeaders.Controllers
{
    [ApiController, Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IMemoryCache cache;
        // cache jest per aplikacja

        public TestController(IMemoryCache cache)
        {
            this.cache = cache; // ten obiekt to SINGLETON
        }
        [HttpGet, Route("persons")]
        public ActionResult GetAllPersons()
        {
            var repo = new PersonRepository();

            var persons =
                cache.GetOrCreate<string[]>("persons", item => {
                    item.SlidingExpiration = TimeSpan.FromSeconds(30);    
                    return repo.GetAll(); 
                });
            // sliding expiration 
            // absolute expiration
            
            //var persons = repo.GetAll();
            return Ok(persons);
        }


        // chcemy zkeszować odpowiedz spod tego get'a przez 30 sek  
        [HttpGet, Route("cache30s")]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 30)]
        // wrzuc odpowiedz do cache dla kazdego uniklanego nagl. user-agent
        public ActionResult Cache30s()
        {
            string message = $"Czas z serwera: {DateTime.Now.ToLongTimeString()}";
            
            return Ok(message);
        }

        [HttpGet, Route("cache2")]
        [ResponseCache(Duration = 30, Location = ResponseCacheLocation.None, NoStore = true)]
        // sterowanie wartoscia naglowka http: Cache-Control
        public ActionResult Cache2()
        {
            string message = $"Czas z serwera: {DateTime.Now.ToLongTimeString()}";

            return Ok(message);
        }

        [HttpGet, Route("cache-profile")]
        [ResponseCache(CacheProfileName = "Default30")]
        public ActionResult CacheProfile()
        {
            string message = $"Czas z serwera: {DateTime.Now.ToLongTimeString()}";

            return Ok(message);
        }

        [HttpGet, Route("persons")]
        public ActionResult GetAllPersonsOld()
        {
            var repo = new PersonRepository();

            // byloby super wrzucic do cache kolekcje persons
            // in-memory cache -> skladujemy dane w pamieci procesu aplikacji
            // czyli robimy to z glowa

            // osobny temat to tzw. distrubted cache
            // czyli keszowanie danych w osobny procesie -> np. Redis

            // najpierw sprawdz czy dane sa w cache
            // jak sa to zwroc z cache
            // a jak nie, to pobierz z bazy
            // wrzuc do cache
            // i zwroc

            var persons = 
                cache.GetOrCreate<string[]>("persons", item => repo.GetAll());

            //var persons = repo.GetAll();

            return Ok(persons);
        }


    }
}
