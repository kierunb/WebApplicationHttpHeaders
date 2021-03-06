﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebApplicationHttpHeaders.Repositories
{
    public interface IPersonRepository
    {
        string[] GetAll();
    }

    // proteza prawdziego repo, do test kontrolera w izolacji
    public class FakePersonRepository : IPersonRepository
    {
        public string[] GetAll()
        {
            return new string[] { "fake", "person", "data" };
        }
    }

    public class PersonRepository : IPersonRepository
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
