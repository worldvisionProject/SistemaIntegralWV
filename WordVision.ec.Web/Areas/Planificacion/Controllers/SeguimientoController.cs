using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.Gestiones.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.IndicadorEstrategicoes.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.Seguimientos.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.Seguimientos.Queries.GetById;
using WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetById;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Planificacion.Models;
using WordVision.ec.Web.Areas.Registro.Models;

namespace WordVision.ec.Web.Areas.Planificacion.Controllers
{
    [Area("Planificacion")]
    [Authorize]
    public class SeguimientoController : BaseController<SeguimientoController>
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
            model.Tipo = "OE";
            model.DescTipo = "Objetivo Estratégico";
            model.CategoriaObjetivo = "Nacional";
            model.Descripcion = descObjetivo;
            model.Contribucion = descIndicador;
            model.Meta = descMeta;

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
            model.Tipo = "Producto";
            model.DescTipo = "Producto";
            model.CategoriaObjetivo = "";
            model.Descripcion = descProducto;
            model.Contribucion = "";
            model.Meta = descMeta;
            modelista.Add(model);

            model = new AcuerdoViewModel();
            model.Tipo = "RE";
            model.DescTipo = "Resposanbilidad";
            model.CategoriaObjetivo = "";
            model.Descripcion = "Coordina la adopción de iniciativas globales , asegurando su correcto funcionamiento a nivel local.";
            model.Contribucion = "";
            model.Meta = "20%";
            modelista.Add(model);

            model = new AcuerdoViewModel();
            model.Tipo = "RE";
            model.DescTipo = "Resposanbilidad";
            model.CategoriaObjetivo = "";
            model.Descripcion = "Incrementar la satisfacción del servicio se porte de TI a través de la solución oportuna de requerimientos enviados por los clientes a través de la mesa de servicio.";
            model.Contribucion = "";
            model.Meta = "20%";
            modelista.Add(model);

