using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationHttpHeaders.Controllers
{
    [ApiController, Route("[controller]")]
    public class TestController : ControllerBase
    {
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
    }
}
