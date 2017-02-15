using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace World.Web.Controllers
{
    public class LifeExpController : Controller
    {
        private readonly Repository.Repository _repo;

        public LifeExpController(IConfiguration configuration)
        {
            _repo = new Repository.Repository(configuration);
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("lifeexp/world")]
        public IActionResult Filter()
        {
            var results = _repo.LifeExp();
            return Json(results);
        }
    }
}
