using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;

using WordVision.ec.Application.Features.Registro.Colaboradores.Commands.Update;
using WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetById;
using WordVision.ec.Application.Features.Registro.Documentos.Queries.GetById;
using WordVision.ec.Application.Features.Registro.Formularios.Commands.Create;
using WordVision.ec.Application.Features.Registro.Formularios.Commands.Update;
using WordVision.ec.Application.Features.Registro.Formularios.Queries.GetById;
using WordVision.ec.Application.Features.Registro.Pregunta.Queries.GetAllCached;
using WordVision.ec.Application.Features.Registro.Pregunta.Queries.GetById;
using WordVision.ec.Application.Features.Registro.Terceros.Commands.Create;
using WordVision.ec.Application.Features.Registro.Terceros.Commands.Delete;
using WordVision.ec.Application.Features.Registro.Terceros.Commands.Update;
using WordVision.ec.Application.Features.Registro.Terceros.Queries.GetById;
using WordVision.ec.Infrastructure.Shared.Pdf;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Identity.Models;
using WordVision.ec.Web.Areas.Registro.Models;
using WordVision.ec.Web.Extensions;

namespace WordVision.ec.Web.Areas.Registro.Controllers
{
    [Area("Registro")]
    [Authorize]
    public class FormularioController : BaseController<FormularioController>
    {
       
        public IActionResult Index()
        {
            var model = new FormularioViewModel();
            return View(model);

        }

        public IActionResult FormularioWizard()
        {
            var model = new FormularioViewModel();
            return View(model);

        }

        public async Task<IActionResult> LoadFormularioWizard(int id = 0)
        {
            //var formualrioViewModel = new FormularioViewModel();
            //return PartialView("_ViewAll", formualrioViewModel);

            var response = await _mediator.Send(new GetFormularioByIdQuery() { Id = id });
            if (response.Succeeded)
            {
                var formularioViewModel = _mapper.Map<FormularioViewModel>(response.Data);
                if (formularioViewModel == null)
                {
                    formularioViewModel = new FormularioViewModel();
                    formularioViewModel.Id = 0;
                }

                formularioViewModel.IdColaborador = id;
                return PartialView("Wizard/Index");//, formularioViewModel);
                // return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", documentoViewModel) });
            }
            return null;

        }

