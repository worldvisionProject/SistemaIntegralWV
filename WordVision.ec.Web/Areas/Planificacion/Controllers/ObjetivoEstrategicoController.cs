using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using SmartBreadcrumbs.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.EstrategiaNacionales.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.ObjetivoEstrategicoes.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.ObjetivoEstrategicoes.Commands.Delete;
using WordVision.ec.Application.Features.Planificacion.ObjetivoEstrategicoes.Commands.Update;
using WordVision.ec.Application.Features.Planificacion.ObjetivoEstrategicoes.Queries.GetAllCached;
using WordVision.ec.Application.Features.Planificacion.ObjetivoEstrategicoes.Queries.GetById;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Planificacion.Models;

namespace WordVision.ec.Web.Areas.Planificacion.Controllers
{
    [Area("Planificacion")]
    [Authorize]
    public class ObjetivoEstrategicoController : BaseController<ObjetivoEstrategicoController>
    {
        
        public IActionResult Index()
        {
            var model = new ObjetivoEstrategicoViewModel();
           
            return View(model);
        }

        public async Task<IActionResult> LoadAll()
        {
            var response = await _mediator.Send(new GetAllObjetivoEstrategicoesCachedQuery());
            if (response.Succeeded)
            {
                var viewModel = _mapper.Map<List<ObjetivoEstrategicoViewModel>>(response.Data);

                return PartialView("_ViewAll", viewModel);
            }
            return null;
        }

        public async Task<IActionResult> LoadObjetivo(int idEstrategia,string idCategoria)
        {
            var response = await _mediator.Send(new GetEstrategiaNacionalByIdQuery() { Id = idEstrategia });
            if (response.Succeeded)
            {

                var entidadViewModel = _mapper.Map<EstrategiaNacionalViewModel>(response.Data);
                entidadViewModel.CategoriaObjetivo = idCategoria;
                ViewBag.Ciclo = entidadViewModel.Nombre;
                var cat2 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 3 });
                entidadViewModel.DimensionesList = new SelectList(cat2.Data, "Secuencia", "Nombre");
                return PartialView(idCategoria=="2"?"_ViewAll":"_ViewAllNacional", entidadViewModel);
             }
            return null;
        }

        //[Breadcrumb("Objetivo", AreaName = "Planificacion", FromAction = "OnGetCreateOrEdit", FromController = typeof(EstrategiaNacionalController))]
        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0,int idEstrategia=0,string categoria="")
        {
            // var brandsResponse = await _mediator.Send(new GetAllBrandsCachedQuery());
            var cat2 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 3 });
            var DimList = new SelectList(cat2.Data, "Secuencia", "Nombre");

            var cat3 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 4 });
            var AreaList = new SelectList(cat3.Data, "Secuencia", "Nombre");

            if (id == 0)
            {
                var entidadViewModel = new ObjetivoEstrategicoViewModel();
                entidadViewModel.Categoria = categoria;
                entidadViewModel.IdEstrategia = idEstrategia;
                entidadViewModel.DimensionList = DimList;
                entidadViewModel.AreaList = AreaList;
                //  return View("_CreateOrEdit", entidadViewModel);
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
            }
            else
            {
                var response = await _mediator.Send(new GetObjetivoEstrategicoByIdQuery() { Id = id });
                if (response.Succeeded)
                {
                    var entidadViewModel = _mapper.Map<ObjetivoEstrategicoViewModel>(response.Data);
                    entidadViewModel.Categoria = categoria;
                    entidadViewModel.IdEstrategia = idEstrategia;
                    entidadViewModel.DimensionList = DimList;
                    entidadViewModel.AreaList = AreaList;
                    // return View("_CreateOrEdit", entidadViewModel);
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
                return null;
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(int id, ObjetivoEstrategicoViewModel entidad)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == 0)
                    {
                        var createEntidadCommand = _mapper.Map<CreateObjetivoEstrategicoCommand>(entidad);
                        var result = await _mediator.Send(createEntidadCommand);
                        if (result.Succeeded)
                        {
                            id = result.Data;
                            _notify.Success($"Objetivo con ID {result.Data} Creado.");
                        }
                        else _notify.Error(result.Message);
                    }
                    else
                    {
                        var updateEntidadCommand = _mapper.Map<UpdateObjetivoEstrategicoCommand>(entidad);
                        var result = await _mediator.Send(updateEntidadCommand);
                        if (result.Succeeded) _notify.Information($"Objetivo con ID {result.Data} Actualizado.");
                    }
                    var response = await _mediator.Send(new GetEstrategiaNacionalByIdQuery() { Id = entidad.IdEstrategia });
                    if (response.Succeeded)
                    {
                       
                        var entidadViewModel = _mapper.Map<EstrategiaNacionalViewModel>(response.Data);
                        entidadViewModel.CategoriaObjetivo = entidad.Categoria;
                        var cat2 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 3 });
                        entidadViewModel.DimensionesList= new SelectList(cat2.Data, "Secuencia", "Nombre");
                        var html1 = await _viewRenderer.RenderViewToStringAsync(entidad.Categoria == "2" ? "_ViewAll" : "_ViewAllNacional", entidadViewModel);
                        return new JsonResult(new { isValid = true, opcion=Convert.ToInt32( entidad.Categoria), page = entidad.Categoria == "2" ? "#viewAll" : "#viewAllNacional", html = html1 });
                    }
                    else
                    {
                        _notify.Error(response.Message);
                        return null;
                    }
                }
                else
                {
                    var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidad);
                    return new JsonResult(new { isValid = false, html = html });
                }
            }catch (Exception ex)
            {
                _logger.LogError("OnPostCreateOrEdit", ex);
                _notify.Error("Error al insertar ObjetivoEstrategico");
            }
            return null;
        }


        public async Task<JsonResult> OnPostDelete(int id = 0, int idEstrategia = 0,string idCategoria="")
        {
            var deleteCommand = await _mediator.Send(new DeleteObjetivoEstrategicoCommand { Id = id });
            if (deleteCommand.Succeeded)
            {
                _notify.Information($"Objetivo con Id {id} Eliminado.");
                var response = await _mediator.Send(new GetEstrategiaNacionalByIdQuery() { Id = idEstrategia });

                if (response.Succeeded)
                {
                 
                    var entidadViewModel = _mapper.Map<EstrategiaNacionalViewModel>(response.Data);
                    ViewBag.Ciclo = entidadViewModel.Nombre;
                    entidadViewModel.CategoriaObjetivo = idCategoria;
                    var cat2 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 3 });
                    entidadViewModel.DimensionesList = new SelectList(cat2.Data, "Secuencia", "Nombre");
                    var html1 = await _viewRenderer.RenderViewToStringAsync(idCategoria == "2" ? "_ViewAll" : "_ViewAllNacional", entidadViewModel);
                    return new JsonResult(new { isValid = true, html = html1 });
                }
                else
                {
                    _notify.Error(response.Message);
                    return null;
                }

            }
            else
            {
                _notify.Error(deleteCommand.Message);
                return null;
            }
        }
    }
}
