using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebApplicationHttpHeaders.Repositories
{
    public class PersonRepository
    {
        public string[] GetAll()
        {
            // pobieranie danych z bazy, ktore trwa "dlugo"
            Thread.Sleep(2000);
            
            string[] persons = { "Zenek", "Heniek", "Marysia" };

            return persons;
        }
    }
}
