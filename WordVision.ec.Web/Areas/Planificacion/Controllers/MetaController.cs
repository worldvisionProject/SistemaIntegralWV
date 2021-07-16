﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.IndicadorEstrategicoes.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.MetaEstrategicas.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.MetaEstrategicas.Commands.Update;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Planificacion.Models;

namespace WordVision.ec.Web.Areas.Planificacion.Controllers
{
    [Area("Planificacion")]
    [Authorize]
    public class MetaController : BaseController<MetaController>
    {
        public IActionResult Index()
        {
            return View();
        }


        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0, int IdFactorCritico = 0, int IdEstrategia = 0,int idGestion=0)
        {
           
            if (id == 0)
            {
                var entidadViewModel = new IndicadorEstrategicoViewModel();
                entidadViewModel.IdFactorCritico = IdFactorCritico;
                entidadViewModel.IdEstrategia = IdEstrategia;
            
                //  return View("_CreateOrEdit", entidadViewModel);
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
            }
            else
            {
                var response = await _mediator.Send(new GetIndicadorEstrategicoByIdQuery() { Id = id });
                if (response.Succeeded)
                {
                    var entidadViewModel = _mapper.Map<IndicadorEstrategicoViewModel>(response.Data);
                    var cat2 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 10 });
                   entidadViewModel.UnidadList = new SelectList(cat2.Data, "Secuencia", "Nombre");
                    entidadViewModel.IdFactorCritico = IdFactorCritico;
                    entidadViewModel.IdEstrategia = IdEstrategia;
                    entidadViewModel.IdGestion = idGestion;
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
                return null;
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(int id,int idGestion, List<MetaViewModel> meta)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var indicador = new IndicadorEstrategicoViewModel();
                    indicador.Id = id;
                    indicador.IdGestion = idGestion;
                    indicador.MetaEstrategicas = meta;
                    if (id == 0)
                    {
                        var createEntidadCommand = _mapper.Map<CreateMetaEstrategicaCommand>(indicador);
                        createEntidadCommand.Id = id;
                        var result = await _mediator.Send(createEntidadCommand);
                        if (result.Succeeded)
                        {
                            id = result.Data;
                            _notify.Success($"Meta Creada.");
                        }
                        else _notify.Error(result.Message);
                    }
                    else
                    {
                        var updateEntidadCommand = _mapper.Map<UpdateMetaEstrategicaCommand>(indicador);
                        updateEntidadCommand.Id = id;
                        var result = await _mediator.Send(updateEntidadCommand);
                        if (result.Succeeded) _notify.Information($"Meta Actualizada.");
                    }
                    return new JsonResult(new { isValid = true, solocerrar = true });
                   
                }
                else
                {
                    var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", meta);
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



    }
}