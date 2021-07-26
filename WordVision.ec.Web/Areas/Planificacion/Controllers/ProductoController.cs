using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using SmartBreadcrumbs.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Planificacion.EstrategiaNacionales.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.FactorCriticoExitoes.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.Gestiones.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.IndicadorEstrategicoes.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.ObjetivoEstrategicoes.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.Productos.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.Productos.Commands.Update;
using WordVision.ec.Application.Features.Planificacion.Productos.Queries.GetAllCached;
using WordVision.ec.Application.Features.Planificacion.Productos.Queries.GetById;
using WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetAllCached;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Planificacion.Models;
using WordVision.ec.Web.Areas.Registro.Models;

namespace WordVision.ec.Web.Areas.Planificacion.Controllers
{
    [Area("Planificacion")]
    [Authorize]
    public class ProductoController :  BaseController<ProductoController>
    {
        public async Task<IActionResult> Index(int id,int idObjetivo, int idEstrategia, int AnioGestion)
        {
            int idObjetivoEstra = idObjetivo;
            int idIndicadorEstra = id;
            string descFactorCritico=String.Empty;
            string descMetaGestio = String.Empty;
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

            var responseI = await _mediator.Send(new GetIndicadorEstrategicoByIdQuery() { Id = id });
            if (responseI.Succeeded)
            {
                ViewBag.Indicador = responseI.Data.IndicadorResultado;
                descFactorCritico=responseI.Data.FactorCriticoExitos.FactorCritico;
                descMetaGestio = responseI.Data.IndicadorAFs.Where(m => m.Anio == AnioGestion.ToString()).FirstOrDefault().Meta.ToString();
                //id = response.Data.IdEstrategia;
            }

            var ciclo = idEstrategia;
            var childNode1 = new MvcBreadcrumbNode("PlanImplementacion", "EstrategiaNacional", "Ciclo Estratégico", false, null, "Planificacion")
            {
                RouteValues = new { ciclo },//this comes in as a param into the action
                                            // Parent = childNode0
            };

            id = idEstrategia;
            var childNode2 = new MvcBreadcrumbNode("OnGetCreateOrEditEstrategia", "EstrategiaNacional", "Gestión " + gestionDesc)
            {
                RouteValues = new { id, AnioGestion },
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

            id = idIndicadorEstra;
            var childNode4 = new MvcBreadcrumbNode("Index", "Producto", "Productos")
            {
                RouteValues = new { id, idEstrategia, AnioGestion },
                OverwriteTitleOnExactMatch = true,
                Parent = childNode3
            };

            ViewData["BreadcrumbNode"] = childNode4;

            //var childNode2 = new MvcBreadcrumbNode("Index", "FactorCriticoExito", "Factor Critico de Exito")
            //{
            //    OverwriteTitleOnExactMatch = true,
            //    Parent = childNode1
            //};

            //ViewData["BreadcrumbNode"] = childNode2;

            var model = new ProductoViewModel();
            model.IdObjetivoEstra = idObjetivoEstra;
            model.IdGestion = AnioGestion;
            model.IdIndicadorEstrategico = id;
            model.DescFactorCritico = descFactorCritico;
            model.DescMetaGestion = descMetaGestio;
            model.DescGestion = gestionDesc;
            ViewBag.Nivel = User.Claims.FirstOrDefault(x => x.Type == "Nivel")?.Value;
            return View( model);
        }

        public async Task<IActionResult> LoadAll(int idIndicador, int idGestion)
        {
            try
            {

                var response = await _mediator.Send(new GetIndicadorEstrategicoByIdQuery() { Id = idIndicador });
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<IndicadorEstrategicoViewModel>(response.Data);
                    viewModel.IdGestion = idGestion;
                    return PartialView("_ViewAll", viewModel);
                }
            }
            catch (Exception ex)
            {
                _notify.Error("No se pudo cargar los Productos");
                _logger.LogError("LoadAll", ex);
            }
            return null;
        }
        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0, int idGestion = 0, int idIndicadorEstra = 0)
        {
            
            if (id == 0)
            {
                var entidadViewModel = new ProductoViewModel();
                entidadViewModel.IdGestion = idGestion;
                entidadViewModel.IdIndicadorEstrategico = idIndicadorEstra;
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
            }
            else
            {
                var response = await _mediator.Send(new GetProductoByIdQuery() { Id = id });
                if (response.Succeeded)
                {
                    var entidadViewModel = _mapper.Map<ProductoViewModel>(response.Data);
                    entidadViewModel.IdGestion = idGestion;
                    entidadViewModel.IdIndicadorEstrategico = idIndicadorEstra;
                    var colaborador = await _mediator.Send(new GetAllColaboradoresCachedQuery());
                    if (colaborador.Succeeded)
                    {
                        var responsable = _mapper.Map<List<ColaboradorViewModel>>(colaborador.Data);
                        entidadViewModel.responsableList = new SelectList(responsable, "Id", "Nombres");
                    }
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
            }
            return null;
        }


        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(int id, ProductoViewModel producto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                  
                    if (id == 0)
                    {
                        var createEntidadCommand = _mapper.Map<CreateProductoCommand>(producto);
                      
                        var result = await _mediator.Send(createEntidadCommand);
                        if (result.Succeeded)
                        {
                            id = result.Data;
                            _notify.Success($"Producto Creado.");
                        }
                        else _notify.Error(result.Message);
                    }
                    else
                    {
                        var updateEntidadCommand = _mapper.Map<UpdateProductoCommand>(producto);
                        updateEntidadCommand.Id = id;
                        var result = await _mediator.Send(updateEntidadCommand);
                        if (result.Succeeded) _notify.Information($"Producto Actualizado.");
                    }
                    var response = await _mediator.Send(new GetIndicadorEstrategicoByIdQuery() { Id = producto.IdIndicadorEstrategico });
                    if (response.Succeeded)
                    {

                        var entidadViewModel = _mapper.Map<IndicadorEstrategicoViewModel>(response.Data);
                        entidadViewModel.IdGestion = producto.IdGestion;
                        return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", entidadViewModel) });
                    }
                    else
                    {   
                        _notify.Error(response.Message);
                        return null;
                    }
                    

                }
                else
                {
                    var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", producto);
                    return new JsonResult(new { isValid = false, html = html });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("OnPostCreateOrEdit", ex);
                _notify.Error("Error al insertar Producto");
            }
            return null;
        }


