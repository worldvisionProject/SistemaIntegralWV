using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.EstrategiaNacionales.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.FactorCriticoExitoes.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.IndicadorEstrategicoes.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.IndicadorEstrategicoes.Commands.Delete;
using WordVision.ec.Application.Features.Planificacion.IndicadorEstrategicoes.Commands.Update;
using WordVision.ec.Application.Features.Planificacion.IndicadorEstrategicoes.Queries.GetAllCached;
using WordVision.ec.Application.Features.Planificacion.IndicadorEstrategicoes.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.TiposIndicadores.Queries.GetAll;
using WordVision.ec.Application.Features.Planificacion.TiposIndicadores.Queries.GetById;
using WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetById;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Planificacion.Models;
using WordVision.ec.Web.Areas.Registro.Models;

namespace WordVision.ec.Web.Areas.Planificacion.Controllers
{
    [Area("Planificacion")]
    [Authorize]
    public class IndicadorEstrategicoController : BaseController<IndicadorEstrategicoController>
    {
        public IActionResult Index()
        {
            var model = new IndicadorEstrategicoViewModel();

            return View(model);
        }
        public async Task<IActionResult> LoadAll()
        {
            var response = await _mediator.Send(new GetAllIndicadorEstrategicoesCachedQuery());
            if (response.Succeeded)
            {
                var viewModel = _mapper.Map<List<IndicadorEstrategicoViewModel>>(response.Data);

                return PartialView("_ViewAll", viewModel);
            }
            return null;
        }

        public async Task<JsonResult> LoadIndicadores(int idFactor, int IdEstrategia = 0)
        {
            var response = await _mediator.Send(new GetFactorCriticoExitoByIdQuery() { Id = idFactor });
            if (response.Succeeded)
            {
                var viewModel = _mapper.Map<FactorCriticoExitoViewModel>(response.Data);
                viewModel.IdEstrategia = IdEstrategia;
                var colaborador = await _mediator.Send(new GetColaboradorByNivelQuery() { Nivel1 = 2, Nivel2 = 1 });
                if (colaborador.Succeeded)
                {
                    var responsable = _mapper.Map<List<ColaboradorViewModel>>(colaborador.Data);
                    viewModel.responsableList = new SelectList(responsable, "Id", "Nombres");
                }
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel) });

