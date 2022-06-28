﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SmartBreadcrumbs.Attributes;
using SmartBreadcrumbs.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.EstrategiaNacionales.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.EstrategiaNacionales.Commands.Update;
using WordVision.ec.Application.Features.Planificacion.EstrategiaNacionales.Queries.GetAllCached;
using WordVision.ec.Application.Features.Planificacion.EstrategiaNacionales.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.Gestiones.Queries.GetById;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Planificacion.Models;

namespace WordVision.ec.Web.Areas.Planificacion.Controllers
{
    [Area("Planificacion")]
    [Authorize]
    public class EstrategiaNacionalController : BaseController<EstrategiaNacionalController>
    {
        [Breadcrumb("Ciclo Estratégico", AreaName = "Planificacion")]
        public IActionResult Index()
        {
            var model = new EstrategiaNacionalViewModel();

            return View(model);
        }

        public async Task<IActionResult> LoadAll()
        {
            try
            {
                var response = await _mediator.Send(new GetAllEstrategiaNacionalesCachedQuery());
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<EstrategiaNacionalViewModel>>(response.Data);
                    var cat1 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 2 });
                    ViewBag.EstadoList = new SelectList(cat1.Data, "Secuencia", "Nombre");

                    return PartialView("_ViewAll", viewModel);
                }
            }
            catch (Exception ex)
            {
                _notify.Error("No se pudo cargar los Ciclos");
                _logger.LogError("LoadAll", ex);
            }
            return null;
        }

        public async Task<JsonResult> LoadEstrategias()
        {

            try
            {
                var response = await _mediator.Send(new GetAllEstrategiaNacionalesCachedQuery());
                if (response.Succeeded)
                {
                    List<SelectListItem> estrategia = new List<SelectListItem>();
                    var viewModel = _mapper.Map<List<EstrategiaNacionalViewModel>>(response.Data.Where(x=>x.Estado=="1"));
                    for (int i = 0; i < viewModel.Count; i++)
                    {
                        estrategia.Add(new SelectListItem
                        {
                            Value = viewModel.ToList()[i].Id.ToString(),
                            Text = viewModel.ToList()[i].Nombre.ToString()
                        });
                    }

                    var dd = JsonConvert.SerializeObject(estrategia);
                    return Json(dd);
                    //  return Json(viewModel);
                }
            }
            catch (Exception ex)
            {
                _notify.Error("No se pudo cargar los Ciclos");
                _logger.LogError("LoadAll", ex);
            }
            return null;
        }


        [Breadcrumb("Objetivos", AreaName = "Planificacion")]
        public async Task<IActionResult> OnGetCreateOrEdit(int id = 0)
        {
            try
            {


                // var brandsResponse = await _mediator.Send(new GetAllBrandsCachedQuery());
                var cat1 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 2 });
                ViewBag.EstadoList = new SelectList(cat1.Data, "Secuencia", "Nombre");
                //ViewData["EstadoList"] = new SelectList(cat1.Data, "Secuencia", "Nombre");

                //var cat2 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 3 });
                //ViewBag.DimensionesList = new SelectList(cat2.Data, "Secuencia", "Nombre");

                var cat3 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 4 });
                ViewBag.AreaList = new SelectList(cat3.Data, "Secuencia", "Nombre");

                var cat4 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 5 });
                ViewBag.CategoriaList = new SelectList(cat4.Data, "Secuencia", "Nombre");

              
            }
            catch (Exception ex)
            {
                _notify.Error("No se pudo cargar los Catalogos");
                _logger.LogError("No se pudo cargar los Catalogos", ex);
            }


            if (id == 0)
            {
                var entidadViewModel = new EstrategiaNacionalViewModel();
                return View("_CreateOrEdit", entidadViewModel);
                // return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
            }
            else
            {
                var response = await _mediator.Send(new GetEstrategiaNacionalByIdQuery() { Id = id });
                if (response.Succeeded)
                {

                    var entidadViewModel = _mapper.Map<EstrategiaNacionalViewModel>(response.Data);
                    ViewBag.Ciclo = entidadViewModel.Nombre;
                    var cat3 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 4 });
                    entidadViewModel.AreaPrioridadList = new SelectList(cat3.Data, "Secuencia", "Nombre");
                    return View("_CreateOrEdit", entidadViewModel);
                    //return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
                return null;
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(int id, EstrategiaNacionalViewModel entidad)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == 0)
                    {
                        var createEntidadCommand = _mapper.Map<CreateEstrategiaNacionalCommand>(entidad);
                        var result = await _mediator.Send(createEntidadCommand);
                        if (result.Succeeded)
                        {
                            id = result.Data;
                            _notify.Success($"Estrategia con ID {result.Data} Creado.");
                        }
                        else _notify.Error(result.Message);
                    }
                    else
                    {
                        var updateEntidadCommand = _mapper.Map<UpdateEstrategiaNacionalCommand>(entidad);
                        var result = await _mediator.Send(updateEntidadCommand);
                        if (result.Succeeded) _notify.Information($"Estrategia con ID {result.Data} Actualizado.");
                    }
                    return new JsonResult(new { isValid = true });
                    //var response = await _mediator.Send(new GetAllEstrategiaNacionalesCachedQuery());
                    //if (response.Succeeded)
                    //{
                    //    var viewModel = _mapper.Map<List<EstrategiaNacionalViewModel>>(response.Data);
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
                    var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidad);
                    return new JsonResult(new { isValid = false, html = html });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"OnPostCreateOrEdit");
                _notify.Error("Error al insertar Ciclo");
                return new JsonResult(new { isValid = false });
            }
           
        }
        class Anios
        {
            public int Id { get; set; }

            public string Anio { get; set; }
        }
        // [Breadcrumb("Ciclo Estrategico", AreaName = "Planificacion")]
        public async Task<ActionResult> PlanImplementacion(int ciclo)
        {
            if (ciclo == 0)
            {
                _notify.Warning("Seleccione un Ciclo Estratégico, para poder continuar");
                var entidadViewModel = new EstrategiaNacionalViewModel();
                ViewBag.Ciclo = "";
                var item = new List<Anios>() { new Anios() { Id = 0, Anio = "" } };
                entidadViewModel.AnioGestion = "0";
                entidadViewModel.Id = 0;
                ViewBag.GestionList = new SelectList(item, "Id", "Anio");
                return View("_PlanImplementacion", entidadViewModel); ;
            }

            var childNode1 = new MvcBreadcrumbNode("PlanImplementacion", "EstrategiaNacional", "Ciclo Estratégico", false, null, "Planificacion")
            {
                // Parent = childNode0
            };
            ViewData["BreadcrumbNode"] = childNode1;


            try
            {


                // var brandsResponse = await _mediator.Send(new GetAllBrandsCachedQuery());
                var cat1 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 2 });
                ViewBag.EstadoList = new SelectList(cat1.Data, "Secuencia", "Nombre");
                //ViewData["EstadoList"] = new SelectList(cat1.Data, "Secuencia", "Nombre");

                //var cat2 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 3 });
                //ViewBag.DimensionesList = new SelectList(cat2.Data, "Secuencia", "Nombre");

                var cat3 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 4 });
                ViewBag.AreaList = new SelectList(cat3.Data, "Secuencia", "Nombre");

                var cat4 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 5 });
                ViewBag.CategoriaList = new SelectList(cat4.Data, "Secuencia", "Nombre");
            }
            catch (Exception ex)
            {
                _notify.Error("No se pudo cargar los Catalogos");
                _logger.LogError("No se pudo cargar los Catalogos", ex);
            }


            var response = await _mediator.Send(new GetEstrategiaNacionalByIdQuery() { Id = ciclo });
            if (response.Succeeded)
            {
               

                var entidadViewModel = _mapper.Map<EstrategiaNacionalViewModel>(response.Data);
                var responseE = await _mediator.Send(new GetListGestionByIdQuery() { Id = entidadViewModel.Id });
                entidadViewModel.AnioFiscalList = new SelectList(responseE.Data, "Id", "Anio");
                ViewBag.Ciclo = entidadViewModel.Nombre;
                ViewBag.GestionList = new SelectList(entidadViewModel.Gestiones, "Id", "Anio");
                return View("_PlanImplementacion", entidadViewModel);
                //return View("_CreateOrEdit", entidadViewModel);
                //return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
            }

            //  return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_PlanImplementacion", anioFiscalViewModeldet) });
            //}
            return null;

        }



        public async Task<IActionResult> OnGetCreateOrEditEstrategia(int id = 0, int AnioGestion = 0, int Categoria = 2)
        {

            var ciclo = id;
            var childNode1 = new MvcBreadcrumbNode("PlanImplementacion", "EstrategiaNacional", "Ciclo Estratégico", false, null, "Planificacion")
            {
                RouteValues = new { ciclo },//this comes in as a param into the action
                                            // Parent = childNode0
            };
            var gestionDesc = string.Empty;
            var responseE = await _mediator.Send(new GetEstrategiaNacionalByIdQuery() { Id = id });
            if (responseE.Succeeded)
            {

                var entidadViewModel = _mapper.Map<EstrategiaNacionalViewModel>(responseE.Data);
                ViewBag.Ciclo = entidadViewModel.Nombre;
                gestionDesc = entidadViewModel.Gestiones.Where(x => x.Id == AnioGestion).FirstOrDefault()?.Anio ?? string.Empty; ;
                //ViewBag.SNGestion = "N";
                //return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
            }
            var childNode2 = new MvcBreadcrumbNode("OnGetCreateOrEditEstrategia", "EstrategiaNacional", "Gestión " + gestionDesc)
            {
                RouteValues = new { id, AnioGestion },
                OverwriteTitleOnExactMatch = true,
                Parent = childNode1
            };

            var childNode3 = new MvcBreadcrumbNode("OnGetCreateOrEditEstrategia", "EstrategiaNacional", "Objetivos")
            {
                OverwriteTitleOnExactMatch = true,
                Parent = childNode2
            };
            ViewData["BreadcrumbNode"] = childNode3;

            try
            {
                // var brandsResponse = await _mediator.Send(new GetAllBrandsCachedQuery());
                var cat1 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 2 });
                ViewBag.EstadoList = new SelectList(cat1.Data, "Secuencia", "Nombre");
                //ViewData["EstadoList"] = new SelectList(cat1.Data, "Secuencia", "Nombre");

                var cat2 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 3 });
                ViewBag.DimensionesList = new SelectList(cat2.Data, "Secuencia", "Nombre");

                var cat3 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 4 });
                ViewBag.AreaList = new SelectList(cat3.Data, "Secuencia", "Nombre");

                var cat4 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 5 });
                ViewBag.CategoriaList = new SelectList(cat4.Data, "Secuencia", "Nombre");
            }
            catch (Exception ex)
            {
                _notify.Error("No se pudo cargar los Catalogos");
                _logger.LogError("No se pudo cargar los Catalogos", ex);
            }
            if (id == 0)
            {
                var entidadViewModel = new EstrategiaNacionalViewModel();
                return View("_CreateOrEditNacional", entidadViewModel);
                // return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
            }
            else
            {
                var response = await _mediator.Send(new GetEstrategiaNacionalByIdQuery() { Id = id });
                if (response.Succeeded)
                {

                    var entidadViewModel = _mapper.Map<EstrategiaNacionalViewModel>(response.Data);
                    entidadViewModel.AnioGestion = AnioGestion.ToString();
                    entidadViewModel.CategoriaObjetivo = Categoria;
                    ViewBag.Ciclo = entidadViewModel.Nombre;
                    ViewBag.Gestion = entidadViewModel.Gestiones.Where(x => x.Id == AnioGestion).FirstOrDefault()?.Anio ?? string.Empty;
                    ViewBag.SNGestion = "N";
                    ViewBag.Nivel = User.Claims.FirstOrDefault(x => x.Type == "Nivel")?.Value;
                    if (User.Claims.FirstOrDefault(x => x.Type == "Nivel")?.Value == "4" && User.IsInRole("CoordPlanificacion"))
                        entidadViewModel.EsCoordinadorEstrategico = "S";
                    else
                        entidadViewModel.EsCoordinadorEstrategico = "N";

                    return View("_CreateOrEditNacional", entidadViewModel);
                    //return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
                return null;
            }
        }


    }
}
