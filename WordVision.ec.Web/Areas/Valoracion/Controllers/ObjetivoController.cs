﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.Actividades.Commands.Delete;
using WordVision.ec.Application.Features.Planificacion.Gestiones.Queries.GetById;
using WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetById;
using WordVision.ec.Application.Features.Soporte.Solicitudes.Commands.Update;
using WordVision.ec.Application.Features.Valoracion.Competencias.Queries.GetAll;
using WordVision.ec.Application.Features.Valoracion.Competencias.Queries.GetById;
using WordVision.ec.Application.Features.Valoracion.Escalas.Queries.GetAll;
using WordVision.ec.Application.Features.Valoracion.Objetivos.Queries.GetById;
using WordVision.ec.Application.Features.Valoracion.PlanificacionResultados.Commands.Create;
using WordVision.ec.Application.Features.Valoracion.PlanificacionResultados.Commands.Delete;
using WordVision.ec.Application.Features.Valoracion.PlanificacionResultados.Queries.GetAllCached;
using WordVision.ec.Application.Features.Valoracion.PlanificacionResultados.Queries.GetById;
using WordVision.ec.Application.Features.Valoracion.Responsabilidades.Queries.GetAll;
using WordVision.ec.Application.Features.Valoracion.Responsabilidades.Queries.GetById;
using WordVision.ec.Application.Features.Valoracion.Resultados.Queries.GetAllCached;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Valoracion.Models;
using WordVision.ec.Web.Areas.Valoracion.Pages.Objetivo.Wizard;
using WordVision.ec.Web.Services;


namespace WordVision.ec.Web.Areas.Valoracion.Controllers
{
   
    [Area("Valoracion")]
    [Authorize]
    public class ObjetivoController :  BaseController<ObjetivoController>
    {
        public IActionResult Index(int id = 0)
        {
           
            return View();
        }


        public async Task<IActionResult> LoadAll(int idAnioFiscal,int idColaborador)
        {
            try
            {
                var response = await _mediator.Send(new GetAllPlanificacionResultadosCachedQuery() { IdAnioFiscal = idAnioFiscal, IdColaborador = idColaborador });
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<ObjetivoResponseViewModel>>(response.Data);
                    return PartialView("_ViewAll", viewModel);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "LoadAll");
                _notify.Error("Error al LoadAll");
            }
            