                //return PartialView("_ViewAll", viewModel);
            }
            return null;
        }

        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0, int IdFactorCritico = 0, int IdEstrategia = 0, int IdObjetivoEstrategico = 0)
        {
            var descEstrategia = "";
            var descObjetivoEstrategico = "";
            var descFactor = "";
            var descCategoria = "";
            var responseE = await _mediator.Send(new GetEstrategiaNacionalByIdQuery() { Id = IdEstrategia });
            SelectList gestionList = new SelectList(responseE.Data.Gestiones);
            if (responseE.Succeeded)
            {

                var entidadViewModel = _mapper.Map<EstrategiaNacionalViewModel>(responseE.Data);
                gestionList = new SelectList(entidadViewModel.Gestiones.OrderBy(b => b.FechaDesde), "Id", "Anio");
                descEstrategia = entidadViewModel.Nombre;
                descObjetivoEstrategico = entidadViewModel.ObjetivoEstrategicos.Where(o => o.Id == IdObjetivoEstrategico).FirstOrDefault().Descripcion;
                descFactor = entidadViewModel.ObjetivoEstrategicos.Where(o => o.Id == IdObjetivoEstrategico).FirstOrDefault().FactorCriticoExitos.Where(f => f.Id == IdFactorCritico).FirstOrDefault().FactorCritico;
                int categoria = entidadViewModel.ObjetivoEstrategicos.Where(o => o.Id == IdObjetivoEstrategico).FirstOrDefault().Categoria;
                var cat2 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 5 });
                descCategoria = cat2.Data.Where(c => c.Secuencia == categoria.ToString()).FirstOrDefault().Nombre;
            }
            if (id == 0)
            {
                var entidadViewModel = new IndicadorEstrategicoViewModel();
                entidadViewModel.IndicadorVinculadoEs = new List<IndicadorVinculadoEViewModel>();
                entidadViewModel.IdFactorCritico = IdFactorCritico;
                entidadViewModel.IdEstrategia = IdEstrategia;
                entidadViewModel.gestionList = gestionList;
                entidadViewModel.DescEstrategia = descEstrategia;
                entidadViewModel.DescObjetivo = descObjetivoEstrategico;
                entidadViewModel.DescFactor = descFactor;
                entidadViewModel.DescCategoria = descCategoria;
                var cat2 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 10 });
                entidadViewModel.UnidadList = new SelectList(cat2.Data, "Secuencia", "Nombre");
                //var cat1 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 40 });
                var cat3 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 39 });
                var cat4 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 43 });
                var cat5 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 44 });

                var entidadModel = await _mediator.Send(new GetTiposIndicadorById() { IdTipoIndicador = 1 });

                entidadViewModel.CodigoIndicadorList = new SelectList(entidadModel.Data, "Id", "CodigoIndicador");
                entidadViewModel.TipoIndicadorList = new SelectList(cat3.Data, "Secuencia", "Nombre");
                entidadViewModel.ActorParticipanteList = new SelectList(cat4.Data, "Secuencia", "Nombre");
                entidadViewModel.TipoMetaList = new SelectList(cat5.Data, "Secuencia", "Nombre");
                var colaborador = await _mediator.Send(new GetColaboradorByNivelQuery() { Nivel1 = 2, Nivel2 = 1 });
                if (colaborador.Succeeded)
                {
                    var responsable = _mapper.Map<List<ColaboradorViewModel>>(colaborador.Data);
                    entidadViewModel.responsableList = new SelectList(responsable, "Id", "Nombres");
                }
                //  return View("_CreateOrEdit", entidadViewModel);
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
            }
            else
            {
                var response = await _mediator.Send(new GetIndicadorEstrategicoByIdQuery() { Id = id });
                if (response.Succeeded)
                {
                    var entidadViewModel = _mapper.Map<IndicadorEstrategicoViewModel>(response.Data);
                    entidadViewModel.gestionList = gestionList;
                    entidadViewModel.IdFactorCritico = IdFactorCritico;
                    entidadViewModel.IdEstrategia = IdEstrategia;
                    entidadViewModel.DescEstrategia = descEstrategia;
                    entidadViewModel.DescObjetivo = descObjetivoEstrategico;
                    entidadViewModel.DescFactor = descFactor;
                    entidadViewModel.DescCategoria = descCategoria;
                    var cat2 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 10 });
                    entidadViewModel.UnidadList = new SelectList(cat2.Data, "Secuencia", "Nombre");
                  //  var cat1 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 40 });
                    var cat3 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 39 });
                    var cat4 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 43 });
                    var cat5 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 44 });
                    var entidadModel = await _mediator.Send(new GetAllTiposIndicadoresQuery());// { IdTipoIndicador = entidadViewModel.TipoIndicador });

                    entidadViewModel.CodigoIndicadorList = new SelectList(entidadModel.Data, "Id", "CodigoIndicador");
                    entidadViewModel.TipoIndicadorList = new SelectList(cat3.Data, "Secuencia", "Nombre");
                    entidadViewModel.ActorParticipanteList = new SelectList(cat4.Data, "Secuencia", "Nombre");
                    entidadViewModel.TipoMetaList = new SelectList(cat5.Data, "Secuencia", "Nombre");
                    var colaborador = await _mediator.Send(new GetColaboradorByNivelQuery() { Nivel1 = 2, Nivel2 = 1 });
                    if (colaborador.Succeeded)
                    {
                        var responsable = _mapper.Map<List<ColaboradorViewModel>>(colaborador.Data);
                        entidadViewModel.responsableList = new SelectList(responsable, "Id", "Nombres");
                    }
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
                return null;
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(int id, IndicadorEstrategicoViewModel entidad, List<IndicadorAFViewModel> indicador)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entidad.IndicadorAFs = _mapper.Map<List<IndicadorAFViewModel>>(indicador);
                    if (id == 0)
                    {
                        var createEntidadCommand = _mapper.Map<CreateIndicadorEstrategicoCommand>(entidad);
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
                        var updateEntidadCommand = _mapper.Map<UpdateIndicadorEstrategicoCommand>(entidad);
                        var result = await _mediator.Send(updateEntidadCommand);
                        if (result.Succeeded) _notify.Information($"Indicador con ID {result.Data} Actualizado.");
                    }
                    //var response = await _mediator.Send(new GetAllIndicadorEstrategicoesCachedQuery());
                    //if (response.Succeeded)
                    //{
                    //    var viewModel = _mapper.Map<List<IndicadorEstrategicoViewModel>>(response.Data);
                    //    var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                    return new JsonResult(new { isValid = true, solocerrar = true });
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
                    //_notify.Success($"Error al insertar Indicador.");
                    //ModelState.AddModelError("", "Error al insertar Indicador.");
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


        public async Task<JsonResult> OnPostDelete(int id = 0, int idFactor = 0)
        {
            var deleteCommand = await _mediator.Send(new DeleteIndicadorEstrategicoCommand { Id = id });
            if (deleteCommand.Succeeded)
            {
                _notify.Information($"Indicador con Id {id} Eliminado.");
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