        // [Route("Formulario/LoadFormulario/{idColaborador}")]
        public async Task<IActionResult> LoadFormulario(int id = 0)
        {
            //var formualrioViewModel = new FormularioViewModel();
            //return PartialView("_ViewAll", formualrioViewModel);

            var response = await _mediator.Send(new GetFormularioByIdQuery() { Id = id });
            if (response.Succeeded)
            {
                var formularioViewModel = _mapper.Map<FormularioViewModel>(response.Data);
                if (formularioViewModel == null)
                {
                    formularioViewModel = new FormularioViewModel();
                    formularioViewModel.Id = 0;
                }
          
                formularioViewModel.IdColaborador = id;
                return PartialView("_ViewAll", formularioViewModel);
                // return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", documentoViewModel) });
            }
            return null;

        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(int id, FormularioViewModel formulario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await _mediator.Send(new GetFormularioByIdQuery() { Id = id });
                    if (response.Succeeded)
                    {
                        if (response.Data == null)
                        {
                            id = 0;
                            formulario.Id = 0;
                        }
                        else
                        {
                            id = 1;
                            formulario.Id = response.Data.Id;
                        }
                        if (Request.Form.Files.Count > 0)
                        {
                            IFormFile file = Request.Form.Files.FirstOrDefault();
                            var image = file.OptimizeImageSize(700, 700);
                            formulario.Image = image;
                        }
                    }
                 
                    if (id == 0)
                    {
                        var createBrandCommand = _mapper.Map<CreateFormularioCommand>(formulario);
                        var result = await _mediator.Send(createBrandCommand);
                        if (result.Succeeded)
                        {
                            id = result.Data;
                            _notify.Success($"Formulario con ID {result.Data} creado.");
                        }
                        else _notify.Error(result.Message);
                    }
                    else
                    {
                        var updateBrandCommand = _mapper.Map<UpdateFormularioCommand>(formulario);
                        var result = await _mediator.Send(updateBrandCommand);

                        ColaboradorViewModel cola = new ColaboradorViewModel();
                        cola.Id = formulario.IdColaborador;
                        cola.Apellidos = formulario.ApellidoPaterno;
                        cola.ApellidoMaterno = formulario.ApellidoMaterno;
                        cola.PrimerNombre = formulario.PrimerNombre;
                        cola.SegundoNombre = formulario.SegundoNombre;
                        //cola.Area = formulario.Area;
                        //cola.Cargo = formulario.Cargo;
                        //cola.LugarTrabajo = formulario.LugarTrabajo;
                        cola.Identificacion = formulario.Identificacion;

                        var updateColaboCommand = _mapper.Map<UpdateColaboradorCommand>(cola);
                        var resultCola = await _mediator.Send(updateColaboCommand);

                        if (result.Succeeded) _notify.Information($"Formulario con ID {result.Data} actualizado.");
                        else _notify.Error(result.Message);
                    }

                    //UsuarioViewModel usr = new UsuarioViewModel();
                    //usr.UserNameRegular = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
                    //usr.ApellidoPaterno = formulario.ApellidoPaterno;
                    //usr.ApellidoMaterno = formulario.ApellidoMaterno;
                    //usr.PrimerNombre = formulario.PrimerNombre;
                    //usr.SegundoNombre = formulario.SegundoNombre;
                   

                    //var updateUsuarioCommand = _mapper.Map<UpdateUsuarioCommand>(usr);
                    //var resultUsuario = await _mediator.Send(updateUsuarioCommand);



                    await EnviarMail(0, formulario.IdColaborador);

                    return new JsonResult(new { isValid = true });


                    //var response = await _mediator.Send(new GetAllColaboradoresCachedQuery());
                    //if (response.Succeeded)
                    //{
                    //    var viewModel = _mapper.Map<List<ColaboradorViewModel>>(response.Data);
                    //    var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                    //    return new JsonResult(new { isValid = true, html = html });
                    //}
                    //else
                    //{
                    //    _notify.Error(response.Message);
                    //    return null;
                    //}
                }
                else
                {
                    var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", formulario);
                    return new JsonResult(new { isValid = false, html = html });
                }
            }
            catch (Exception ex)
            {
                _notify.Error($"Error en insertar los datos.");
                //var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", formulario);
                return new JsonResult(new { isValid = false});
            }
        }


      
        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0, int idFormulario = 0,int IdColaborador=0,string tipo="")
        {
            var response = await _mediator.Send(new GetTerceroByIdFormularioQuery() { Id = id });
            if (response.Succeeded)
            {
                var terceroViewModel = new TerceroViewModel();
                terceroViewModel.idFormulario = idFormulario;
                terceroViewModel.IdColaborador = IdColaborador;
                if (response.Data != null)
                    terceroViewModel = _mapper.Map<TerceroViewModel>(response.Data);
                terceroViewModel.idFormulario = idFormulario;
                terceroViewModel.IdColaborador = IdColaborador;
                terceroViewModel.TipoGrupo = tipo;

                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", terceroViewModel) });
            }
            return null;

        }

        public async Task<IActionResult> LoadTercero(int id = 0,string tipo="")
        {
            //var formualrioViewModel = new FormularioViewModel();
            //return PartialView("_ViewAll", formualrioViewModel);

            var response = await _mediator.Send(new GetFormularioByIdQuery() { Id = id,Tipo=tipo });
            if (response.Succeeded)
            {
                var formularioViewModel = _mapper.Map<FormularioViewModel>(response.Data);
                if (formularioViewModel == null)
                {
                    formularioViewModel = new FormularioViewModel();
                    formularioViewModel.Id = 0;
                }

                formularioViewModel.IdColaborador = id;
                formularioViewModel.TipoContacto = tipo;
                 formularioViewModel.NumContacto = formularioViewModel.FormularioTerceros.Where(x => x.Tipo == "C").Count();
                return PartialView("_Tercero", formularioViewModel);
                // return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", documentoViewModel) });
            }
            return null;

        }

        public async Task<IActionResult> LoadIdioma(int id = 0)
        {
            //var formualrioViewModel = new FormularioViewModel();
            //return PartialView("_ViewAll", formualrioViewModel);

            var response = await _mediator.Send(new GetFormularioByIdQuery() { Id = id });
            if (response.Succeeded)
            {
                var formularioViewModel = _mapper.Map<FormularioViewModel>(response.Data);
                if (formularioViewModel == null)
                {
                    formularioViewModel = new FormularioViewModel();
                    formularioViewModel.Id = 0;
                }

                formularioViewModel.IdColaborador = id;
               
                return PartialView("_Idioma", formularioViewModel);
                // return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", documentoViewModel) });
            }
            return null;

        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEditar(int id, TerceroViewModel tercero)
        {
            try
            {
                if (tercero.TipoGrupo != "C")
                {
                    if (!ModelState.IsValid)

                    {
                        var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", tercero);
                        return new JsonResult(new { isValid = false, html = html });
                    }

                    //if (tercero.TipoGrupo=="C")
                    //    {
                    //        tercero.FecNacimiento = DateTime.Now;
                    //        tercero.VigDesde = DateTime.Now;
                    //        tercero.VigHasta = DateTime.Now;
                    //        tercero.Genero = "0";
                    //    }
                    if (Request.Form.Files.Count > 0)
                    {
                        IFormFile file = Request.Form.Files.FirstOrDefault();
                        var image = file.OpenReadStream();
                        MemoryStream ms = new MemoryStream();
                        image.CopyTo(ms);
                        tercero.ImageCedula = ms.ToArray();
                    }
                    else
                    {
                        _notify.Error("Ingrese PDF de la cédula.");
                        return new JsonResult(new { isValid = false });
                    }
                }
                if (id == 0)
                    {

                        var createTerceroCommand = _mapper.Map<CreateTerceroCommand>(tercero);
                        var result = await _mediator.Send(createTerceroCommand);
                        if (result.Succeeded)
                        {
                            id = result.Data;
                            _notify.Success($"Tercero con ID {result.Data} Creado.");
                        }
                        else _notify.Error(result.Message);
                    }
                    else
                    {
                        var updateBrandCommand = _mapper.Map<UpdateTerceroCommand>(tercero);
                        var result = await _mediator.Send(updateBrandCommand);
                        if (result.Succeeded) _notify.Information($"Tercero con ID  {result.Data} Actualizado.");
                    }



                //return new RedirectToPageResult("/Formulario/Wizard/Index",new { id=4});

                var response = await _mediator.Send(new GetFormularioByIdQuery() { Id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value) });
                if (response.Succeeded)
                {
                    if (response.Data != null)
                    {
                        var viewModel = _mapper.Map<FormularioViewModel>(response.Data);
                        viewModel.TipoContacto = tercero.TipoGrupo;
                        viewModel.NumContacto = viewModel.FormularioTerceros.Where(x => x.Tipo == "C").Count();
                         var html1 = await _viewRenderer.RenderViewToStringAsync("_Tercero", viewModel);
                        return new JsonResult(new { isValid = true, html = html1 });
                    }
                    else
                        return new JsonResult(new { isValid = true });
                }
                return new JsonResult(new { isValid = true });
                //}
                //else
                //{
                //    _notify.Error(response.Message);
                //    return null;
                //}
                //return RedirectToPage("/Index", new { area = "Registro" });
                //  RedirectToAction("~/Pages/Wizard/Index");

                // return new JsonResult(new { isValid = true });

            }
            catch (Exception ex)
            {
                _notify.Error($"Error en insertar los datos.");
                //var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", formulario);
                return new JsonResult(new { isValid = false });
            }
        }

       
        public async Task<JsonResult> OnPostDelete(int id=0,int IdColaborador=0)
        {
            var deleteCommand = await _mediator.Send(new DeleteTerceroCommand { Id = id });
            if (deleteCommand.Succeeded)
            {
                _notify.Information($"Tercero con Id {id} Eliminado.");
                return new JsonResult(new { isValid = true });
                //return RedirectToPage("/Formulario/Wizard/Index", new { area = "Registro" });
                //var response = await _mediator.Send(new GetFormularioByIdQuery() { Id = IdColaborador });
                //if (response.Succeeded)
                //{
                //    var viewModel = _mapper.Map<FormularioViewModel>(response.Data);
                //    var html = await _viewRenderer.RenderViewToStringAsync("~/Areas/Registro/Pages/Formulario/Wizard/Index.cshtml", viewModel);
                //    return new JsonResult(new { isValid = true, html = html });
                //}
                //else
                //{
                //    _notify.Error(response.Message);
                //    return null;
                //}


            }
            else
            {
                _notify.Error(deleteCommand.Message);
                return null;
            }


        }


        public async Task<Byte[]> FormularioPdf(int id = 0)
        {
            try
            {

                var response =await _mediator.Send(new GetFormularioByIdQuery() { Id = id });
                if (response.Succeeded)
                {
                    var formularioViewModel = _mapper.Map<FormularioViewModel>(response);
                    if (formularioViewModel == null)
                    {
                        formularioViewModel = new FormularioViewModel();
                        formularioViewModel.Id = 0;
                    }
                    formularioViewModel.IdColaborador = id;
                    var res = new ViewAsPdf("_ViewAll", formularioViewModel)
                    {

                        //FileName="ccc.pdf",
                        PageOrientation = WordVision.ec.Infrastructure.Shared.Pdf.Options.Orientation.Portrait,
                        PageSize = Infrastructure.Shared.Pdf.Options.Size.A4
                        // Establece la Cabecera y el Pie de página
                        // CustomSwitches = "--page-offset 0 --footer-center [page] --footer-font-size 12"
                    }.BuildFile(this.ControllerContext);
                    return res.Result;
                }

                
                
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }


        public async Task<ActionResult> EnviarMail(int idDocumento, int idColaborador)
        {
            List<Attachment> attachments = new List<Attachment>();
           
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
                    apellidos = response.Data.Apellidos + " " + response.Data.ApellidoMaterno;
                    nombres = response.Data.PrimerNombre + " " + response.Data.SegundoNombre;
                    mail = response.Data.Email;
                }

                string plantilla = "";
                string asunto = "";
                switch (idDocumento)
                {

                    case 0:
                        plantilla = "DatosPersonales.html";
                        asunto = "AsuntoDatosPersonales";

                        idColaborador = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value);
                        var responseF = await _mediator.Send(new GetFormularioByIdQuery() { Id = idColaborador });
                      
                        var formularioViewModel = _mapper.Map<FormularioViewModel>(responseF.Data);
                        if (formularioViewModel == null)
                        {
                            formularioViewModel = new FormularioViewModel();
                            formularioViewModel.Id = 0;
                        }

                        formularioViewModel.IdColaborador = idColaborador;

                         actionPDF = new ViewAsPdf("_ViewAll", formularioViewModel)
                        {
                            PageOrientation = WordVision.ec.Infrastructure.Shared.Pdf.Options.Orientation.Portrait,
                            PageSize = Infrastructure.Shared.Pdf.Options.Size.A4
                        }.BuildFile(this.ControllerContext);


                        ///actulaizar el pdf en el formulario
                        ///
                        var updatePdfCommand = _mapper.Map<UpdateFormularioPdfCommand>(formularioViewModel);
                        updatePdfCommand.Pdf = actionPDF.Result;
                        var result = await _mediator.Send(updatePdfCommand);
                        if (result.Succeeded)
                        {
                            stream = new MemoryStream(actionPDF.Result);
                            attachment = new Attachment(stream, apellidos+nombres+"_DatosPersonales.pdf");
                            attachments.Add(attachment);
                        }
                        else
                        {
                            _notify.Error($"Mail no Enviado vuelva a intentar.");
                            _logger.LogError($"Mail no Enviado vuelva a intentar. Al momento de guardar el pdf");
                        }
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

                var subject = _configuration[asunto] + apellidos + " " + nombres;

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
                    apellidos + " " + nombres,
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
                _logger.LogError(ex,$"Error en enviar Mail.");
            }

            //   return new JsonResult(new { isValid = true });
            // return RedirectToPage("/Wizard/Index", new { area = "Registro" });
            return RedirectToPage("/Formulario/Wizard/Index", new { area = "Registro" });
        }

    }
}
