﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.Actividades.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.Actividades.Commands.Delete;
using WordVision.ec.Application.Features.Planificacion.Actividades.Commands.Update;
using WordVision.ec.Application.Features.Planificacion.Actividades.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.Gestiones.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.IndicadorEstrategicoes.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.IndicadorPOAes.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.IndicadorPOAs.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.IndicadorPOAs.Commands.Update;
using WordVision.ec.Application.Features.Planificacion.Productos.Queries.GetById;
using WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetAllCached;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Planificacion.Models;
using WordVision.ec.Web.Areas.Registro.Models;

namespace WordVision.ec.Web.Areas.Planificacion.Controllers
{
    [Area("Planificacion")]
    [Authorize]
    public class ActividadController : BaseController<ActividadController>
    {
        public IActionResult Index()
        {
            var model = new IndicadorPOAViewModel();

            return View(model);
        }
        public async Task<IActionResult> LoadAll()
        {
            //var response = await _mediator.Send(new GetAllIndicadorEstrategicoesCachedQuery());
            //if (response.Succeeded)
            //{

            //  var viewModel = _mapper.Map<List<IndicadorEstrategicoViewModel>>(response.Data);

            //return PartialView("_ViewAll", viewModel);
            //}
            return null;
        }

        public async Task<JsonResult> LoadIndicadores(int idProducto)
        {
            var response = await _mediator.Send(new GetProductoByIdQuery() { Id = idProducto });
            if (response.Succeeded)
            {
                var viewModel = _mapper.Map<ProductoViewModel>(response.Data);
                var colaborador = await _mediator.Send(new GetAllColaboradoresCachedQuery());
                if (colaborador.Succeeded)
                {
                    var responsable = _mapper.Map<List<ColaboradorViewModel>>(colaborador.Data);
                    viewModel.responsableList = new SelectList(responsable, "Id", "Nombres");
                }
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel) });


            }
            return null;
        }


        public async Task<JsonResult> LoadxIndicadores(int idIndicadorPOA, int idIndicadorEstrategia = 0, int idGestion = 0)
        {
            try
            {

                var response = await _mediator.Send(new GetIndicadorPOAByIdQuery() { Id = idIndicadorPOA });
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<IndicadorPOAViewModel>(response.Data);
                    viewModel.IdIndicadorEstrategia = idIndicadorEstrategia;
                    viewModel.IdGestion = idGestion;
                    var colaborador = await _mediator.Send(new GetAllColaboradoresCachedQuery());
                    if (colaborador.Succeeded)
                    {
                        var responsable = _mapper.Map<List<ColaboradorViewModel>>(colaborador.Data);
                        viewModel.responsableList = new SelectList(responsable, "Id", "Nombres");
                    }
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel) });


                }
            }
            catch (Exception ex)
            {
                _logger.LogError("LoadxIndicadores", ex);
                _notify.Error("Error al insertar IndicadorEstrategico");
            }
            return null;
        }

        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0, int idIndicadorEstrategia = 0, int idGestion = 0, int idProducto = 0, int idIndicadorPOA = 0, int idResponsablePOA = 0)
        {
            string descProducto = "";
            string descObjetivo = "";
            string descFactor = "";
            string descIndicador = "";
            string descMeta = "";
            string descGestion = "";
            int idResponsable = 0;
            string descLineaBase = "";
            int idResponsableProd = 0;
            string descUnidad = "";

            var responseG = await _mediator.Send(new GetGestionByIdQuery() { Id = idGestion });
            if (responseG.Succeeded)
            {
                var entidadViewModel = _mapper.Map<GestionViewModel>(responseG.Data);
                descGestion = entidadViewModel?.Anio ?? "";
            }

            var responseI = await _mediator.Send(new GetIndicadorEstrategicoByIdQuery() { Id = idIndicadorEstrategia });
            if (responseI.Succeeded)
            {
                var entidadViewModel = _mapper.Map<IndicadorEstrategicoViewModel>(responseI.Data);
                descProducto = entidadViewModel.Productos.Where(p => p.Id == idProducto).FirstOrDefault().DescProducto;
                idResponsableProd = entidadViewModel.Productos.Where(p => p.Id == idProducto).FirstOrDefault().IdCargoResponsable;
                descObjetivo = entidadViewModel.FactorCriticoExitos.ObjetivoEstrategicos.Descripcion;
                descFactor = entidadViewModel.FactorCriticoExitos.FactorCritico;
                descIndicador = entidadViewModel.IndicadorResultado;
                descMeta = entidadViewModel.IndicadorAFs.Where(x => x.Anio == idGestion.ToString()).FirstOrDefault()?.Meta;
                idResponsable = (int)entidadViewModel.Responsable;
                descLineaBase = entidadViewModel.LineaBase;
                var cat2 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 10 });
                descUnidad = cat2.Data.Where(x => x.Secuencia == entidadViewModel.UnidadMedida.ToString())?.FirstOrDefault()?.Nombre ?? "";

            }
            if (id == 0)
            {
                var indicadorPOA = "";
                var response = await _mediator.Send(new GetIndicadorPOAByIdQuery() { Id = idIndicadorPOA });
                if (response.Succeeded)
                {
                    indicadorPOA = response.Data.IndicadorProducto;
                    idResponsablePOA = (int)response.Data.Responsable;
                }

                var entidadViewModel = new ActividadViewModel();
                entidadViewModel.DescProducto = descProducto;
                entidadViewModel.DescObjetivo = descObjetivo;
                entidadViewModel.DescFactor = descFactor;
                entidadViewModel.DescIndicador = descIndicador;
                entidadViewModel.DescMeta = descMeta;
                entidadViewModel.DescUnidad = descUnidad;
                entidadViewModel.DescGestion = descGestion;
                entidadViewModel.DescLineaBase = descLineaBase;
                entidadViewModel.IdProducto = idProducto;
                entidadViewModel.IndicadorProducto = indicadorPOA;
                entidadViewModel.IdIndicadorPOA = idIndicadorPOA;
                var colaborador = await _mediator.Send(new GetAllColaboradoresCachedQuery());
                if (colaborador.Succeeded)
                {
                    var responsa = _mapper.Map<List<ColaboradorViewModel>>(colaborador.Data);
                    entidadViewModel.responsableList = new SelectList(responsa, "Id", "Nombres");
                    entidadViewModel.ResponsableIndicador = responsa.Where(r => r.Id == idResponsable).FirstOrDefault().Nombres;
                    entidadViewModel.DescResponsable = responsa.Where(r => r.Id == idResponsablePOA).FirstOrDefault().Nombres;
                }
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
            }
            else
            {
                var indicadorPOA = "";
                var responsePOA = await _mediator.Send(new GetIndicadorPOAByIdQuery() { Id = idIndicadorPOA });
                if (responsePOA.Succeeded)
                {
                    indicadorPOA = responsePOA.Data.IndicadorProducto;
                    idResponsablePOA = (int)responsePOA.Data.Responsable;
                }

                var response = await _mediator.Send(new GetActividadByIdQuery() { Id = id });
                if (response.Succeeded)
                {
                    var entidadViewModel = _mapper.Map<ActividadViewModel>(response.Data);
                    entidadViewModel.DescProducto = descProducto;
                    entidadViewModel.DescObjetivo = descObjetivo;
                    entidadViewModel.DescFactor = descFactor;
                    entidadViewModel.DescIndicador = descIndicador;
                    entidadViewModel.DescMeta = descMeta;
                    entidadViewModel.DescUnidad = descUnidad;
                    entidadViewModel.DescGestion = descGestion;
                    entidadViewModel.DescLineaBase = descLineaBase;
                    entidadViewModel.IdProducto = idProducto;
                    entidadViewModel.IndicadorProducto = indicadorPOA;
                    entidadViewModel.IdIndicadorPOA = idIndicadorPOA;
                    var colaborador = await _mediator.Send(new GetAllColaboradoresCachedQuery());
                    if (colaborador.Succeeded)
                    {
                        var responsa = _mapper.Map<List<ColaboradorViewModel>>(colaborador.Data);
                        entidadViewModel.responsableList = new SelectList(responsa, "Id", "Nombres");
                        entidadViewModel.ResponsableIndicador = responsa.Where(r => r.Id == idResponsable).FirstOrDefault().Nombres;
                        entidadViewModel.DescResponsable = responsa.Where(r => r.Id == idResponsablePOA).FirstOrDefault().Nombres;
                    }

                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
            }
            return null;
        }


        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEditInicador(int id, IndicadorPOAViewModel entidad)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == 0)
                    {
                        var createEntidadCommand = _mapper.Map<CreateIndicadorPOACommand>(entidad);
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
                        var updateEntidadCommand = _mapper.Map<UpdateIndicadorPOACommand>(entidad);
                        var result = await _mediator.Send(updateEntidadCommand);
                        if (result.Succeeded) _notify.Information($"Indicador con ID {result.Data} Actualizado.");
                    }
                    return new JsonResult(new { isValid = true, solocerrar = true });
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
                _notify.Error("Error al insertar IndicadorEstrategico");
            }
            return null;
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(int id, ActividadViewModel entidad)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == 0)
                    {
                        var createEntidadCommand = _mapper.Map<CreateActividadCommand>(entidad);
                        var result = await _mediator.Send(createEntidadCommand);
                        if (result.Succeeded)
                        {
                            id = result.Data;
                            _notify.Success($"Actividad con ID {result.Data} Creado.");
                        }
                        else _notify.Error(result.Message);
                    }
                    else
                    {
                        var updateEntidadCommand = _mapper.Map<UpdateActividadCommand>(entidad);
                        var result = await _mediator.Send(updateEntidadCommand);
                        if (result.Succeeded) _notify.Information($"Actividad con ID {result.Data} Actualizado.");
                    }
                    return new JsonResult(new { isValid = true, solocerrar = true });
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
                _notify.Error("Error al insertar IndicadorEstrategico");
            }
            return null;
        }


        public async Task<JsonResult> OnPostDelete(int id = 0, int idProducto = 0)
        {
            var deleteCommand = await _mediator.Send(new DeleteActividadCommand { Id = id });
            if (deleteCommand.Succeeded)
            {
                _notify.Information($"Actividad con Id {id} Eliminado.");
                return new JsonResult(new { isValid = true });
                //var response = await _mediator.Send(new GetFactorCriticoExitoByIdQuery() { Id = idFactor });

                //if (response.Succeeded)
                //{


                //    var viewModel = new List<IndicadorEstrategicoViewModel>();
                //    if (response.Data != null)
                //        viewModel = _mapper.Map<List<IndicadorEstrategicoViewModel>>(response.Data.IndicadorEstrategicos);

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
                _notify.Error(deleteCommand.Message);
                return null;
            }
        }

    }
}
