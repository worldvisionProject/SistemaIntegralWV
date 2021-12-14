using Microsoft.AspNetCore.Authorization;
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
using WordVision.ec.Application.Features.Planificacion.MetaTacticas.Commands.Delete;
using WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetById;
using WordVision.ec.Application.Features.Soporte.Ponentes.Queries.GetAll;
using WordVision.ec.Application.Features.Soporte.Solicitudes.Commands.Create;
using WordVision.ec.Application.Features.Soporte.Solicitudes.Commands.Update;
using WordVision.ec.Application.Features.Soporte.Solicitudes.Queries.GetById;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Registro.Models;
using WordVision.ec.Web.Areas.Soporte.Models;

namespace WordVision.ec.Web.Areas.Soporte.Controllers
{
    [Area("Soporte")]
    [Authorize]
    public class ComunicacionController : BaseController<ComunicacionController>
    {
        public IActionResult Index(int id = 0)
        {
            var model = new SolicitudViewModel();
            model.IdAsignadoA = id;
            return View(model);
        }


        public async Task<IActionResult> LoadAll(int idSolicitante, int op = 0)
        {
            ViewBag.Op = op;
            switch (op)
            {
                case 1:
                    var response = await _mediator.Send(new GetSolicitudByIdSolicitanteQuery() { Id = idSolicitante, Tipo = 2 });
                    if (response.Succeeded)
                    {
                        var viewModel = _mapper.Map<List<SolicitudViewModel>>(response.Data);
                        return PartialView("_ViewAll", viewModel);
                    }
                    break;

                case 2:
                    response = await _mediator.Send(new GetSolicitudByIdEstadoQuery() { Id = 1, Tipo = 2 });
                    if (response.Succeeded)
                    {
                        var viewModel = _mapper.Map<List<SolicitudViewModel>>(response.Data);
                        //var cat2 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 19 });
                        //TempData["EstadoList"] = new SelectList(cat2.Data, "Secuencia", "Nombre");

                        return PartialView("_ViewAll", viewModel);
                    }
                    break;

                case 3:
                    response = await _mediator.Send(new GetSolicitudByIdAsignadoQuery() { Id = idSolicitante });
                    if (response.Succeeded)
                    {
                        var viewModel = _mapper.Map<List<SolicitudViewModel>>(response.Data);
                        //var cat2 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 19 });
                        //TempData["EstadoList"] = new SelectList(cat2.Data, "Secuencia", "Nombre");

                        return PartialView("_ViewAll", viewModel);
                    }
                    break;
            }


            return null;
        }
        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0, int op = 0)
        {

            if (id == 0)
            {
                var entidadViewModel = new SolicitudViewModel();
                entidadViewModel.Estado = 1;
                entidadViewModel.Op = op;
                entidadViewModel.CreatedOn = DateTime.Now;
               
                var cat2 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 19 });
                entidadViewModel.EstadoList = new SelectList(cat2.Data, "Secuencia", "Nombre");
                cat2 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 38 });
                entidadViewModel.TiposTramitesList = new SelectList(cat2.Data, "Secuencia", "Nombre");
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
            }
            else
            {
                var response = await _mediator.Send(new GetSolicitudByIdQuery() { Id = id });
                if (response.Succeeded)
                {
                    var entidadViewModel = _mapper.Map<SolicitudViewModel>(response.Data);
                    entidadViewModel.Op = op;
                    switch (op)
                    {
                        //case 1:
                        //    if (entidadViewModel.Estado==null)
                        //        entidadViewModel.Estado = 1;
                        //    break;
                        //case 2:
                        //    entidadViewModel.Estado = 2;


                        //    break;
                        case 3:
                            entidadViewModel.Estado = 3;
                            break;
                    }

                    var colaborador = await _mediator.Send(new GetColaboradorByIdAreaQuery() { Id = 6 });
                    if (colaborador.Succeeded)
                    {
                        var responsable = _mapper.Map<List<ColaboradorViewModel>>(colaborador.Data);
                        entidadViewModel.AsignadoAList = new SelectList(responsable, "Id", "Nombres");
                    }
                    var cat2 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 19 });
                    entidadViewModel.EstadoList = new SelectList(cat2.Data, "Secuencia", "Nombre");

                    cat2 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 38 });
                    entidadViewModel.TiposTramitesList = new SelectList(cat2.Data, "Secuencia", "Nombre");

                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
                return null;
            }
        }

        [HttpPost]  
        public async Task<JsonResult> OnPostCreateOrEdit(int id, SolicitudViewModel entidad)
        {
            try
            {
                var op = entidad.Op;
                if (ModelState.IsValid)
                {

                    if (Request.Form.Files.Count > 0)
                    {
                        for (int i = 0; i <= Request.Form.Files.Count - 1; i++)
                        {
                            IFormFile file = Request.Form.Files[i];
                            var image = file.OpenReadStream();

                            switch (Request.Form.Files[i].Name)
                            {

                                case "Comunicaciones.DisponibilidadPresupuestaria":
                                    MemoryStream ms = new();
                                    image.CopyTo(ms);
                                    entidad.Comunicaciones.DisponibilidadPresupuestaria = ms.ToArray();
                                    break;
                                case "Comunicaciones.DocumentoBase":
                                    MemoryStream msd = new();
                                    image.CopyTo(msd);
                                    entidad.Comunicaciones.DocumentoBase = msd.ToArray();
                                    break;
                                case "Comunicaciones.GuionEvento":
                                    MemoryStream msg = new();
                                    image.CopyTo(msg);
                                    entidad.Comunicaciones.GuionEvento = msg.ToArray();
                                    break;

                            }
                        }



                    }

                    if (id == 0)
                    {
                        entidad.Estado = 1;
                        entidad.TipoSistema = 2;
                        var createEntidadCommand = _mapper.Map<CreateSolicitudCommand>(entidad);
                        var result = await _mediator.Send(createEntidadCommand);
                        if (result.Succeeded)
                        {
                            id = result.Data;
                            _notify.Success($"Solicitud con ID {result.Data} Creado.");
                        }
                        else _notify.Error(result.Message);
                    }
                    else
                    {
                        entidad.Estado = entidad.Fin == 0 ? entidad.Op : entidad.Fin;
                        var updateEntidadCommand = _mapper.Map<UpdateSolicitudCommand>(entidad);
                        var result = await _mediator.Send(updateEntidadCommand);
                        if (result.Succeeded) _notify.Information($"Solicitud con ID {result.Data} Actualizado.");
                    }


                    ViewBag.Op = op;
                    switch (op)
                    {
                        case 1:
                            var response1 = await _mediator.Send(new GetSolicitudByIdSolicitanteQuery() { Id = entidad.IdColaborador, Tipo = 2 });
                            if (response1.Succeeded)
                            {
                                var viewModel = _mapper.Map<List<SolicitudViewModel>>(response1.Data);
                                //  var cat2 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 19 });
                                // ViewBag.EstadoList = new SelectList(cat2.Data, "Secuencia", "Nombre");
                                // TempData["EstadoList"] = new SelectList(cat2.Data, "Secuencia", "Nombre");

                                var html1 = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                                html1 = html1.Replace("&op=", "&op=1");
                                //await EnviarMail(id);

                                return new JsonResult(new { isValid = true, html = html1 });
                            }
                            break;

                        case 2:
                            response1 = await _mediator.Send(new GetSolicitudByIdEstadoQuery() { Id = 1 });
                            if (response1.Succeeded)
                            {
                                var viewModel = _mapper.Map<List<SolicitudViewModel>>(response1.Data);
                                //  var cat2 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 19 });
                                //   ViewBag.EstadoList = new SelectList(cat2.Data, "Secuencia", "Nombre");

                                var html1 = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                                html1 = html1.Replace("&op=", "&op=2");
                                //await EnviarMail(id);
                                return new JsonResult(new { isValid = true, html = html1 });
                            }
                            break;

                        case >= 3:
                            response1 = await _mediator.Send(new GetSolicitudByIdAsignadoQuery() { Id = entidad.IdColaborador });
                            if (response1.Succeeded)
                            {
                                var viewModel = _mapper.Map<List<SolicitudViewModel>>(response1.Data);
                                //  var cat2 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 19 });
                                //  ViewBag.EstadoList = new SelectList(cat2.Data, "Secuencia", "Nombre");

                                var html1 = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                                html1 = html1.Replace("&op=", "&op=2");

                                //await EnviarMail(id);

                                return new JsonResult(new { isValid = true, html = html1 });
                            }
                            break;
                    }

                    //var response = await _mediator.Send(new GetSolicitudByIdSolicitanteQuery() { Id = entidad.Solicitante });
                    //if (response.Succeeded)
                    //{
                    //    var viewModel = _mapper.Map<List<SolicitudViewModel>>(response.Data);

                    //    var html1 = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                    //    return new JsonResult(new { isValid = true, html = html1 });
                    //}
                    //else
                    //{
                    //    _notify.Error(response.Message);
                    //    return null;
                    //}


                }
                else
                {
                    var result = string.Join(',', ModelState.Values.SelectMany(v => v.Errors).Select(a => a.ErrorMessage));
                    _notify.Error("Error de datos. "+ result);
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


        public async Task<FileResult> ShowPDF(int idSolicitud, int tipo)
        {
            var responseC = await _mediator.Send(new GetSolicitudByIdQuery() { Id = idSolicitud });
            if (responseC.Succeeded)
            {
                var entidadViewModel = _mapper.Map<SolicitudViewModel>(responseC.Data);
                switch (tipo)
                {
                    case 1:
                        if (entidadViewModel.Comunicaciones.DisponibilidadPresupuestaria != null)
                        {
                            byte[] dataArray = entidadViewModel.Comunicaciones.DisponibilidadPresupuestaria;
                            return File(dataArray, "application/pdf");
                        }
                        break;
                    case 2:
                        if (entidadViewModel.Comunicaciones.AutorizaciondelLider != null)
                        {
                            byte[] dataArray = entidadViewModel.Comunicaciones.AutorizaciondelLider;
                            return File(dataArray, "application/pdf");
                        }
                        break;
                    case 4:
                        if (entidadViewModel.Comunicaciones.DocumentoBase != null)
                        {
                            byte[] dataArray = entidadViewModel.Comunicaciones.DocumentoBase;
                            return File(dataArray, "application/pdf");
                        }
                        break;
                    case 3:
                        if (entidadViewModel.Comunicaciones.GuionEvento != null)
                        {
                            byte[] dataArray = entidadViewModel.Comunicaciones.GuionEvento;
                            return File(dataArray, "application/pdf");
                        }
                        break;

                }


            }

            return null;
        }


        public async Task<ActionResult> EnviarMail(int idSoporte)
        {

            DateTime fechaRequerida = DateTime.Now;
            string descripcion = "";
            string mail = "";
            int estado = 0;
            int calificacion = 0;
            int idAsignado = 0;
            string asignado = "";

            try
            {
                var response = await _mediator.Send(new GetSolicitudByIdQuery() { Id = idSoporte });
                if (response.Succeeded)
                {
                    fechaRequerida = response.Data.Mensajerias.FechaRequerida.Value;
                    descripcion = response.Data.Mensajerias.DescripcionTramite;
                    mail = response.Data.Colaboradores.Email;
                    estado = response.Data.Estado;
                    asignado = response.Data.AsignadoA;
                    calificacion = response.Data.EstadoSatisfaccion;
                    idAsignado = response.Data.IdAsignadoA;
                }



                string plantilla = "";
                string asunto = "";
                switch (estado)
                {

                    case 1:
                        plantilla = "NuevaSolicitud.html";
                        asunto = _configuration["NuevaSolicitud"] + "#" + idSoporte;
                        break;
                    case 2:
                        plantilla = "AsignacionSolicitud.html";
                        asunto = _configuration["AsignacionSolicitud"] + "#" + idSoporte;
                        var responseC = await _mediator.Send(new GetColaboradorByIdQuery() { Id = idAsignado });
                        if (responseC.Succeeded)
                        {
                            mail = responseC.Data.Email;
                        }
                        break;
                    case 4:
                        plantilla = "ResolucionSolicitud.html";
                        asunto = _configuration["ResolucionSolicitud"] + "#" + idSoporte;
                        break;

                    case 5:
                        plantilla = "CalificacionSolicitud.html";
                        asunto = _configuration["CalificacionSolicitud"] + "#" + idSoporte;
                        break;

                }
                //Get TemplateFile located at wwwroot/Templates/EmailTemplate/Register_EmailTemplate.html  
                var pathToFile = _env.WebRootPath
                        + Path.DirectorySeparatorChar.ToString()
                        + "Templates"
                        + Path.DirectorySeparatorChar.ToString()
                        + "EmailTemplate"
                        + Path.DirectorySeparatorChar.ToString()
                        + plantilla;


                var builder = new BodyBuilder();
                using (StreamReader SourceReader = System.IO.File.OpenText(pathToFile))
                {
                    builder.HtmlBody = SourceReader.ReadToEnd();
                }


                string messageBody = string.Format(builder.HtmlBody,
                    idSoporte,
                    String.Format("{0:dddd, d MMMM yyyy}", fechaRequerida),
                    descripcion,
                    _configuration["linkSistema"],
                    asignado,
                    calificacion
                    );


                await _emailSender
                    .SendEmailAsync(mail, asunto, messageBody, _configuration["CopiaMensajeria"])
                    .ConfigureAwait(false);


                _notify.Success($"Mail Enviado.");


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en enviar Mail.");
            }

            //   return new JsonResult(new { isValid = true });
            // return RedirectToPage("/Wizard/Index", new { area = "Registro" });
            return null;
        }



        public async Task<IActionResult> LoadAllPonente(int idComunicacion)
        {
            try
            {

                var response = await _mediator.Send(new GetAllPonentesQuery() { IdComunicacion = idComunicacion });
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<PonenteViewModel>>(response.Data);
                    //var html = await _viewRenderer.RenderViewToStringAsync("_PonentesAll", viewModel);
                    //html = html.Replace("&idComunicacion=", "&idComunicacion="+ idComunicacion.ToString());
                    //return new JsonResult(new { isValid = true, html });

                    return PartialView("_PonentesAll", viewModel);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "LoadAllPonente");

            }
            return null;
        }


        public async Task<JsonResult> OnGetCreateOrEditPonente(int id = 0, int idComunicacion = 0)
        {
            try
            {
                if (id == 0)
                {
                    var entidadViewModel = new PonenteViewModel();
                    entidadViewModel.IdComunicacion = idComunicacion;
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEditPonente", entidadViewModel) });
                }
                else
                {
                    var response = await _mediator.Send(new GetPonenteByIdQuery() { Id = id });
                    if (response.Succeeded)
                    {
                        var entidadViewModel = _mapper.Map<PonenteViewModel>(response.Data);


                        return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEditPonente", entidadViewModel) });
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "OnGetCreateOrEditPonente");

            }
            return null;
        }


        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEditPonente(int id, PonenteViewModel entidad)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //if (id == 0)
                    //{
                    //    var createEntidadCommand = _mapper.Map<CreatePonenteCommand>(entidad);
                    //    var result = await _mediator.Send(createEntidadCommand);
                    //    if (result.Succeeded)
                    //    {
                    //        id = result.Data;

                    //        _notify.Success($"Ponente con ID {result.Data} Creado.");
                    //    }
                    //    else _notify.Error(result.Message);
                    //}
                    //else
                    //{
                    //    var updateEntidadCommand = _mapper.Map<UpdatePonenteCommand>(entidad);
                    //    var result = await _mediator.Send(updateEntidadCommand);
                    //    if (result.Succeeded) _notify.Information($"Ponente con ID {result.Data} Actualizado.");
                    //}
                    var viewModel = new List<PonenteViewModel>();
                    viewModel.Add(entidad);

                    return new JsonResult(new { isValid = true, opcion = 103, page = "#viewAllPonente", html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEditPonente", viewModel) });
                }
                else
                {
                    var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEditPonente", entidad);
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

        public async Task<JsonResult> OnPostDelete(int id = 0,int idColaborador=0)
        {
            var deleteCommand = await _mediator.Send(new DeleteSolicitudCommand { Id = id });
            if (deleteCommand.Succeeded)
            {
                _notify.Information($"Solicitud con Id {id} Eliminado.");
               
                var response1 = await _mediator.Send(new GetSolicitudByIdSolicitanteQuery() { Id = idColaborador, Tipo = 2 });
                if (response1.Succeeded)
                {
                    var viewModel = _mapper.Map<List<SolicitudViewModel>>(response1.Data);
                    var html1 = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                    html1 = html1.Replace("&op=", "&op=1");
                    return new JsonResult(new { isValid = true, html = html1 });
                }
                else
                    return new JsonResult(new { isValid = true });

            }
            else
            {
                _notify.Error(deleteCommand.Message);
                return null;
            }
        }


    }
}
