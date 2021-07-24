using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartBreadcrumbs.Attributes;
using SmartBreadcrumbs.Nodes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Planificacion.EstrategiaNacionales.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.FactorCriticoExitoes.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.FactorCriticoExitoes.Commands.Delete;
using WordVision.ec.Application.Features.Planificacion.FactorCriticoExitoes.Commands.Update;
using WordVision.ec.Application.Features.Planificacion.FactorCriticoExitoes.Queries.GetAllCached;
using WordVision.ec.Application.Features.Planificacion.FactorCriticoExitoes.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.Gestiones.Queries.GetById;
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

            var responseE = await _mediator.Send(new GetEstrategiaNacionalByIdQuery() { Id = id });
            if (responseE.Succeeded)
            {

                var entidadViewModel = _mapper.Map<EstrategiaNacionalViewModel>(responseE.Data);
                ViewBag.Ciclo = entidadViewModel.Nombre;
                //return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
            }

            var childNode0 = new MvcBreadcrumbNode("Index", "EstrategiaNacional", "Ciclo Estratégico", false, null, "Planificacion")
            {
                //RouteValues = new { id }//this comes in as a param into the action
            };

            var childNode1 = new MvcBreadcrumbNode("OnGetCreateOrEdit", "EstrategiaNacional", "Objetivos", false, null, "Planificacion")
            {
                RouteValues = new { id },//this comes in as a param into the action
                 Parent = childNode0
            };

            var childNode2 = new MvcBreadcrumbNode("Index", "FactorCriticoExito", "Factor Crítico de Éxito")
            {
                OverwriteTitleOnExactMatch = true,
                Parent = childNode1
            };

            ViewData["BreadcrumbNode"] = childNode2;

            var model = new FactorCriticoExitoViewModel();
            model.IdObjetivoEstra = idObjetivoEstra;
            return View(model);
        }


        public async Task<IActionResult> IndexIndicador(int id,int idEstrategia, int AnioGestion)
        {
            int idObjetivoEstra = id;


            var response = await _mediator.Send(new GetObjetivoEstrategicoByIdQuery() { Id = idObjetivoEstra });
            if (response.Succeeded)
            {
                ViewBag.Message = response.Data.Descripcion;
                //id = response.Data.IdEstrategia;
            }
            var gestionDesc = string.Empty;
            var responseE = await _mediator.Send(new GetEstrategiaNacionalByIdQuery() { Id = idEstrategia });
            if (responseE.Succeeded)
            {

                var entidadViewModel = _mapper.Map<EstrategiaNacionalViewModel>(responseE.Data);
                ViewBag.Ciclo = entidadViewModel.Nombre;
                gestionDesc = entidadViewModel.Gestiones.Where(x => x.Id == AnioGestion).FirstOrDefault()?.Anio ?? string.Empty; ;
                //ViewBag.SNGestion = "N";
                //return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
            }
            
           var ciclo = idEstrategia;
            var childNode1 = new MvcBreadcrumbNode("PlanImplementacion", "EstrategiaNacional", "Ciclo Estratégico", false, null, "Planificacion")
            {
                RouteValues = new { ciclo },//this comes in as a param into the action
                                            // Parent = childNode0
            };
            id = idEstrategia;
            var childNode2 = new MvcBreadcrumbNode("OnGetCreateOrEditEstrategia", "EstrategiaNacional", "Gestión "+ gestionDesc)
            {
                RouteValues = new { id, AnioGestion},
                OverwriteTitleOnExactMatch = true,
                Parent = childNode1
            };
            id = idObjetivoEstra;
            var childNode3 = new MvcBreadcrumbNode("IndexIndicador", "FactorCriticoExito", "Indicadores de Resultado")
            {
                RouteValues = new { id, idEstrategia, AnioGestion },
                OverwriteTitleOnExactMatch = true,
                Parent = childNode2
            };


            ViewData["BreadcrumbNode"] = childNode3;

            //var childNode2 = new MvcBreadcrumbNode("Index", "FactorCriticoExito", "Factor Critico de Exito")
            //{
            //    OverwriteTitleOnExactMatch = true,
            //    Parent = childNode1
            //};

            //ViewData["BreadcrumbNode"] = childNode2;

            var model = new FactorCriticoExitoViewModel();
            model.IdObjetivoEstra = idObjetivoEstra;
            model.IdGestion = AnioGestion;
            model.IdEstrategia = idEstrategia;
            ViewBag.Nivel = User.Claims.FirstOrDefault(x => x.Type == "Nivel")?.Value;
            return View("IndexIndicador", model);
        }



        public async Task<JsonResult> IndexIndicadorChild(int id, int idEstrategia, int AnioGestion)
        {
            int idObjetivoEstra = id;


           
            var model = new FactorCriticoExitoViewModel();
            model.IdObjetivoEstra = idObjetivoEstra;
            model.IdGestion = AnioGestion;
            // ViewBag.Nivel = User.Claims.FirstOrDefault(x => x.Type == "Nivel")?.Value;
            // return new JsonResult(

            string json = string.Empty;
            using (var stream = new MemoryStream())
            {
                await JsonSerializer.SerializeAsync(stream, model);
                stream.Position = 0;
                using var reader = new StreamReader(stream);
                json = await reader.ReadToEndAsync();
            }
            return new JsonResult(json);

       
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
                    var viewModel = _mapper.Map<ObjetivoEstrategicoViewModel>(response.Data);
                    //var viewModel = new List<FactorCriticoExitoViewModel>();
                    //if (response.Data != null)
                    //    viewModel = _mapper.Map<List<FactorCriticoExitoViewModel>>(response.Data.FactorCriticoExitos);

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

        [Breadcrumb("FactorCriticoExito", AreaName = "Planificacion", FromAction = "OnGetCreateOrEdit", FromController = typeof(EstrategiaNacionalController))]
        public async Task<IActionResult> LoadFactorIndicadores(int idObjetivo,int idGestion)
        {
            try
            {
                var descGestion = "";
                var responseG = await _mediator.Send(new GetGestionByIdQuery() { Id = idGestion });
                if (responseG.Succeeded)
                {
                    var entidadViewModel = _mapper.Map<GestionViewModel>(responseG.Data);
                    descGestion = entidadViewModel.Anio;
                }

                var responseO = await _mediator.Send(new GetObjetivoEstrategicoByIdQuery() { Id = idObjetivo });
                if (responseO.Succeeded)
                {
                    ViewBag.Message = responseO.Data.Descripcion;
                }
                
                var response = await _mediator.Send(new GetFactorCriticoxObjetivoByIdQuery() { Id = idObjetivo });
                if (response.Succeeded)
                {
                    ViewBag.IdGestion = idGestion;
                    ViewBag.DescGestion = descGestion;
                    ViewBag.IdObjetivo = idObjetivo;
                    ViewBag.IdEstrategia = responseO.Data.IdEstrategia;
                    var viewModel = _mapper.Map<List<FactorCriticoExitoViewModel>>(response.Data);
                    return PartialView("_ViewAllxIndicador", viewModel);
                }
            }
            catch (Exception ex)
            {
                _notify.Error("No se pudo cargar los Factores");
                _logger.LogError("LoadAll", ex);
            }
            return null;
        }


        public async Task<JsonResult> LoadFactorIndicadoresChild(int idObjetivo, int idGestion)
        {
            try
            {
                var responseO = await _mediator.Send(new GetObjetivoEstrategicoByIdQuery() { Id = idObjetivo });
                if (responseO.Succeeded)
                {
                    ViewBag.Message = responseO.Data.Descripcion;
                }

                var response = await _mediator.Send(new GetFactorCriticoxObjetivoByIdQuery() { Id = idObjetivo });
                if (response.Succeeded)
                {
                    ViewBag.IdGestion = idGestion;
                    var viewModel = _mapper.Map<List<FactorCriticoExitoViewModel>>(response.Data);
                   
                    string json = string.Empty;
                    using (var stream = new MemoryStream())
                    {
                        await JsonSerializer.SerializeAsync(stream, viewModel);
                        stream.Position = 0;
                        using var reader = new StreamReader(stream);
                        json = await reader.ReadToEndAsync();
                    }
                    return new JsonResult(json);
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
                    var response = await _mediator.Send(new GetObjetivoEstrategicoByIdQuery() { Id = entidad.IdObjetivoEstra });
                    if (response.Succeeded)
                    {
                       
                        //var viewModel = new List<FactorCriticoExitoViewModel>();
                        //if (response.Data != null)
                        //    viewModel = _mapper.Map<List<FactorCriticoExitoViewModel>>(response.Data.FactorCriticoExitos);
                        var viewModel = _mapper.Map<ObjetivoEstrategicoViewModel>(response.Data);
                        ViewBag.Message = viewModel.Descripcion;
                        var html1 = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
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

        public async Task<JsonResult> OnPostDelete(int id = 0, int idObjetivo = 0)
        {
            var deleteCommand = await _mediator.Send(new DeleteFactorCriticoExitoCommand { Id = id });
            if (deleteCommand.Succeeded)
            {
                _notify.Information($"Factor con Id {id} Eliminado.");
                var response = await _mediator.Send(new GetObjetivoEstrategicoByIdQuery() { Id = idObjetivo });

                if (response.Succeeded)
                {

                   
                        ViewBag.Message = response.Data.Descripcion;
                        var viewModel = new List<FactorCriticoExitoViewModel>();
                        if (response.Data != null)
                            viewModel = _mapper.Map<List<FactorCriticoExitoViewModel>>(response.Data.FactorCriticoExitos);
                  
                    var html1 = await _viewRenderer.RenderViewToStringAsync( "_ViewAll", viewModel);
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
