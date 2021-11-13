using Bz.ClassFinder.Attributes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Areas.Admin.Controllers
{
    [BzDescription("Admin")]
    public class HomeController : AdminController
    {
        [BzDescription("Dashboard")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
