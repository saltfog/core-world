using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using World.Web.Repository;
using Microsoft.Extensions.Configuration;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace World.Web.Controllers
{
    public class CityController : Controller
    {
        private readonly CityRepository _repo;

        public CityController(IConfiguration configuration)
        {
            _repo = new CityRepository(configuration);
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(_repo.GetAll());
        }

        public IActionResult Select()
        {
            return View(_repo.GetAll());
        }
    }
}
