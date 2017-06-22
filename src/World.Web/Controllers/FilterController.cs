using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using World.Web.Repository;
using Microsoft.Extensions.Configuration;
using System.Threading;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace World.Web.Controllers
{
    public class FilterController : Controller
    {
        private readonly Repository.Repository _repo;

        public FilterController(IConfiguration configuration)
        {
            _repo = new Repository.Repository(configuration);
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("filter/world")]
        public IActionResult Filter()
        {
            var results = _repo.Filter();
            Thread.Sleep(8000);
            return Json(results);

        }
    }
}
