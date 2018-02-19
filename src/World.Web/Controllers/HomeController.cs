using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Kendo.Mvc.Extensions;
using World.Web.Models;

namespace World.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly Repository.Repository _repo;

        public HomeController(IConfiguration configuration)
        {
            _repo = new Repository.Repository(configuration);
        }

        public IActionResult Index()
        {
            return View(_repo.GetSummary());
        }

        public ViewResult List()
        {
            return View(_repo.TotalCountries());
        }

        public IActionResult KOAdvanced()
        {
            return View();
        }
    }
}