            return null;     
        }
        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0, int idColaborador = 0,int idObjetivo=0,int idObjetivoAnioFiscal=0, int idResultado = 0,int anioFiscal=0,int objNumero=0,int tipoObjetivo=0,decimal ponderacionObjetivo=decimal.Zero,int perfil=0)
        {
            try
            {
                var idEstructura = 0;
                var idNivel = 0;
                   
                var responseGerencia = await _mediator.Send(new GetColaboradorByIdQuery() { Id = idColaborador });
                if (responseGerencia.Succeeded)
                {
                    if (responseGerencia.Data==null)
                    {
                        _notify.Error("El Id de Colaborador: "+ idColaborador+" no existe.");
                        return new JsonResult(new { isValid = false }); 
                    }
                    idEstructura = responseGerencia.Data.Estructuras.Id;
                    idNivel = responseGerencia.Data.Estructuras.Nivel;
                }

                if (id == 0)
                {
                    var entidadViewModel = new PlanificacionResultadoViewModel();
                    var anioFiscalViewModel = new ObjetivoAnioFiscalViewModel();
                    anioFiscalViewModel.AnioFiscal = anioFiscal;
                    anioFiscalViewModel.IdObjetivo = idObjetivo;
                    anioFiscalViewModel.Id = idObjetivoAnioFiscal;
                    entidadViewModel.IdColaborador = idColaborador;
                    entidadViewModel.IdResultado = idResultado;
                    entidadViewModel.IdObjetivoAnioFiscal = idObjetivoAnioFiscal;
                    entidadViewModel.TipoObjetivo = tipoObjetivo;
                    entidadViewModel.ObjetivoAnioFiscales = anioFiscalViewModel;
                    entidadViewModel.IdObjetivo= idObjetivo;
                    entidadViewModel.AnioFiscal = anioFiscal;
                    entidadViewModel.PonderacionObjetivo = ponderacionObjetivo;
                    entidadViewModel.NumeroObjetivo = objNumero;
                    entidadViewModel.chkOpcional = 1;//por efecto obligatorio
                    entidadViewModel.Perfil = perfil;

                    if (objNumero==3)
                    {
                       
                        //var cat11 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 10 });
                        //entidadViewModel.TipoListHito = new SelectList(cat11.Data, "Secuencia", "Nombre");
                        var entidadModelResponsabillidad = await _mediator.Send(new GetAllResponsabilidadQuery() { IdEstructura = idEstructura, IdObjetivoAnioFiscal = idObjetivoAnioFiscal });
                        entidadViewModel.IdResponsabillidadList = new SelectList(entidadModelResponsabillidad.Data, "IdResponsabilidad", "NombreResponsabilidad");
                        var entidadModelIndicador = await _mediator.Send(new GetResponsabilidadByIdPadreQuery() { IdPadre = entidadViewModel.IdPadre });
                        entidadViewModel.IdentificadorList = new SelectList(entidadModelIndicador.Data, "Id", "Indicador");


                        //var cat11 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 10 });
                        //entidadViewModel.TipoListHito = new SelectList(cat11.Data, "Secuencia", "Nombre");
                        //var entidadModelResponsabillidad = await _mediator.Send(new GetAllResponsabilidadQuery() {IdEstructura= Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "IdEstructura")?.Value), IdObjetivoAnioFiscal = idObjetivoAnioFiscal });
                        //entidadViewModel.IdResponsabillidadList = new SelectList(entidadModelResponsabillidad.Data, "IdResponsabilidad", "NombreResponsabilidad");
                        //var entidadModelIndicador = await _mediator.Send(new GetResponsabilidadByIdPadreQuery() { IdPadre = entidadMapper.IdPadre });
                        //entidadViewModel.IdentificadorList = new SelectList(entidadModelIndicador.Data, "Id", "Indicador");

                    }
                    else if (objNumero == 4)
                    {
                        var entidadModelResponsabillidad = await _mediator.Send(new GetAllCompetenciasQuery() { Nivel = idNivel });
                        entidadViewModel.IdCompetenciaList = new SelectList(entidadModelResponsabillidad.Data, "IdCompetencia", "NombreCompetencia");
                        //var entidadModelComportamiento = await _mediator.Send(new GetCompetenciaByIdPadreQuery() { IdPadre = entidadViewModel.IdPadreCompetencia });
                        //entidadViewModel.ComportamientoList = new SelectList(entidadModelComportamiento.Data, "Id", "Comportamiento");

                    }
                    else
                    {
                        var entidadModelResultado = await _mediator.Send(new GetAllResultadosCachedQuery() { IdObjetivo = idObjetivo, IdObjetivoAnioFiscal = idObjetivoAnioFiscal });
                        entidadViewModel.IdResultadoList = new SelectList(entidadModelResultado.Data.Where(c=>c.EsObligatorio==1), "Id", "Nombre");

                    }
                    if (objNumero == 2)
                    {
                        var entidadModelResultado = await _mediator.Send(new GetAllResultadosCachedQuery() { IdObjetivo = idObjetivo, IdObjetivoAnioFiscal = idObjetivoAnioFiscal });
                        entidadViewModel.IdResultadoOpcionalList = new SelectList(entidadModelResultado.Data.Where(c => c.EsObligatorio == 0), "Id", "Nombre");

                    }
                    var cat11 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 10 });
                    entidadViewModel.TipoListHito = new SelectList(cat11.Data, "Secuencia", "Nombre");
                    var entidadModelComportamiento = await _mediator.Send(new GetCompetenciaByIdPadreQuery() { IdPadre = entidadViewModel.IdPadreCompetencia });
                    entidadViewModel.ComportamientoList = new SelectList(entidadModelComportamiento.Data, "Id", "Comportamiento");

                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
                else
                {
                    tipoObjetivo= objNumero==3 ? 2 : objNumero == 4 ? 3:(objNumero == 5 || objNumero == 6 || objNumero == 7) ?4:1;
                    var entidadModel = await _mediator.Send(new GetPlanificacionResultadoByIdQuery() { Id = id });
                    var entidadMapper = _mapper.Map<PlanificacionResultadoViewModel>(entidadModel.Data);
                    entidadMapper.TipoObjetivo = tipoObjetivo;
                    entidadMapper.NumeroObjetivo = objNumero;
                    entidadMapper.IdObjetivoAnioFiscal = idObjetivoAnioFiscal;
                    var anioFiscalViewModel = new ObjetivoAnioFiscalViewModel();
                    anioFiscalViewModel.AnioFiscal = anioFiscal;
                    anioFiscalViewModel.IdObjetivo = idObjetivo;
                    anioFiscalViewModel.Id = idObjetivoAnioFiscal;
                    entidadMapper.ObjetivoAnioFiscales = anioFiscalViewModel;
                    entidadMapper.IdObjetivo = idObjetivo;
                    entidadMapper.AnioFiscal = anioFiscal;
                    entidadMapper.PonderacionObjetivo = ponderacionObjetivo;
                    entidadMapper.IdResultado = idResultado;
                    entidadMapper.Perfil = perfil;
                    if (objNumero == 3)
                    {
                        if (idResultado!=0)
                        {
                            var entidadResponsabillidad = await _mediator.Send(new GetResponsabilidadByIdQuery() { Id = entidadMapper.IdResultado });
                            entidadMapper.IdPadre = entidadResponsabillidad.Data.Padre;
                        }
                        
                        //var cat11 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 10 });
                        //entidadMapper.TipoListHito = new SelectList(cat11.Data, "Secuencia", "Nombre");
                        var entidadModelResponsabillidad = await _mediator.Send(new GetAllResponsabilidadQuery() { IdEstructura = idEstructura, IdObjetivoAnioFiscal = idObjetivoAnioFiscal });
                        entidadMapper.IdResponsabillidadList = new SelectList(entidadModelResponsabillidad.Data, "IdResponsabilidad", "NombreResponsabilidad");
                        var entidadModelIndicador = await _mediator.Send(new GetResponsabilidadByIdPadreQuery() { IdPadre = entidadMapper.IdPadre });
                        entidadMapper.IdentificadorList = new SelectList(entidadModelIndicador.Data, "Id", "Indicador");

                        entidadMapper.chkOpcional = entidadMapper.IdResultado==0?0:1;

                    }
                    else if (objNumero == 4)
                    {
                        var entidadResponsabillidad = await _mediator.Send(new GetCompetenciaByIdQuery() { Id = entidadMapper.IdResultado });
                        entidadMapper.IdPadreCompetencia = entidadResponsabillidad.Data.Padre;
                        var entidadModelResponsabillidad = await _mediator.Send(new GetAllCompetenciasQuery() { Nivel = idNivel });
                        entidadMapper.IdCompetenciaList = new SelectList(entidadModelResponsabillidad.Data, "IdCompetencia", "NombreCompetencia");
                        //var entidadModelComportamiento = await _mediator.Send(new GetCompetenciaByIdPadreQuery() { IdPadre = entidadMapper.IdPadreCompetencia });
                        //entidadMapper.ComportamientoList = new SelectList(entidadModelComportamiento.Data, "Id", "Comportamiento");
                        entidadMapper.chkOpcional = 1;//por efecto obligatorio
                    }
                    else
                    {
                        var entidadModelResultado = await _mediator.Send(new GetAllResultadosCachedQuery() { IdObjetivo = idObjetivo, IdObjetivoAnioFiscal = idObjetivoAnioFiscal });
                        entidadMapper.IdResultadoList = new SelectList(entidadModelResultado.Data.Where(c => c.EsObligatorio == 1), "Id", "Nombre");
                        entidadMapper.chkOpcional = 1;
                    }

                    if (objNumero == 2)
                    {
                        var entidadModelResultado = await _mediator.Send(new GetAllResultadosCachedQuery() { IdObjetivo = idObjetivo, IdObjetivoAnioFiscal = idObjetivoAnioFiscal });
                        entidadMapper.chkOpcional = entidadModelResultado.Data.Where(c => c.Id == entidadMapper.IdResultado).FirstOrDefault()?.EsObligatorio;
                        entidadMapper.IdResultadoOpcionalList = new SelectList(entidadModelResultado.Data.Where(c => c.EsObligatorio == 0), "Id", "Nombre");
                        entidadMapper.IdResultadoOpcional = entidadMapper.IdResultado;
                        entidadMapper.chkOpcional = 1;
                    }
                    var cat11 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 10 });
                    entidadMapper.TipoListHito = new SelectList(cat11.Data, "Secuencia", "Nombre");
                    var entidadModelComportamiento = await _mediator.Send(new GetCompetenciaByIdPadreQuery() { IdPadre = entidadMapper.IdPadreCompetencia });
                    entidadMapper.ComportamientoList = new SelectList(entidadModelComportamiento.Data, "Id", "Comportamiento");

                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadMapper) });

                }
            }    
            catch (Exception ex)
            {
                _logger.LogError(ex, "OnGetCreateOrEdit");
                _notify.Error("Error al actualizar la planificacion.");
            }

            return null;
        }

        public async Task<JsonResult> GetComportamientosList(int idCompetencia)
        {
            var entidadModel = await _mediator.Send(new GetCompetenciaByIdPadreQuery() { IdPadre = idCompetencia });
            var lista = _mapper.Map<List<CompetenciaViewModel>>(entidadModel.Data);
            return  Json(lista);
        }

        public async Task<JsonResult> GetIndicadorResponsabilidadList(int idResponsabilidad)
        {
            var entidadModel = await _mediator.Send(new GetResponsabilidadByIdPadreQuery() { IdPadre = idResponsabilidad });
            var lista = _mapper.Map<List<ResponsabilidadViewModel>>(entidadModel.Data);
            return Json(lista);

        }

        public async Task<JsonResult> GetResultado(int idResultado)
        {
            var entidadModel = await _mediator.Send(new GetResultadoByIdQuery() { Id = idResultado });
            var lista = _mapper.Map<ResultadoViewModel>(entidadModel.Data);
            return Json(lista);

        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(int id, PlanificacionResultadoViewModel entidad)
        {
            try
            {
                if (entidad.PlanificacionComportamientos != null)
                {
                    foreach(var c in entidad.PlanificacionComportamientos)
                    {
                      int cuenta = entidad.PlanificacionComportamientos.Where(cp => cp.IdCompetencia == c.IdCompetencia).Count();
                      if  (cuenta>1)
                        {
                            _notify.Information("Existen dos o mas Comportamiento iguales, solo debe existir uno.");

                            return new JsonResult(new { isValid = false });
                        }
                    }
                }

               
                if (entidad.NumeroObjetivo == 2)
                {
                    if (entidad.chkOpcional == 1)
                    {
                        entidad.IdResultado = (int)entidad.IdResultadoOpcional;
                    }
                }
                else if (entidad.NumeroObjetivo==3)
                {
                    if (entidad.chkOpcional == 1)
                    {
                        entidad.IdResultado = 0;
                    }
                    var entidadModel = await _mediator.Send(new GetPlanificacionResultadoByIdQuery() { Id = id });
                    var entidadMapper = _mapper.Map<PlanificacionResultadoViewModel>(entidadModel.Data);
                    int hitoBd = 0;
                    int existe = 0;
                    if (entidadMapper!=null)
                     hitoBd = entidadMapper.PlanificacionHitos.Count();
                    if (entidad.PlanificacionHitos != null)
                    {
                        if (entidadMapper!=null)
                        {
                            foreach (var h in entidadMapper.PlanificacionHitos)
                            {
                                foreach (var ha in entidad.PlanificacionHitos)
                                {
                                    if (h.Id == ha.Id)
                                    {
                                        existe = 0;
                                        break;
                                    }
                                    else
                                        existe++;
                                }
                            }
                        }
                        else
                        {
                            existe = 0;
                            hitoBd = entidad.PlanificacionHitos.Count();
                        }
                        
                        var cuenta = existe + hitoBd;
                        if (cuenta > 3)
                        {
                            _notify.Error("Debe ingresar máximo 3 Hitos por cada responsabilidad.");

                            return new JsonResult(new { isValid = false });
                        }
                        else if (!(cuenta >= 1 && cuenta <= 3))
                        {
                            _notify.Error("Debe ingresar mínimo 1 y máximo 3 Hitos por cada responsabilidad.");

                            return new JsonResult(new { isValid = false });
                        }
                    }
                    else
                    {
                        if (hitoBd > 3)
                        {
                            _notify.Error("Debe ingresar máximo 3 Hitos por cada responsabilidad.");

                            return new JsonResult(new { isValid = false });
                        }
                        else if (! (hitoBd>=1 && hitoBd <= 3))
                        {
                            _notify.Error("Debe ingresar mínimo 1 y máximo 3 Hitos por cada responsabilidad.");

                            return new JsonResult(new { isValid = false });
                        }
                    }

                }
                else if(entidad.NumeroObjetivo == 4)
                {
                    if (id==0)
                    {
                        if (entidad.PlanificacionComportamientos.Count()==0)
                        {
                            entidad.IdResultado = 0;
                        }
                        else
                        entidad.IdResultado = entidad.PlanificacionComportamientos.FirstOrDefault().IdCompetencia;
                    }
                    else
                    {
                        
                        var ponderacion = await _mediator.Send(new GetPlanificacionResultadoByIdQuery() { Id = id });
                        if (ponderacion.Data==null)
                        {
                            entidad.IdResultado = entidad.PlanificacionComportamientos.FirstOrDefault().IdCompetencia;
                            id=0;
                        }
                        else
                            entidad.IdResultado = ponderacion.Data.IdResultado;
                    }
                    
                }
                if (ModelState.IsValid)
                {
                    decimal ponderaObjetivo = 0;
                    var ponderacion = await _mediator.Send(new GetObjetivoByIdAnioQuery() { Id = entidad.ObjetivoAnioFiscales.IdObjetivo });
                    ponderaObjetivo = ponderacion.Data.Ponderacion;
                    var planifica = await _mediator.Send(new GetPlanificacionResultadoByIdObjetivoColaboradorQuery() { IdObjetivo = entidad.ObjetivoAnioFiscales.IdObjetivo, IdColaborador = entidad.IdColaborador });
                    var contar = planifica.Data.Count();
                    var d = planifica.Data.Where(b => b.Id != id).ToList();
                    var existe = planifica.Data.Where(b => b.IdResultado == entidad.IdResultado).Count();
                    decimal suma = 0;
                    decimal sumaBasePoderacion = 0;

                    if (entidad.NumeroObjetivo == 5 || entidad.NumeroObjetivo == 6 || entidad.NumeroObjetivo == 7)
                    {
                        if (contar==d.Count())
                        {
                            contar = contar + 1;
                        }
                    }

                        //if (!(contar>=ponderacion.Data.Minimo && contar <= ponderacion.Data.Maximo))
                        if (!(contar <= ponderacion.Data.Maximo))
                        {
                            _notify.Error("El Objetivo " + entidad.NumeroObjetivo.ToString() + " debe tener mínimo " + ponderacion.Data.Minimo.ToString() + " y máximo " + ponderacion.Data.Maximo.ToString() + " Items.");

                            return new JsonResult(new { isValid = false });
                        }
                        //foreach (var s in planifica.Data)
                        //{
                        //    sumaBasePoderacion = sumaBasePoderacion + Convert.ToDecimal(s.Ponderacion);
                        //    //  ponderaObjetivo = i.Resultados.ObjetivoAnioFiscales.Ponderacion;
                        //}
                        foreach (var i in d)
                        {
                            suma = suma + Convert.ToDecimal(i.Ponderacion);
                            //  ponderaObjetivo = i.Resultados.ObjetivoAnioFiscales.Ponderacion;
                        }
                        var total = suma + Convert.ToDecimal(entidad.Ponderacion);
                        var restan = ponderaObjetivo - suma;
                        if (total > ponderaObjetivo)
                        {    
                            _notify.Error("Los items debe  sumar un total del " + ponderaObjetivo.ToString() + " %, en la ponderación. Actualmente suman: "+ suma.ToString());
     
                           // _notify.Error("La suma de la ponderación de objetivo no pude ser mayor a la Ponderacion de Resultado que es igual a:" + ponderaObjetivo.ToString() + ", le faltan " + restan.ToString() + " para llegar al máximo permitido.");

                            return new JsonResult(new { isValid = false });
                        }
                    
                    
                    if (id == 0)
                    {
                        if (entidad.NumeroObjetivo == 1 || entidad.NumeroObjetivo ==2 || entidad.NumeroObjetivo == 3 || entidad.NumeroObjetivo == 4)
                        {
                            if (existe >= 1)
                            {
                                _notify.Error("Ya existe un Resultado/Responsabilidad/Competencias ingresado en este Objetivo.");

                                return new JsonResult(new { isValid = false });
                            }
                        }
                        entidad.Estado = 1;/*en proceso*/
                       var createEntidadCommand = _mapper.Map<CreatePlanificacionResultadoCommand>(entidad);
                        var result = await _mediator.Send(createEntidadCommand);
                        if (result.Succeeded)
                        {
                            id = result.Data;
                            _notify.Success($"PlanificacionResultado con ID {result.Data} Creado.");
                        }
                        else _notify.Error(result.Message);
                    }
                    else
                    {
                        if (entidad.NumeroObjetivo == 1 || entidad.NumeroObjetivo == 2 || entidad.NumeroObjetivo == 3 || entidad.NumeroObjetivo == 4)
                        {
                            var lista = planifica.Data.ToList();
                            foreach(var item in lista)
                            {
                                if (item.Id!=id)
                                {
                                    if (item.IdResultado==entidad.IdResultado)
                                    {
                                        _notify.Error("Ya existe un Resultado/Responsabilidad/Competencias ingresado en este Objetivo.");

                                        return new JsonResult(new { isValid = false });
                                    }
                                }
                            
                            }
                        }


                        var updateEntidadCommand = _mapper.Map<UpdatePlanificacionResultadoCommand>(entidad);
                        var result = await _mediator.Send(updateEntidadCommand);
                        if (result.Succeeded) _notify.Information($"PlanificacionResultado con ID {result.Data} Actualizado.");
                    }

                    var viewModel = new Objetivo_1Step();
                    viewModel.IdObjetivo = entidad.IdObjetivo;
                    viewModel.AnioFiscal = entidad.AnioFiscal;
                    viewModel.IdObjetivoAnioFiscal = entidad.IdObjetivoAnioFiscal;
                    viewModel.NumeroObjetivo = entidad.NumeroObjetivo.ToString();
                    viewModel.PonderacionObjetivo = entidad.PonderacionObjetivo;
                    viewModel.Perfil = entidad.Perfil;
                    viewModel.IdColaborador = entidad.IdColaborador;

                    var responseObj = await _mediator.Send(new GetObjetivoByIdQuery() { Id = entidad.IdObjetivo });
                    viewModel.Objetivo = responseObj.Data.Nombre;
                    var response = await _mediator.Send(new GetPlanificacionResultadoByIdColabotadorQuery() { IdObjetivoAnioFiscal = entidad.IdObjetivoAnioFiscal, IdColaborador = entidad.IdColaborador });
                    if (response.Succeeded)
                    {
                        var entidadP = _mapper.Map<List<PlanificacionResultadoResponse>>(response.Data);
                        viewModel.PlanificacionResultados = entidadP;
                        string pagina = entidad.NumeroObjetivo == 4 ? "_ViewAllObjetivoCompetencia" : entidad.NumeroObjetivo == 5 || entidad.NumeroObjetivo == 6 || entidad.NumeroObjetivo == 7 ? "_ViewAllObjetivoPregunta" : "_ViewAllObjetivoResultado";
                        var html1 = await _viewRenderer.RenderViewToStringAsync(pagina, viewModel);
                        return new JsonResult(new { isValid = true, html = html1 });
                    }




                }
                else
                {
                    var result = string.Join(',', ModelState.Values.SelectMany(v => v.Errors).Select(a => a.ErrorMessage));
                    _notify.Error("Error de datos. " + result);
                    _logger.LogError(result);

                    return new JsonResult(new { isValid = false });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "OnPostCreateOrEdit");
                _notify.Error("Error al insertar Gestion");
            }
            return new JsonResult(new { isValid = false });
        }

        [RequestFormLimits(ValueLengthLimit = int.MaxValue, MultipartBodyLengthLimit = int.MaxValue)]
        [DisableRequestSizeLimit]
        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return Content("file not selected");

            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot",
                        file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("Files");
        }

        public async Task<IActionResult> Download(string filename)
        {
            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }
        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats officedocument.spreadsheetml.sheet"},  
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }
        public async Task<JsonResult> OnPostDelete(int id = 0,int idColaborador=0, int idObjetivo = 0, int anioFiscal = 0, int idObjetivoAnioFiscal = 0, int numeroObjetivo = 0, int ponderacionObjetivo = 0)
        {
            try
            {
                var deleteCommand = await _mediator.Send(new DeletePlanificacionResultadoCommand { Id = id });
                if (deleteCommand.Succeeded)
                {
                    _notify.Information($"Planificacion con Id {id} Eliminado.");
                }
                else
                {
                    _notify.Error(deleteCommand.Message);
                    return null;
                }

                var viewModel = new Objetivo_1Step();
                viewModel.IdObjetivo = idObjetivo;
                viewModel.AnioFiscal = anioFiscal;
                viewModel.IdObjetivoAnioFiscal = idObjetivoAnioFiscal;
                viewModel.NumeroObjetivo = numeroObjetivo.ToString();
                viewModel.PonderacionObjetivo = ponderacionObjetivo;
                var response = await _mediator.Send(new GetPlanificacionResultadoByIdColabotadorQuery() { IdObjetivoAnioFiscal = idObjetivoAnioFiscal, IdColaborador = idColaborador });
                if (response.Succeeded)
                {
                    var entidadP = _mapper.Map<List<PlanificacionResultadoResponse>>(response.Data);
                    viewModel.PlanificacionResultados = entidadP;
                    string pagina = numeroObjetivo == 4 ? "_ViewAllObjetivoCompetencia" : numeroObjetivo == 5 || numeroObjetivo == 6 || numeroObjetivo == 7 ? "_ViewAllObjetivoPregunta" : "_ViewAllObjetivoResultado";
                    var html1 = await _viewRenderer.RenderViewToStringAsync(pagina, viewModel);
                    return new JsonResult(new { isValid = true, html = html1 });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "OnPostDelete");
                _notify.Error("Error al Eliminar Planificacion.");
            }
           

            return new JsonResult(new { isValid = false });
        }
        public async Task<JsonResult> OnPostDeleteHito(int id = 0)
        {
            try
            {
                var deleteCommand = await _mediator.Send(new DeletePlanificacionHitoCommand { Id = id });
                if (deleteCommand.Succeeded)
                {
                    _notify.Information($"Hito con Id {id} Eliminado.");
                    return new JsonResult(new { isValid = true });
                }
                else
                {
                    _notify.Error(deleteCommand.Message);
                    return null;
                }

               
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "OnPostDelete");
                _notify.Error("Error al Eliminar Planificacion.");
            }


            return new JsonResult(new { isValid = false });
        }

        public async Task<JsonResult> OnPostDeleteAvance(int id = 0)
        {
            try
            {
                var deleteCommand = await _mediator.Send(new DeleteAvanceObjetivoCommand { Id = id });
                if (deleteCommand.Succeeded)
                {
                    _notify.Information($"Avance con Id {id} Eliminado.");
                    return new JsonResult(new { isValid = true });
                }
                else
                {
                    _notify.Error(deleteCommand.Message);
                    return null;
                }


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "OnPostDelete");
                _notify.Error("Error al Eliminar Planificacion.");
            }


            return new JsonResult(new { isValid = false });
        }

        
        public async Task<JsonResult> OnPostDeleteComportamiento(int id = 0)
        {
            try
            {
                var deleteCommand = await _mediator.Send(new DeletePlanificacionComportamientoCommand { Id = id });
                if (deleteCommand.Succeeded)
                {
                    _notify.Information($"Comportamiento con Id {id} Eliminado.");
                    return new JsonResult(new { isValid = true });
                }
                else
                {
                    _notify.Error(deleteCommand.Message);
                    return null;
                }


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "OnPostDelete");
                _notify.Error("Error al Eliminar Comportamiento.");
            }


            return new JsonResult(new { isValid = false });
        }
        public async Task<IActionResult> LoadObjetivoResultado(int id = 0,int idObjetivo=0,int idObjetivoAnioFiscal=0,int anioFiscal=0,string objNumero="", List<PlanificacionResultadoResponse> entidad =null,decimal ponderacion=decimal.Zero,int perfil=0,string comentario ="")
        {
            try
            {
                var viewModel = new Objetivo_1Step();
                viewModel.IdObjetivo = idObjetivo;
                viewModel.AnioFiscal = anioFiscal;
                viewModel.IdObjetivoAnioFiscal = idObjetivoAnioFiscal;
                viewModel.NumeroObjetivo = objNumero;
                viewModel.PonderacionObjetivo = ponderacion;
                viewModel.Perfil = perfil;
                viewModel.IdColaborador = id;
              

                var responseObj = await _mediator.Send(new GetObjetivoByIdQuery() { Id  = idObjetivo });
                viewModel.Objetivo = responseObj.Data.Nombre;

                var response = await _mediator.Send(new GetPlanificacionResultadoByIdColabotadorQuery() { IdObjetivoAnioFiscal = idObjetivoAnioFiscal, IdColaborador = id });
                if (response.Succeeded)
                {
                    entidad = _mapper.Map<List<PlanificacionResultadoResponse>>(response.Data);
                    
                }
                viewModel.PlanificacionResultados = entidad;

                
                string pagina = objNumero == "4" ? "_ViewAllObjetivoCompetencia" : objNumero == "5" || objNumero == "6" || objNumero == "7" ? "_ViewAllObjetivoPregunta" : "_ViewAllObjetivoResultado";
                //entidad.NumContacto = formularioViewModel.FormularioTerceros.Where(x => x.Tipo == "C").Count();
                return PartialView(pagina, viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "OnPostDelete");
                _notify.Error("Error al Eliminar Comportamiento.");
            }

            return null;  

        }

        public async Task<JsonResult> OnPostAbrirValoracion(int idColaborador,int anioFiscal, int estado)
        {
            try
            {
                var deleteCommand = await _mediator.Send(new UpdateAbrirEdicionCommand { IdColaborador = idColaborador, AnioFiscal=anioFiscal,Estado=estado });
                if (deleteCommand.Succeeded)
                {
                    _notify.Information($"Valoración con Id Anio Fiscal {anioFiscal} abierto.");
                    return new JsonResult(new { isValid = true });
                }
                else
                {
                    _notify.Error(deleteCommand.Message);
                    return null;
                }


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "OnPostAbrirValoracion");
                _notify.Error($"Error al Abrir Valoración del Anio Fiscal {anioFiscal}.");
            }


            return new JsonResult(new { isValid = false });
        }
        public async Task<ActionResult> EnviarMail( int idColaborador,int reportaA,int proceso,int idAnioFiscal, string ComentarioColaborador 
        ,string ComentarioLider1 
        ,string ComentarioLider2 
        ,string ComentarioLiderMatricial
        ,decimal? ValorValoracionFinal 
        ,string ValoracionFinal
        ,string ValoracionLider1 , int estadoProceso=0)
        {
         
            string apellidos = "";
            string nombres = "";
            string mail = "";
            string apellidosReporta = "";
            string nombresReporta = "";
            string mailReporta = "";
            string anioFiscal = "";
            string copia = "";
            int estado = 0;
            int codReportaA = 0;
            try
            {
                var responseAF = await _mediator.Send(new GetGestionByIdQuery() { Id = idAnioFiscal });
                if (responseAF.Succeeded)
                {
                    anioFiscal = responseAF.Data.Anio;
                }
                   var response = await _mediator.Send(new GetColaboradorByIdQuery() { Id = idColaborador });
                if (response.Succeeded)
                { 
                    if (response.Data!=null)
                    {
                        apellidos = response.Data.Apellidos + " " + response.Data.ApellidoMaterno;
                        nombres = response.Data.PrimerNombre + " " + response.Data.SegundoNombre;
                        mail = response.Data.Email;
                        codReportaA = response.Data.Estructuras.ReportaID;
                        apellidosReporta = response.Data.ApellidosReporta + " " + response.Data.ApellidoMaternoReporta;
                        nombresReporta = response.Data.PrimerNombreReporta + " " + response.Data.SegundoNombreReporta;
                        mailReporta = response.Data.EmailReporta;

                        //var responseReporta = await _mediator.Send(new GetColaboradorByIdQuery() { Id = codReportaA });
                        //    if (responseReporta.Succeeded)
                        //    {
                        //        if (responseReporta.Data != null)
                        //        {
                        //            apellidosReporta = responseReporta.Data.Apellidos + " " + responseReporta.Data.ApellidoMaterno;
                        //            nombresReporta = responseReporta.Data.PrimerNombre + " " + responseReporta.Data.SegundoNombre;
                        //            mailReporta = responseReporta.Data.Email;
                        //        }
                        //    else
                        //    {
                        //        _notify.Error($"Error en devolver los datos del jefe inmediato. Proceso enviar mail.");
                        //        _logger.LogError($"Error en devolver los datos del jefe inmediat. Proceso enviar mail.");
                        //        return RedirectToPage("/Objetivo/Wizard/Index", new { area = "Valoracion", id = idColaborador, perfil = proceso == 1 ? 0 : 1 });
                        //    }
                        //}


                    }
                    else
                    {
                        _notify.Error($"Error en devolver los datos del colaborador. Proceso enviar mail.");
                        _logger.LogError($"Error en devolver los datos del colaborador. Proceso enviar mail.");
                        return RedirectToPage("/Objetivo/Wizard/Index", new { area = "Valoracion", id = idColaborador, perfil = proceso == 1 ? 0 : 1 });
                    }
                   

                }




                string plantilla = "";

                switch (proceso)
                {
                    case 1:
                        if (estadoProceso==4 || estadoProceso == 5)
                        {
                            plantilla = "";
                            estado = 5;
                        }
                        else
                        {
                            plantilla = "RevisionLider.html";
                            estado = 2;
                        }
                       
                        break;
                    case 2:
                        if (estadoProceso == 5)
                        {
                            plantilla = "";
                            estado = 6;
                        }
                        else
                        {
                            plantilla = "AprovacionLider.html";
                            estado = 4;
                        }
                        break;
                    case 3:
                        plantilla = "DevolverLider.html";
                        estado = 3;
                        break;
                }

                if (plantilla!="")
                { 
                //Get TemplateFile located at wwwroot/Templates/EmailTemplate/Register_EmailTemplate.html  
                var pathToFile = _env.WebRootPath
                        + Path.DirectorySeparatorChar.ToString()
                        + "Templates"
                        + Path.DirectorySeparatorChar.ToString()
                        + "EmailTemplate"
                        + Path.DirectorySeparatorChar.ToString()
                        + "Valoracion" + Path.DirectorySeparatorChar.ToString()
                        + plantilla;

                var subject ="";

                var builder = new BodyBuilder();
                using (StreamReader SourceReader = System.IO.File.OpenText(pathToFile))
                {
                    builder.HtmlBody = SourceReader.ReadToEnd();
                }
                //{0} : Subject  
                //{1} : DateTime  
                //{2} : Email  
                //{3} : Username  
                //{4} : Password  
                //{5} : Message  
                //{6} : callbackURL  
                string messageBody=builder.ToString();
                switch (proceso)
                {
                    case 1:
                        subject = _configuration["AsuntoRevisionLider"] + apellidos + " " + nombres;
                        plantilla = "RevisionLider.html";
                        messageBody = string.Format(builder.HtmlBody,
                        apellidosReporta + " " + nombresReporta,
                        apellidos + " " + nombres
                        );
                        mail = mailReporta;
                        copia = _configuration["CopiaRevisionLider"];
                        break;
                    case 2:
                        subject = _configuration["AsuntoAprobacionLider"] + apellidos + " " + nombres;
                        plantilla = "AprovacionLider.html";
                        messageBody = string.Format(builder.HtmlBody,
                        anioFiscal,
                        apellidos + " " + nombres
                        );
                        copia = _configuration["CopiaAprobacionLider"];
                        //mail = mailReporta;
                        break;
                    case 3:
                        subject = _configuration["AsuntoDevolucionLider"] + apellidos + " " + nombres;
                        plantilla = "DevolverLider.html";
                        messageBody = string.Format(builder.HtmlBody,
                        anioFiscal,
                        apellidos + " " + nombres
                        );
                        copia = _configuration["CopiaRevisionLider"];
                        //mail = mailReporta;
                        break;
                }

                    await _emailSender
                       .SendEmailAsync(mail, subject, messageBody, copia)
                       .ConfigureAwait(false);

                    PlanificacionResultadoViewModel entidad = new PlanificacionResultadoViewModel();
                entidad.Estado = estado;
                entidad.Proceso = 1;// si ya esta en el borton finalizar o devolver
                entidad.IdColaborador = idColaborador;
                entidad.AnioFiscal = idAnioFiscal;
                    if (estado== 5 || estado == 6)
                    {
                        entidad.ComentarioColaborador = ComentarioColaborador;
                        entidad.ComentarioLider1 = ComentarioLider1;
                        entidad.ComentarioLider2 = ComentarioLider2;
                        entidad.ComentarioLiderMatricial = ComentarioLiderMatricial;
                        entidad.ValorValoracionFinal = ValorValoracionFinal;
                        entidad.ValoracionFinal = ValoracionFinal;
                        entidad.ValoracionLider1 = ValoracionLider1;

                    }

                    var updateEntidadCommand = _mapper.Map<UpdatePlanificacionResultadoCommand>(entidad);
                var result = await _mediator.Send(updateEntidadCommand);


              
                //_notify.Success($"Mail Enviado.");
                }
                else
                {
                    PlanificacionResultadoViewModel entidad = new PlanificacionResultadoViewModel();
                    entidad.Estado = estado;
                    entidad.Proceso = 1;// si ya esta en el borton finalizar o devolver
                    entidad.IdColaborador = idColaborador;
                    entidad.AnioFiscal = idAnioFiscal;
                    if (estado == 5 || estado == 6)
                    {
                        entidad.ComentarioColaborador = ComentarioColaborador;
                        entidad.ComentarioLider1 = ComentarioLider1;
                        entidad.ComentarioLider2 = ComentarioLider2;
                        entidad.ComentarioLiderMatricial = ComentarioLiderMatricial;
                        entidad.ValorValoracionFinal = ValorValoracionFinal;
                        entidad.ValoracionFinal = ValoracionFinal;
                        entidad.ValoracionLider1 = ValoracionLider1;

                    }

                    var updateEntidadCommand = _mapper.Map<UpdatePlanificacionResultadoCommand>(entidad);
                    var result = await _mediator.Send(updateEntidadCommand);
                    //_notify.Success($"Enviado a .");
                }
                switch (estado)
                {
                    case 1:
                        _notify.Success($"Valoración en proceso.");
                        break;
                    case 2:
                        _notify.Success($"Valoración enviado a Lider.");
                        break;
                    case 3:
                        _notify.Success($"Valoración devuelta.");
                        break;
                    case 4:
                        _notify.Success($"Valoración ingresada aprobado por el Lider.");
                        break;
                    case 5:
                        _notify.Success($"Valoración en revisión.");
                        break;
                    case 6:
                        _notify.Success($"Valoración finalizada.");
                        break;
                }

            }
            catch (Exception ex)
            {
                _notify.Error($"Error en enviar al proceso.");
                _logger.LogError(ex, $"Error en enviar Mail.");
            }

            //   return new JsonResult(new { isValid = true });
            // return RedirectToPage("/Wizard/Index", new { area = "Registro" });
            return RedirectToPage("/Objetivo/Wizard/Index", new { area = "Valoracion",id= idColaborador, perfil=proceso==1?0:1 });
        }


    }
}
