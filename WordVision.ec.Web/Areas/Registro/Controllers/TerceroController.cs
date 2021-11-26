using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Registro.Formularios.Queries.GetById;
using WordVision.ec.Application.Features.Registro.Terceros.Commands.Create;
using WordVision.ec.Application.Features.Registro.Terceros.Commands.Update;
using WordVision.ec.Application.Features.Registro.Terceros.Queries.GetById;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Registro.Models;

namespace WordVision.ec.Web.Areas.Registro.Controllers
{
    [Area("Registro")]
    [Authorize]
    public class TerceroController : BaseController<TerceroController>
    {
        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0, int idFormulario = 0)
        {
            var response = await _mediator.Send(new GetTerceroByIdFormularioQuery() { Id = id });
            if (response.Succeeded)
            {
                var terceroViewModel = new TerceroViewModel();
                terceroViewModel.idFormulario = idFormulario;
                if (response.Data != null)
                    terceroViewModel = _mapper.Map<TerceroViewModel>(response.Data);

                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", terceroViewModel) });
            }
            return null;

        }




        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(int id, TerceroViewModel tercero)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    var createTerceroCommand = _mapper.Map<CreateTerceroCommand>(tercero);
                    var result = await _mediator.Send(createTerceroCommand);
                    if (result.Succeeded)
                    {
                        id = result.Data;
                        _notify.Success($"Tercero con ID {result.Data} Creado.");
                    }
                    else _notify.Error(result.Message);
                }
                else
                {
                    var updateBrandCommand = _mapper.Map<UpdateTerceroCommand>(tercero);
                    var result = await _mediator.Send(updateBrandCommand);
                    if (result.Succeeded) _notify.Information($"Tercero con ID  {result.Data} Actualizado.");
                }
                var response = await _mediator.Send(new GetFormularioByIdQuery() { Id = id });
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<FormularioViewModel>>(response.Data);
                    var html = await _viewRenderer.RenderViewToStringAsync("Formulario/_ViewAll", viewModel);
                    return new JsonResult(new { isValid = true, html = html });
                }
                else
                {
                    _notify.Error(response.Message);
                    return null;
                }
            }
            else
            {
                var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", tercero);
                return new JsonResult(new { isValid = false, html = html });
            }
        }
    }



}
