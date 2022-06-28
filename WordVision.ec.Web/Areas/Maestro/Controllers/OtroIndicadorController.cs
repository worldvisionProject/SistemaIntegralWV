using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.ActorParticipante.Queries.GetAll;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Application.Features.Maestro.OtroIndicador.Commands.Create;
using WordVision.ec.Application.Features.Maestro.OtroIndicador.Commands.Update;
using WordVision.ec.Application.Features.Maestro.OtroIndicador.Queries.GetAll;
using WordVision.ec.Application.Features.Maestro.OtroIndicador.Queries.GetById;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Maestro.Models;
using WordVision.ec.Web.Common;
using WordVision.ec.Web.Common.Constants;

namespace WordVision.ec.Web.Areas.Maestro.Controllers
{
    [Area("Maestro")]
    [Authorize]
    public class OtroIndicadorController : BaseController<OtroIndicadorController>
    {
        private readonly CommonMethods _commonMethods;

        public OtroIndicadorController()
        {
            _commonMethods = new CommonMethods();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LoadAll()
        {
            List<OtroIndicadorViewModel> viewModels = new List<OtroIndicadorViewModel>();
            var response = await _mediator.Send(new GetAllOtroIndicadorQuery { Include = true });
            if (response.Succeeded)
                viewModels = _mapper.Map<List<OtroIndicadorViewModel>>(response.Data);

            return PartialView("_ViewAll", viewModels);
        }

        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0)
        {
            try
            {
                var entidadViewModel = new OtroIndicadorViewModel();
                if (id == 0)
                {
                    await SetDropDownList(entidadViewModel);
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
                else
                {
                    var response = await _mediator.Send(new GetOtroIndicadorByIdQuery() { Id = id });
                    if (response.Succeeded)
                    {
                        entidadViewModel = _mapper.Map<OtroIndicadorViewModel>(response.Data);
                        await SetDropDownList(entidadViewModel);
                        return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                    }
                    return new JsonResult(new
                    {
                        isValid = false
                    });
                }
            }
            catch (Exception ex)
            {
                return _commonMethods.SaveError($"OnGetCreateOrEdit Error al consultar OtroIndicador.", ex.Message);                
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(OtroIndicadorViewModel OtroIndicadorViewModel)
        {
            _commonMethods.SetProperties(_notify, _logger);
            if (ModelState.IsValid)
            {
                if (OtroIndicadorViewModel.Id == 0)
                {                    
                    var createEntidadCommand = _mapper.Map<CreateOtroIndicadorCommand>(OtroIndicadorViewModel);
                    createEntidadCommand.IdEstado = CatalogoConstant.IdDetalleCatalogoEstadoActivo;
                    var result = await _mediator.Send(createEntidadCommand);
                    if (result.Succeeded)
                        _notify.Success($"OtroIndicador con Código {createEntidadCommand.Codigo} Creado.");
                    else return _commonMethods.SaveError(result.Message);
                }
                else
                {
                    var updateEntidadCommand = _mapper.Map<UpdateOtroIndicadorCommand>(OtroIndicadorViewModel);
                    var result = await _mediator.Send(updateEntidadCommand);
                    if (result.Succeeded) _notify.Information($"OtroIndicador con Código {updateEntidadCommand.Codigo} Actualizado.");
                    else return _commonMethods.SaveError(result.Message);
                }
                var response = await _mediator.Send(new GetAllOtroIndicadorQuery { Include = true });
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<OtroIndicadorViewModel>>(response.Data);
                    var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                    return new JsonResult(new { isValid = true, html = html });
                }
                else
                    return _commonMethods.SaveError(response.Message);
            }
            else
            {
                var result = string.Join(',', ModelState.Values.SelectMany(v => v.Errors).Select(a => a.ErrorMessage));
                return _commonMethods.SaveError($"Error al insertar OtroIndicador", result);
            }
        }

        private async Task SetDropDownList(OtroIndicadorViewModel entidadViewModel)
        {
            bool isNew = true;
            if (entidadViewModel.Id != 0)
                isNew = false;
            var estado = await _mediator.Send(new GetListByIdDetalleQuery() { Id = CatalogoConstant.IdCatalogoEstado });
            var frecuencia = await _mediator.Send(new GetListByIdDetalleQuery() { Id = CatalogoConstant.IdCatalogoFrecuencia });
            var tipo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = CatalogoConstant.IdCatalogoTipoMedida });
            var area = await _mediator.Send(new GetListByIdDetalleQuery() { Id = CatalogoConstant.IdCatalogoArea });
            var tipoIndicador = await _mediator.Send(new GetListByIdDetalleQuery() { Id = CatalogoConstant.IdCatalogoTipoIndicador });
            var actor = await _mediator.Send(new GetAllActorParticipanteQuery());

            List<GetListByIdDetalleResponse> estados = estado.Data;
            List<GetListByIdDetalleResponse> frecuencias = frecuencia.Data;
            List<GetListByIdDetalleResponse> tipos = tipo.Data;
            List<GetListByIdDetalleResponse> areas = area.Data;
            List<GetListByIdDetalleResponse> tipoIndicadores = tipoIndicador.Data;
            List<ActorParticipanteViewModel> actores = _mapper.Map<List<ActorParticipanteViewModel>>(actor.Data);


            if (isNew)
            {
                estados = estados.Where(e => e.Estado == CatalogoConstant.EstadoActivo).ToList();
                frecuencias = frecuencias.Where(e => e.Estado == CatalogoConstant.EstadoActivo).ToList();
                tipos = tipos.Where(e => e.Estado == CatalogoConstant.EstadoActivo).ToList();
                areas = areas.Where(e => e.Estado == CatalogoConstant.EstadoActivo).ToList();
                tipoIndicadores = tipoIndicadores.Where(e => e.Estado == CatalogoConstant.EstadoActivo).ToList();
                actores = actores.Where(e => e.IdEstado == CatalogoConstant.IdDetalleCatalogoEstadoActivo).ToList();
            }

            entidadViewModel.EstadoList = _commonMethods.SetGenericCatalog(estados, CatalogoConstant.FieldEstado);
            entidadViewModel.FrecuenciaList = _commonMethods.SetGenericCatalog(frecuencias, CatalogoConstant.FieldFrecuencia);
            entidadViewModel.TipoMedidaList = _commonMethods.SetGenericCatalog(tipos, CatalogoConstant.FieldTipoMedida);
            entidadViewModel.AreaList = _commonMethods.SetGenericCatalog(areas, CatalogoConstant.FieldTipoMedida);
            entidadViewModel.TipoIndicadorList = _commonMethods.SetGenericCatalog(tipoIndicadores, CatalogoConstant.FieldTipoIndicador);
            entidadViewModel.ActorParticipanteList = _commonMethods.SetGenericCatalog(actores, CatalogoConstant.FieldActorParticipante);
        }
    }
}
