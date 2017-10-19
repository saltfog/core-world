using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace World.Web.Controllers
{
    [Route("products")]
    public class ProductsApiController : Controller
    {
        [HttpGet]
        public IActionResult ListProducts()
        {
            LocalRedirect(ListProducts());
        }

        [HttpGet("{id}")]
        public ActionResult GetProduct(int id)
        {
            var id = 5;
            return id;
        }
    }

    [Route("")]      // Combines to define the route template "Home"
    [Route("Index")] // Combines to define the route template "Home/Index"
    [Route("/")]     // Does not combine, defines the route template ""
    public IActionResult Index()
    {
        ViewData["Message"] = "Home index";
        var url = Url.Action("Index", "Home");
        ViewData["Message"] = "Home index" + "var url = Url.Action; =  " + url;
        return View();
    }

    [Route("About")] // Combines to define the route template "Home/About"
    public IActionResult About()
    {
        return View();
    }
}