            return PartialView("_ViewAll", modelista);
            //}

        }
        //public async Task<JsonResult> OnGetCreateOrEdit(int id = 0, int idNivel = 0)
        //{

        //    if (id == 0)
        //    {
        //        string descProducto = "";
        //        string descObjetivo = "";
        //        string descFactor = "";
        //        string descIndicador = "";
        //        string descMeta = "";
        //        string descGestion = "";
        //        int idResponsable = 0;
        //        string descLineaBase = "";
        //        int idResponsableProd = 0;
        //        string metaIndicadorPOA = "";
        //        string entregableIndicadorPOA = "";
        //        var responseG = await _mediator.Send(new GetGestionByIdQuery() { Id = 2 });
        //        if (responseG.Succeeded)
        //        {
        //            var entidadViewModel = _mapper.Map<GestionViewModel>(responseG.Data);
        //            descGestion = entidadViewModel.Anio;
        //        }

        //        var responseI = await _mediator.Send(new GetIndicadorEstrategicoByIdQuery() { Id = 1023 });
        //        if (responseI.Succeeded)
        //        {
        //            var entidadViewModel = _mapper.Map<IndicadorEstrategicoViewModel>(responseI.Data);
        //            descProducto = entidadViewModel.Productos.Where(p => p.Id == 3).FirstOrDefault().DescProducto;
        //            idResponsableProd = entidadViewModel.Productos.Where(p => p.Id == 3).FirstOrDefault().IdCargoResponsable;
        //            descObjetivo = entidadViewModel.FactorCriticoExitos.ObjetivoEstrategicos.Descripcion;
        //            descFactor = entidadViewModel.FactorCriticoExitos.FactorCritico;
        //            descIndicador = entidadViewModel.IndicadorResultado;
        //            descMeta = entidadViewModel.IndicadorAFs.Where(x => x.Anio == 2.ToString()).FirstOrDefault().Meta;
        //            idResponsable = (int)entidadViewModel.Responsable;
        //            descLineaBase = entidadViewModel.LineaBase;
        //            metaIndicadorPOA = "100";// entidadViewModel.Productos.Where(p => p.Id == 1).FirstOrDefault().IndicadorPOAs.Where(p=>p.Id==1).FirstOrDefault().Meta;

        //        }

        //        var indicadorPOA = "";
        //        int idResponsablePOA = 0;
        //        var response = await _mediator.Send(new GetIndicadorPOAByIdQuery() { Id = 4 });
        //        if (response.Succeeded)
        //        {
        //            indicadorPOA = response.Data.IndicadorProducto;
        //            idResponsablePOA = (int)response.Data.Responsable;
        //        }
        //        var entidadViewModels = new SeguimientoViewModel();
        //        entidadViewModels.DescProducto = descProducto;
        //        entidadViewModels.DescObjetivo = descObjetivo;
        //        entidadViewModels.DescFactor = descFactor;
        //        entidadViewModels.DescIndicador = descIndicador;
        //        entidadViewModels.DescMeta = descMeta;
        //        entidadViewModels.DescGestion = descGestion;
        //        entidadViewModels.DescLineaBase = descLineaBase;
        //        //entidadViewModel.IdProducto = idProducto;
        //        //entidadViewModel.IndicadorProducto = indicadorPOA;
        //        //entidadViewModel.IdIndicadorPOA = idIndicadorPOA;
        //        var colaborador = await _mediator.Send(new GetAllColaboradoresCachedQuery());
        //        if (colaborador.Succeeded)
        //        {
        //            var responsa = _mapper.Map<List<ColaboradorViewModel>>(colaborador.Data);
        //            // entidadViewModels.responsableList = new SelectList(responsa, "Id", "Nombres");
        //            entidadViewModels.ResponsableIndicador = responsa.Where(r => r.Id == idResponsable).FirstOrDefault().Nombres;
        //            entidadViewModels.DescResponsable = responsa.Where(r => r.Id == idResponsablePOA).FirstOrDefault().Nombres;
        //        }

        //        return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModels) });
        //    }
        //    //else
        //    //{
        //    //    var response = await _mediator.Send(new GetIndicadorPOAByIdQuery() { Id = id });
        //    //    if (response.Succeeded)
        //    //    {
        //    //        var entidadViewModel = _mapper.Map<IndicadorPOAViewModel>(response.Data);
        //    //        return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
        //    //    }
        //    //}
        //    return null;
        //}

        public async Task<JsonResult> LoadSeguimiento(int idIndicadorEstrategico, string tipo)
        {
            var response = await _mediator.Send(new GetSeguimientoByIdIndicador() { Id = idIndicadorEstrategico, Tipo = tipo });
            if (response.Succeeded)
            {
                var entidadViewModel = _mapper.Map<List<SeguimientoViewModel>>(response.Data);
                var cat11 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 16 });
                for (var i = 0; i < entidadViewModel.Count(); i++)
                {
                    entidadViewModel[i].DescMes = cat11.Data.Where(c => c.Secuencia == entidadViewModel[i].Mes.ToString()).FirstOrDefault().Nombre;
                }

                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", entidadViewModel) });

            }

            return null;
        }
        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0, int IdIndicador = 0, int IdEstrategia = 0, int idGestion = 0, string tipo = "")
        {

            var descGestion = "";
            var responseG = await _mediator.Send(new GetGestionByIdQuery() { Id = idGestion });
            if (responseG.Succeeded)
            {
                var entidadViewModel = _mapper.Map<GestionViewModel>(responseG.Data);
                descGestion = entidadViewModel.Anio;
            }
            var response = await _mediator.Send(new GetIndicadorEstrategicoByIdQuery() { Id = IdIndicador });
            if (response.Succeeded)
            {
                var entidadViewModel = _mapper.Map<IndicadorEstrategicoViewModel>(response.Data);

                if (id == 0)
                {

                    var entidadViewModelSeguimi = new SeguimientoViewModel();
                    entidadViewModelSeguimi.Tipo = tipo;
                    entidadViewModelSeguimi.IdIndicador = IdIndicador;
                    entidadViewModelSeguimi.DescObjetivo = entidadViewModel.FactorCriticoExitos.ObjetivoEstrategicos.Descripcion;
                    entidadViewModelSeguimi.DescIndicador = entidadViewModel.IndicadorResultado;
                    entidadViewModelSeguimi.DescFactor = entidadViewModel.FactorCriticoExitos.FactorCritico;

                    entidadViewModelSeguimi.DescLineaBase = entidadViewModel.LineaBase;
                    entidadViewModelSeguimi.DescGestion = descGestion + ": " + entidadViewModel.IndicadorAFs.Where(x => x.Anio == Convert.ToString(idGestion)).FirstOrDefault().Meta;
                    var cat11 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 16 });
                    entidadViewModelSeguimi.NumMesesList = new SelectList(cat11.Data, "Secuencia", "Nombre");
                    var responseC = await _mediator.Send(new GetColaboradorByIdQuery() { Id = (int)entidadViewModel.Responsable });
                    if (responseC.Succeeded)
                    {
                        var entidadViewModelCol = _mapper.Map<ColaboradorViewModel>(responseC.Data);
                        entidadViewModelSeguimi.DescResponsable = entidadViewModelCol.Nombres;
                    }

                    entidadViewModelSeguimi.MetaEstrategicas = entidadViewModel.MetaEstrategicas;

                    //entidadViewModel.IdFactorCritico = IdFactorCritico;
                    //entidadViewModel.IdEstrategia = IdEstrategia;
                    //entidadViewModel.IdGestion = idGestion;
                    //entidadViewModel.DescGestion = descGestion;
                    //  return View("_CreateOrEdit", entidadViewModel);
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModelSeguimi) });
                }
                else
                {
                    var responseSeguimiento = await _mediator.Send(new GetIndicadorEstrategicoByIdQuery() { Id = id });
                    if (responseSeguimiento.Succeeded)
                    {
                        var entidadViewModelS = _mapper.Map<SeguimientoViewModel>(responseSeguimiento.Data);

                        var cat11 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 16 });
                        entidadViewModelS.NumMesesList = new SelectList(cat11.Data, "Secuencia", "Nombre");

                        entidadViewModelS.DescObjetivo = entidadViewModel.FactorCriticoExitos.ObjetivoEstrategicos.Descripcion;
                        entidadViewModelS.DescIndicador = entidadViewModel.IndicadorResultado;
                        entidadViewModelS.DescFactor = entidadViewModel.FactorCriticoExitos.FactorCritico;

                        entidadViewModelS.DescLineaBase = entidadViewModel.LineaBase;
                        entidadViewModelS.DescGestion = descGestion + ": " + entidadViewModel.IndicadorAFs.Where(x => x.Anio == Convert.ToString(idGestion)).FirstOrDefault().Meta;

                        var responseC = await _mediator.Send(new GetColaboradorByIdQuery() { Id = (int)entidadViewModel.Responsable });
                        if (responseC.Succeeded)
                        {
                            var entidadViewModelCol = _mapper.Map<ColaboradorViewModel>(responseC.Data);
                            entidadViewModelS.DescResponsable = entidadViewModelCol.Nombres;
                        }
                        return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                    }
                    return null;
                }

            }
            return null;
        }
        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(int id, SeguimientoViewModel entidad)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == 0)
                    {
                        var createEntidadCommand = _mapper.Map<CreateSeguimientoCommand>(entidad);
                        var result = await _mediator.Send(createEntidadCommand);
                        if (result.Succeeded)
                        {
                            id = result.Data;
                            _notify.Success($"Seguimiento con ID {result.Data} Creado.");
                        }
                        else _notify.Error(result.Message);
                    }
                    //else
                    //{
                    //    var updateEntidadCommand = _mapper.Map<UpdateSeguimientoCommand>(entidad);
                    //    var result = await _mediator.Send(updateEntidadCommand);
                    //    if (result.Succeeded) _notify.Information($"Indicador con ID {result.Data} Actualizado.");
                    //}
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

        public async Task<JsonResult> OnGetCreateOrEditEvidencia(int id = 0, int idNivel = 0)
        {

            if (id == 0)
            {
                var entidadViewModelList = new List<EvidenciaViewModel>();
                var entidadViewModel = new EvidenciaViewModel();
                entidadViewModel.Nombre = "Documento de respaldo aF22";
                entidadViewModel.Descripcion = "Este Documento contiene la evidencia del proceso cumplido respaldo aF22";
                entidadViewModel.Archivo = "Documento_AF22-PDF";
                entidadViewModelList.Add(entidadViewModel);

                entidadViewModel = new EvidenciaViewModel();
                entidadViewModel.Nombre = "Documento de respaldo sgs";
                entidadViewModel.Descripcion = "Este Documento contiene la evidencia del proceso cumplido.";
                entidadViewModel.Archivo = "Documento_SGS";
                entidadViewModelList.Add(entidadViewModel);

                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEditEvidencia", entidadViewModelList) });
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
