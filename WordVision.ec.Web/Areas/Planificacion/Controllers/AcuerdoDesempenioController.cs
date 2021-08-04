﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.Gestiones.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.IndicadorEstrategicoes.Queries.GetById;
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

            string descProducto = "";
            string descObjetivo = "";
            string descFactor = "";
            string descIndicador = "";
            string descMeta = "";
            string descGestion = "";
            int idResponsable = 0;
            string descLineaBase = "";
            int idResponsableProd = 0;
            string metaIndicadorPOA = "";
            string entregableIndicadorPOA = "";
            var responseG = await _mediator.Send(new GetGestionByIdQuery() { Id = 2 });
            if (responseG.Succeeded)
            {
                var entidadViewModel = _mapper.Map<GestionViewModel>(responseG.Data);
                descGestion = entidadViewModel.Anio;
            }

            var responseI = await _mediator.Send(new GetIndicadorEstrategicoByIdQuery() { Id = 1024 });
            if (responseI.Succeeded)
            {
                var entidadViewModel = _mapper.Map<IndicadorEstrategicoViewModel>(responseI.Data);
                descProducto = entidadViewModel.Productos.Where(p => p.Id == 1).FirstOrDefault().DescProducto;
                idResponsableProd = entidadViewModel.Productos.Where(p => p.Id == 1).FirstOrDefault().IdCargoResponsable;
                descObjetivo = entidadViewModel.FactorCriticoExitos.ObjetivoEstrategicos.Descripcion;
                descFactor = entidadViewModel.FactorCriticoExitos.FactorCritico;
                descIndicador = entidadViewModel.IndicadorResultado;
                descMeta = entidadViewModel.IndicadorAFs.Where(x => x.Anio == 2.ToString()).FirstOrDefault().Meta;
                idResponsable = (int)entidadViewModel.Responsable;
                descLineaBase = entidadViewModel.LineaBase;
                metaIndicadorPOA = "100";// entidadViewModel.Productos.Where(p => p.Id == 1).FirstOrDefault().IndicadorPOAs.Where(p=>p.Id==1).FirstOrDefault().Meta;
                
            }
            var modelista = new List<AcuerdoViewModel>();
            var model = new AcuerdoViewModel();
            model.Objetivo = descObjetivo;
            model.Factor = descFactor;
            model.IndicadorEstrategico = descIndicador;
            model.MetaEstrategico = descMeta;
            model.Producto = descProducto;
            model.Meta = metaIndicadorPOA;

            modelista.Add(model);
            responseI = await _mediator.Send(new GetIndicadorEstrategicoByIdQuery() { Id = 1023 });
            if (responseI.Succeeded)
            {
                var entidadViewModel = _mapper.Map<IndicadorEstrategicoViewModel>(responseI.Data);
                descProducto = entidadViewModel.Productos.Where(p => p.Id == 3).FirstOrDefault().DescProducto;
                idResponsableProd = entidadViewModel.Productos.Where(p => p.Id == 3).FirstOrDefault().IdCargoResponsable;
                descObjetivo = entidadViewModel.FactorCriticoExitos.ObjetivoEstrategicos.Descripcion;
                descFactor = entidadViewModel.FactorCriticoExitos.FactorCritico;
                descIndicador = entidadViewModel.IndicadorResultado;
                descMeta = entidadViewModel.IndicadorAFs.Where(x => x.Anio == 2.ToString()).FirstOrDefault().Meta;
                idResponsable = (int)entidadViewModel.Responsable;
                descLineaBase = entidadViewModel.LineaBase;
                metaIndicadorPOA = "100";// entidadViewModel.Productos.Where(p => p.Id == 1).FirstOrDefault().IndicadorPOAs.Where(p=>p.Id==1).FirstOrDefault().Meta;

            }
            model = new AcuerdoViewModel();
            model.Objetivo = descObjetivo;
            model.Factor = descFactor;
            model.IndicadorEstrategico = descIndicador;
            model.MetaEstrategico = descMeta;
            model.Producto = descProducto;
            model.Meta = metaIndicadorPOA;

            //var response = await _mediator.Send(new GetAllIndicadorEstrategicoesCachedQuery());
            //if (response.Succeeded)
            //{

            //  var viewModel = _mapper.Map<List<IndicadorEstrategicoViewModel>>(response.Data);
            //var modelista = new List<PerfilDesempenioViewModel>();
            //var model = new PerfilDesempenioViewModel();
            //model.Accion = "Capacitación con el equipo técnico de Visión Mundial, Curso de Marco Lógico";
            //model.FactorExito = "Al 30 de septiembre con capacidades fortalecidas en marco lógico";
            //model.Indicador = "100% capacidades fortalecidas en marco lógico";
            //model.LineaBase = "20%";
            //model.MedioVerificacion = "Evaluación de capacidades en Marco Lógico";
            //model.Objetivo = "Fortalecimiento de Marco Lógico";
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
