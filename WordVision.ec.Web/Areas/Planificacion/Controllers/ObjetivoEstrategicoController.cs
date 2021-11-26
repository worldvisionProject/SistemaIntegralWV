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
using WordVision.ec.Application.Features.Planificacion.ObjetivoEstrategicoes.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.ObjetivoEstrategicoes.Commands.Delete;
using WordVision.ec.Application.Features.Planificacion.ObjetivoEstrategicoes.Commands.Update;
using WordVision.ec.Application.Features.Planificacion.ObjetivoEstrategicoes.Queries.GetAllCached;
using WordVision.ec.Application.Features.Planificacion.ObjetivoEstrategicoes.Queries.GetById;
using WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetById;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Planificacion.Models;

namespace WordVision.ec.Web.Areas.Planificacion.Controllers
{
    [Area("Planificacion")]
    [Authorize]
    public class ObjetivoEstrategicoController : BaseController<ObjetivoEstrategicoController>
    {

        public IActionResult Index()
        {
            var model = new ObjetivoEstrategicoViewModel();

            return View(model);
        }

        public async Task<IActionResult> LoadAll()
        {
            var response = await _mediator.Send(new GetAllObjetivoEstrategicoesCachedQuery());
            if (response.Succeeded)
            {
                var viewModel = _mapper.Map<List<ObjetivoEstrategicoViewModel>>(response.Data);

                return PartialView("_ViewAll", viewModel);
            }
            return null;
        }

