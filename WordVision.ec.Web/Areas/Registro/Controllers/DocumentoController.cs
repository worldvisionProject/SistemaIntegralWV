using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Registro.Documentos.Commands.Create;
using WordVision.ec.Application.Features.Registro.Documentos.Commands.Update;
using WordVision.ec.Application.Features.Registro.Documentos.Queries.GetAllCached;
using WordVision.ec.Application.Features.Registro.Documentos.Queries.GetById;
using WordVision.ec.Application.Features.Registro.Firma.Commands.Create;
using WordVision.ec.Application.Features.Registro.Firma.Queries.GetById;
using WordVision.ec.Application.Features.Registro.Pregunta.Queries.GetAllCached;
using WordVision.ec.Application.Features.Registro.Pregunta.Queries.GetById;
using WordVision.ec.Application.Features.Registro.Respuestas.Commands.Create;
using WordVision.ec.Application.Features.Registro.Respuestas.Commands.Update;
using WordVision.ec.Application.Features.Registro.Respuestas.Queries.GetById;
using WordVision.ec.Application.Interfaces.Shared;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Registro.Models;
using WordVision.ec.Web.Extensions;
using WordVision.ec.Infrastructure.Shared.Pdf;
using System.Net.Mail;
using SelectPdf;
using WordVision.ec.Application.Features.Registro.Formularios.Queries.GetById;
using WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetById;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using WordVision.ec.Application.Features.Registro.Terceros.Queries.GetById;

namespace WordVision.ec.Web.Areas.Registro.Controllers
{


    [Area("Registro")]
    [Authorize]
    public class DocumentoController : BaseController<DocumentoController>
    {
     //   private readonly FormularioController _myControllerIwantToInject;

     //public DocumentoController(FormularioController myControllerIwantToInject)
     //   {
     //       _myControllerIwantToInject = myControllerIwantToInject;
     //   }
        public IActionResult Index(int id = 0, string ventana = "N")
        {
            var model = new DocumentoViewModel();
            model.Id = id;
            model.Ventana = ventana;

            return View(model);

        }

        public async Task<JsonResult> IndexPopPup(int id = 0, string ventana = "S")
        {
            //var model = new DocumentoViewModel();
            //model.Id = id;
            //model.Ventana = ventana;

            //return View(model);


            try
            {
                //var preguntaResponse = await _mediator.Send(new GetPreguntasByIdDocumentoQuery() { Id = Convert.ToInt32(id.Split('|')[0]) });


                var response = await _mediator.Send(new GetDocumentoByIdQuery() { Id = id });
                if (response.Succeeded)
                {
                    var documentoViewModel = _mapper.Map<DocumentoViewModel>(response.Data);

                    List<RespuestaViewModel> lr = new List<RespuestaViewModel>();
                    foreach (var respu in documentoViewModel.Preguntas)
                    {
                        RespuestaViewModel r = new RespuestaViewModel();
                        var responseResp = await _mediator.Send(new GetByIdColaboradorQuery() { IdColaorador = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value), IdDocumento = id, IdPregunta = respu.Id });
                        if (response.Succeeded)
                        {
                            if (responseResp.Data != null)
                            {
                                r.DescRespuesta = responseResp.Data.DescRespuesta;
                                r.IdPregunta = respu.Id;
                            }
                        }
                        lr.Add(r);
                    }
                    documentoViewModel.Respuestas = lr;

                    var responseFirma = await _mediator.Send(new GetFirmaByIdQuery() { IdColaborador = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value), IdDocumento = id });
                    if (responseFirma.Succeeded)
                    {
                        if (responseFirma.Data != null)
                        {
                            documentoViewModel.Image = responseFirma.Data.Image;
                         }
                    }

                    var responseCola = await _mediator.Send(new GetColaboradorByIdQuery() { Id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value) });
                    if (responseCola.Succeeded)
                    {
                        documentoViewModel.Colaborador = responseCola.Data.Apellidos + " " + responseCola.Data.ApellidoMaterno+" "+responseCola.Data.PrimerNombre + " " + responseCola.Data.SegundoNombre;
                        documentoViewModel.Identificacion = responseCola.Data.Identificacion;
                       
                    }

                   

