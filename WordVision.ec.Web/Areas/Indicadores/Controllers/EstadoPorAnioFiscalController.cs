using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Indicadores.EstadoPorAnioFiscal.Commands.Create;
using WordVision.ec.Application.Features.Indicadores.EstadoPorAnioFiscal.Commands.Update;
using WordVision.ec.Application.Features.Indicadores.EstadoPorAnioFiscal.Queries.GetAll;
using WordVision.ec.Application.Features.Indicadores.EstadoPorAnioFiscal.Queries.GetById;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Indicadores.Models;
using WordVision.ec.Web.Common;
using WordVision.ec.Web.Common.Constants;

namespace WordVision.ec.Web.Areas.Indicadores.Controllers
{
    [Area("Indicadores")]
    [Authorize]
    public class EstadoPorAnioFiscalController : BaseController<EstadoPorAnioFiscalController>
    {
        private readonly CommonMethods _commonMethods;

        public EstadoPorAnioFiscalController()
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
            List<EstadoPorAnioFiscalViewModel> viewModels = new List<EstadoPorAnioFiscalViewModel>();
            var response = await _mediator.Send(new GetAllEstadoPorAnioFiscalQuery { Include = true });
            if (response.Succeeded)
                viewModels = _mapper.Map<List<EstadoPorAnioFiscalViewModel>>(response.Data);

            return PartialView("_ViewAll", viewModels);
        }

        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0)
        {
            try
            {
                var entidadViewModel = new EstadoPorAnioFiscalViewModel 
                {
                    FechaInicio = DateTime.Now,
                    FechaFin = DateTime.Now,
                    
                };
                if (id == 0)
                {
                    await SetDropDownList(entidadViewModel);
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
                else
                {
                    var response = await _mediator.Send(new GetEstadoPorAnioFiscalByIdQuery() { Id = id });
                    if (response.Succeeded)
                    {
                        entidadViewModel = _mapper.Map<EstadoPorAnioFiscalViewModel>(response.Data);
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
                return _commonMethods.SaveError($"OnGetCreateOrEdit Error al consultar EstadoPorAnioFiscal.", ex.Message);
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(EstadoPorAnioFiscalViewModel EstadoPorAnioFiscalViewModel)
        {
            _commonMethods.SetProperties(_notify, _logger);
            if (ModelState.IsValid)
            {
                if (EstadoPorAnioFiscalViewModel.Id == 0)
                {
                    var createEntidadCommand = _mapper.Map<CreateEstadoPorAnioFiscalCommand>(EstadoPorAnioFiscalViewModel);
                    //createEntidadCommand.IdEstado = CatalogoConstant.IdDetalleCatalogoEstadoActivo;
                    var result = await _mediator.Send(createEntidadCommand);
                    if (result.Succeeded)
                        _notify.Success($"EstadoPorAnioFiscal con ID {result.Data} Creado.");
                    else return _commonMethods.SaveError(result.Message);
                }
                else
                {
                    var updateEntidadCommand = _mapper.Map<UpdateEstadoPorAnioFiscalCommand>(EstadoPorAnioFiscalViewModel);
                    var result = await _mediator.Send(updateEntidadCommand);
                    if (result.Succeeded) _notify.Information($"EstadoPorAnioFiscal con ID {result.Data} Actualizado.");
                    else return _commonMethods.SaveError(result.Message);
                }

                var response = await _mediator.Send(new GetAllEstadoPorAnioFiscalQuery { Include = true });
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<EstadoPorAnioFiscalViewModel>>(response.Data);
                    var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                    return new JsonResult(new { isValid = true, html = html });
                }
                else
                    return _commonMethods.SaveError(response.Message);
            }
            else
            {
                var result = string.Join(',', ModelState.Values.SelectMany(v => v.Errors).Select(a => a.ErrorMessage));
                return _commonMethods.SaveError($"Error al insertar EstadoPorAnioFiscal", result);
            }
        }

        private async Task SetDropDownList(EstadoPorAnioFiscalViewModel entidadViewModel)
        {
            bool isNew = true;
            if (entidadViewModel.Id != 0)
                isNew = false;
            var estadoFiscal = await _mediator.Send(new GetListByIdDetalleQuery() { Id = CatalogoConstant.IdCatalogoEstadoAnioFiscal });
            var proceso = await _mediator.Send(new GetListByIdDetalleQuery() { Id = CatalogoConstant.IdCatalogoProceso });

            List<GetListByIdDetalleResponse> estados = estadoFiscal.Data;
            List<GetListByIdDetalleResponse> procesos = proceso.Data;

            if (isNew)
            {
                estados = estados.Where(e => e.Estado == CatalogoConstant.EstadoActivo).ToList();
                procesos = procesos.Where(e => e.Estado == CatalogoConstant.EstadoActivo).ToList();
            }

            entidadViewModel.EstadoAnioFiscalList = _commonMethods.SetGenericCatalog(estados, CatalogoConstant.FieldEstadoAnioFiscal);
            entidadViewModel.ProcesoList = _commonMethods.SetGenericCatalog(procesos, CatalogoConstant.FieldProceso);
        }
    }
}
