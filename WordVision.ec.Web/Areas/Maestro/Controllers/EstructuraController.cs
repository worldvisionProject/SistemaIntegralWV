using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.Estructuras.Queries.GetAllCached;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Maestro.Controllers
{
    [Area("Maestro")]
    //[Authorize]
    public class EstructuraController : BaseController<EstructuraController>
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> LoadAll()
        {
            var response = await _mediator.Send(new GetAllEstructurasCachedQuery());
            if (response.Succeeded)
            {
                var viewModel = _mapper.Map<List<EstructuraViewModel>>(response.Data);
                return Json(viewModel);
            }
            return null;
        }
    }
}
