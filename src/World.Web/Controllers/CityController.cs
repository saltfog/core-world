using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace World.Web.Controllers
{
    public class CityController : Controller
    {
        private readonly Repository.Repository _repo;

        public CityController(IConfiguration configuration)
        {
            _repo = new Repository.Repository(configuration);
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(_repo.Cities());
        }
    }
}
