using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Soporte.Solicitudes.Commands.Update;
using WordVision.ec.Application.Features.Valoracion.Objetivos.Queries.GetById;
using WordVision.ec.Application.Features.Valoracion.PlanificacionResultados.Commands.Create;
using WordVision.ec.Application.Features.Valoracion.PlanificacionResultados.Queries.GetAllCached;
using WordVision.ec.Application.Features.Valoracion.PlanificacionResultados.Queries.GetById;
using WordVision.ec.Application.Features.Valoracion.Resultados.Queries.GetAllCached;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Valoracion.Models;

namespace WordVision.ec.Web.Areas.Valoracion.Controllers
{
    [Area("Valoracion")]
    [Authorize]
    public class ObjetivoController :  BaseController<ObjetivoController>
    {
        public IActionResult Index(int id = 0)
        {
           
            return View();
        }


        public async Task<IActionResult> LoadAll(int idAnioFiscal,int idColaborador)
        {
            try
            {
                var response = await _mediator.Send(new GetAllPlanificacionResultadosCachedQuery() { IdAnioFiscal = idAnioFiscal, IdColaborador = idColaborador });
                if (response.Succeeded)
                {
                        var viewModel = _mapper.Map<List<ObjetivoResponseViewModel>>(response.Data);
                    return PartialView("_ViewAll", viewModel);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "LoadAll");
                _notify.Error("Error al LoadAll");
            }
            
            return null;     
        }
        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0, int idColaborador = 0,int idObjetivo=0,int idObjetivoAnioFiscal=0, int idResultado = 0,int anioFiscal=0)
        {
            try
            {
                if (id == 0)
                {
                    var entidadViewModel = new PlanificacionResultadoViewModel();
                    var resultadoViewModel = new ResultadoViewModel();
                    var anioFiscalViewModel = new ObjetivoAnioFiscalViewModel();
                    anioFiscalViewModel.AnioFiscal = anioFiscal;
                    anioFiscalViewModel.IdObjetivo = idObjetivo;
                    resultadoViewModel.ObjetivoAnioFiscales = anioFiscalViewModel;
                    resultadoViewModel.Id = idResultado;
                    entidadViewModel.IdColaborador = idColaborador;
                    entidadViewModel.IdResultado = idResultado;
                    entidadViewModel.Resultados= resultadoViewModel;
                    var entidadModelResultado = await _mediator.Send(new GetAllResultadosCachedQuery() { IdObjetivo = idObjetivo, IdObjetivoAnioFiscal = idObjetivoAnioFiscal });
                    entidadViewModel.IdResultadoList = new SelectList(entidadModelResultado.Data, "Id", "Nombre");

                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
                else
                {

                    var entidadModel = await _mediator.Send(new GetPlanificacionResultadoByIdQuery() { Id = id });
                    var entidadMapper = _mapper.Map<PlanificacionResultadoViewModel>(entidadModel.Data);
                    var entidadModelResultado = await _mediator.Send(new GetAllResultadosCachedQuery() { IdObjetivo = idObjetivo, IdObjetivoAnioFiscal = idObjetivoAnioFiscal });
                    entidadMapper.IdResultadoList = new SelectList(entidadModelResultado.Data, "Id", "Nombre");

                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadMapper) });

                }
            }    
            catch (Exception ex)
            {
                _logger.LogError(ex, "OnGetCreateOrEdit");
                _notify.Error("Error al actualizar la planificacion.");
            }

            return null;
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(int id, PlanificacionResultadoViewModel entidad)
        {
            try
            {
                
                if (ModelState.IsValid)
                {  var planifica = await _mediator.Send(new GetPlanificacionResultadoByIdObjetivoQuery() { IdObjetivo = entidad.Resultados.ObjetivoAnioFiscales.IdObjetivo });
                   var d= planifica.Data.Where(b=>b.Id!=id).ToList();
                    decimal suma = 0;
                    decimal ponderaObjetivo = 0;
                    foreach (var i in d)
                    {
                        suma = suma + Convert.ToDecimal( i.Ponderacion);
                         ponderaObjetivo = i.Resultados.ObjetivoAnioFiscales.Ponderacion;
                    }
                    var total = suma + Convert.ToDecimal(entidad.Ponderacion);
                  
                    if (total > ponderaObjetivo)
                    {
                        
                        _notify.Error("La suma de la ponderación de resultado no pude ser mayor a la Ponderacion de Objetivo " + ponderaObjetivo.ToString());
                       
                        return new JsonResult(new { isValid = false });
                    }
                    if (id == 0)
                    {
                      
                        var createEntidadCommand = _mapper.Map<CreatePlanificacionResultadoCommand>(entidad);
                        var result = await _mediator.Send(createEntidadCommand);
                        if (result.Succeeded)
                        {
                            id = result.Data;
                            _notify.Success($"PlanificacionResultado con ID {result.Data} Creado.");
                        }
                        else _notify.Error(result.Message);
                    }
                    else
                    {
                       
                        var updateEntidadCommand = _mapper.Map<UpdatePlanificacionResultadoCommand>(entidad);
                        var result = await _mediator.Send(updateEntidadCommand);
                        if (result.Succeeded) _notify.Information($"PlanificacionResultado con ID {result.Data} Actualizado.");
                    }


                    var response = await _mediator.Send(new GetAllPlanificacionResultadosCachedQuery() { IdAnioFiscal = entidad.Resultados.ObjetivoAnioFiscales.AnioFiscal, IdColaborador = entidad.IdColaborador });
                    if (response.Succeeded)
                    {
                        var viewModel = _mapper.Map<List<ObjetivoResponseViewModel>>(response.Data);
                        var html1 = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                        return new JsonResult(new { isValid = true, html = html1 });


                    }


                }
                else
                {
                    var result = string.Join(',', ModelState.Values.SelectMany(v => v.Errors).Select(a => a.ErrorMessage));
                    _notify.Error("Error de datos. " + result);
                    _logger.LogError(result);

                    return new JsonResult(new { isValid = false });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "OnPostCreateOrEdit");
                _notify.Error("Error al insertar Gestion");
            }
            return new JsonResult(new { isValid = false });
        }


    }
}
