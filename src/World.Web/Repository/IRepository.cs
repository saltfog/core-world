using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using World.Web.Models;

namespace World.Web.Repository
{
    public interface IRepository
    {
        List<City> GetAll();
        List<SelectListItem> GetSelectList();
    }
}
