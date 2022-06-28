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
using WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetById;
using WordVision.ec.Application.Features.Soporte.Donantes.Commands.Create;
using WordVision.ec.Application.Features.Soporte.Donantes.Commands.Update;
using WordVision.ec.Application.Features.Soporte.Donantes.Queries.GetAllCached;
using WordVision.ec.Application.Features.Soporte.Donantes.Queries.GetById;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Soporte.Models;

namespace WordVision.ec.Web.Areas.Soporte.Controllers
{
    [Area("Soporte")]
    [Authorize]//Sirve para dar permiso cuando esta logeado
    public class DonanteController : BaseController<DonanteController>
    {
        // ejecuta una accion
        public async Task<IActionResult> Index()
        {
            var entidadViewModel = new DonanteViewModel();
            var responseCola = await _mediator.Send(new GetColaboradorByIdQuery() { Id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value) });
            if (responseCola.Succeeded)
            {
                entidadViewModel.Colaborador = responseCola.Data.Apellidos + " " + responseCola.Data.ApellidoMaterno + " " + responseCola.Data.PrimerNombre + " " + responseCola.Data.SegundoNombre;
                entidadViewModel.Colaborador = entidadViewModel.Colaborador + "-" + responseCola.Data.Estructuras?.Designacion;
            }