        public async Task<IActionResult> LoadObjetivo(int idEstrategia, int idCategoria, string AnioGestion, string esCoordinadorEstrategico)
        {
            int idColaborador = 0;
            if (esCoordinadorEstrategico == "N")
            {
                switch (Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Nivel")?.Value))
                {
                    case 2:
                        idColaborador = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value);
                        break;
                    case 3:
                        idColaborador = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "ReportaA")?.Value);
                        break;
                    case 4:
                        idColaborador = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "ReportaA")?.Value);
                        var responseGerencia = await _mediator.Send(new GetColaboradorByIdQuery() { Id = idColaborador });
                        if (responseGerencia.Succeeded)
                        {
                            var responseNivel = await _mediator.Send(new GetColaboradorByNivelQuery() { Nivel1 = 1, Nivel2 = 2 });

                            idColaborador = responseNivel.Data.Where(c => c.Cargo == responseGerencia.Data.Estructuras.ReportaID).FirstOrDefault().Id;
                        }
                        break;
                }


            }
            var response = await _mediator.Send(new GetEstrategiaNacionalByIdQuery() { Id = idEstrategia, IdColaborador = idColaborador, Nivel = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Nivel")?.Value) });
            if (response.Succeeded)
            {

                var entidadViewModel = _mapper.Map<EstrategiaNacionalViewModel>(response.Data);
                entidadViewModel.CategoriaObjetivo = idCategoria;
                entidadViewModel.AnioGestion = AnioGestion;
                entidadViewModel.EsCoordinadorEstrategico = esCoordinadorEstrategico;
                ViewBag.Ciclo = entidadViewModel.Nombre;
                var cat2 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 4 });
                entidadViewModel.AreaPrioridadList = new SelectList(cat2.Data, "Secuencia", "Nombre");
                return PartialView(idCategoria == 2 ? "_ViewAll" : "_ViewAllNacional", entidadViewModel);
            }
            return null;
        }

        //[Breadcrumb("Objetivo", AreaName = "Planificacion", FromAction = "OnGetCreateOrEdit", FromController = typeof(EstrategiaNacionalController))]
        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0, int idEstrategia = 0, int categoria = 0)
        {
            // var brandsResponse = await _mediator.Send(new GetAllBrandsCachedQuery());
            //var cat2 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 3 });
            //var DimList = new SelectList(cat2.Data, "Secuencia", "Nombre");

            var cat3 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 4 });
            var AreaList = new SelectList(cat3.Data, "Secuencia", "Nombre");

            var catPrograma = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 17 });
            var ProgramaList = new SelectList(catPrograma.Data, "Secuencia", "Nombre");

            var catCtwo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 18 });
            var CwboList = new SelectList(catCtwo.Data, "Secuencia", "Nombre");
            if (id == 0)
            {
                var entidadViewModel = new ObjetivoEstrategicoViewModel();
                entidadViewModel.Categoria = categoria;
                entidadViewModel.IdEstrategia = idEstrategia;
                //entidadViewModel.DimensionList = DimList;
                entidadViewModel.AreaList = AreaList;
                entidadViewModel.ProgramaList = ProgramaList;
                entidadViewModel.CwboList = CwboList;
                //  return View("_CreateOrEdit", entidadViewModel);
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
            }
            else
            {
                var response = await _mediator.Send(new GetObjetivoEstrategicoByIdQuery() { Id = id });
                if (response.Succeeded)
                {
                    var entidadViewModel = _mapper.Map<ObjetivoEstrategicoViewModel>(response.Data);
                    entidadViewModel.Categoria = categoria;
                    entidadViewModel.IdEstrategia = idEstrategia;
                    //entidadViewModel.DimensionList = DimList;
                    entidadViewModel.AreaList = AreaList;
                    entidadViewModel.ProgramaList = ProgramaList;
                    entidadViewModel.CwboList = CwboList;
                    // return View("_CreateOrEdit", entidadViewModel);
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
                return null;
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(int id, ObjetivoEstrategicoViewModel entidad)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == 0)
                    {
                        var createEntidadCommand = _mapper.Map<CreateObjetivoEstrategicoCommand>(entidad);
                        var result = await _mediator.Send(createEntidadCommand);
                        if (result.Succeeded)
                        {
                            id = result.Data;
                            _notify.Success($"Objetivo con ID {result.Data} Creado.");
                        }
                        else _notify.Error(result.Message);
                    }
                    else
                    {
                        var updateEntidadCommand = _mapper.Map<UpdateObjetivoEstrategicoCommand>(entidad);
                        var result = await _mediator.Send(updateEntidadCommand);
                        if (result.Succeeded) _notify.Information($"Objetivo con ID {result.Data} Actualizado.");
                    }
                    var response = await _mediator.Send(new GetEstrategiaNacionalByIdQuery() { Id = entidad.IdEstrategia });
                    if (response.Succeeded)
                    {

                        var entidadViewModel = _mapper.Map<EstrategiaNacionalViewModel>(response.Data);
                        entidadViewModel.CategoriaObjetivo = entidad.Categoria;
                        var cat2 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 4 });
                        entidadViewModel.AreaPrioridadList = new SelectList(cat2.Data, "Secuencia", "Nombre");
                        var html1 = await _viewRenderer.RenderViewToStringAsync(entidad.Categoria == 2 ? "_ViewAll" : "_ViewAllNacional", entidadViewModel);
                        return new JsonResult(new { isValid = true, opcion = Convert.ToInt32(entidad.Categoria), page = entidad.Categoria == 2 ? "#viewAll" : "#viewAllNacional", html = html1 });
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


        public async Task<JsonResult> OnPostDelete(int id = 0, int idEstrategia = 0, int idCategoria = 0)
        {
            var deleteCommand = await _mediator.Send(new DeleteObjetivoEstrategicoCommand { Id = id });
            if (deleteCommand.Succeeded)
            {
                _notify.Information($"Objetivo con Id {id} Eliminado.");
                var response = await _mediator.Send(new GetEstrategiaNacionalByIdQuery() { Id = idEstrategia });

                if (response.Succeeded)
                {

                    var entidadViewModel = _mapper.Map<EstrategiaNacionalViewModel>(response.Data);
                    ViewBag.Ciclo = entidadViewModel.Nombre;
                    entidadViewModel.CategoriaObjetivo = idCategoria;
                    var cat2 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 4 });
                    entidadViewModel.AreaPrioridadList = new SelectList(cat2.Data, "Secuencia", "Nombre");
                    var html1 = await _viewRenderer.RenderViewToStringAsync("_ViewAll", entidadViewModel);
                    return new JsonResult(new { isValid = true, opcion = Convert.ToInt32(idCategoria), page = "#viewAll", html = html1 });
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


        public async Task<JsonResult> OnPostDeleteNacional(int id = 0, int idEstrategia = 0, int idCategoria = 0)
        {
            var deleteCommand = await _mediator.Send(new DeleteObjetivoEstrategicoCommand { Id = id });
            if (deleteCommand.Succeeded)
            {
                _notify.Information($"Objetivo con Id {id} Eliminado.");
                var response = await _mediator.Send(new GetEstrategiaNacionalByIdQuery() { Id = idEstrategia });

                if (response.Succeeded)
                {

                    var entidadViewModel = _mapper.Map<EstrategiaNacionalViewModel>(response.Data);
                    ViewBag.Ciclo = entidadViewModel.Nombre;
                    entidadViewModel.CategoriaObjetivo = idCategoria;
                    var cat2 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 4 });
                    entidadViewModel.AreaPrioridadList = new SelectList(cat2.Data, "Secuencia", "Nombre");
                    var html1 = await _viewRenderer.RenderViewToStringAsync("_ViewAllNacional", entidadViewModel);
                    return new JsonResult(new { isValid = true, opcion = Convert.ToInt32(idCategoria), page = "#viewAllNacional", html = html1 });
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
