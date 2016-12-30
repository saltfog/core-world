using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using World.Web.Models;

namespace World.Web.Models
{
    public class Country
    {
        public string CountryCode { get; set; }
        public string Name { get; set; }
        public string Continent { get; set; }
        public string Region { get; set; }
    }
}
