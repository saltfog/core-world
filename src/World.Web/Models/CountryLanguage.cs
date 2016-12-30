using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace World.Web.Models
{
    public class CountryLanguage
    {
        public string CountryCode { get; set; }
        public string Language { get; set; }
        public bool IsOfficial { get; set; }
        public float Percentage { get; set; }
    }
}
