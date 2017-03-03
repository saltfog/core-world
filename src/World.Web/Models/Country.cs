using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using World.Web.Models;

namespace World.Web.Models
{
    public class Country
    {
        public string code { get; set; }
        public string name { get; set; }
        public string continent { get; set; }
        public string region { get; set; }
        public int population { get; set; }
        public decimal lifeexpectancy { get; set; }
    }
}
