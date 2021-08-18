using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.TechoPresupuestarios.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.TechoPresupuestarios.Commands.Delete;
using WordVision.ec.Application.Features.Planificacion.TechoPresupuestarios.Commands.Update;
using WordVision.ec.Application.Features.Planificacion.TechoPresupuestarios.Queries.GetById;
using WordVision.ec.Application.Features.Registro.TechoPresupuestarios.Queries.GetAllCached;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Planificacion.Models;

namespace WordVision.ec.Web.Areas.Planificacion.Controllers
{
    [Area("Planificacion")]
    [Authorize]
    public class TechoPresupuestarioController : BaseController<RecursoController>
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> LoadAll()
        {
            try
            {
                var response = await _mediator.Send(new GetAllTechoPresupuestariosQuery());
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<TechoPresupuestarioViewModel>>(response.Data);

                    return PartialView("_ViewAll", viewModel);

                }
            }
            catch (Exception ex)
            {
                _logger.LogError("LoadxActividades", ex);
                _notify.Error("Error al consultar LoadxActividades");
            }
            return null;
        }
        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0)
        {

            if (id == 0)
            {
                var entidadViewModel = new TechoPresupuestarioViewModel();
               
                var catCentroCosto = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 14 });
                entidadViewModel.CentroCostosList = new SelectList(catCentroCosto.Data, "Secuencia", "Nombre");
                
                return new JsonResult(new { isValid = true, hijo = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
            }
            else
            {
                var response = await _mediator.Send(new GetTechoPresupuestarioById() { Id = id });
                if (response.Succeeded)
                {
                    var entidadViewModel = _mapper.Map<TechoPresupuestarioViewModel>(response.Data);
                   
                    var catCentroCosto = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 14 });
                    entidadViewModel.CentroCostosList = new SelectList(catCentroCosto.Data, "Secuencia", "Nombre");
               
                    return new JsonResult(new { isValid = true, hijo = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
                return null;
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(int id, TechoPresupuestarioViewModel techoPresupuestario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == 0)
                    {
                        var createEntidadCommand = _mapper.Map<CreateTechoPresupuestarioCommand>(techoPresupuestario);
                        var result = await _mediator.Send(createEntidadCommand);
                        if (result.Succeeded)
                        {
                            id = result.Data;
                            _notify.Success($"TechoPresupuestario Creado.");
                        }
                        else _notify.Error(result.Message);
                    }
                    else
                    {
                        var updateEntidadCommand = _mapper.Map<UpdateTechoPresupuestarioCommand>(techoPresupuestario);
                        var result = await _mediator.Send(updateEntidadCommand);
                        if (result.Succeeded) _notify.Information($"TechoPresupuestario Actualizado.");
                    }

                    var response = await _mediator.Send(new GetAllTechoPresupuestariosQuery());
                    if (response.Succeeded)
                    {

                        var viewModel = _mapper.Map<List<TechoPresupuestarioViewModel>>(response.Data);

                        return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel) });
                    }
                    else
                    {
                        _notify.Error(response.Message);
                        return null;
                    }
                  

                }
                else
                {
                    var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", techoPresupuestario);
                    return new JsonResult(new { isValid = false, html = html });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("OnPostCreateOrEdit", ex);
                _notify.Error("Error al insertar IndicadorEstrategico");
            }
            return null;
        }


        public async Task<JsonResult> OnPostDelete(int id = 0)
        {
            var deleteCommand = await _mediator.Send(new DeleteTechoPresupuestarioCommand { Id = id });
            if (deleteCommand.Succeeded)
            {
                _notify.Information($"TechoPresupuestario con Id {id} Eliminado.");
                return new JsonResult(new { isValid = true });
            }
            else
            {
                _notify.Error(deleteCommand.Message);
                return null;
            }
        }

    }
}
