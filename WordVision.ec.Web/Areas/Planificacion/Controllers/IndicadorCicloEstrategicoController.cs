using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.EstrategiaNacionales.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.Gestiones.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.IndicadorCicloEstrategicos.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.IndicadorCicloEstrategicos.Commands.Delete;
using WordVision.ec.Application.Features.Planificacion.IndicadorCicloEstrategicos.Commands.Update;
using WordVision.ec.Application.Features.Planificacion.IndicadorCicloEstrategicos.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.TiposIndicadores.Queries.GetAll;
using WordVision.ec.Application.Features.Planificacion.TiposIndicadores.Queries.GetById;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Planificacion.Models;

namespace WordVision.ec.Web.Areas.Planificacion.Controllers
{
    [Area("Planificacion")]
    [Authorize]

    public class IndicadorCicloEstrategicoController : BaseController<IndicadorCicloEstrategicoController>
    {
        public async Task<ActionResult> LoadIndicadores(int idEstrategia,string ciclo)
        {
            try
            {
                var response = await _mediator.Send(new GetIndicadorCicloEstrategicoByIdEstrategiaQuery() { Id = idEstrategia });
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<IndicadorCicloEstrategicoViewModel>>(response.Data);
                    ViewBag.IdEstrategia = idEstrategia;
                    var responseE = await _mediator.Send(new GetListGestionByIdQuery() { Id = idEstrategia });
                    //if (responseE.Succeeded)
                    //{

                    //    var entidadViewModel = _mapper.Map<List<GestionViewModel>>(responseE.Data);



                    //     ViewBag.AnioList = entidadViewModel;
                    //}
                    var model = new IndicadorCicloEstrategicoViewModelMaster();
                    model.IndicadorCicloEstrategicoViewModel = viewModel;
                    model.AnioFiscalList = new SelectList(responseE.Data, "Id", "Anio");
                    model.Ciclo = ciclo;
                    //var html1 = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                    //return new JsonResult(new { isValid = true, html = html1 });
                    return PartialView("_ViewAll", model);

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
            //var cat1 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 40 });
            var cat2 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 39 });
            var cat3 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 10 });
            var cat4 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 43 });
            var cat5 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 44 });

            if (id == 0)
            {
                var entidadViewModel = new IndicadorCicloEstrategicoViewModel();
                entidadViewModel.IndicadorVinculadoCEs = new List<IndicadorVinculadoCEViewModel>();
                entidadViewModel.IdEstrategia = idEstrategia;
                var responseE = await _mediator.Send(new GetListGestionByIdQuery() { Id = idEstrategia });
                if (responseE.Succeeded)
                {

                    var gestionViewModel = _mapper.Map<List<GestionViewModel>>(responseE.Data);
                    entidadViewModel.AnioFiscalList = new SelectList(gestionViewModel, "Id", "Anio");
                }
                var entidadModel = await _mediator.Send(new GetTiposIndicadorById() { IdTipoIndicador = 1 });

                entidadViewModel.CodigoIndicadorList = new SelectList(entidadModel.Data, "Id", "CodigoIndicador");
                entidadViewModel.TipoIndicadorList = new SelectList(cat2.Data, "Secuencia", "Nombre");
                entidadViewModel.UnidadMedidaList = new SelectList(cat3.Data, "Secuencia", "Nombre");
                entidadViewModel.ActorParticipanteList = new SelectList(cat4.Data, "Secuencia", "Nombre");
                entidadViewModel.TipoMetaList = new SelectList(cat5.Data, "Secuencia", "Nombre");
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
            }
            else
            {
                var response = await _mediator.Send(new GetIndicadorCicloEstrategicoByIdQuery() { Id = id });
                if (response.Succeeded)
                {
                    var entidadViewModel = _mapper.Map<IndicadorCicloEstrategicoViewModel>(response.Data);
                    var responseE = await _mediator.Send(new GetListGestionByIdQuery() { Id = idEstrategia });
                    if (responseE.Succeeded)
                    {

                        var gestionViewModel = _mapper.Map<List<GestionViewModel>>(responseE.Data);
                        entidadViewModel.AnioFiscalList = new SelectList(gestionViewModel, "Id", "Anio");
                    }
                    var entidadModel = await _mediator.Send(new GetAllTiposIndicadoresQuery() );// { IdTipoIndicador = entidadViewModel.TipoIndicador });
         
                    entidadViewModel.CodigoIndicadorList = new SelectList(entidadModel.Data, "Id", "CodigoIndicador");
                    entidadViewModel.TipoIndicadorList = new SelectList(cat2.Data, "Secuencia", "Nombre");
                    entidadViewModel.UnidadMedidaList = new SelectList(cat3.Data, "Secuencia", "Nombre");
                    entidadViewModel.ActorParticipanteList = new SelectList(cat4.Data, "Secuencia", "Nombre");
                    entidadViewModel.TipoMetaList = new SelectList(cat5.Data, "Secuencia", "Nombre");
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
                  
                    switch (entidad.TipoMeta)
                    {
                        case 1:
                            if (entidad.Meta2 != null && entidad.Meta3 == null)
                            {
                                if (Convert.ToDecimal(entidad.Meta2) < Convert.ToDecimal(entidad.Meta))
                                {
                                    _notify.Information("La meta debe ser mayor");
                                    return new JsonResult(new { isValid = true, Id = id });
                                }
                            }
                            else if (entidad.Meta2 != null && entidad.Meta3 != null)
                            {
                                if (Convert.ToDecimal(entidad.Meta3) < Convert.ToDecimal(entidad.Meta2))
                                {
                                    _notify.Information("La meta debe ser mayor");
                                    return new JsonResult(new { isValid = true, Id = id });
                                }
                            }

                            break;
                        case 2:
                            if (entidad.Meta2 != null && entidad.Meta3 == null)
                            {
                                if (Convert.ToDecimal(entidad.Meta2) > Convert.ToDecimal(entidad.Meta))
                                {
                                    _notify.Information("La meta debe ser menor");
                                }
                            }
                            else if (entidad.Meta2 != null && entidad.Meta3 != null)
                            {
                                if (Convert.ToDecimal(entidad.Meta3) > Convert.ToDecimal(entidad.Meta2))
                                {
                                    _notify.Information("La meta debe ser mayor");
                                    return new JsonResult(new { isValid = true, Id = id });
                                }
                            }
                            break;
                        case 3:
                            if (entidad.Meta2 != null && entidad.Meta3 == null)
                            {
                                if (Convert.ToDecimal(entidad.Meta2) != Convert.ToDecimal(entidad.Meta))
                                {
                                    _notify.Information("La meta debe ser igual");
                                }
                            }
                            else if (entidad.Meta2 != null && entidad.Meta3 != null)
                            {
                                if (Convert.ToDecimal(entidad.Meta3) != Convert.ToDecimal(entidad.Meta2))
                                {
                                    _notify.Information("La meta debe ser mayor");
                                    return new JsonResult(new { isValid = true, Id = id });
                                }
                            }
                            break;
                        case 4:
                            //if($(this).val() > m1) {
                            //    alert('Debe ser mayor');
                            //    }
                            break;

                        default:
                            _notify.Information("Debe seleccionar un tipo de meta.");
                            break;
                    }

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

                    var response = await _mediator.Send(new GetIndicadorCicloEstrategicoByIdEstrategiaQuery() { Id = entidad.IdEstrategia });
                    if (response.Succeeded)
                    {
                        var viewModel = _mapper.Map<List<IndicadorCicloEstrategicoViewModel>>(response.Data);
                        ViewBag.IdEstrategia = entidad.IdEstrategia;
                        var responseE = await _mediator.Send(new GetListGestionByIdQuery() { Id = entidad.IdEstrategia });

                        var model = new IndicadorCicloEstrategicoViewModelMaster();
                        model.IndicadorCicloEstrategicoViewModel = viewModel;
                        model.AnioFiscalList = new SelectList(responseE.Data, "Id", "Anio");
                        var html1 = await _viewRenderer.RenderViewToStringAsync("_ViewAll", model);
                        return new JsonResult(new { isValid = true, opcion = 102, page = "#viewAllIndicador", html = html1 });

                    }
                    else
                    {
                        _notify.Error(response.Message);
                        return null;
                    }


                }
                else
                {
                    return new JsonResult(new { isValid = false, Id = id });
                }
                //return new JsonResult(new { isValid = true, Id = id });
            }
            catch (Exception ex)
            {
                _logger.LogError("OnPostCreateOrEdit", ex);
                _notify.Error("Error al insertar Gestion");
            }
            return null;
        }


        public async Task<JsonResult> OnPostDelete(int id = 0, int idEstrategia=0)
        {
            var deleteCommand = await _mediator.Send(new DeleteIndicadorCicloEstrategicoCommand { Id = id });
            if (deleteCommand.Succeeded)
            {
                _notify.Information($"Indicador con Id {id} Eliminado.");
              
            }
            else
            {
                _notify.Error(deleteCommand.Message);
               
            }
            var response = await _mediator.Send(new GetIndicadorCicloEstrategicoByIdEstrategiaQuery() { Id = idEstrategia });
            if (response.Succeeded)
            {
                var viewModel = _mapper.Map<List<IndicadorCicloEstrategicoViewModel>>(response.Data);
                ViewBag.IdEstrategia = idEstrategia;
                var responseE = await _mediator.Send(new GetListGestionByIdQuery() { Id = idEstrategia });

                var model = new IndicadorCicloEstrategicoViewModelMaster();
                model.IndicadorCicloEstrategicoViewModel = viewModel;
                model.AnioFiscalList = new SelectList(responseE.Data, "Id", "Anio");
                var html1 = await _viewRenderer.RenderViewToStringAsync("_ViewAll", model);
                return new JsonResult(new { isValid = true, opcion = 102, page = "#viewAllIndicador", html = html1 });

            }
            else
            {
                _notify.Error(response.Message);
                return null;
            }
        }

    }
}
