using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.EstrategiaNacionales.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.Gestiones.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.Gestiones.Commands.Delete;
using WordVision.ec.Application.Features.Planificacion.Gestiones.Commands.Update;
using WordVision.ec.Application.Features.Planificacion.Gestiones.Queries.GetAllCached;
using WordVision.ec.Application.Features.Planificacion.Gestiones.Queries.GetById;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Planificacion.Models;

namespace WordVision.ec.Web.Areas.Planificacion.Controllers
{
    [Area("Planificacion")]
    [Authorize]
    public class GestionController : BaseController<GestionController>
    {
        public IActionResult Index()
        {
            var model = new GestionViewModel();

            return View(model);
        }
        public async Task<IActionResult> LoadAll()
        {
            var response = await _mediator.Send(new GetAllGestionesCachedQuery());
            if (response.Succeeded)
            {
                var viewModel = _mapper.Map<List<GestionViewModel>>(response.Data);

                return PartialView("_ViewAll", viewModel);
            }
            return null;
        }

        public async Task<IActionResult> LoadGestiones(int idEstrategico)
        {
            var response = await _mediator.Send(new GetEstrategiaNacionalByIdQuery() { Id = idEstrategico });
            if (response.Succeeded)
            {

                var entidadViewModel = _mapper.Map<EstrategiaNacionalViewModel>(response.Data);
                ViewBag.Ciclo = entidadViewModel.Nombre;
                var cat1 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 2 });
                entidadViewModel.EstadoList = new SelectList(cat1.Data, "Secuencia", "Nombre");
                return PartialView("_ViewAll", entidadViewModel);
                //return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
            }
            return null;
            //var response = await _mediator.Send(new GetListGestionByIdQuery() { Id = idEstrategico });
            //if (response.Succeeded)
            //{
            //    var viewModel = _mapper.Map<List<GestionViewModel>>(response.Data);

            //    var dd = JsonConvert.SerializeObject(viewModel);
            //    return Json(dd);
            //}
            //return null;
        }


        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0, int idEstrategia = 0)
        {
            // var brandsResponse = await _mediator.Send(new GetAllBrandsCachedQuery());
            var cat1 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 2 });

            if (id == 0)
            {
                var entidadViewModel = new GestionViewModel();
                entidadViewModel.IdEstrategia = idEstrategia;
                entidadViewModel.EstadoList = new SelectList(cat1.Data, "Secuencia", "Nombre");
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
            }
            else
            {
                var response = await _mediator.Send(new GetGestionByIdQuery() { Id = id });
                if (response.Succeeded)
                {
                    var entidadViewModel = _mapper.Map<GestionViewModel>(response.Data);
                    entidadViewModel.EstadoList = new SelectList(cat1.Data, "Secuencia", "Nombre");
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
                return null;
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(int? id, GestionViewModel entidad)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == 0)
                    {
                        var createEntidadCommand = _mapper.Map<CreateGestionCommand>(entidad);
                        var result = await _mediator.Send(createEntidadCommand);
                        if (result.Succeeded)
                        {
                            id = result.Data;
                            _notify.Success($"Gestion con ID {result.Data} Creado.");
                        }
                        else _notify.Error(result.Message);
                    }
                    else
                    {
                        var updateEntidadCommand = _mapper.Map<UpdateGestionCommand>(entidad);
                        var result = await _mediator.Send(updateEntidadCommand);
                        if (result.Succeeded) _notify.Information($"Gestion con ID {result.Data} Actualizado.");
                    }

                    var response = await _mediator.Send(new GetEstrategiaNacionalByIdQuery() { Id = entidad.IdEstrategia });
                    if (response.Succeeded)
                    {

                        var entidadViewModel = _mapper.Map<EstrategiaNacionalViewModel>(response.Data);
                        var cat2 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 2 });
                        entidadViewModel.EstadoList = new SelectList(cat2.Data, "Secuencia", "Nombre");
                        var html1 = await _viewRenderer.RenderViewToStringAsync("_ViewAll", entidadViewModel);
                        return new JsonResult(new { isValid = true, opcion = 99, page = "#viewAllGestion", html = html1 });
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


        public async Task<JsonResult> OnPostDelete(int id = 0, int IdColaborador = 0)
        {
            var deleteCommand = await _mediator.Send(new DeleteGestionCommand { Id = id });
            if (deleteCommand.Succeeded)
            {
                _notify.Information($"Gestion con Id {id} Eliminado.");
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