                    //if (preguntaResponse.Succeeded)
                    //{
                    //    var preguntaViewModel = _mapper.Map<List<PreguntaViewModel>>(preguntaResponse.Data);
                    //    documentoViewModel.Preguntas = preguntaViewModel;
                    //}

                    var response1 = await _mediator.Send(new GetCountByIdColaboradorQuery() { IdColaorador = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value), IdDocumento = id });
                    if (response1.Succeeded)
                    {
                        int existe = 0;
                        if (response1 != null)
                            existe = response1.Data;

                        if (existe != 0)
                            _notify.Success($"Ya se ingreso datos en este formulario.");

                    }


                    if (id == 7 || id == 10)
                        return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_SolicitudAcumulacion", documentoViewModel) });
                    else
                        return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", documentoViewModel) });

                    // 
                    // return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", documentoViewModel) });
                }
            }
            catch (Exception EX)
            {
                _notify.Error($"Respuesta con con error.");
                _logger.LogError(EX, $"Respuesta con con error.");
            }

            return null;

        }


        [HttpGet]
        public async Task<IActionResult> LoadDocumento(string id = "", string idColaborador = "")
        {
            try
            {
                //var preguntaResponse = await _mediator.Send(new GetPreguntasByIdDocumentoQuery() { Id = Convert.ToInt32(id.Split('|')[0]) });


                var response = await _mediator.Send(new GetDocumentoByIdQuery() { Id = Convert.ToInt32(id.Split('|')[0]) });
                if (response.Succeeded)
                {
                    var documentoViewModel = _mapper.Map<DocumentoViewModel>(response.Data);

                    List<RespuestaViewModel> lr = new List<RespuestaViewModel>();
                    foreach (var respu in documentoViewModel.Preguntas)
                    {
                        RespuestaViewModel r = new RespuestaViewModel();
                        var responseResp = await _mediator.Send(new GetByIdColaboradorQuery() { IdColaorador = Convert.ToInt32(id.Split('|')[1]), IdDocumento = Convert.ToInt32(id.Split('|')[0]), IdPregunta = respu.Id });
                        if (response.Succeeded)
                        {
                            if (responseResp.Data != null)
                            {
                                r.DescRespuesta = responseResp.Data.DescRespuesta;
                                r.IdPregunta = respu.Id;
                            }
                        }
                        lr.Add(r);
                    }
                    documentoViewModel.Respuestas = lr;

                    var responseFirma = await _mediator.Send(new GetFirmaByIdQuery() { IdColaborador = Convert.ToInt32(id.Split('|')[1]), IdDocumento = Convert.ToInt32(id.Split('|')[0]) });
                    if (responseFirma.Succeeded)
                    {
                        if (responseFirma.Data != null)
                        {
                            documentoViewModel.Image = responseFirma.Data.Image;
                         }
                    }
                    var responseCola = await _mediator.Send(new GetColaboradorByIdQuery() { Id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value) });
                    if (responseCola.Succeeded)
                    {
                        documentoViewModel.Colaborador = responseCola.Data.Apellidos + " " + responseCola.Data.ApellidoMaterno + " " + responseCola.Data.PrimerNombre + " " + responseCola.Data.SegundoNombre;
                        documentoViewModel.Identificacion = responseCola.Data.Identificacion;
                       
                    }
                    //if (preguntaResponse.Succeeded)
                    //{
                    //    var preguntaViewModel = _mapper.Map<List<PreguntaViewModel>>(preguntaResponse.Data);
                    //    documentoViewModel.Preguntas = preguntaViewModel;
                    //}

                    var response1 = await _mediator.Send(new GetCountByIdColaboradorQuery() { IdColaorador = Convert.ToInt32(id.Split('|')[1]), IdDocumento = Convert.ToInt32(id.Split('|')[0]) });
                    if (response1.Succeeded)
                    {
                        int existe = 0;
                        if (response1 != null)
                            existe = response1.Data;

                        if (existe != 0)
                            _notify.Success($"Ya se ingreso datos en este formulario.");

                    }

                    if (idColaborador == "N")
                        if (Convert.ToInt32(id.Split('|')[0]) == 7 || Convert.ToInt32(id.Split('|')[0]) == 10)
                            return PartialView("_SolicitudAcumulacion", documentoViewModel);
                        else
                            return PartialView("_ViewAll", documentoViewModel);
                    else
                        return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", documentoViewModel) });
                    // 
                    // return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", documentoViewModel) });
                }
            }
            catch (Exception EX)
            {
                _notify.Error($"Respuesta con con error.");
                _logger.LogError(EX,$"Respuesta con con error.");
            }

            return null;

        }

        public async Task<JsonResult> ExisteDocumento(int idColaborador, int idDocumento)
        {
            var response = await _mediator.Send(new GetCountByIdColaboradorQuery() { IdColaorador = idColaborador, IdDocumento = idDocumento });
            if (response.Succeeded)
            {
                int existe = 0;
                if (response != null)
                    existe = response.Data;

                if (existe != 0)
                    _notify.Success($"Ya se ingreso datos en este formulario.");
                return new JsonResult(new { isValid = true });
            }
            return null;

        }


        public IActionResult Documento(int id = 0)
        {
            var model = new DocumentoViewModel();
            return View(model);

        }
        public async Task<IActionResult> LoadAll()
        {
            var response = await _mediator.Send(new GetAllDocumentosCachedQuery());
            if (response.Succeeded)
            {
                var viewModel = _mapper.Map<List<DocumentoViewModel>>(response.Data);
                return PartialView("_ViewAllDocumentos", viewModel);
            }
            return null;
        }


        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0)
        {
            if (id == 0)
            {
                var documentoViewModel = new DocumentoViewModel();
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", documentoViewModel) });
            }
            else
            {
                var response = await _mediator.Send(new GetDocumentoByIdQuery() { Id = id });
                if (response.Succeeded)
                {
                    var documentoViewModel = _mapper.Map<DocumentoViewModel>(response.Data);
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", documentoViewModel) });
                }
                return null;
            }
        }

        public async Task<JsonResult> OnGetCreateOrEditPregunta(int idPregunta = 0)
        {
            if (idPregunta == 0)
            {
                var documentoViewModel = new PreguntaViewModel();
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEditPregunta", documentoViewModel) });
            }
            else
            {
                var response = await _mediator.Send(new GetPreguntaByIdQuery() { Id = idPregunta });
                if (response.Succeeded)
                {
                    var documentoViewModel = _mapper.Map<DocumentoViewModel>(response.Data);
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEditPregunta", documentoViewModel) });
                }
                return null;
            }
        }

        public async Task<JsonResult> OnPostDeletePregunta(int id = 0)
        {
            var deleteCommand = await _mediator.Send(new UpdateDocumentoCommand { Id = id });
            if (deleteCommand.Succeeded)
            {
                _notify.Information($"Pregunta con Id {id} Eliminado.");
                var response = await _mediator.Send(new GetPreguntaByIdQuery() { Id = id });
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<PreguntaViewModel>(response.Data);
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
                _notify.Error(deleteCommand.Message);
                return null;
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEditar(int id, DocumentoViewModel documento)
        {
            if (ModelState.IsValid)
            {

                if (id == 0)
                {
                    var createDocumentoCommand = _mapper.Map<CreateDocumentoCommand>(documento);
                    var result = await _mediator.Send(createDocumentoCommand);
                    if (result.Succeeded)
                    {
                        id = result.Data;
                        _notify.Success($"Documento con ID {result.Data} creado.");
                    }
                    else _notify.Error(result.Message);
                }
                else
                {
                    var updateDocumentoCommand = _mapper.Map<UpdateDocumentoCommand>(documento);
                    var result = await _mediator.Send(updateDocumentoCommand);
                    if (result.Succeeded) _notify.Information($"Documento con ID {result.Data} actualizado.");
                    else _notify.Error(result.Message);
                }

                var response = await _mediator.Send(new GetAllDocumentosCachedQuery());
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<DocumentoViewModel>>(response.Data);
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
                var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", documento);
                return new JsonResult(new { isValid = false, html = html });
            }
        }


        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(int idColaborador, DocumentoViewModel documento, PreguntaViewModel[] preguntas, string poppup = "N")
        {
            //if (ModelState.IsValid)
            //{
            //if (documento.Titulo == null)
            //{
            //    _notify.Error("Ingrese una firma antes de guardar.");
            //    return new JsonResult(new { isValid = true });
            //}

                int i = 0, idDocumento = 0;
                idDocumento = documento.Id;
                foreach (var c in preguntas)
                {
                    RespuestaViewModel respuesta = new RespuestaViewModel();
                    respuesta.IdColaborador = idColaborador;
                    respuesta.IdDocumento = c.IdDocumento;
                    respuesta.IdPregunta = c.Id;
                    respuesta.DescRespuesta = c.Estado == null ? c.DescripcionUrl1 + "|" + c.DescripcionUrl2 : c.Estado;
                    if (c.Id == 29 && c.IdDocumento == 5)
                        respuesta.DescRespuesta = documento.Estado??"";
                    idDocumento = c.IdDocumento;
                    try
                    {
                        var response1 = await _mediator.Send(new GetByIdColaboradorQuery() { IdColaorador = idColaborador, IdDocumento = c.IdDocumento, IdPregunta = c.Id });
                        if (response1.Succeeded)
                        {

                            if (response1.Data != null)
                            {
                                var updateBrandCommand = _mapper.Map<UpdateRespuestaCommand>(respuesta);
                                var result = await _mediator.Send(updateBrandCommand);
                                if (result.Succeeded)
                                {

                                    i++;
                                }
                                else _notify.Error(result.Message);
                            }
                            else
                            {
                                var createBrandCommand = _mapper.Map<CreateRespuestaCommand>(respuesta);
                                var result = await _mediator.Send(createBrandCommand);
                                if (result.Succeeded)
                                {

                                    i++;
                                }
                                else _notify.Error(result.Message);
                            }

                        }


                    }
                    catch (Exception EX)
                    {
                        _notify.Error($"Respuesta con con error.");
                    _logger.LogError(EX, $"Respuesta con con error.");
                }

                }


                if (Request.Form.Files.Count > 0)
                {
                    IFormFile file = Request.Form.Files.FirstOrDefault();
                    var image = file.OptimizeImageSize(700, 700);
                    // await _mediator.Send(new UpdateProductImageCommand() { Id = id, Image = image });

                    FirmaViewModel firma = new FirmaViewModel();
                    firma.IdColaborador = idColaborador;
                    firma.IdDocumento = idDocumento;
                    firma.Image = image;

                    var createFirmaCommand = _mapper.Map<CreateFirmaCommand>(firma);
                    var resultFirma = await _mediator.Send(createFirmaCommand);
                    if (resultFirma.Succeeded)
                    {

                        i++;
                    }
                    else _notify.Error(resultFirma.Message);

                }

                _notify.Success($"{i} Respuesta almacenadas.");

                //if (poppup == "N")
                //{
                if (idDocumento == 10)
                {
                    await EnviarMail(idDocumento, idColaborador);
                    await EnviarMail(-1, idColaborador);
                }
                else
                    await EnviarMail(idDocumento, idColaborador);

                //}

            //}
            return new JsonResult(new { isValid = true });
           
        }

        public async Task<IActionResult> DescargaDocumento(string id = "", string idColaborador = "", string nombreFormulario = "")
        {
            //string param1 = "";
            //FormularioAdjunto adjunto = new FormularioAdjunto();
            string param1 = id + "|" + idColaborador;
            FormularioAdjunto adjunto = await LoadDocumentoAdjuntar(param1, "N");
            return new ViewAsPdf(adjunto.Vista, (DocumentoViewModel)adjunto.Modelo)
            {
                FileName = id.ToString() + "_" + nombreFormulario + ".pdf",
                PageOrientation = WordVision.ec.Infrastructure.Shared.Pdf.Options.Orientation.Portrait,
                PageSize = Infrastructure.Shared.Pdf.Options.Size.A4
            };

        }

        public async Task<FileResult> ShowPDF(int idColaborador,int tipo)
        {
            var responseC = await _mediator.Send(new GetFormularioByIdQuery() { Id = idColaborador });
            if (responseC.Succeeded)
            {
                var formularioViewModel = _mapper.Map<FormularioViewModel>(responseC.Data);
                switch (tipo)
                {
                    case 1:
                        if (formularioViewModel.ImageCedula != null)
                        {
                            byte[] dataArray = formularioViewModel.ImageCedula;
                            return File(dataArray, "application/pdf");
                        }
                        break;
                    case 2:
                        if (formularioViewModel.ImagePapeleta != null)
                        {
                            byte[] dataArray = formularioViewModel.ImagePapeleta;
                            return File(dataArray, "application/pdf");
                        }
                        break;
                    case 3:
                        if (formularioViewModel.ImageCovid != null)
                        {
                            byte[] dataArray = formularioViewModel.ImageCovid;
                            return File(dataArray, "application/pdf");
                        }
                        break;
                    case 4:
                        if (formularioViewModel.ImageDiscapacidad != null)
                        {
                            byte[] dataArray = formularioViewModel.ImageDiscapacidad;
                            return File(dataArray, "application/pdf");
                        }
                        break;
                    case 5:
                        if (formularioViewModel.ImageDiscapacidadFamiliar != null)
                        {
                            byte[] dataArray = formularioViewModel.ImageDiscapacidadFamiliar;
                            return File(dataArray, "application/pdf");
                        }
                        break;
                }
                

            }

            return null;
        }

        public async Task<FileResult> ShowPDFTercero(int idTercero)
        {
            var responseC = await _mediator.Send(new GetTerceroByIdFormularioQuery() { Id = idTercero });
            if (responseC.Succeeded)
            {
                var formularioViewModel = _mapper.Map<TerceroViewModel>(responseC.Data);
               
                        if (formularioViewModel.ImageCedula != null)
                        {
                            byte[] dataArray = formularioViewModel.ImageCedula;
                            return File(dataArray, "application/pdf");
                        }
                       

            }

            return null;
        }
        public async Task<FormularioAdjunto> LoadDocumentoAdjuntar(string id = "", string idColaborador = "")
        {
            FormularioAdjunto salida = new FormularioAdjunto();
            try
            {

                var response = await _mediator.Send(new GetDocumentoByIdQuery() { Id = Convert.ToInt32(id.Split('|')[0]) });
                if (response.Succeeded)
                {
                    var documentoViewModel = _mapper.Map<DocumentoViewModel>(response.Data);

                    List<RespuestaViewModel> lr = new List<RespuestaViewModel>();
                    foreach (var respu in documentoViewModel.Preguntas)
                    {
                        RespuestaViewModel r = new RespuestaViewModel();
                        var responseResp = await _mediator.Send(new GetByIdColaboradorQuery() { IdColaorador = Convert.ToInt32(id.Split('|')[1]), IdDocumento = Convert.ToInt32(id.Split('|')[0]), IdPregunta = respu.Id });
                        if (response.Succeeded)
                        {
                            if (responseResp.Data != null)
                            {
                                r.DescRespuesta = responseResp.Data.DescRespuesta;
                                r.IdPregunta = respu.Id;
                            }
                        }
                        lr.Add(r);
                    }
                    documentoViewModel.Respuestas = lr;

                    var responseFirma = await _mediator.Send(new GetFirmaByIdQuery() { IdColaborador = Convert.ToInt32(id.Split('|')[1]), IdDocumento = Convert.ToInt32(id.Split('|')[0]) });
                    if (responseFirma.Succeeded)
                    {
                        if (responseFirma.Data != null)
                        {
                            documentoViewModel.Image = responseFirma.Data.Image;
                            documentoViewModel.CreatedOn = responseFirma.Data.CreatedOn;
                            documentoViewModel.LastModifiedOn = responseFirma.Data.LastModifiedOn;
                        }
                    }

                    var responseCola = await _mediator.Send(new GetColaboradorByIdQuery() { Id = Convert.ToInt32(id.Split('|')[1]) });
                    if (responseCola.Succeeded)
                    {
                        documentoViewModel.Colaborador = responseCola.Data.Apellidos + " " + responseCola.Data.ApellidoMaterno + " " + responseCola.Data.PrimerNombre + " " + responseCola.Data.SegundoNombre;
                        documentoViewModel.Identificacion = responseCola.Data.Identificacion;
                        
                    }
                   
                    //var response1 = await _mediator.Send(new GetCountByIdColaboradorQuery() { IdColaorador = Convert.ToInt32(id.Split('|')[1]), IdDocumento = Convert.ToInt32(id.Split('|')[0]) });
                    //if (response1.Succeeded)
                    //{
                    //    int existe = 0;
                    //    if (response1 != null)
                    //        existe = response1.Data;

                    //    if (existe != 0)
                    //        _notify.Success($"Ya se ingreso datos en este formulario.");

                    //}

                    if (idColaborador == "N")
                        if (Convert.ToInt32(id.Split('|')[0]) == 7 || Convert.ToInt32(id.Split('|')[0]) == 10)
                        {
                            salida.Vista = "_RptSolicitudAcumulacion";
                            salida.Modelo = documentoViewModel;
                        }

                        else
                        {
                            salida.Vista = "_RptDocumentos";
                            salida.Modelo = documentoViewModel;
                        }

                    //else
                    //    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", documentoViewModel) });

                }
                return salida;
            }
            catch (Exception EX)
            {
                _notify.Error($"Respuesta con con error.");
                _logger.LogError(EX, $"Respuesta con con error.");
            }

            return salida;

        }


        public async Task<JsonResult> EnviarMail(int idDocumento, int idColaborador)
        {
            List<Attachment> attachments = new List<Attachment>();
            string param1 = "";
            FormularioAdjunto adjunto = new FormularioAdjunto();
            var actionPDF = new ViewAsPdf().BuildFile(this.ControllerContext); ;
            Stream stream = new MemoryStream();
            Attachment attachment;
            string apellidos = "";
            string nombres = "";
            string mail = "";
            try
            {
                var response = await _mediator.Send(new GetColaboradorByIdQuery() { Id = idColaborador });
                if (response.Succeeded)
                {
                    apellidos= response.Data.Apellidos+" "+response.Data.ApellidoMaterno;
                    nombres = response.Data.PrimerNombre + " " + response.Data.SegundoNombre;
                    mail = response.Data.Email;
                }

               
                string plantilla = "";
                string asunto = "";
                switch (idDocumento) {

                    case 3:
                        plantilla = "DocumentosPersonales.html";
                        asunto = "AsuntoDocumentosClaves";



                        param1 = "3|" + User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value;
                        adjunto = await LoadDocumentoAdjuntar(param1, "N");
                        actionPDF = new ViewAsPdf(adjunto.Vista, (DocumentoViewModel)adjunto.Modelo)
                        {
                            PageOrientation = WordVision.ec.Infrastructure.Shared.Pdf.Options.Orientation.Portrait,
                            PageSize = Infrastructure.Shared.Pdf.Options.Size.A4
                        }.BuildFile(this.ControllerContext);
                        stream = new MemoryStream(actionPDF.Result);
                        attachment = new Attachment(stream, apellidos + nombres + "_DocumentosClaves.pdf");
                        attachments.Add(attachment);

                       

                        var responseC = await _mediator.Send(new GetFormularioByIdQuery() { Id = idColaborador });
                        if (response.Succeeded)
                        {
                            var formularioViewModel = _mapper.Map<FormularioViewModel>(responseC.Data);
                            if (formularioViewModel.Pdf!=null)
                            {
                                stream = new MemoryStream(formularioViewModel.Pdf);
                                attachment = new Attachment(stream, apellidos + nombres + "_DatosPersonales.pdf");
                                attachments.Add(attachment);
                            }
 
                        }



                        param1 = "7|" + User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value;
                        adjunto = await LoadDocumentoAdjuntar(param1, "N");
                        actionPDF = new ViewAsPdf(adjunto.Vista, (DocumentoViewModel)adjunto.Modelo)
                        {
                            PageOrientation = WordVision.ec.Infrastructure.Shared.Pdf.Options.Orientation.Portrait,
                            PageSize = Infrastructure.Shared.Pdf.Options.Size.A4
                            // Establece la Cabecera y el Pie de página
                            // CustomSwitches = "--page-offset 0 --footer-center [page] --footer-font-size 12"
                        }.BuildFile(this.ControllerContext);
                      
                        stream = new MemoryStream(actionPDF.Result);
                        // = new Attachment(stream, "xxx.pdf");
                        attachment = new Attachment(stream, apellidos + nombres + "_AcumulacionDecimosTercero.pdf");
                        attachments.Add(attachment);


                        param1 = "10|" + User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value;
                        adjunto = await LoadDocumentoAdjuntar(param1, "N");
                        actionPDF = new ViewAsPdf(adjunto.Vista, (DocumentoViewModel)adjunto.Modelo)
                        {
                            PageOrientation = WordVision.ec.Infrastructure.Shared.Pdf.Options.Orientation.Portrait,
                            PageSize = Infrastructure.Shared.Pdf.Options.Size.A4
                        }.BuildFile(this.ControllerContext);
                        stream = new MemoryStream(actionPDF.Result);
                        attachment = new Attachment(stream, apellidos + nombres + "_PlanSeguroMedico.pdf");
                        attachments.Add(attachment);
                        break;

                    case 4:
                        plantilla = "FormularioPoliticas.html";
                        asunto = "AsuntoFormularioPoliticas";

                        param1 = "4|" + User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value;
                        adjunto = await LoadDocumentoAdjuntar(param1, "N");
                        actionPDF = new ViewAsPdf(adjunto.Vista, (DocumentoViewModel)adjunto.Modelo)
                        {
                            PageOrientation = WordVision.ec.Infrastructure.Shared.Pdf.Options.Orientation.Portrait,
                            PageSize = Infrastructure.Shared.Pdf.Options.Size.A4
                        }.BuildFile(this.ControllerContext);

                        stream = new MemoryStream(actionPDF.Result);
                        attachment = new Attachment(stream, apellidos + nombres + "_FormularioPoliticas.pdf");
                        attachments.Add(attachment);

                        param1 = "5|" + User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value;
                        adjunto = await LoadDocumentoAdjuntar(param1, "N");
                        actionPDF = new ViewAsPdf(adjunto.Vista, (DocumentoViewModel)adjunto.Modelo)
                        {
                            PageOrientation = WordVision.ec.Infrastructure.Shared.Pdf.Options.Orientation.Portrait,
                            PageSize = Infrastructure.Shared.Pdf.Options.Size.A4
                        }.BuildFile(this.ControllerContext);

                        stream = new MemoryStream(actionPDF.Result);
                        attachment = new Attachment(stream, apellidos + nombres + "_DeclaracionConflicto.pdf");
                        attachments.Add(attachment);
                        break;
                    case 0:
                        plantilla = "DatosPersonales.html";
                        asunto = "AsuntoDatosPersonales";
                        break;
                    case -1:
                        plantilla = "CapacitacionSeguroPrivado.html";
                        asunto = "AsuntoCapacitacionSeguroPrivado";

                        //var byteArrayData = System.IO.File.ReadAllBytes(Path.Combine(_env.WebRootPath, @"Templates\EmailTemplate\adjunto", "CAPACITACIONSEGURO.pdf"));
                        //stream = new MemoryStream(byteArrayData);
                        //attachment = new Attachment(stream, "CapacitacionSeguroPrivado.pdf");
                        //attachments.Add(attachment);

                        break;
                    case 7:
                        plantilla = "AcumulacionDecimo.html";
                        asunto = "AsuntoAcumulacionDecimo";

                        param1 = "7|" + User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value;
                        adjunto = await LoadDocumentoAdjuntar(param1, "N");
                        actionPDF = new ViewAsPdf(adjunto.Vista, (DocumentoViewModel)adjunto.Modelo)
                        {
                            PageOrientation = WordVision.ec.Infrastructure.Shared.Pdf.Options.Orientation.Portrait,
                            PageSize = Infrastructure.Shared.Pdf.Options.Size.A4
                        }.BuildFile(this.ControllerContext);

                        stream = new MemoryStream(actionPDF.Result);
                        attachment = new Attachment(stream, apellidos + nombres + "_AcumulacionDecimo.pdf");
                        attachments.Add(attachment);
                       
                        break;
                    case 5:
                        plantilla = "DeclaracionConflicto.html";
                        asunto = "AsuntoDeclaracionConflicto";
                       
                        param1 = "5|" + User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value;
                        adjunto = await LoadDocumentoAdjuntar(param1, "N");
                        actionPDF = new ViewAsPdf(adjunto.Vista, (DocumentoViewModel)adjunto.Modelo)
                        {
                            PageOrientation = WordVision.ec.Infrastructure.Shared.Pdf.Options.Orientation.Portrait,
                            PageSize = Infrastructure.Shared.Pdf.Options.Size.A4
                        }.BuildFile(this.ControllerContext);

                        stream = new MemoryStream(actionPDF.Result);
                        attachment = new Attachment(stream, apellidos + nombres + "_DeclaracionConflicto.pdf");
                        attachments.Add(attachment);
                        break;
                    case 10:
                        plantilla = "SeguroPrivado.html";
                        asunto = "AsuntoSeguroPrivado";

                        param1 = "10|" + User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value;
                        adjunto = await LoadDocumentoAdjuntar(param1, "N");
                        actionPDF = new ViewAsPdf(adjunto.Vista, (DocumentoViewModel)adjunto.Modelo)
                        {
                            PageOrientation = WordVision.ec.Infrastructure.Shared.Pdf.Options.Orientation.Portrait,
                            PageSize = Infrastructure.Shared.Pdf.Options.Size.A4
                        }.BuildFile(this.ControllerContext);

                        stream = new MemoryStream(actionPDF.Result);
                        attachment = new Attachment(stream, apellidos + nombres + "_SeguroPrivado.pdf");
                        attachments.Add(attachment);
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

                var subject = _configuration[asunto] + apellidos+" "+nombres;

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

                string messageBody = string.Format(builder.HtmlBody,
                    apellidos+" "+nombres,
                    apellidos + " " + nombres,
                    String.Format("{0:dddd, d MMMM yyyy}", DateTime.Now)
                    //User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value,
                    //User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value,
                    //"",
                    //"Mensaje",
                    //null
                    );


                await _emailSender
                    .SendEmailAsync(mail, subject, messageBody, attachments)
                    .ConfigureAwait(false);


                _notify.Success($"Mail Enviado.");


            }
            catch (Exception ex)
            {
              
                _notify.Success($"Error al Enviar el Mail.");
                _logger.LogError(ex, $"Error al Enviar el Mail.");
                return new JsonResult(new { isValid = false });
            }

            return new JsonResult(new { isValid = true });
        }

    }
}
