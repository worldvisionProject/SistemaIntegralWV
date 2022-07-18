using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Application.Features.Maestro.PresupuestoProyecto.Commands.Create;
using WordVision.ec.Application.Features.Maestro.PresupuestoProyecto.Commands.Delete;
using WordVision.ec.Application.Features.Maestro.PresupuestoProyecto.Commands.Update;
using WordVision.ec.Application.Features.Maestro.PresupuestoProyecto.Queries.GetAll;
using WordVision.ec.Application.Features.Maestro.PresupuestoProyecto.Queries.GetById;
using WordVision.ec.Application.Features.Maestro.ProgramaArea.Queries.GetAll;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Maestro.Models;
using WordVision.ec.Web.Common;
using WordVision.ec.Web.Common.Constants;

namespace WordVision.ec.Web.Areas.Maestro.Controllers
{
    [Area("Maestro")]
    [Authorize]
    public class PresupuestoProyectoController : BaseController<PresupuestoProyectoController>
    {
        private readonly CommonMethods _commonMethods;

        public PresupuestoProyectoController()
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
            List<PresupuestoProyectoViewModel> viewModels = new List<PresupuestoProyectoViewModel>();
            var response = await _mediator.Send(new GetAllPresupuestoProyectoQuery { Include = true });
            if (response.Succeeded)
                viewModels = _mapper.Map<List<PresupuestoProyectoViewModel>>(response.Data);

            return PartialView("_ViewAll", viewModels);
        }

        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0)
        {
            try
            {
                var entidadViewModel = new PresupuestoProyectoViewModel();
                if (id == 0)
                {
                    await SetDropDownList(entidadViewModel);
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
                else
                {
                    var response = await _mediator.Send(new GetPresupuestoProyectoByIdQuery() { Id = id });
                    if (response.Succeeded)
                    {
                        entidadViewModel = _mapper.Map<PresupuestoProyectoViewModel>(response.Data);
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
                return _commonMethods.SaveError($"OnGetCreateOrEdit Error al consultar PresupuestoProyecto.", ex.Message);                
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(PresupuestoProyectoViewModel PresupuestoProyectoViewModel)
        {
            _commonMethods.SetProperties(_notify, _logger);
            if (ModelState.IsValid)
            {
                if (PresupuestoProyectoViewModel.Id == 0)
                {                    
                    var createEntidadCommand = _mapper.Map<CreatePresupuestoProyectoCommand>(PresupuestoProyectoViewModel);
                    createEntidadCommand.IdEstado = CatalogoConstant.IdDetalleCatalogoEstadoActivo;
                    var result = await _mediator.Send(createEntidadCommand);
                    if (result.Succeeded)
                        _notify.Success($"PresupuestoProyecto con ID {result.Data} Creado.");
                    else return _commonMethods.SaveError(result.Message);
                }
                else
                {
                    var updateEntidadCommand = _mapper.Map<UpdatePresupuestoProyectoCommand>(PresupuestoProyectoViewModel);
                    var result = await _mediator.Send(updateEntidadCommand);
                    if (result.Succeeded) _notify.Information($"PresupuestoProyecto con ID {result.Data} Actualizado.");
                    else return _commonMethods.SaveError(result.Message);
                }
                var response = await _mediator.Send(new GetAllPresupuestoProyectoQuery { Include = true });
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<PresupuestoProyectoViewModel>>(response.Data);
                    var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                    return new JsonResult(new { isValid = true, html = html });
                }
                else
                    return _commonMethods.SaveError(response.Message);
            }
            else
            {
                var result = string.Join(',', ModelState.Values.SelectMany(v => v.Errors).Select(a => a.ErrorMessage));
                return _commonMethods.SaveError($"Error al insertar PresupuestoProyecto", result);
            }
        }

        [HttpDelete]
        public async Task<JsonResult> OnPostDelete(int id)
        {
            _commonMethods.SetProperties(_notify, _logger);
            var deleteCommand = await _mediator.Send(new DeletePresupuestoProyectoCommand { Id = id });
            if (deleteCommand.Succeeded)
            {
                _notify.Information($"El registro de PresupuestoProyecto fue eliminado");
                var response = await _mediator.Send(new GetAllPresupuestoProyectoQuery { Include = true });
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<PresupuestoProyectoViewModel>>(response.Data);
                    var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                    return new JsonResult(new { isValid = true, html = html });
                }
                else
                    return _commonMethods.SaveError(response.Message);

            }
            else
            {
                return _commonMethods.SaveError(deleteCommand.Message);
            }
        }

        private async Task SetDropDownList(PresupuestoProyectoViewModel entidadViewModel)
        {
            bool isNew = true;
            if (entidadViewModel.Id != 0)
                isNew = false;
            var estado = await _mediator.Send(new GetListByIdDetalleQuery() { Id = CatalogoConstant.IdCatalogoEstado });
            var programaAreas = await _mediator.Send(new GetAllProgramaAreaQuery());

            List<GetListByIdDetalleResponse> estados = estado.Data;
            List<ProgramaAreaViewModel> programas = _mapper.Map<List<ProgramaAreaViewModel>>(programaAreas.Data);
            if (isNew)
            {
                estados = estados.Where(e => e.Estado == CatalogoConstant.EstadoActivo).ToList();
                programas = programas.Where(e => e.IdEstado == CatalogoConstant.IdDetalleCatalogoEstadoActivo).ToList();
            }

            entidadViewModel.EstadoList = _commonMethods.SetGenericCatalogWithoutIdLabel(estados, CatalogoConstant.FieldEstado);
            entidadViewModel.ProgramaAreaList = _commonMethods.SetGenericCatalog(programas, CatalogoConstant.FieldProgramaArea);
        }
    }
}