            var catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 21, Ninguno = true });
            var formaPago = new SelectList(catalogo.Data, "Secuencia", "Nombre");
            catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 22, Ninguno = true });
            var canal = new SelectList(catalogo.Data, "Secuencia", "Nombre");
            catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 23, Ninguno = true });
            var responsable = new SelectList(catalogo.Data, "Secuencia", "Nombre");
            catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 24, Ninguno = true });
            var tipo = new SelectList(catalogo.Data, "Secuencia", "Nombre");
            catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 25, Ninguno = true });
            var categoria = new SelectList(catalogo.Data, "Secuencia", "Nombre");
            catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 26, Ninguno = true });
            var campana = new SelectList(catalogo.Data, "Secuencia", "Nombre");
            catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 27, Ninguno = true });
            var estadoDonante = new SelectList(catalogo.Data, "Secuencia", "Nombre");
            catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 28, Ninguno = true });
            var genero = new SelectList(catalogo.Data, "Secuencia", "Nombre");
            catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 30, Ninguno = true });
            var tipoId = new SelectList(catalogo.Data, "Secuencia", "Nombre");
            catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 31, Ninguno = true });
            var region = new SelectList(catalogo.Data, "Secuencia", "Nombre");
            catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 32, Ninguno = true });
            var provincia = new SelectList(catalogo.Data, "Secuencia", "Nombre");
            catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 33, Ninguno = true });
            var ciudad = new SelectList(catalogo.Data, "Secuencia", "Nombre");
            catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 34, Ninguno = true });
            var frecuencia = new SelectList(catalogo.Data, "Secuencia", "Nombre");
            catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 35, Ninguno = true });
            var tipoCuenta = new SelectList(catalogo.Data, "Secuencia", "Nombre");
            catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 36, Ninguno = true });
            var tipoTarjeta = new SelectList(catalogo.Data, "Secuencia", "Nombre");
            catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 37, Ninguno = true });
            var banco = new SelectList(catalogo.Data, "Secuencia", "Nombre");
            catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 46, Ninguno = true });
            var codigoArea = new SelectList(catalogo.Data, "Secuencia", "Nombre");



            entidadViewModel.FormaPagoList = formaPago;
                entidadViewModel.CanalList = canal;
                entidadViewModel.ResponsableList = responsable;
                entidadViewModel.TipoList = tipo;
                entidadViewModel.CategoriaList = categoria;
                entidadViewModel.CampanaList = campana;
                entidadViewModel.EstadoDonanteList = estadoDonante;
                entidadViewModel.GeneroList = genero;
                entidadViewModel.TipoIdList = tipoId;
                entidadViewModel.RegionList = region;
                entidadViewModel.ProvinciaList = provincia;
                entidadViewModel.CiudadList = ciudad;
                entidadViewModel.FrecuenciaList = frecuencia;
                entidadViewModel.TipoCuentaList = tipoCuenta;
                entidadViewModel.TipoTarjetaList = tipoTarjeta;
                entidadViewModel.BancoList = banco;
                entidadViewModel.CodigoAreaList=codigoArea;
                entidadViewModel.FechaConversion = DateTime.Now;

               // return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });

                return View(entidadViewModel);// dirije a la carpeta Views
        }

        public async Task<IActionResult> LoadAll()
        {
            var response = await _mediator.Send(new GetAllDonantesQuery());
            if (response.Succeeded)
            {
                DonanteViewModelView entidad = new DonanteViewModelView();

                var viewModel = _mapper.Map<List<DonanteViewModel>>(response.Data);
                entidad.DonanteViewModels = viewModel;
                var catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 26, Ninguno = true });
                var campana = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                entidad.CampanaList = campana;
                catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 27, Ninguno = true });
                var estadoDonante = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                entidad.EstadoDonanteList = estadoDonante;
                catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 33, Ninguno = true });
                var ciudad = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                entidad.CiudadList = ciudad;
                return PartialView("_ViewAll", entidad);
            }

            return null;

        }
        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0)
        {


            var catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 21, Ninguno = true });
            var formaPago = new SelectList(catalogo.Data, "Secuencia", "Nombre");
            catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 22, Ninguno = true });
            var canal = new SelectList(catalogo.Data, "Secuencia", "Nombre");
            catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 23, Ninguno = true });
            var responsable = new SelectList(catalogo.Data, "Secuencia", "Nombre");
            catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 24, Ninguno = true });
            var tipo = new SelectList(catalogo.Data, "Secuencia", "Nombre");
            catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 25, Ninguno = true });
            var categoria = new SelectList(catalogo.Data, "Secuencia", "Nombre");
            catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 26, Ninguno = true });
            var campana = new SelectList(catalogo.Data, "Secuencia", "Nombre");
            catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 27, Ninguno = true });
            var estadoDonante = new SelectList(catalogo.Data, "Secuencia", "Nombre");
            catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 28, Ninguno = true });
            var genero = new SelectList(catalogo.Data, "Secuencia", "Nombre");
            catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 30, Ninguno = true });
            var tipoId = new SelectList(catalogo.Data, "Secuencia", "Nombre");
            catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 31, Ninguno = true });
            var region = new SelectList(catalogo.Data, "Secuencia", "Nombre");
            catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 32, Ninguno = true });
            var provincia = new SelectList(catalogo.Data, "Secuencia", "Nombre");
            catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 33, Ninguno = true });
            var ciudad = new SelectList(catalogo.Data, "Secuencia", "Nombre");
            catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 34, Ninguno = true });
            var frecuencia = new SelectList(catalogo.Data, "Secuencia", "Nombre");
            catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 35, Ninguno = true });
            var tipoCuenta = new SelectList(catalogo.Data, "Secuencia", "Nombre");
            catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 36, Ninguno = true });
            var tipoTarjeta = new SelectList(catalogo.Data, "Secuencia", "Nombre");
            catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 37, Ninguno = true });
            var banco = new SelectList(catalogo.Data, "Secuencia", "Nombre");



            if (id == 0)
            {
                var entidadViewModel = new DonanteViewModel();
                entidadViewModel.FormaPagoList = formaPago;
                entidadViewModel.CanalList = canal;
                entidadViewModel.ResponsableList = responsable;
                entidadViewModel.TipoList = tipo;
                entidadViewModel.CategoriaList = categoria;
                entidadViewModel.CampanaList = campana;
                entidadViewModel.EstadoDonanteList = estadoDonante;
                entidadViewModel.GeneroList = genero;
                entidadViewModel.TipoIdList = tipoId;
                entidadViewModel.RegionList = region;
                entidadViewModel.ProvinciaList = provincia;
                entidadViewModel.CiudadList = ciudad;
                entidadViewModel.FrecuenciaList = frecuencia;
                entidadViewModel.TipoCuentaList = tipoCuenta;
                entidadViewModel.TipoTarjetaList = tipoTarjeta;
                entidadViewModel.BancoList = banco;
                entidadViewModel.FechaConversion = DateTime.Now;

                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
            }
            else
            {
                var response = await _mediator.Send(new GetDonantesByIdQuery() { Id = id });
                if (response.Succeeded)
                {
                    var entidadViewModel = _mapper.Map<DonanteViewModel>(response.Data);
                    entidadViewModel.FormaPagoList = formaPago;
                    entidadViewModel.CanalList = canal;
                    entidadViewModel.ResponsableList = responsable;
                    entidadViewModel.TipoList = tipo;
                    entidadViewModel.CategoriaList = categoria;
                    entidadViewModel.CampanaList = campana;
                    entidadViewModel.EstadoDonanteList = estadoDonante;
                    entidadViewModel.GeneroList = genero;
                    entidadViewModel.TipoIdList = tipoId;
                    entidadViewModel.RegionList = region;
                    entidadViewModel.ProvinciaList = provincia;
                    entidadViewModel.CiudadList = ciudad;
                    entidadViewModel.FrecuenciaList = frecuencia;
                    entidadViewModel.TipoCuentaList = tipoCuenta;
                    entidadViewModel.TipoTarjetaList = tipoTarjeta;
                    entidadViewModel.BancoList = banco;

                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
                return null;
            }
        }


        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(int? id, DonanteViewModel entidad)
        {
            try
            {
                if (entidad.EsAdmin!=null)
                {
                    var updateEntidadCommand = _mapper.Map<UpdateDonanteCommand>(entidad);
                    var result = await _mediator.Send(updateEntidadCommand);
                    if (result.Succeeded) _notify.Information($"Donante con ID {result.Data} Actualizado.");
                }

                if (ModelState.IsValid)
                {
                    if (Request.Form.Files.Count > 0)
                    {
                        IFormFile file = Request.Form.Files.FirstOrDefault();
                        var image = file.OpenReadStream();
                        MemoryStream ms = new MemoryStream();
                        image.CopyTo(ms);
                        entidad.EvidenciaConversion = ms.ToArray();
                    }

                    if (id == 0)
                    {
                        var createEntidadCommand = _mapper.Map<CreateDonanteCommand>(entidad);
                        var result = await _mediator.Send(createEntidadCommand);
                        if (result.Succeeded)
                        {
                            id = result.Data;
                            _notify.Success($"Donante con ID {result.Data} Creado.");

                            await EnviarMail(result.Data, 1);
                        }
                        else _notify.Error(result.Message);
                    }
                    else
                    {
                        var updateEntidadCommand = _mapper.Map<UpdateDonanteCommand>(entidad);
                        var result = await _mediator.Send(updateEntidadCommand);
                        if (result.Succeeded) _notify.Information($"Donante con ID {result.Data} Actualizado.");
                        if (entidad.ComentarioActualizacion.Length!=0 && entidad.ComentarioResolucion.Length == 0)
                             await EnviarMail(result.Data, 2);
                        else if (entidad.ComentarioResolucion.Length != 0)
                            await EnviarMail(result.Data, 3);
                    }

                    var response = await _mediator.Send(new GetAllDonantesQuery());
                    if (response.Succeeded)
                    {

                        DonanteViewModelView donante = new DonanteViewModelView();

                        var viewModel = _mapper.Map<List<DonanteViewModel>>(response.Data);
                        donante.DonanteViewModels = viewModel;
                        var catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 26, Ninguno = true });
                        var campana = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                        donante.CampanaList = campana;
                        catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 27, Ninguno = true });
                        var estadoDonante = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                        donante.EstadoDonanteList = estadoDonante;
                        catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 33, Ninguno = true });
                        var ciudad = new SelectList(catalogo.Data, "Secuencia", "Nombre");
                        donante.CiudadList = ciudad;
                        var html1 = await _viewRenderer.RenderViewToStringAsync("_ViewAll", donante);
                        return new JsonResult(new { isValid = true, html = html1 });


                    }


                }
                else
                {
                    return new JsonResult(new { isValid = false });
                }

                return new JsonResult(new { isValid = true, Id = id });
            }
            catch (Exception ex)
            {
                _logger.LogError("OnPostCreateOrEdit", ex);
                _notify.Error("Error al insertar el Donante");
            }
            return null;
        }

        public async Task<FileResult> ShowPDF(int id, int tipo)
        {
            var responseC = await _mediator.Send(new GetDonantesByIdQuery() { Id = id });
            if (responseC.Succeeded)
            {
                var entidadViewModel = _mapper.Map<DonanteViewModel>(responseC.Data);
                switch (tipo)
                {
                    case 1:
                        if (entidadViewModel.EvidenciaConversion != null)
                        {
                            byte[] dataArray = entidadViewModel.EvidenciaConversion;
                            return File(dataArray, "application/pdf");
                        }
                        break;

                }


            }

            return null;
        }


        public async Task<ActionResult> EnviarMail(int idDonante, int estado)
        {

            DateTime fechaEnvio = DateTime.Now;
            string primerNombre = "";
            string segundoNombre = "";
            string primerApellido = "";
            string segundoApellido = "";
            string fechaConversion = "";
            string comentario = "";
            string comentarioResponsable = "";
            string email = "";
            string celular = "";
            string responsable = "";
            string emailResponsable = "";

            try
            {
                var response = await _mediator.Send(new GetDonantesByIdQuery() { Id = idDonante });
                if (response.Succeeded)
                {
                    primerNombre = response.Data.Nombre1;
                    segundoNombre = response.Data.Nombre2;
                    primerApellido = response.Data.Apellido1;
                    segundoApellido = response.Data.Apellido2;
                    fechaConversion = response.Data.FechaConversion.ToString();
                    email = response.Data.Email;
                    celular = response.Data.TelefonoCelular;
                    comentario = response.Data.ComentarioActualizacion;
                    comentarioResponsable = response.Data.ComentarioResolucion;
                    responsable = response.Data.CreatedBy;
                }

                var responseC = await _mediator.Send(new GetColaboradorByUserNameQuery() { UserName = responsable });
                if (responseC.Succeeded)
                {
                    emailResponsable = responseC.Data.Email;
                    responsable = responseC.Data.PrimerNombre + " " + responseC.Data.Apellidos;
                }

                string plantilla = "";
                string asunto = "";
                switch (estado)
                {

                    case 1:
                        plantilla = "Donantes\\Nuevo.html";
                        asunto = "Ingreso de nuevo donante: " + primerNombre +" "+ primerApellido;
                        email = _configuration["DestinoDonante"];
                        break;
                    case 2:
                        plantilla = "Donantes\\Devolucion.html";
                        email = emailResponsable;
                        asunto = "Realizar cambios en la información del donante " + primerNombre + " " + primerApellido;
                        break;
                    case 3:
                        plantilla = "Donantes\\Realizacion.html";
                        asunto = "Confirmación de cambios realizados " + primerNombre + " " + primerApellido;
                        email = _configuration["DestinoDonante"];
                        comentario = comentarioResponsable;
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
                    String.Format("{0:dddd, d MMMM yyyy}", fechaConversion),
                    primerNombre+" "+segundoNombre + " " +primerApellido + " " +segundoApellido,
                    email,
                    celular,
                    responsable,
                    comentario,
                    String.Format("{0:dddd, d MMMM yyyy}", DateTime.Now)
                    );


                await _emailSender
                    .SendEmailAsync(email, asunto, messageBody)
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


    }
}

