using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Web.Abstractions;

namespace WordVision.ec.Web.Areas.Dashboard.Controllers
{
    [Authorize]
    [Area("Dashboard")]
    public class HomeController : BaseController<HomeController>
    {
        public IActionResult Index()
        {
            _notify.Information("Bienvenidos!");
            return View();
        }
    }
}
