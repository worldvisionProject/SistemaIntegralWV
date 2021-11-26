using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.Actividades.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.Recursos.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.Recursos.Commands.Delete;
using WordVision.ec.Application.Features.Planificacion.Recursos.Commands.Update;
using WordVision.ec.Application.Features.Planificacion.Recursos.Queries.GetById;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Planificacion.Models;

namespace WordVision.ec.Web.Areas.Planificacion.Controllers
{
    [Area("Planificacion")]
    [Authorize]
    public class RecursoController : BaseController<RecursoController>
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> LoadxActividades(int idActividad)
        {
            try
            {
                var response = await _mediator.Send(new GetActividadByIdQuery() { Id = idActividad });
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<ActividadViewModel>(response.Data);

                    var cat2 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 12 });
                    viewModel.CategoriaList = new SelectList(cat2.Data, "Secuencia", "Nombre");
                    var cat11 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 13 });
                    viewModel.InsumoList = new SelectList(cat11.Data, "Secuencia", "Nombre");

                    var catCentroCosto = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 14 });
                    viewModel.CentroCostosList = new SelectList(catCentroCosto.Data, "Secuencia", "Nombre");
                    var catCuentaCodigoCC = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 15 });
                    viewModel.CuentaCCList = new SelectList(catCuentaCodigoCC.Data, "Secuencia", "Nombre");


                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel) });


                }
            }
            catch (Exception ex)
            {
                _logger.LogError("LoadxActividades", ex);
                _notify.Error("Error al consultar LoadxActividades");
            }
            return null;
        }
        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0, int idActividad = 0)
        {

            //var descGestion = "";
            //var responseG = await _mediator.Send(new GetActividadByIdQuery() { Id = idActividad });
            //if (responseG.Succeeded)
            //{
            //    var entidadViewModel = _mapper.Map<GestionViewModel>(responseG.Data);
            //    descGestion = entidadViewModel.Anio;
            //}
            if (id == 0)
            {
                var entidadViewModel = new RecursoViewModel();
                entidadViewModel.IdActividad = idActividad;
                var cat2 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 12 });
                entidadViewModel.CategoriaList = new SelectList(cat2.Data, "Secuencia", "Nombre");
                var cat11 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 13 });
                entidadViewModel.InsumoList = new SelectList(cat11.Data, "Secuencia", "Nombre");

                var catCentroCosto = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 14 });
                entidadViewModel.CentroCostosList = new SelectList(catCentroCosto.Data, "Secuencia", "Nombre");
                var catCuentaCodigoCC = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 15 });
                entidadViewModel.CuentaCCList = new SelectList(catCuentaCodigoCC.Data, "Secuencia", "Nombre");
                var catMes = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 16 });
                entidadViewModel.MesList = new SelectList(catMes.Data, "Secuencia", "Nombre");

                return new JsonResult(new { isValid = true, hijo = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
            }
            else
            {
                var response = await _mediator.Send(new GetRecursoByIdQuery() { Id = id });
                if (response.Succeeded)
                {
                    var entidadViewModel = _mapper.Map<RecursoViewModel>(response.Data);
                    entidadViewModel.IdActividad = idActividad;
                    var cat2 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 12 });
                    entidadViewModel.CategoriaList = new SelectList(cat2.Data, "Secuencia", "Nombre");
                    var cat11 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 13 });
                    entidadViewModel.InsumoList = new SelectList(cat11.Data, "Secuencia", "Nombre");

                    var catCentroCosto = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 14 });
                    entidadViewModel.CentroCostosList = new SelectList(catCentroCosto.Data, "Secuencia", "Nombre");
                    var catCuentaCodigoCC = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 15 });
                    entidadViewModel.CuentaCCList = new SelectList(catCuentaCodigoCC.Data, "Secuencia", "Nombre");

                    var catMes = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 16 });
                    entidadViewModel.MesList = new SelectList(catMes.Data, "Secuencia", "Nombre");

                    entidadViewModel.Gtrm = entidadViewModel.Gtrm == "S" ? "true" : "false";
                    return new JsonResult(new { isValid = true, hijo = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
                return null;
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(int id, int idActividad, RecursoViewModel recurso, List<FechaCantidadRecursoViewModel> mes)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    recurso.Gtrm = recurso.Gtrm.ToUpper() == "FALSE" ? "N" : "S";
                    if (id == 0)
                    {
                        var createEntidadCommand = _mapper.Map<CreateRecursoCommand>(recurso);
                        createEntidadCommand.IdActividad = idActividad;
                        var result = await _mediator.Send(createEntidadCommand);
                        if (result.Succeeded)
                        {
                            id = result.Data;
                            _notify.Success($"Recurso Creado.");
                        }
                        else _notify.Error(result.Message);
                    }
                    else
                    {
                        var updateEntidadCommand = _mapper.Map<UpdateRecursoCommand>(recurso);
                        updateEntidadCommand.IdActividad = idActividad;
                        var result = await _mediator.Send(updateEntidadCommand);
                        if (result.Succeeded) _notify.Information($"Recurso Actualizado.");
                    }
                    return new JsonResult(new { isValid = true, solocerrar = true });

                }
                else
                {
                    var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", recurso);
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
            var deleteCommand = await _mediator.Send(new DeleteRecursoCommand { Id = id });
            if (deleteCommand.Succeeded)
            {
                _notify.Information($"Recurso con Id {id} Eliminado.");
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
