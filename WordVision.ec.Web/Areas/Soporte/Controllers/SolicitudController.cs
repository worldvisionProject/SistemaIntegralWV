using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetById;
using WordVision.ec.Application.Features.Soporte.Solicitudes.Commands.Create;
using WordVision.ec.Application.Features.Soporte.Solicitudes.Commands.Update;
using WordVision.ec.Application.Features.Soporte.Solicitudes.Queries.GetById;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Registro.Models;
using WordVision.ec.Web.Areas.Soporte.Models;

namespace WordVision.ec.Web.Areas.Soporte.Controllers
{
    [Area("Soporte")]
    [Authorize]
    public class SolicitudController :  BaseController<SolicitudController>
    {
        public IActionResult Index(int op=0)
        {
            var model = new SolicitudViewModel();
            model.AsignadoA = op;
            return View(model);
        }


        public async Task<IActionResult> LoadAll(int idSolicitante,int op=0)
        {
            ViewBag.Op = op;
            switch (op)
            {
                case 1:
                    var response = await _mediator.Send(new GetSolicitudByIdSolicitanteQuery() { Id = idSolicitante });
                    if (response.Succeeded)
                    {
                        var viewModel = _mapper.Map<List<SolicitudViewModel>>(response.Data);
                        var cat2 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 19 });
                        ViewBag.EstadoList = new SelectList(cat2.Data, "Secuencia", "Nombre");

                        return PartialView("_ViewAll", viewModel);
                    }
                    break;

                case 2:
                     response = await _mediator.Send(new GetSolicitudByIdEstadoQuery() { Id = 1 });
                    if (response.Succeeded)
                    {
                        var viewModel = _mapper.Map<List<SolicitudViewModel>>(response.Data);
                        var cat2 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 19 });
                        ViewBag.EstadoList = new SelectList(cat2.Data, "Secuencia", "Nombre");

                        return PartialView("_ViewAll", viewModel);
                    }
                    break;

                case 3:
                    response = await _mediator.Send(new GetSolicitudByIdAsignadoQuery() { Id = idSolicitante });
                    if (response.Succeeded)
                    {
                        var viewModel = _mapper.Map<List<SolicitudViewModel>>(response.Data);
                        var cat2 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 19 });
                        ViewBag.EstadoList = new SelectList(cat2.Data, "Secuencia", "Nombre");

                        return PartialView("_ViewAll", viewModel);
                    }
                    break;
            }
           
            
            return null;
        }
        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0,int op=0)
        {
           
            if (id == 0)
            {
                var entidadViewModel = new SolicitudViewModel();
                entidadViewModel.Estado = 1;
                var cat2 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 19 });
                entidadViewModel.EstadoList = new SelectList(cat2.Data, "Secuencia", "Nombre");

                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
            }
            else
            {
                var response = await _mediator.Send(new GetSolicitudByIdQuery() { Id = id });
                if (response.Succeeded)
                {
                    var entidadViewModel = _mapper.Map<SolicitudViewModel>(response.Data); 
                    switch (op)
                    {
                        case 1:
                            entidadViewModel.Estado = 1;
                            break;
                        case 2:
                            entidadViewModel.Estado = 2;
                            var colaborador = await _mediator.Send(new GetColaboradorByIdAreaQuery() { Id = 17 });
                            if (colaborador.Succeeded)
                            {
                                var responsable = _mapper.Map<List<ColaboradorViewModel>>(colaborador.Data);
                                entidadViewModel.AsignadoAList = new SelectList(responsable, "Id", "Nombres");
                            }
                            
                            break;
                        case 3:
                            entidadViewModel.Estado =3;
                            break;
                    }
                    var cat2 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 19 });

                    entidadViewModel.EstadoList = new SelectList(cat2.Data, "Secuencia", "Nombre");

                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
                return null;
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(int id, SolicitudViewModel entidad)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == 0)
                    {
                        entidad.Estado = 1;
                        var createEntidadCommand = _mapper.Map<CreateSolicitudCommand>(entidad);
                        var result = await _mediator.Send(createEntidadCommand);
                        if (result.Succeeded)
                        {
                            id = result.Data;
                            _notify.Success($"Solicitud con ID {result.Data} Creado.");
                        }
                        else _notify.Error(result.Message);
                    }
                    else
                    {
                        var updateEntidadCommand = _mapper.Map<UpdateSolicitudCommand>(entidad);
                        var result = await _mediator.Send(updateEntidadCommand);
                        if (result.Succeeded) _notify.Information($"Solicitud con ID {result.Data} Actualizado.");
                    }

                    var op = entidad.Estado;
                    ViewBag.Op = op;
                    switch (op)
                    {
                        case 1:
                            var response1 = await _mediator.Send(new GetSolicitudByIdSolicitanteQuery() { Id = entidad.Solicitante });
                            if (response1.Succeeded)
                            {
                                var viewModel = _mapper.Map<List<SolicitudViewModel>>(response1.Data);
                                var cat2 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 19 });
                                ViewBag.EstadoList = new SelectList(cat2.Data, "Secuencia", "Nombre");

                                var html1 = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                                return new JsonResult(new { isValid = true, html = html1 });
                            }
                            break;

                        case 2:
                            response1 = await _mediator.Send(new GetSolicitudByIdEstadoQuery() { Id = 1 });
                            if (response1.Succeeded)
                            {
                                var viewModel = _mapper.Map<List<SolicitudViewModel>>(response1.Data);
                                var cat2 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 19 });
                                ViewBag.EstadoList = new SelectList(cat2.Data, "Secuencia", "Nombre");

                                var html1 = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                                return new JsonResult(new { isValid = true, html = html1 });
                            }
                            break;

                        case >=3:
                            response1 = await _mediator.Send(new GetSolicitudByIdAsignadoQuery() { Id = entidad.Solicitante });
                            if (response1.Succeeded)
                            {
                                var viewModel = _mapper.Map<List<SolicitudViewModel>>(response1.Data);
                                var cat2 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 19 });
                                ViewBag.EstadoList = new SelectList(cat2.Data, "Secuencia", "Nombre");

                                var html1 = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                                return new JsonResult(new { isValid = true, html = html1 });
                            }
                            break;
                    }

                    //var response = await _mediator.Send(new GetSolicitudByIdSolicitanteQuery() { Id = entidad.Solicitante });
                    //if (response.Succeeded)
                    //{
                    //    var viewModel = _mapper.Map<List<SolicitudViewModel>>(response.Data);

                    //    var html1 = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                    //    return new JsonResult(new { isValid = true, html = html1 });
                    //}
                    //else
                    //{
                    //    _notify.Error(response.Message);
                    //    return null;
                    //}


                }
                else
                {
                    var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidad);
                    return new JsonResult(new { isValid = false, html = html });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("OnPostCreateOrEdit", ex);
                _notify.Error("Error al insertar Gestion");
            }
            return null;
        }

    }
}
