using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Planificacion.FactorCriticoExitoes.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.IndicadorEstrategicoes.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.IndicadorEstrategicoes.Commands.Update;
using WordVision.ec.Application.Features.Planificacion.IndicadorEstrategicoes.Queries.GetAllCached;
using WordVision.ec.Application.Features.Planificacion.IndicadorEstrategicoes.Queries.GetById;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Planificacion.Models;

namespace WordVision.ec.Web.Areas.Planificacion.Controllers
{
    [Area("Planificacion")]
    [Authorize]
    public class IndicadorPOAController :  BaseController<IndicadorPOAController>
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
            //var response = await _mediator.Send(new GetFactorCriticoExitoByIdQuery() { Id = idFactor });
            //if (response.Succeeded)
            //{
            //    var viewModel = new List<IndicadorEstrategicoViewModel>();
            //    if (response.Data!=null)
            //      viewModel = _mapper.Map<List<IndicadorEstrategicoViewModel>>(response.Data.IndicadorEstrategicos);

            var viewModel = new List<IndicadorPOAViewModel>();
            var entidad = new IndicadorPOAViewModel();
            entidad.Id = 1;
            entidad.IndicadorProducto = "# de PA que implementan metodología CPA para mejoramiento de sistemas";
            entidad.LineaBase = 50;
            entidad.Meta = 70;
            entidad.MedioVerificacion = "Informes semestrales y anuales de PA";
            entidad.Responsable = 1;
            viewModel.Add(entidad);

            entidad = new IndicadorPOAViewModel();
            entidad.Id = 2;
            entidad.IndicadorProducto = "% de ejecución del plan de indicencia para la expedición de políticas públicas u ordenanzas cumplido";
            entidad.LineaBase = 60;
            entidad.Meta = 50;
            entidad.MedioVerificacion = "Informe ASM";
            entidad.Responsable = 1;
            viewModel.Add(entidad);

            return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel) });

                //return PartialView("_ViewAll", viewModel);
            //}
            //return null;
        }

        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0, int idProducto = 0)
        {
            // var brandsResponse = await _mediator.Send(new GetAllBrandsCachedQuery());

            if (id == 0)
            {
                var entidadViewModel = new IndicadorPOAViewModel();
                entidadViewModel.IdProducto = idProducto;

                //  return View("_CreateOrEdit", entidadViewModel);
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
            }
            else
            {
                //    var response = await _mediator.Send(new GetIndicadorEstrategicoByIdQuery() { Id = id });
                //    if (response.Succeeded)
                //    {
                //        var entidadViewModel = _mapper.Map<IndicadorEstrategicoViewModel>(response.Data);
                //        // return View("_CreateOrEdit", entidadViewModel);
                var entidad = new IndicadorPOAViewModel();
                entidad.Id = 1;
                entidad.IndicadorProducto = "# de PA que implementan metodología CPA para mejoramiento de sistemas";
                entidad.LineaBase = 50;
                entidad.Meta = 70;
                entidad.MedioVerificacion = "Informes semestrales y anuales de PA";
                entidad.Responsable = 1;
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidad) });
            }
            return null;
      }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(int id, IndicadorEstrategicoViewModel entidad)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == 0)
                    {
                        var createEntidadCommand = _mapper.Map<CreateIndicadorEstrategicoCommand>(entidad);
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
                        var updateEntidadCommand = _mapper.Map<UpdateIndicadorEstrategicoCommand>(entidad);
                        var result = await _mediator.Send(updateEntidadCommand);
                        if (result.Succeeded) _notify.Information($"Objetivo con ID {result.Data} Actualizado.");
                    }
                    var response = await _mediator.Send(new GetAllIndicadorEstrategicoesCachedQuery());
                    if (response.Succeeded)
                    {
                        var viewModel = _mapper.Map<List<IndicadorEstrategicoViewModel>>(response.Data);
                        var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                        return new JsonResult(new { isValid = true, html = html });
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
                _notify.Error("Error al insertar IndicadorEstrategico");
            }
            return null;
        }

    }
}
