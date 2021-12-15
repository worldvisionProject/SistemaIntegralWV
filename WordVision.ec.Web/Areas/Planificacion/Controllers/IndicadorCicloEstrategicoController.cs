using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.EstrategiaNacionales.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.IndicadorCicloEstrategicos.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.IndicadorCicloEstrategicos.Commands.Delete;
using WordVision.ec.Application.Features.Planificacion.IndicadorCicloEstrategicos.Commands.Update;
using WordVision.ec.Application.Features.Planificacion.IndicadorCicloEstrategicos.Queries.GetById;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Planificacion.Models;

namespace WordVision.ec.Web.Areas.Planificacion.Controllers
{
    [Area("Planificacion")]
    [Authorize]

    public class IndicadorCicloEstrategicoController : BaseController<ActividadController>
    {
        public async Task<ActionResult> LoadIndicadores(int idEstrategia)
        {
            try
            {
                var response = await _mediator.Send(new GetIndicadorCicloEstrategicoByIdEstrategiaQuery() { Id = idEstrategia });
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<IndicadorCicloEstrategicoViewModel>>(response.Data);
                    ViewBag.IdEstrategia = idEstrategia;
                    //var html1 = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                    //return new JsonResult(new { isValid = true, html = html1 });
                    return PartialView("_ViewAll", viewModel);

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "LoadIndicadores");
                _notify.Error("Error a cargar Indicadores Ciclo Estrategico");
            }

            return null;
        }



        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0, int idEstrategia = 0)
        {
            // var brandsResponse = await _mediator.Send(new GetAllBrandsCachedQuery());
            //var responseGestion = await _mediator.Send(new GetListGestionByIdQuery() { Id = idEstrategia });
            //if (responseGestion.Succeeded)
            //{
            //    var viewModel = _mapper.Map<List<GestionViewModel>>(responseGestion.Data);
            //}

            if (id == 0)
            {
                var entidadViewModel = new IndicadorCicloEstrategicoViewModel();
                entidadViewModel.IdEstrategia = idEstrategia;
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
            }
            else
            {
                var response = await _mediator.Send(new GetIndicadorCicloEstrategicoByIdQuery() { Id = id });
                if (response.Succeeded)
                {
                    var entidadViewModel = _mapper.Map<IndicadorCicloEstrategicoViewModel>(response.Data);

                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
                return null;
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(int? id, IndicadorCicloEstrategicoViewModel entidad)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == 0)
                    {
                        var createEntidadCommand = _mapper.Map<CreateIndicadorCicloEstrategicoCommand>(entidad);
                        var result = await _mediator.Send(createEntidadCommand);
                        if (result.Succeeded)
                        {
                            id = result.Data;
                            _notify.Success($"Indicador con ID {result.Data} Creado.");
                        }
                        else _notify.Error(result.Message);
                    }
                    else
                    {
                        var updateEntidadCommand = _mapper.Map<UpdateIndicadorCicloEstrategicoCommand>(entidad);
                        var result = await _mediator.Send(updateEntidadCommand);
                        if (result.Succeeded) _notify.Information($"Indicador con ID {result.Data} Actualizado.");
                    }

                    var response = await _mediator.Send(new GetEstrategiaNacionalByIdQuery() { Id = entidad.IdEstrategia });
                    if (response.Succeeded)
                    {

                        var entidadViewModel = _mapper.Map<EstrategiaNacionalViewModel>(response.Data);
                        var cat2 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 2 });
                        entidadViewModel.EstadoList = new SelectList(cat2.Data, "Secuencia", "Nombre");
                        var html1 = await _viewRenderer.RenderViewToStringAsync("_ViewAll", entidadViewModel);
                        return new JsonResult(new { isValid = true, opcion = 102, page = "#viewAllIndicador", html = html1 });
                    }
                    else
                    {
                        _notify.Error(response.Message);
                        return null;
                    }


                }
                return new JsonResult(new { isValid = true, Id = id });
            }
            catch (Exception ex)
            {
                _logger.LogError("OnPostCreateOrEdit", ex);
                _notify.Error("Error al insertar Gestion");
            }
            return null;
        }


        public async Task<JsonResult> OnPostDelete(int id = 0)
        {
            var deleteCommand = await _mediator.Send(new DeleteIndicadorCicloEstrategicoCommand { Id = id });
            if (deleteCommand.Succeeded)
            {
                _notify.Information($"Indicador con Id {id} Eliminado.");
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
