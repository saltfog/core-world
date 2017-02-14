using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using World.Web.Models;

namespace World.Web.Repository
{
    public interface IRepository
    {
        List<City> GetAll();
        List<SelectListItem> GetSelectList();
        IEnumerable<FilterList> Get();
    }
}
