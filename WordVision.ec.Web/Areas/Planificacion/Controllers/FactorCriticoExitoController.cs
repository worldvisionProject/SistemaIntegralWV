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
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.Actividades.Queries.GetAllCached;
using WordVision.ec.Application.Features.Planificacion.EstrategiaNacionales.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.FactorCriticoExitoes.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.FactorCriticoExitoes.Commands.Delete;
using WordVision.ec.Application.Features.Planificacion.FactorCriticoExitoes.Commands.Update;
using WordVision.ec.Application.Features.Planificacion.FactorCriticoExitoes.Queries.GetAllCached;
using WordVision.ec.Application.Features.Planificacion.FactorCriticoExitoes.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.Gestiones.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.IndicadorEstrategicoes.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.IndicadorPOAs.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.ObjetivoEstrategicoes.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.ObjetivoEstrategicoes.Commands.Update;
using WordVision.ec.Application.Features.Planificacion.ObjetivoEstrategicoes.Queries.GetAllCached;
using WordVision.ec.Application.Features.Planificacion.ObjetivoEstrategicoes.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.Productos.Queries.GetAllCached;
using WordVision.ec.Application.Features.Planificacion.Productos.Queries.GetById;
using WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetById;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Planificacion.Models;
using WordVision.ec.Web.Areas.Registro.Models;

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


        public async Task<IActionResult> IndexIndicador(int id, int idEstrategia, int AnioGestion, int Categoria)
        {
            int idObjetivoEstra = id;

            var TipoObjetivo = string.Empty;
            var response = await _mediator.Send(new GetObjetivoEstrategicoByIdQuery() { Id = idObjetivoEstra });
            if (response.Succeeded)
            {
                ViewBag.Message = response.Data.Descripcion;
                var catCategoria = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 5 });
                TipoObjetivo = catCategoria.Data.Where(r => r.Secuencia == response.Data.Categoria).FirstOrDefault().Nombre;
                //id = response.Data.IdEstrategia;
                ViewBag.Categoria = TipoObjetivo;
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
            var childNode2 = new MvcBreadcrumbNode("OnGetCreateOrEditEstrategia", "EstrategiaNacional", "Gestión " + gestionDesc)
            {
                RouteValues = new { id, AnioGestion },
                OverwriteTitleOnExactMatch = true,
                Parent = childNode1
            };

            id = idEstrategia;
            var childNode21 = new MvcBreadcrumbNode("OnGetCreateOrEditEstrategia", "EstrategiaNacional", "Objetivo "+ TipoObjetivo)
            {
                RouteValues = new { id, AnioGestion, Categoria },
                OverwriteTitleOnExactMatch = true,
                Parent = childNode2
            };


            id = idObjetivoEstra;
            var childNode3 = new MvcBreadcrumbNode("IndexIndicador", "FactorCriticoExito", "Indicadores de Resultado")
            {
                RouteValues = new { id, idEstrategia, AnioGestion },
                OverwriteTitleOnExactMatch = true,
                Parent = childNode21
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
        public async Task<IActionResult> LoadFactorIndicadores(int idObjetivo, int idGestion)
        {
            try
            {
                int idColaborador = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value);
                //switch (Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Nivel")?.Value))
                //{
                //    case 2:
                //        idColaborador = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value);
                //        break;
                //    case 3:
                //        idColaborador = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "ReportaA")?.Value);
                //        break;
                //    case 4:
                //        idColaborador = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "ReportaA")?.Value);
                //        var responseGerencia = await _mediator.Send(new GetColaboradorByIdQuery() { Id = idColaborador });
                //        if (responseGerencia.Succeeded)
                //        {
                //            var responseNivel = await _mediator.Send(new GetColaboradorByNivelQuery() { Nivel1 = 1, Nivel2 = 2 });

                //            idColaborador = responseNivel.Data.Where(c => c.Cargo == responseGerencia.Data.Estructuras.ReportaID).FirstOrDefault().Id;
                //        }
                //        break;
                //}
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

                //var response = await _mediator.Send(new GetFactorCriticoxObjetivoByIdQuery() { Id = idObjetivo, IdColaborador = idColaborador, IdGestion = idGestion });
                //if (response.Succeeded)
                //{
                //    ViewBag.IdGestion = idGestion;
                //    ViewBag.DescGestion = descGestion;
                //    ViewBag.IdObjetivo = idObjetivo;
                //    ViewBag.IdEstrategia = responseO.Data.IdEstrategia;

                //    var viewModel = _mapper.Map<List<FactorCriticoExitoViewModel>>(response.Data);
                //    return PartialView("_ViewAllxIndicador", viewModel);
                //}
                var colaborador = await _mediator.Send(new GetColaboradorByNivelQuery() { Nivel1 = 2, Nivel2 = 3 });
               
                switch (Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Nivel")?.Value))
                {
                    case 2:

                        var response = await _mediator.Send(new GetAllIndicadorEstrategicoesQuery() { IdObjetivoEstrategico = idObjetivo,IdColaborador=idColaborador });
                        if (response.Succeeded)
                        {
                            ViewBag.IdGestion = idGestion;
                            ViewBag.DescGestion = descGestion;
                            ViewBag.IdObjetivo = idObjetivo;
                            ViewBag.IdEstrategia = responseO.Data.IdEstrategia;
                            var ListatableroModel = new List<TableroControlViewModel>();
                            var viewModel = _mapper.Map<List<IndicadorEstrategicoViewModel>>(response.Data.Where(i => i.Responsable == idColaborador));
                            var listTableroModel = new List<TableroControlViewModel>();
                            for (var i=0;i< viewModel.Count();i++)
                            {
                               
                                if (viewModel[i].Productos.Count() != 0)
                                {
                                    for (var j = 0; j < viewModel[i].Productos.Count(); j++)
                                    {
                                        viewModel[i].Productos[j].DescCargoResponsable = colaborador.Data.Where(c => c.Id == viewModel[i].Productos[j].IdCargoResponsable).FirstOrDefault().Alias;

                                        if (viewModel[i].Productos[j].IndicadorPOAs.Count() != 0)
                                        {
                                            for (var k = 0; k < viewModel[i].Productos[j].IndicadorPOAs.Count(); k++)
                                            {
                                                if (viewModel[i].Productos[j].IndicadorPOAs[k].Actividades.Count() != 0)
                                                {
                                                    for (var l = 0; l < viewModel[i].Productos[j].IndicadorPOAs[k].Actividades.Count(); l++)
                                                    {
                                                        var tableroModel = new TableroControlViewModel();
                                                        tableroModel.IdObjetivoEstrategico = idObjetivo;
                                                        tableroModel.IdFactor = viewModel[i].FactorCriticoExitos.Id;
                                                        tableroModel.DescFactor = viewModel[i].FactorCriticoExitos.FactorCritico;

                                                        tableroModel.IdIndicadorEstrategico = viewModel[i].Id;
                                                        tableroModel.DescIndicadorEstrategico = viewModel[i].IndicadorResultado;
                                                        tableroModel.IdRespIndicadorEstrategico = (int)viewModel[i].Responsable;

                                                        tableroModel.IdProducto = viewModel[i].Productos[j].Id;
                                                        tableroModel.DescProducto = viewModel[i].Productos[j].DescProducto;
                                                        tableroModel.IdRespProducto = (int)viewModel[i].Productos[j].IdCargoResponsable;

                                                        tableroModel.IdIndicadorProducto = viewModel[i].Productos[j].IndicadorPOAs[k].Id;
                                                        tableroModel.DescIndicadorProducto = viewModel[i].Productos[j].IndicadorPOAs[k].IndicadorProducto;
                                                        tableroModel.IdRespIndicadorProducto = (int)viewModel[i].Productos[j].IndicadorPOAs[k].Responsable;

                                                        tableroModel.IdActividad = viewModel[i].Productos[j].IndicadorPOAs[k].Actividades[l].Id;
                                                        tableroModel.DescActividad = viewModel[i].Productos[j].IndicadorPOAs[k].Actividades[l].DescripcionActividad;
                                                        tableroModel.IdRespActividad = (int)viewModel[i].Productos[j].IndicadorPOAs[k].Actividades[l].IdCargoResponsable;
                                                        ListatableroModel.Add(tableroModel);
                                                    }
                                                }
                                                else
                                                {
                                                    var lact = new List<ActividadViewModel>();
                                                    var act = new ActividadViewModel();
                                                    lact.Add(act);
                                                    viewModel[i].Productos[j].IndicadorPOAs[k].Actividades = lact;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            var lact = new List<IndicadorPOAViewModel>();
                                            var act = new IndicadorPOAViewModel();
                                            var lact1 = new List<ActividadViewModel>();
                                            var act1 = new ActividadViewModel();
                                            lact1.Add(act1);
                                            act.Actividades = lact1;
                                            lact.Add(act);
                                            viewModel[i].Productos[j].IndicadorPOAs = lact;


                                        }
                                    }

                                }
                                else
                                {
                                    var lpro = new List<ProductoViewModel>();
                                    var pro = new ProductoViewModel();

                                    var lact = new List<IndicadorPOAViewModel>();
                                    var act = new IndicadorPOAViewModel();
                                    
                                    var lact1 = new List<ActividadViewModel>();
                                    var act1 = new ActividadViewModel();
                                    lact1.Add(act1);
                                    
                                    act.Actividades = lact1;
                                    lact.Add(act);
                                 
                                    pro.IndicadorPOAs = lact;
                                    lpro.Add(pro);
                                    viewModel[i].Productos = lpro;
                                }
                            }

                             return PartialView("_ViewAllxIndicador", viewModel);
                        }
                        break;
                    case 3:
                        var responseProducto = await _mediator.Send(new GetProductoByIdObjetivoQuery() { IdObjetivoEstrategico = idObjetivo, IdColaborador = idColaborador });
                        if (responseProducto.Succeeded)
                        {
                            ViewBag.IdGestion = idGestion;
                            ViewBag.DescGestion = descGestion;
                            ViewBag.IdObjetivo = idObjetivo;
                            ViewBag.IdEstrategia = responseO.Data.IdEstrategia;

                            var viewModel = _mapper.Map<List<ProductoViewModel>>(responseProducto.Data.Where(c => c.IdCargoResponsable == idColaborador));
                            if (viewModel.Count != 0)
                            {
                                for (var j = 0; j < viewModel.Count(); j++)
                                {
                                    viewModel[j].IndicadorEstrategicos.DescResponsable = colaborador.Data.Where(c => c.Id == viewModel[j].IndicadorEstrategicos.Responsable).FirstOrDefault().Alias;
                                    if (viewModel[j].IndicadorPOAs.Count() != 0)
                                    {
                                        for (var k = 0; k < viewModel[j].IndicadorPOAs.Count(); k++)
                                        {
                                            viewModel[j].IndicadorPOAs[k].DescResponsable = colaborador.Data.Where(c => c.Id == viewModel[j].IndicadorPOAs[k].Responsable).FirstOrDefault().Alias;
                                            if (viewModel[j].IndicadorPOAs[k].Actividades.Count() != 0)
                                            {
                                                for (var l = 0; l < viewModel[j].IndicadorPOAs[k].Actividades.Count(); l++)
                                                {
                                                    
                                                }
                                            }
                                            else
                                            {
                                                var lact = new List<ActividadViewModel>();
                                                var act = new ActividadViewModel();
                                                lact.Add(act);
                                                viewModel[j].IndicadorPOAs[k].Actividades = lact;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        var lact = new List<IndicadorPOAViewModel>();
                                        var act = new IndicadorPOAViewModel();
                                        var lact1 = new List<ActividadViewModel>();
                                        var act1 = new ActividadViewModel();
                                        lact1.Add(act1);
                                        act.Actividades = lact1;
                                        lact.Add(act);
                                        viewModel[j].IndicadorPOAs = lact;


                                    }
                                }

                            }
                            else
                            {

                                var responseIndicadorProducto = await _mediator.Send(new GetIndicadorPOAByIdObjetivoQuery() { IdObjetivoEstrategico = idObjetivo, IdColaborador = idColaborador });
                                if (responseIndicadorProducto.Succeeded)
                                {
                                    var ListatableroModel = new List<TableroControlViewModel>();
                                    var viewModelIndicador = _mapper.Map<List<IndicadorPOAViewModel>>(responseIndicadorProducto.Data.Where(c => c.Responsable == idColaborador));
                                    if (viewModelIndicador.Count() != 0)
                                    {
                                        for (var k = 0; k < viewModelIndicador.Count(); k++)
                                        {

                                            viewModelIndicador[k].DescResponsable = colaborador.Data.Where(c => c.Id == viewModelIndicador[k].Responsable).FirstOrDefault().Alias;
                                            if (viewModelIndicador[k].Actividades.Count() != 0)
                                            {
                                                for (var l = 0; l < viewModelIndicador[k].Actividades.Count(); l++)
                                                {
                                                    var tableroModel = new TableroControlViewModel();
                                                    tableroModel.IdObjetivoEstrategico = idObjetivo;
                                                    tableroModel.IdFactor = viewModelIndicador[k].Productos.IndicadorEstrategicos.FactorCriticoExitos.Id;
                                                    tableroModel.DescFactor = viewModelIndicador[k].Productos.IndicadorEstrategicos.FactorCriticoExitos.FactorCritico;

                                                    tableroModel.IdIndicadorEstrategico = viewModelIndicador[k].Productos.IndicadorEstrategicos.Id;
                                                    tableroModel.DescIndicadorEstrategico = viewModelIndicador[k].Productos.IndicadorEstrategicos.IndicadorResultado;
                                                    tableroModel.IdRespIndicadorEstrategico = (int)viewModelIndicador[k].Productos.IndicadorEstrategicos.Responsable;

                                                    tableroModel.IdProducto = viewModelIndicador[k].Productos.Id;
                                                    tableroModel.DescProducto = viewModelIndicador[k].Productos.DescProducto;
                                                    tableroModel.IdRespProducto = (int)viewModelIndicador[k].Productos.IdCargoResponsable;

                                                    tableroModel.IdIndicadorProducto = viewModelIndicador[k].Id;
                                                    tableroModel.DescIndicadorProducto = viewModelIndicador[k].IndicadorProducto;
                                                    tableroModel.IdRespIndicadorProducto = (int)viewModelIndicador[k].Responsable;

                                                    tableroModel.IdActividad = viewModelIndicador[k].Actividades[l].Id;
                                                    tableroModel.DescActividad = viewModelIndicador[k].Actividades[l].DescripcionActividad;
                                                    tableroModel.IdRespActividad = (int)viewModelIndicador[k].Actividades[l].IdCargoResponsable;
                                                    ListatableroModel.Add(tableroModel);
                                                }
                                            }
                                            else
                                            {
                                                var lact = new List<ActividadViewModel>();
                                                var act = new ActividadViewModel();
                                                lact.Add(act);
                                                viewModelIndicador[k].Actividades = lact;

                                                var tableroModel = new TableroControlViewModel();
                                                tableroModel.IdObjetivoEstrategico = idObjetivo;
                                                tableroModel.IdFactor = viewModelIndicador[k].Productos.IndicadorEstrategicos.FactorCriticoExitos.Id;
                                                tableroModel.DescFactor = viewModelIndicador[k].Productos.IndicadorEstrategicos.FactorCriticoExitos.FactorCritico;

                                                tableroModel.IdIndicadorEstrategico = viewModelIndicador[k].Productos.IndicadorEstrategicos.Id;
                                                tableroModel.DescIndicadorEstrategico = viewModelIndicador[k].Productos.IndicadorEstrategicos.IndicadorResultado;
                                                tableroModel.IdRespIndicadorEstrategico = (int)viewModelIndicador[k].Productos.IndicadorEstrategicos.Responsable;

                                                tableroModel.IdProducto = viewModelIndicador[k].Productos.Id;
                                                tableroModel.DescProducto = viewModelIndicador[k].Productos.DescProducto;
                                                tableroModel.IdRespProducto = (int)viewModelIndicador[k].Productos.IdCargoResponsable;

                                                tableroModel.IdIndicadorProducto = viewModelIndicador[k].Id;
                                                tableroModel.DescIndicadorProducto = viewModelIndicador[k].IndicadorProducto;
                                                tableroModel.IdRespIndicadorProducto = (int)viewModelIndicador[k].Responsable;

                                                tableroModel.IdActividad = 0;
                                                tableroModel.DescActividad = null;
                                                tableroModel.IdRespActividad = 0;
                                                ListatableroModel.Add(tableroModel);
                                            }

                                        }

                                        var viewModelP = new ProductoViewModel();
                                        viewModelP.IndicadorPOAs = viewModelIndicador;
                                     
                                        viewModel = new List<ProductoViewModel>();
                                        viewModel.Add(viewModelP);
                                        
                                    }
                                    else
                                    {
                                        var lact = new List<IndicadorPOAViewModel>();
                                        var act = new IndicadorPOAViewModel();
                                        var lact1 = new List<ActividadViewModel>();
                                        var act1 = new ActividadViewModel();
                                        lact1.Add(act1);
                                        act.Actividades = lact1;
                                        lact.Add(act);
                                        viewModelIndicador = lact;


                                    }
                                    //var viewModelP = new ProductoViewModel();
                                    //viewModelP.IndicadorPOAs = viewModelIndicador;
                                    //viewModel = new List<ProductoViewModel>();
                                    //viewModel.Add(viewModelP);
                                }
                               

                            }
                            return PartialView("_ViewAllxProducto", viewModel);
                        }
                        break;

                    case 4:
                        var responseActividad = await _mediator.Send(new GetAllActividadesQuery() { IdObjetivoEstrategico = idObjetivo,IdColaborador=idColaborador });
                        if (responseActividad.Succeeded)
                        {
                            ViewBag.IdGestion = idGestion;
                            ViewBag.DescGestion = descGestion;
                            ViewBag.IdObjetivo = idObjetivo;
                            ViewBag.IdEstrategia = responseO.Data.IdEstrategia;
                            var res = responseActividad.Data;
                            var viewModel = _mapper.Map<List<ActividadViewModel>>(res);
                            return PartialView("_ViewAllxActividad", viewModel);
                        }


                        break;

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



        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0, int idObjetivoEstra = 0)
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
            }
            catch (Exception ex)
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
                _notify.Error(deleteCommand.Message);
                return null;
            }
        }

    }
}
