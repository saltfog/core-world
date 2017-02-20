using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace World.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly Repository.Repository _repo;

        public SearchController(IConfiguration configuration)
        {
            _repo = new Repository.Repository(configuration);
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("SearchCountry")]
        public IActionResult SearchCountry(string search)
        {
            var countries = _repo.SearchCountry(search);
            return Json(countries);
        }
    }
}
