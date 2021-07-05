using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Registro.Respuestas.Commands.Create;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Registro.Models;

namespace WordVision.ec.Web.Areas.Registro.Controllers
{
    [Area("Registro")]
    [Authorize]
    public class RespuestaController : BaseController<RespuestaController>
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(int id, RespuestaViewModel respuesta)
        {
            if (ModelState.IsValid)
            {

                if (id == 0)
                {
                    var createBrandCommand = _mapper.Map<CreateRespuestaCommand>(respuesta);
                    var result = await _mediator.Send(createBrandCommand);
                    if (result.Succeeded)
                    {
                        id = result.Data;
                        _notify.Success($"Respuesta con ID {result.Data} creado.");
                    }
                    else _notify.Error(result.Message);
                }
                //else
                //{
                //    var updateBrandCommand = _mapper.Map<UpdateColaboradorCommand>(colaborador);
                //    var result = await _mediator.Send(updateBrandCommand);
                //    if (result.Succeeded) _notify.Information($"Colaborador con ID {result.Data} actualizado.");
                //    else _notify.Error(result.Message);
                //}
                return new JsonResult(new { isValid = true });
                //var response = await _mediator.Send(new GetAllColaboradoresCachedQuery());
                //if (response.Succeeded)
                //{
                //    var viewModel = _mapper.Map<List<ColaboradorViewModel>>(response.Data);
                //    var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                //    return new JsonResult(new { isValid = true, html = html });
                //}
                //else
                //{
                //    _notify.Error(response.Message);
                //    return null;
                //}
            }
            else
            {
                var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", respuesta);
                return new JsonResult(new { isValid = false, html = html });
            }
        }
    }
}
