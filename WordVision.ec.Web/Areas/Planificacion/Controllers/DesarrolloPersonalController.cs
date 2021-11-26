using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Planificacion.Models;

namespace WordVision.ec.Web.Areas.Planificacion.Controllers
{
    [Area("Planificacion")]
    [Authorize]
    public class DesarrolloPersonalController : BaseController<DesarrolloPersonalController>
    {
        public IActionResult Index()
        {
            var model = new DesarrolloPersonalViewModel();

            return PartialView("_CreateOrEdit", model);
        }

    }
}
