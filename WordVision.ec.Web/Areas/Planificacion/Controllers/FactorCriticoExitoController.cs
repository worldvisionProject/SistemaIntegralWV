using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartBreadcrumbs.Attributes;
using SmartBreadcrumbs.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Planificacion.FactorCriticoExitoes.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.FactorCriticoExitoes.Commands.Update;
using WordVision.ec.Application.Features.Planificacion.FactorCriticoExitoes.Queries.GetAllCached;
using WordVision.ec.Application.Features.Planificacion.FactorCriticoExitoes.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.ObjetivoEstrategicoes.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.ObjetivoEstrategicoes.Commands.Update;
using WordVision.ec.Application.Features.Planificacion.ObjetivoEstrategicoes.Queries.GetAllCached;
using WordVision.ec.Application.Features.Planificacion.ObjetivoEstrategicoes.Queries.GetById;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Planificacion.Models;

namespace WordVision.ec.Web.Areas.Planificacion.Controllers
{
    [Area("Planificacion")]
    [Authorize]
    public class FactorCriticoExitoController : BaseController<FactorCriticoExitoController>
    {
        //[Breadcrumb("FactorCriticoExito", AreaName = "Planificacion", FromAction = "OnGetCreateOrEdit", FromController = typeof(EstrategiaNacionalController))]

        public async Task<IActionResult> Index(int id)
        {
            int idObjetivoEstra = id;
          

            var response = await _mediator.Send(new GetObjetivoEstrategicoByIdQuery() { Id = id });
            if (response.Succeeded)
            {
                ViewBag.Message = response.Data.Descripcion;
                id = response.Data.IdEstrategia;
            }

            var childNode0 = new MvcBreadcrumbNode("Index", "EstrategiaNacional", "Ciclo Estrategico", false, null, "Planificacion")
            {
                //RouteValues = new { id }//this comes in as a param into the action
            };

            var childNode1 = new MvcBreadcrumbNode("OnGetCreateOrEdit", "EstrategiaNacional", "Parametros", false, null, "Planificacion")
            {
                RouteValues = new { id },//this comes in as a param into the action
                 Parent = childNode0
            };

            var childNode2 = new MvcBreadcrumbNode("Index", "FactorCriticoExito", "Factor Critico de Exito")
            {
                OverwriteTitleOnExactMatch = true,
                Parent = childNode1
            };

            ViewData["BreadcrumbNode"] = childNode2;

            var model = new FactorCriticoExitoViewModel();
            model.IdObjetivoEstra = idObjetivoEstra;
            return View(model);
        }
        [Breadcrumb("FactorCriticoExito", AreaName = "Planificacion", FromAction = "OnGetCreateOrEdit", FromController = typeof(EstrategiaNacionalController))]
        public async Task<IActionResult> LoadFactor(int idObjetivo)
        {
            try
            {
                var response = await _mediator.Send(new GetObjetivoEstrategicoByIdQuery() { Id = idObjetivo });
                if (response.Succeeded)
                {
                    ViewBag.Message = response.Data.Descripcion;
                    var viewModel = new List<FactorCriticoExitoViewModel>();
                    if (response.Data != null)
                        viewModel = _mapper.Map<List<FactorCriticoExitoViewModel>>(response.Data.FactorCriticoExitos);

                    return PartialView("_ViewAll", viewModel);
                }
            }
            catch (Exception ex)
            {
                _notify.Error("No se pudo cargar los Factores");
                _logger.LogError("LoadAll", ex);
            }
            return null;
        }

        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0,int idObjetivoEstra = 0)
        {
            // var brandsResponse = await _mediator.Send(new GetAllBrandsCachedQuery());

            if (id == 0)
            {
                var entidadViewModel = new FactorCriticoExitoViewModel();
                entidadViewModel.IdObjetivoEstra = idObjetivoEstra;
              
                //return View("_CreateOrEdit", entidadViewModel);
                 return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
            }
            else
            {
                var response = await _mediator.Send(new GetFactorCriticoExitoByIdQuery() { Id = id });
                if (response.Succeeded)
                {
                    var entidadViewModel = _mapper.Map<FactorCriticoExitoViewModel>(response.Data);
                   // return View("_CreateOrEdit", entidadViewModel);
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
                return null;
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(int id, FactorCriticoExitoViewModel entidad)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == 0)
                    {
                        var createEntidadCommand = _mapper.Map<CreateFactorCriticoExitoCommand>(entidad);
                        var result = await _mediator.Send(createEntidadCommand);
                        if (result.Succeeded)
                        {
                            id = result.Data;
                            _notify.Success($"Factor con ID {result.Data} Creado.");
                        }
                        else _notify.Error(result.Message);
                    }
                    else
                    {
                        var updateEntidadCommand = _mapper.Map<UpdateFactorCriticoExitoCommand>(entidad);
                        var result = await _mediator.Send(updateEntidadCommand);
                        if (result.Succeeded) _notify.Information($"Factor con ID {result.Data} Actualizado.");
                    }
                    var response = await _mediator.Send(new GetAllFactorCriticoExitoesCachedQuery());
                    if (response.Succeeded)
                    {
                        var viewModel = _mapper.Map<List<FactorCriticoExitoViewModel>>(response.Data);
                        var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
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

    }
}
