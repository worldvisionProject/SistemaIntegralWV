using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Planificacion.Models;

namespace WordVision.ec.Web.Areas.Planificacion.Controllers
{
    [Area("Planificacion")]
    [Authorize]
    public class AcuerdoDesempenioController : BaseController<AcuerdoDesempenioController>
    {
        public IActionResult Index()
        {
            var model = new PerfilDesempenioViewModel();

            return View(model);
        }
        public async Task<IActionResult> LoadAll()
        {
            //var response = await _mediator.Send(new GetAllIndicadorEstrategicoesCachedQuery());
            //if (response.Succeeded)
            //{

            //  var viewModel = _mapper.Map<List<IndicadorEstrategicoViewModel>>(response.Data);
            var modelista = new List<PerfilDesempenioViewModel>();
            var model = new PerfilDesempenioViewModel();
            model.Accion = "Capacitación con el equipo técnico de Visión Mundial, Curso de Marco Lógico";
            model.FactorExito = "Al 30 de septiembre con capacidades fortalecidas en marco lógico";
            model.Indicador = "100% capacidades fortalecidas en marco lógico";
            model.LineaBase = "20%";
            model.MedioVerificacion = "Evaluación de capacidades en Marco Lógico";
            model.Objetivo = "Fortalecimiento de Marco Lógico";
            modelista.Add(model);


            return PartialView("_ViewAll", modelista);
            //}
           
        }
        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0, int idNivel = 0)
        {

            if (id == 0)
            {
                var entidadViewModel = new AcuerdoDesempenioViewModel();
               
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
            }
            //else
            //{
            //    var response = await _mediator.Send(new GetIndicadorPOAByIdQuery() { Id = id });
            //    if (response.Succeeded)
            //    {
            //        var entidadViewModel = _mapper.Map<IndicadorPOAViewModel>(response.Data);
            //        return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
            //    }
            //}
            return null;
        }

        public async Task<JsonResult> OnGetCreateOrEditPerfil(int id = 0, int idNivel = 0)
        {

            if (id == 0)
            {
                var entidadViewModel = new PerfilDesempenioViewModel();
                var cat2 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 10 });
                entidadViewModel.UnidadList = new SelectList(cat2.Data, "Secuencia", "Nombre");
                var cat11 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 11 });
                entidadViewModel.NumMesesList = new SelectList(cat11.Data, "Secuencia", "Nombre");
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEditPerfil", entidadViewModel) });
            }
            //else
            //{
            //    var response = await _mediator.Send(new GetIndicadorPOAByIdQuery() { Id = id });
            //    if (response.Succeeded)
            //    {
            //        var entidadViewModel = _mapper.Map<IndicadorPOAViewModel>(response.Data);
            //        return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
            //    }
            //}
            return null;
        }
    }
}
