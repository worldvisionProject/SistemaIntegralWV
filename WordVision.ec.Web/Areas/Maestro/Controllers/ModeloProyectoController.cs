using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Application.Features.Maestro.EtapaModeloProyecto.Queries.GetAll;
using WordVision.ec.Application.Features.Maestro.ModeloProyecto.Commands.Create;
using WordVision.ec.Application.Features.Maestro.ModeloProyecto.Commands.Update;
using WordVision.ec.Application.Features.Maestro.ModeloProyecto.Queries.GetAll;
using WordVision.ec.Application.Features.Maestro.ModeloProyecto.Queries.GetById;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Maestro.Models;
using WordVision.ec.Web.Common;
using WordVision.ec.Web.Common.Constants;

namespace WordVision.ec.Web.Areas.Maestro.Controllers
{
    [Area("Maestro")]
    [Authorize]
    public class ModeloProyectoController : BaseController<ModeloProyectoController>
    {
        private readonly CommonMethods _commonMethods;

        public ModeloProyectoController()
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
            List<ModeloProyectoViewModel> viewModels = new List<ModeloProyectoViewModel>();
            var response = await _mediator.Send(new GetAllModeloProyectoQuery { Include = true });
            if (response.Succeeded)
                viewModels = _mapper.Map<List<ModeloProyectoViewModel>>(response.Data);

            return PartialView("_ViewAll", viewModels);
        }

        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0)
        {
            try
            {
                var entidadViewModel = new ModeloProyectoViewModel();
                if (id == 0)
                {                    
                    await SetDropDownList(entidadViewModel);
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
                else
                {
                    var response = await _mediator.Send(new GetModeloProyectoByIdQuery() { Id = id });
                    if (response.Succeeded)
                    {
                        entidadViewModel = _mapper.Map<ModeloProyectoViewModel>(response.Data);
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
                return _commonMethods.SaveError($"OnGetCreateOrEdit Error al consultar Modelo Proyectos.", ex.Message);
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(ModeloProyectoViewModel ModeloProyectoViewModel)
        {
            _commonMethods.SetProperties(_notify, _logger);
            if (ModelState.IsValid)
            {               
                if (ModeloProyectoViewModel.Id == 0)
                {
                    var createEntidadCommand = _mapper.Map<CreateModeloProyectoCommand>(ModeloProyectoViewModel);
                    createEntidadCommand.IdEstado = CatalogoConstant.IdDetalleCatalogoEstadoActivo;
                    var result = await _mediator.Send(createEntidadCommand);
                    if (result.Succeeded)
                        _notify.Success($"Modelo Proyecto con Código {result.Data} Creado.");
                    else return _commonMethods.SaveError(result.Message);
                }
                else
                {
                    var updateEntidadCommand = _mapper.Map<UpdateModeloProyectoCommand>(ModeloProyectoViewModel);
                    var result = await _mediator.Send(updateEntidadCommand);
                    if (result.Succeeded) _notify.Information($"Modelo Proyecto con Código {result.Data} Actualizado.");
                    else return _commonMethods.SaveError(result.Message);
                }

                var response = await _mediator.Send(new GetAllModeloProyectoQuery { Include = true });
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<ModeloProyectoViewModel>>(response.Data);
                    var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                    return new JsonResult(new { isValid = true, html = html });
                }
                else
                    return _commonMethods.SaveError(response.Message);
            }
            else
            {
                var result = string.Join(',', ModelState.Values.SelectMany(v => v.Errors).Select(a => a.ErrorMessage));
                return _commonMethods.SaveError($"Error al insertar Modelo Proyecto.", result);
            }
        }

        private async Task SetDropDownList(ModeloProyectoViewModel entidadViewModel)
        {
            bool isNew = true;
            if (entidadViewModel.Id != 0)
                isNew = false;
            var estado = await _mediator.Send(new GetListByIdDetalleQuery() { Id = CatalogoConstant.IdCatalogoEstado });
            var proyecto = await _mediator.Send(new GetAllEtapaModeloProyectoQuery());

            List<GetListByIdDetalleResponse> estados = estado.Data;
            List<EtapaModeloProyectoViewModel> proyectos = _mapper.Map<List<EtapaModeloProyectoViewModel>>(proyecto.Data);
            if (isNew)
            {
                estados = estados.Where(e => e.Estado == CatalogoConstant.EstadoActivo).ToList();
                proyectos = proyectos.Where(e => e.IdEstado == CatalogoConstant.IdDetalleCatalogoEstadoActivo).ToList();
            }

            entidadViewModel.EstadoList = _commonMethods.SetGenericCatalogWithoutIdLabel(estados, CatalogoConstant.FieldEstado);
            entidadViewModel.EtapaModeloProyectoList = _commonMethods.SetGenericCatalog(proyectos, CatalogoConstant.FieldEtapaModeloProyecto);
        }
    }
}
