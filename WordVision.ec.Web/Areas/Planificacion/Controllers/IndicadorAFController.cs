using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Planificacion.IndicadorAFes.Commands.Delete;
using WordVision.ec.Web.Abstractions;

namespace WordVision.ec.Web.Areas.Planificacion.Controllers
{
    [Area("Planificacion")]
    [Authorize]
    public class IndicadorAFController : BaseController<IndicadorAFController>
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> OnPostDelete(int id = 0)
        {
            var deleteCommand = await _mediator.Send(new DeleteIndicadorAFCommand { Id = id });
            if (deleteCommand.Succeeded)
            {
                _notify.Information($"Indicador Año Fiscal con Id {id} Eliminado.");
                return new JsonResult(new { isValid = true});
            }
            else
            {
                _notify.Error(deleteCommand.Message);
                return null;
            }
        }
    }
}
