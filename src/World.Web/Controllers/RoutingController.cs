using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace World.Web.Controllers
{
    //Attribute routing with Http[Verb] attributes
    [HttpGet("/products")]
    public IActionResult ListProducts()
    {
        // ...
    }

    [HttpPost("/products")]
    public IActionResult CreateProduct(...)
    {
        // ...
    }






    //Multiple Routes

    [Route("api/[controller]")]
    public class RoutingController : Controller
    {
        [HttpPut("Buy")]      // Matches PUT 'api/Products/Buy'
        [HttpPost("Checkout")] // Matches POST 'api/Products/Checkout'
        public IActionResult Buy();
    }

    [Route("Store")]
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        [HttpPost("Buy")]     // Matches 'Products/Buy' and 'Store/Buy'
        [HttpPost("Checkout")] // Matches 'Products/Checkout' and 'Store/Checkout'
        public IActionResult Buy();
    }

}
