using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace World.Web.Models
{
    public class City
    {
        public int id { get; set; }
        public string name { get; set; }
        public string countrycode { get; set; }
        public string district { get; set; }
        public int population { get; set; }

        public IEnumerable<SelectListItem> Cities
        {
            get { return new SelectList("id", "name"); }
        }
    }
}