         public async Task<IActionResult> LoadIndicadores(int id, int idObjetivo, int idEstrategia, int AnioGestion)
        {
            try
            {
                int idObjetivoEstra = idObjetivo;
                int idIndicadorEstra = id;
                string descFactorCritico = String.Empty;
                string descMetaGestio = String.Empty;
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

                var responseI = await _mediator.Send(new GetIndicadorEstrategicoByIdQuery() { Id = id });
                if (responseI.Succeeded)
                {
                    ViewBag.Indicador = responseI.Data.IndicadorResultado;
                    descFactorCritico = responseI.Data.FactorCriticoExitos.FactorCritico;
                    descMetaGestio = responseI.Data.IndicadorAFs.Where(m => m.Anio == AnioGestion.ToString()).FirstOrDefault().Meta.ToString();
                    //id = response.Data.IdEstrategia;
                }

                var ciclo = idEstrategia;
                var childNode1 = new MvcBreadcrumbNode("PlanImplementacion", "EstrategiaNacional", "Ciclo Estratégico", false, null, "Planificacion")
                {
                    RouteValues = new { ciclo },//this comes in as a param into the action
                                                // Parent = childNode0
                };

                id = idEstrategia;
                var childNode2 = new MvcBreadcrumbNode("OnGetCreateOrEditEstrategia", "EstrategiaNacional", "Gestión " + gestionDesc)
                {
                    RouteValues = new { id, AnioGestion },
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

                id = idIndicadorEstra;
                var childNode4 = new MvcBreadcrumbNode("Index", "Producto", "Productos")
                {
                    RouteValues = new { id, idEstrategia, AnioGestion },
                    OverwriteTitleOnExactMatch = true,
                    Parent = childNode3
                };

                ViewData["BreadcrumbNode"] = childNode4;

                var responseIp = await _mediator.Send(new GetProductoByIdIndicadorQuery() { Id = idIndicadorEstra });
                if (responseIp.Succeeded)
                {
                    ViewBag.IdGestion = AnioGestion;
                    ViewBag.DescGestion = gestionDesc;
                    ViewBag.IdObjetivo = idObjetivo;
                    ViewBag.IdEstrategia = idEstrategia;
                    ViewBag.DescFactorCritico = descFactorCritico;
                    ViewBag.DescMetaGestion = descMetaGestio;
                  
                    var viewModel = _mapper.Map<List<ProductoViewModel>>(responseIp.Data);
                    return View("_ViewAllxIndicador", viewModel);
                }
            }
            catch (Exception ex)
            {
                _notify.Error("No se pudo cargar los Factores");
                _logger.LogError("LoadAll", ex);
            }
            return null;
        }


    }
}
