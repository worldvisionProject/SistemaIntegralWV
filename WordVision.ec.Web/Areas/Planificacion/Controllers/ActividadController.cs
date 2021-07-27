using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.Actividades.Commands.Delete;
using WordVision.ec.Application.Features.Planificacion.FactorCriticoExitoes.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.Gestiones.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.IndicadorEstrategicoes.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.IndicadorEstrategicoes.Commands.Update;
using WordVision.ec.Application.Features.Planificacion.IndicadorEstrategicoes.Queries.GetAllCached;
using WordVision.ec.Application.Features.Planificacion.IndicadorEstrategicoes.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.IndicadorPOAes.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.IndicadorPOAs.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.IndicadorPOAs.Commands.Delete;
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
    public class ActividadController :  BaseController<ActividadController>
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

        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0,int idIndicadorEstrategia=0, int idGestion = 0, int idProducto = 0)
        {
            string descProducto = "";
            string descObjetivo = "";
            string descFactor = "";
            string descIndicador = "";
            string descMeta = "";
            string descGestion = "";
            int idResponsable = 0;
            string descLineaBase = "";

            var responseG = await _mediator.Send(new GetGestionByIdQuery() { Id = idGestion });
            if (responseG.Succeeded)
            {
                var entidadViewModel = _mapper.Map<GestionViewModel>(responseG.Data);
                descGestion = entidadViewModel.Anio;
            }

            var responseI = await _mediator.Send(new GetIndicadorEstrategicoByIdQuery() { Id = idIndicadorEstrategia });
            if (responseI.Succeeded)
            {
                var entidadViewModel = _mapper.Map<IndicadorEstrategicoViewModel>(responseI.Data);
                descProducto = entidadViewModel.Productos.Where(p => p.Id == idProducto).FirstOrDefault().DescProducto;
                descObjetivo = entidadViewModel.FactorCriticoExitos.ObjetivoEstrategicos.Descripcion;
                descFactor = entidadViewModel.FactorCriticoExitos.FactorCritico;
                descIndicador = entidadViewModel.IndicadorResultado;
                descMeta = entidadViewModel.IndicadorAFs.Where(x => x.Anio == idGestion.ToString()).FirstOrDefault().Meta;
                idResponsable =(int)entidadViewModel.Responsable;
                descLineaBase = entidadViewModel.LineaBase;
            }
            if (id == 0)
            {
                var entidadViewModel = new IndicadorPOAViewModel();
                entidadViewModel.IdProducto = idProducto;
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
            }
            else
            {
                var response = await _mediator.Send(new GetIndicadorPOAByIdQuery() { Id = id });
                if (response.Succeeded)
                {
                    var entidadViewModel = _mapper.Map<IndicadorPOAViewModel>(response.Data);
                    entidadViewModel.DescProducto = descProducto;
                    entidadViewModel.DescObjetivo = descObjetivo;
                    entidadViewModel.DescFactor = descFactor;
                    entidadViewModel.DescIndicador = descIndicador;
                    entidadViewModel.DescMeta = descMeta;
                  
                    entidadViewModel.DescGestion = descGestion;
                    entidadViewModel.DescLineaBase = descLineaBase;
                    var colaborador = await _mediator.Send(new GetAllColaboradoresCachedQuery());
                    if (colaborador.Succeeded)
                    {
                        var responsa = _mapper.Map<List<ColaboradorViewModel>>(colaborador.Data);
                        entidadViewModel.responsableList = new SelectList(responsa, "Id", "Nombres");
                        entidadViewModel.ResponsableIndicador = responsa.Where(r => r.Id == idResponsable).FirstOrDefault().Nombres;
                    }
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
            }
            return null;
        }


        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(int id, IndicadorPOAViewModel entidad)
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
