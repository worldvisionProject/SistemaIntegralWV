using Microsoft.AspNetCore.Authorization;
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
using WordVision.ec.Application.Features.Valoracion.Objetivos.Queries.GetById;
using WordVision.ec.Application.Features.Valoracion.PlanificacionResultados.Commands.Create;
using WordVision.ec.Application.Features.Valoracion.PlanificacionResultados.Queries.GetAllCached;
using WordVision.ec.Application.Features.Valoracion.PlanificacionResultados.Queries.GetById;
using WordVision.ec.Application.Features.Valoracion.Responsabilidades.Queries.GetAll;
using WordVision.ec.Application.Features.Valoracion.Responsabilidades.Queries.GetById;
using WordVision.ec.Application.Features.Valoracion.Resultados.Queries.GetAllCached;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Valoracion.Models;
using WordVision.ec.Web.Areas.Valoracion.Pages.Objetivo.Wizard;

namespace WordVision.ec.Web.Areas.Valoracion.Controllers
{
    [Area("Valoracion")]
    [Authorize]
    public class LiderController :  BaseController<LiderController>
    {
        public IActionResult Index(int id = 0)
        {
           
            return View();
        }


        public async Task<IActionResult> LoadAll(int idLider)
        {
            try
            {
                var response = await _mediator.Send(new GetPlanificacionResultadoByIdLiderQuery() { IdLider = idLider });
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<PlanificacionResultadoViewModel>>(response.Data);
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
        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0, int idColaborador = 0,int idObjetivo=0,int idObjetivoAnioFiscal=0, int idResultado = 0,int anioFiscal=0,int objNumero=0,int tipoObjetivo=0,decimal ponderacionObjetivo=decimal.Zero)
        {
            try
            {
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
                    if (objNumero==3)
                    {
                        
                        var cat11 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 10 });
                        entidadViewModel.TipoListHito = new SelectList(cat11.Data, "Secuencia", "Nombre");
                        var entidadModelResponsabillidad = await _mediator.Send(new GetAllResponsabilidadQuery() {IdEstructura= Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "IdEstructura")?.Value), IdObjetivoAnioFiscal = idObjetivoAnioFiscal });
                        entidadViewModel.IdResponsabillidadList = new SelectList(entidadModelResponsabillidad.Data, "IdResponsabilidad", "NombreResponsabilidad");
                    }
                    else if (objNumero == 4)
                    {
                        var entidadModelResponsabillidad = await _mediator.Send(new GetAllCompetenciasQuery() { Nivel = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Nivel")?.Value) });
                        entidadViewModel.IdCompetenciaList = new SelectList(entidadModelResponsabillidad.Data, "IdCompetencia", "NombreCompetencia");
                    }
                    else
                    {
                        var entidadModelResultado = await _mediator.Send(new GetAllResultadosCachedQuery() { IdObjetivo = idObjetivo, IdObjetivoAnioFiscal = idObjetivoAnioFiscal });
                        entidadViewModel.IdResultadoList = new SelectList(entidadModelResultado.Data, "Id", "Nombre");

                    }
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

                    if (objNumero == 3)
                    {
                        var entidadResponsabillidad = await _mediator.Send(new GetResponsabilidadByIdQuery() { Id = entidadMapper.IdResultado });
                        entidadMapper.IdPadre = entidadResponsabillidad.Data.Padre;
                        var cat11 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 10 });
                        entidadMapper.TipoListHito = new SelectList(cat11.Data, "Secuencia", "Nombre");
                        var entidadModelResponsabillidad = await _mediator.Send(new GetAllResponsabilidadQuery() { IdEstructura = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "IdEstructura")?.Value), IdObjetivoAnioFiscal = idObjetivoAnioFiscal });
                        entidadMapper.IdResponsabillidadList = new SelectList(entidadModelResponsabillidad.Data, "IdResponsabilidad", "NombreResponsabilidad");
                    }
                    else if (objNumero == 4)
                    {
                        var entidadResponsabillidad = await _mediator.Send(new GetCompetenciaByIdQuery() { Id = entidadMapper.IdResultado });
                        entidadMapper.IdPadreCompetencia = entidadResponsabillidad.Data.Padre;
                        var entidadModelResponsabillidad = await _mediator.Send(new GetAllCompetenciasQuery() { Nivel = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Nivel")?.Value) });
                        entidadMapper.IdCompetenciaList = new SelectList(entidadModelResponsabillidad.Data, "IdCompetencia", "NombreCompetencia");
                    }
                    else
                    {
                        var entidadModelResultado = await _mediator.Send(new GetAllResultadosCachedQuery() { IdObjetivo = idObjetivo, IdObjetivoAnioFiscal = idObjetivoAnioFiscal });
                        entidadMapper.IdResultadoList = new SelectList(entidadModelResultado.Data, "Id", "Nombre");

                    }

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
               if (entidad.NumeroObjetivo==3)
                {
                    var entidadModel = await _mediator.Send(new GetPlanificacionResultadoByIdQuery() { Id = id });
                    var entidadMapper = _mapper.Map<PlanificacionResultadoViewModel>(entidadModel.Data);
                    int hitoBd = 0;
                    if (entidadMapper!=null)
                     hitoBd = entidadMapper.PlanificacionHitos.Count();
                    if (entidad.PlanificacionHitos!=null)
                    {
                        var cuenta = entidad.PlanificacionHitos.Count()+ hitoBd;
                        if (cuenta>3)
                        {
                            _notify.Error("Debe ingresar máximo 3 Hitos por cada responsabilidad.");

                            return new JsonResult(new { isValid = false });
                        }
                    }
                
                }
                if (ModelState.IsValid)
                {
                    decimal ponderaObjetivo = 0;
                    var ponderacion = await _mediator.Send(new GetObjetivoByIdAnioQuery() { Id = entidad.ObjetivoAnioFiscales.IdObjetivo });
                    ponderaObjetivo = ponderacion.Data.Ponderacion;
                    var planifica = await _mediator.Send(new GetPlanificacionResultadoByIdObjetivoColaboradorQuery() { IdObjetivo = entidad.ObjetivoAnioFiscales.IdObjetivo,IdColaborador=entidad.IdColaborador });
                    var contar = planifica.Data.Count();
                    var d= planifica.Data.Where(b=>b.Id!=id).ToList();
                    var existe= planifica.Data.Where(b => b.IdResultado ==entidad.IdResultado).Count();
                    decimal suma = 0;
                    decimal sumaBasePoderacion = 0;


                    //if (!(contar>=ponderacion.Data.Minimo && contar <= ponderacion.Data.Maximo))
                    if (!(contar<=ponderacion.Data.Maximo))
                    {
                        _notify.Error("El Objetivo "+ entidad.NumeroObjetivo.ToString() + " debe tener mínimo "+ ponderacion.Data.Minimo.ToString() + " y máximo "+ponderacion.Data.Maximo.ToString()+" Items.");

                        return new JsonResult(new { isValid = false });
                    }
                    //foreach (var s in planifica.Data)
                    //{
                    //    sumaBasePoderacion = sumaBasePoderacion + Convert.ToDecimal(s.Ponderacion);
                    //    //  ponderaObjetivo = i.Resultados.ObjetivoAnioFiscales.Ponderacion;
                    //}
                    foreach (var i in d)
                    {
                        suma = suma + Convert.ToDecimal( i.Ponderacion);
                       //  ponderaObjetivo = i.Resultados.ObjetivoAnioFiscales.Ponderacion;
                    }
                    var total = suma + Convert.ToDecimal(entidad.Ponderacion);
                    var restan = ponderaObjetivo-suma;
                    if (total > ponderaObjetivo)
                    {
                        
                        _notify.Error("La suma de la ponderación de resultado no pude ser mayor a la Ponderacion de Objetivo " + ponderaObjetivo.ToString()+", restan "+restan.ToString()+" para llegar al máximo permitido.");
                       
                        return new JsonResult(new { isValid = false });
                    }
                    if (id == 0)
                    {
                        if (existe >= 1)
                        {
                            _notify.Error("Ya existe un Resultado/Responsabilidad/Competencias ingresado en este Objetivo.");

                            return new JsonResult(new { isValid = false });
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

        public async Task<IActionResult> LoadObjetivoResultado(int id = 0,int idObjetivo=0,int idObjetivoAnioFiscal=0,int anioFiscal=0,string objNumero="", List<PlanificacionResultadoResponse> entidad =null,decimal ponderacion=decimal.Zero)
        {
            var viewModel = new Objetivo_1Step();
            viewModel.IdObjetivo = idObjetivo;
            viewModel.AnioFiscal = anioFiscal;
            viewModel.IdObjetivoAnioFiscal = idObjetivoAnioFiscal;
            viewModel.NumeroObjetivo = objNumero;
            viewModel.PonderacionObjetivo = ponderacion;
            var response = await _mediator.Send(new GetPlanificacionResultadoByIdColabotadorQuery() { IdObjetivoAnioFiscal = idObjetivoAnioFiscal, IdColaborador = id });
            if (response.Succeeded)
            {
                entidad = _mapper.Map<List<PlanificacionResultadoResponse>>(response.Data);
            }
            viewModel.PlanificacionResultados= entidad;
            string pagina=objNumero=="4"?"_ViewAllObjetivoCompetencia":objNumero=="5" || objNumero == "6" || objNumero == "7" ? "_ViewAllObjetivoPregunta" :"_ViewAllObjetivoResultado";
            //entidad.NumContacto = formularioViewModel.FormularioTerceros.Where(x => x.Tipo == "C").Count();
            return PartialView(pagina, viewModel);
               

        }


        public async Task<ActionResult> EnviarMail( int idColaborador,int reportaA,int proceso,int idAnioFiscal)
        {
         
            string apellidos = "";
            string nombres = "";
            string mail = "";
            string apellidosReporta = "";
            string nombresReporta = "";
            string mailReporta = "";
            string anioFiscal = "";
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
                    apellidos = response.Data.Apellidos + " " + response.Data.ApellidoMaterno;
                    nombres = response.Data.PrimerNombre + " " + response.Data.SegundoNombre;
                    mail = response.Data.Email;
                }

                var responseReporta = await _mediator.Send(new GetColaboradorByIdQuery() { Id = reportaA });
                if (responseReporta.Succeeded)
                {
                    apellidosReporta = responseReporta.Data.Apellidos + " " + responseReporta.Data.ApellidoMaterno;
                    nombresReporta = responseReporta.Data.PrimerNombre + " " + responseReporta.Data.SegundoNombre;
                    mailReporta = responseReporta.Data.Email;
                }

                string plantilla = "";

                switch (proceso)
                {
                    case 1:
                        plantilla = "RevisionLider.html";
                     
                        break;
                    case 2:
                        plantilla = "AprovacionLider.html";
                        break;
                }


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
                        
                        break;
                    case 2:
                        subject = _configuration["AsuntoAprobacionLider"] + apellidos + " " + nombres;
                        plantilla = "AprovacionLider.html";
                        messageBody = string.Format(builder.HtmlBody,
                        anioFiscal,
                        apellidos + " " + nombres
                        );
                        mail = mailReporta;
                        break;
                }

                     
                PlanificacionResultadoViewModel entidad = new PlanificacionResultadoViewModel();
                entidad.Estado = 2;
                entidad.IdColaborador = idColaborador;
                var updateEntidadCommand = _mapper.Map<UpdatePlanificacionResultadoCommand>(entidad);
                var result = await _mediator.Send(updateEntidadCommand);


                //await _emailSender
                //    .SendEmailAsync(mail, subject, messageBody)
                //    .ConfigureAwait(false);
                _notify.Success($"Mail Enviado.");


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en enviar Mail.");
            }

            //   return new JsonResult(new { isValid = true });
            // return RedirectToPage("/Wizard/Index", new { area = "Registro" });
            return RedirectToPage("/Objetivo/Wizard/Index", new { area = "Valoracion" });
        }


    }
}
